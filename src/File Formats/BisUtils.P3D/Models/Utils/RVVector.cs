﻿namespace BisUtils.P3D.Models.Utils;

using Core.Binarize;
using Core.Binarize.Implementation;
using BisUtils.Core.Binarize.Options;
using Core.Extensions;
using Core.IO;
using FResults;

public interface IRVVector: IBinaryObject<IBinarizationOptions>
{
    float X { get; set; }
    float Y { get; set; }
    float Z { get; set; }
    float SquaredSize();
    static abstract IRVVector operator -(IRVVector a, IRVVector b);
    static abstract IRVVector operator /(float a, IRVVector b);

}

public class RVVector: BinaryObject<IBinarizationOptions>, IRVVector
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public float SquaredSize() => (X*X)+(Y*Y)+(Z*Z);

    static IRVVector IRVVector.operator -(IRVVector a, IRVVector b) => new RVVector(a.X-b.X, a.Y-b.Y, a.Z-b.Z);

    static IRVVector IRVVector.operator /(float a, IRVVector b)
    {
        var i = 1 / a;
        return new RVVector(b.X*i, b.Y*i, b.Z*i);
    }


    public RVVector(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public RVVector()
    {

    }

    public RVVector(BisBinaryReader reader, IBinarizationOptions options)
    {
        if (!Debinarize(reader, options))
        {
            LastResult!.Throw();
        }
    }


    public override Result Binarize(BisBinaryWriter writer, IBinarizationOptions options)
    {
        writer.Write(X);
        writer.Write(Y);
        writer.Write(Z);
        return Result.Ok();
    }

    public sealed override Result Debinarize(BisBinaryReader reader, IBinarizationOptions options)
    {
        X = reader.ReadSingle();
        Y = reader.ReadSingle();
        Z = reader.ReadSingle();
        return Result.Ok();
    }
}

