﻿namespace BisUtils.P3D.Models;

using System.Numerics;

public interface IRVLod
{
    string Name { get; }
    RVResolution Resolution { get; }
    IEnumerable<Vector3> Points { get; }
    IEnumerable<Vector3> Normals { get; }
    IEnumerable<string> Textures { get; }
    IEnumerable<string> Materials { get; }
}

public abstract class RVLod : IRVLod
{
    public string Name => Resolution.Name;
    public RVResolution Resolution { get; }
    public abstract IEnumerable<Vector3> Points { get; }
    public abstract IEnumerable<Vector3> Normals { get; }
    public abstract IEnumerable<string> Textures { get; }
    public abstract IEnumerable<string> Materials { get; }

    protected RVLod(RVResolution resolution) => Resolution = resolution;
}