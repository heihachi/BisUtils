﻿namespace BisUtils.P3D.Errors;

using FResults.Reasoning;
using Models;
using Models.Data;

public class FaceReadError : ErrorBase
{
    public sealed override string? AlertName { get; init; }
    public sealed override Type? AlertScope { get; init; }
    public sealed override string? Message { get; set; }

    public FaceReadError(string reason, string alertName = "Generic Face Read Failure")
    {
        AlertName = alertName;
        AlertScope = typeof(RVShapeData);
        Message = $"There was an error reading a LOD Face. {reason}";
    }
}