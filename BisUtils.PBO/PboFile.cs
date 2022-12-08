﻿using System.Text;
using BisUtils.Core;
using BisUtils.Core.Compression;
using BisUtils.Core.Compression.Options;
using BisUtils.PBO.Builders;
using BisUtils.PBO.Entries;
using BisUtils.PBO.Extensions;

namespace BisUtils.PBO;

public interface IPboFile : IBisBinarizable<PboDebinarizationOptions, PboBinarizationOptions>, IDisposable {
    byte[] GetEntryData(PboDataEntry dataEntry, bool decompress = true);
    void OverwriteEntryData(PboDataEntry dataEntry, byte[] data, bool compressed = false, bool syncToStream = true);

    void AddEntry(PboDataEntryDto dataEntryDto, bool syncStream = false);
    void DeleteEntry(PboDataEntry dataEntry, bool syncStream = false);
    void RenameEntry(PboDataEntry dataEntry, string newName, bool syncStream = false);
    
    void SyncToStream();
    void DeSyncStream();

    IEnumerable<PboEntry> GetPboEntries();
    IEnumerable<PboDataEntry>? GetDataEntries();
    IEnumerable<PboDataEntryDto>? GetDTOEntries();

    IEnumerable<PboVersionEntry>? GetVersionEntries();
    PboVersionEntry? GetVersionEntry();

}

public class PboFile : IPboFile {
    private bool _streamIsSynced;
    private bool _disposed;
    
    public readonly Stream PboStream;
    public bool IsWritable => PboStream.CanWrite;
    
    private List<PboEntry> PBOEntries { get; set;}
    public ulong DataBlockStartOffset => PBOEntries.Where(entry => entry is not PboDataEntryDto).Aggregate<PboEntry, ulong>(0, (current, entry) => current + entry.CalculateMetaLength());
    public ulong DataBlockEndOffset => PBOEntries.Where(e => e is PboDataEntry and not PboDataEntryDto).Cast<PboDataEntry>().Aggregate(DataBlockStartOffset, (current, entry) => current + entry.PackedSize);

    
    public PboFile(Stream pboStream, PboFileOption option = PboFileOption.Read) {
        PboStream = pboStream;
        PBOEntries = new List<PboEntry>();

        switch (option) {
            case PboFileOption.Read: {
                ReadBinary(new BinaryReader(pboStream, Encoding.UTF8, true));
                break;
            }
            case PboFileOption.Create: {
                PBOEntries.Add(new PboVersionEntry(this));
                PBOEntries.Add(new PboDummyEntry(this));
                WriteBinary(new BinaryWriter(pboStream, Encoding.UTF8, true));
                break;
            }
            default: throw new ArgumentOutOfRangeException(option.ToString());
        }
        _streamIsSynced = true;
    }

    public byte[] GetEntryData(PboDataEntry dataEntry, bool decompress = true) {

        if (dataEntry is PboDataEntryDto dto) return dto.EntryData;

        using var reader = new BinaryReader(PboStream, Encoding.UTF8, true);
        
        if (!dataEntry.RespectOffsets && !(dataEntry.BinaryOffset <= 0)) {
            reader.BaseStream.Position = (long) dataEntry.BinaryOffset;
        } else {
            reader.BaseStream.Seek((long)DataBlockStartOffset, SeekOrigin.Begin);
            reader.BaseStream.Position += (long) dataEntry.EntryDataStartOffset;
        }
        
        
        return dataEntry.EntryMagic switch {
            PboEntryMagic.Compressed => decompress ? reader.ReadCompressedData<BisLZSSCompressionAlgorithms>(
                new BisLZSSDecompressionOptions() {
                    AlwaysDecompress = false, ExpectedSize = (int)dataEntry.OriginalSize, UseSignedChecksum = true
                }).ToArray() : reader.ReadBytes((int)dataEntry.PackedSize),
            PboEntryMagic.Decompressed => reader.ReadBytes((int)dataEntry.PackedSize),
            PboEntryMagic.Encrypted => throw new NotSupportedException("Encrypted PBOs are not supported by BisUtils."),
            _ => throw new ArgumentOutOfRangeException(dataEntry.EntryMagic.ToString())
        };
    }


    public void AddEntry(PboDataEntryDto dataEntryDto, bool syncPbo = false) {
        _streamIsSynced = false;
        PBOEntries.Add(dataEntryDto);
        
        if(syncPbo) SyncToStream();
    }

    public void SyncToStream() {
        if(!IsWritable) throw new Exception("Cannot sync a readonly stream. Try opening the PBO with write access or writing to a new file.");

        if(_streamIsSynced) return;

        using (var newStream = new MemoryStream()) {
            using (var newPboWriter = new BinaryWriter(newStream, Encoding.UTF8, true)) {
                WriteBinary(newPboWriter);
                
                newPboWriter.Flush();
            }
            PboStream.SetLength(0);

            PboStream.SetLength(newStream.Length);
            newStream.WriteTo(PboStream);
        }

        PboStream.Seek(0, SeekOrigin.Begin);
        PBOEntries = new List<PboEntry>();
        ReadBinary(new BinaryReader(PboStream, Encoding.UTF8, true));
        _streamIsSynced = true;
    }

    public void DeSyncStream() => _streamIsSynced = false;
    
    public IEnumerable<PboEntry> GetPboEntries() => PBOEntries;
    
    public IEnumerable<PboDataEntry> GetDataEntries() {
        var dataEntries = PBOEntries.Where(b => b is PboDataEntry).Cast<PboDataEntry>();
        var pboDataEntries = dataEntries as PboDataEntry[] ?? dataEntries.ToArray();
        return pboDataEntries;
    }

    public IEnumerable<PboDataEntryDto> GetDTOEntries() {
        var dtoEntries = PBOEntries.Where(b => b is PboDataEntry).Cast<PboDataEntryDto>();
        var pboDataEntries = dtoEntries as PboDataEntryDto[] ?? dtoEntries.ToArray();
        return pboDataEntries;
    }

    // ReSharper disable once ReturnTypeCanBeNotNullable RedundantAssignment
    public IEnumerable<PboVersionEntry>? GetVersionEntries() {
        var versionEntries = PBOEntries.Where(b => b is PboVersionEntry).Cast<PboVersionEntry>();
        var pboVersionEntries = versionEntries as PboVersionEntry[] ?? versionEntries.ToArray();

        return pboVersionEntries;
    }

    public PboVersionEntry? GetVersionEntry() {
        var versionEntries = GetVersionEntries();
        if (versionEntries is null) return null;

        var versionEntriesArr = versionEntries.ToArray();

        return versionEntriesArr.First();
    }

    public void RenameEntry(PboDataEntry dataEntry, string newName, bool syncStream = false) {
        switch (dataEntry) {
            case PboDataEntryDto dataEntryDto:
                dataEntryDto.EntryName = newName;
                if(syncStream) SyncToStream();
                break;
            case not null:
                AddEntry(new PboDataEntryDto(this, new MemoryStream(GetEntryData(dataEntry, false)), dataEntry.TimeStamp, dataEntry.EntryMagic is PboEntryMagic.Compressed), syncStream);
                DeleteEntry(dataEntry, syncStream);
                break;
        }
    }
    public void DeleteEntry(PboDataEntry dataEntry, bool syncStream = false) {
        if (dataEntry.EntryParent != this) throw new Exception("Cannot delete an entry outside of the pbo.");

        if(!dataEntry.IsQueuedForDeletion()) dataEntry.QueueDeletion();
        if(syncStream) SyncToStream();
    }


    internal ulong GetMetadataOffset(PboDataEntry dataEntry) {
        if (dataEntry is PboDataEntryDto)
            throw new Exception("Transfer(dto) entries are not stream-synced and therefore have no offsets.");
        if (dataEntry.EntryParent != this) throw new Exception("Cannot calculate offset for an entry outside of this pbo instance.");

        ulong offset = 0;
        foreach (var ent in PBOEntries) {
            if (ent is PboDataEntryDto) continue;
            if (ent == dataEntry) break;
            offset += ent.CalculateMetaLength();
        }

        return offset;
    }
    
    public void OverwriteEntryData(PboDataEntry dataEntry, byte[] data, bool compressed = false, bool syncStream = false) {
        if (dataEntry is PboDataEntryDto dto) {
            dto.EntryData = data;
            return;
        }
        if (!IsWritable && syncStream) throw new Exception("The pbo file you're trying to write to is readonly.");
        
        AddEntry(new PboDataEntryDto(this, new MemoryStream(data), dataEntry.TimeStamp, compressed), syncStream);
        DeleteEntry(dataEntry, syncStream);
    }

    public IBisBinarizable<PboDebinarizationOptions, PboBinarizationOptions> ReadBinary(BinaryReader reader, PboDebinarizationOptions? debinarizationOptions = null) {
        debinarizationOptions ??= PboDebinarizationOptions.DefaultOptions;

        PboEntry entry;

        if (debinarizationOptions.StrictVersionEntry) {
            PBOEntries.Add(entry = PboEntry.ReadPboEntry(this, reader));
            if (entry is not PboVersionEntry) throw new Exception($"Expected a starting version entry, instead got {entry.GetType().Name}");
        }
        
        do {
            PBOEntries.Add(entry = PboEntry.ReadPboEntry(this, reader));
            if (debinarizationOptions.StrictVersionEntry && entry is PboVersionEntry)
                throw new Exception("Only one version entry is allowed in strict mode.");
            if (debinarizationOptions.UseEntryDataOffsets && entry is PboDataEntry dataEntry)
                dataEntry.RespectOffsets = true;

        } while (entry is not PboDummyEntry);

        foreach (var e in PBOEntries) {
            if(e is not PboDataEntry dataEntry) continue;
            dataEntry.ReinitializeOffsets();
        }

        reader.BaseStream.Seek((long) DataBlockEndOffset, SeekOrigin.Begin);

        if (debinarizationOptions.RequireVersionEntry && GetVersionEntry() is null) throw new Exception("No version entry was found while reading pbo.");

        if (!debinarizationOptions.VerifyChecksum) return this;
        
        //if (!reader.VerifyPboChecksum()) throw new Exception("The PBO checksum does not match the one calculated.");
        return this;
    }

    public void WriteBinary(BinaryWriter writer, PboBinarizationOptions? binarizationOptions = null) {
        binarizationOptions ??= PboBinarizationOptions.DefaultOptions;

        
        if (binarizationOptions.RequireVersionEntry) {
            if (!PBOEntries.Where(v => v is PboVersionEntry).ToArray().Any())
                throw new Exception("Cannot write PBO without a version entry.");
        }
        
        if (binarizationOptions.RequireDummyEntry) {
            if (!PBOEntries.Where(v => v is PboDummyEntry).ToArray().Any())
                throw new Exception("Cannot write PBO without a dummy data entry.");
        }

        if (binarizationOptions.StrictVersionEntry) {
            if (PBOEntries.First() is not PboVersionEntry)
                throw new Exception("In strict mode there must be a single version entry at the beginning of the pbo.");
            if (PBOEntries.Where(v => v is PboDummyEntry).ToArray().Length > 1)
                throw new Exception("In strict mode there can only be a single version entry.");
        }

        var dtos = PBOEntries.Where(e => e is PboDataEntryDto).Cast<PboDataEntryDto>().ToList();
        
        
        
        foreach (var entry in PBOEntries) {
            if (entry is PboDataEntry pboDataEntry && binarizationOptions.UseCommonTimeStamp is { } timeStamp) 
                pboDataEntry.TimeStamp = timeStamp;
            switch (entry) {
                case PboDataEntryDto: continue;
                case PboDataEntry dataEntry: {
                    if(dataEntry.IsQueuedForDeletion()) 
                        continue;
                    entry.WriteBinary(writer);
                    break;
                }
                case PboDummyEntry: {
                    foreach (var dtoEnt in dtos) {
                        if(dtoEnt.IsQueuedForDeletion())
                            continue;
                        dtoEnt.WriteBinary(writer);
                    }
                    break;
                }
            }

        }
        
        foreach (var entry in PBOEntries) {
            if(entry is not PboDataEntry dataEntry) continue;
            if(dataEntry.IsQueuedForDeletion()) continue;
            if(entry is PboDataEntryDto ) continue; 
            writer.Write(GetEntryData(dataEntry, false));
        }

        foreach (var entry in dtos) {
            if(entry.IsQueuedForDeletion()) continue;
            entry.WriteEntryData(writer);
            entry.RewriteMetadata(writer);
        }

        if (binarizationOptions.WriteDataOffsets) {
            var startPos = writer.BaseStream.Position;
            foreach (var entry in PBOEntries) {
                if(entry is not PboDataEntry dataEntry) continue;
                var dataOffset = DataBlockStartOffset + dataEntry.EntryDataStartOffset;
                writer.Seek((int) GetMetadataOffset(dataEntry), SeekOrigin.Begin);
                writer.Seek(Encoding.UTF8.GetBytes(dataEntry.EntryName).Length + 9, SeekOrigin.Current);
                writer.Write(BitConverter.GetBytes((int) dataOffset), 0, 4);
            }

            writer.Seek((int)startPos, SeekOrigin.Begin);
        }
        
        writer.WritePboChecksum();
        writer.Flush();
        writer.BaseStream.Flush();
    }

    public void Dispose() {
        if(_disposed) return;
        PboStream.Dispose();
        foreach (var dto in GetDTOEntries()) dto.Dispose();
        GC.SuppressFinalize(this);
        _disposed = true;
    }
}