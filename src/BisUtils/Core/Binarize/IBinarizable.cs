﻿namespace BisUtils.Core.Binarize;

using BisUtils.Core.Binarize.Options;
using BisUtils.Core.Binarize.Utils;
using BisUtils.Core.IO;
using FResults;

public interface IBinarizable<in TBinarizationOptions> : ICachedResult where TBinarizationOptions : IBinarizationOptions
{
    [MustBeValidated("Object is not currently in a valid state to be written.")]
    public Result Binarize(BisBinaryWriter writer, TBinarizationOptions options);
}
