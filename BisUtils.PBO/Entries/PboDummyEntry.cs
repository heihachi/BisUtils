﻿namespace BisUtils.PBO.Entries; 

public sealed class PboDummyEntry : BasePboEntry {
    public PboDummyEntry(PboFile entryParent) : base(entryParent) {
    }

    public override int CompareTo(BasePboEntry? other) {
        throw new NotImplementedException();
    }
}