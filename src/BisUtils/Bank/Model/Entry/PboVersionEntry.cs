﻿namespace BisUtils.Bank.Model.Entry;

using System.Diagnostics;
using BisUtils.Bank.Model.Stubs;
using BisUtils.Bank.Alerts.Errors;
using BisUtils.Bank.Alerts.Warnings;
using BisUtils.Core.IO;
using BisUtils.Core.Binarize.Exceptions;
using BisUtils.Core.Cloning;
using BisUtils.Core.Family;
using FResults;
using FResults.Extensions;

public interface IPboVersionEntry : IPboEntry, IFamilyParent, IBisCloneable<IPboVersionEntry>
{
    IEnumerable<IFamilyMember> IFamilyParent.Children => Properties;

    List<IPboProperty> Properties { get; }

    Result ReadPboProperties(BisBinaryReader reader, PboOptions options);

    Result WritePboProperties(BisBinaryWriter writer, PboOptions options);
}

public class PboVersionEntry : PboEntry, IPboVersionEntry
{
    //public string FileName { get; } = "$PROPERTIES$";
    public static readonly string[] UsedPboProperties = { "product", "prefix", "version", "encrypted", "obfuscated" };
    public List<IPboProperty> Properties { get; set; } = new();

    public PboVersionEntry(
        IPboFile? file,
        string fileName = "",
        PboEntryMime mime = PboEntryMime.Version,
        int originalSize = 0,
        int offset = 0,
        int timeStamp = 0,
        int dataSize = 0,
        List<IPboProperty>? properties = null
    ) : base(file, file, fileName, mime, originalSize, offset, timeStamp, dataSize) =>
        Properties = properties ?? new List<IPboProperty>();

    public PboVersionEntry(BisBinaryReader reader, PboOptions options) : base(reader, options)
    {
        Debinarize(reader, options);
        if (LastResult!.IsFailed)
        {
            throw new DebinarizeFailedException(LastResult.ToString());
        }
    }

    public Result ReadPboProperties(BisBinaryReader reader, PboOptions options)
    {
#if DEBUG
        var watch = Stopwatch.StartNew();
#endif

        var results = new List<Result>();
        var property = new PboProperty(PboFile, this, string.Empty, string.Empty);
        Result result;
        while (!(result = property.Debinarize(reader, options)).HasError<PboEmptyPropertyNameError>())
        {
            results.Add(result);
            if(options.RemoveBenignProperties && !UsedPboProperties.Contains(property.Name))
            {
                continue;
            }

            if (!options.AllowObfuscated && property.Name.Equals("obfuscated", StringComparison.OrdinalIgnoreCase))
            {
                throw new ObfuscatedPboException();
            }

            if (!options.AllowEncrypted && property.Name.Equals("encrypted", StringComparison.OrdinalIgnoreCase))
            {
                throw new ObfuscatedPboException();
            }

            Properties.Add(property.BisClone());
        }

        if (!options.IgnoreValidation)
        {
            results.Add(Validate(options));
        }
#if DEBUG
        watch.Stop();
        Console.WriteLine($"(PboVersionEntry::ReadPboProperties) Execution Time: {watch.ElapsedMilliseconds} ms");
#endif

        return LastResult = Result.Merge(results);
    }

    public sealed override Result Binarize(BisBinaryWriter writer, PboOptions options)
    {
#if DEBUG
        var watch = Stopwatch.StartNew();
#endif

        LastResult = Result.Merge(base.Binarize(writer, options), WritePboProperties(writer, options));

#if DEBUG
        watch.Stop();
        Console.WriteLine($"(PboVersionEntry::Binarize) Execution Time: {watch.ElapsedMilliseconds} ms");
#endif


        return LastResult;
    }


    public sealed override Result Debinarize(BisBinaryReader reader, PboOptions options)
    {
#if DEBUG
        var watch = Stopwatch.StartNew();
#endif

        LastResult = base.Debinarize(reader, options);
        EntryMime = (PboEntryMime) reader.ReadInt32();// TODO WARN/ERROR then recover
        OriginalSize = reader.ReadInt32();
        TimeStamp = reader.ReadInt32();
        Offset = reader.ReadInt32();
        DataSize = reader.ReadInt32();
        LastResult = Result.Merge(LastResult, ReadPboProperties(reader, options));

#if DEBUG
        watch.Stop();
        Console.WriteLine($"(PboVersionEntry::Debinarize) Execution Time: {watch.ElapsedMilliseconds} ms");
#endif

        return LastResult;
    }



    public Result WritePboProperties(BisBinaryWriter writer, PboOptions options)
    {
#if DEBUG
                var watch = Stopwatch.StartNew();

#endif
        LastResult = Result.Merge(Properties.Select(p => p.Binarize(writer, options)));
        writer.Write((byte) 0);

#if DEBUG
        watch.Stop();
        Console.WriteLine($"(PboVersionEntry::WritePboProperties) Execution Time: {watch.ElapsedMilliseconds} ms");
#endif
        return LastResult;
    }

    public sealed override Result Validate(PboOptions options)
    {
#if DEBUG
        var watch = Stopwatch.StartNew();
#endif

        LastResult = Result.Merge(new List<Result>
        {
            EntryMime is not PboEntryMime.Version
                ? Result.Ok()
                    .WithWarning(new PboImproperMimeWarning(options.RequireVersionMimeOnVersion,
                        typeof(PboVersionEntry)))
                : Result.ImmutableOk(),
            !IsEmptyMeta()
                ? Result.Ok()
                    .WithWarning(new PboImproperMetaWarning(options.RequireEmptyVersionMeta, typeof(PboVersionEntry)))
                : Result.ImmutableOk(),
            EntryName != string.Empty
                ? Result.Ok()
                    .WithWarning(new PboNamedVersionEntryWarning(options.RequireVersionNotNamed,
                        typeof(PboVersionEntry)))
                : Result.ImmutableOk()
        });

#if DEBUG
        watch.Stop();
        Console.WriteLine($"(PboVersionEntry::Validate) Execution Time: {watch.ElapsedMilliseconds} ms");
#endif
        return LastResult;
    }

    public IPboVersionEntry BisClone() => new PboVersionEntry(PboFile, EntryName, EntryMime, OriginalSize, Offset, TimeStamp, DataSize, Properties);
}
