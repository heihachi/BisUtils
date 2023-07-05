﻿namespace BisUtils.Param.Models.Literals;

using Core.IO;
using Enumerations;
using FResults;
using Options;
using Stubs;

public interface IParamString : IParamLiteral
{
    ParamStringType StringType { get; }

    public bool ToInt(out ParamInt? paramInt);
    public bool ToFloat(out ParamFloat? paramFloat);
}

public class ParamString : ParamLiteral<string>, IParamString
{
    public override byte LiteralId => 4;
    public override string? Value { get; set; }
    public ParamStringType StringType { get; } //TODO: Constructors and Stringtype

    public ParamString(IParamFile? file, string? value, ParamStringType stringType) : base(file, value) =>
        StringType = stringType;

    public ParamString(IParamFile? file, BisBinaryReader reader, ParamOptions options) : base(file, reader, options) => StringType = ParamStringType.Quoted;

    public override Result Binarize(BisBinaryWriter writer, ParamOptions options)
    {
        var result = base.Binarize(writer, options);
        writer.WriteAsciiZ(Value ?? "", options);
        return LastResult = result;
    }

    public override Result Debinarize(BisBinaryReader reader, ParamOptions options)
    {
        LastResult = reader.ReadAsciiZ(out var paramValue, options);
        Value = paramValue;
        return LastResult;
    }
    public override Result Validate(ParamOptions options) =>
        LastResult = Result.ImmutableOk();

    public static Result Stringify(out string stringified, string str, ParamStringType stringType, ParamOptions options)
    {
        switch (stringType)
        {
            case ParamStringType.Quoted:
            case ParamStringType.Unquoted:
                stringified = ""; //TODO:
                return Result.ImmutableOk();
            default:
                stringified = "";
                return Result.Fail("");
        }
    }


    public override Result ToParam(out string str, ParamOptions options) =>
        LastResult = Stringify(out str, Value ?? "", StringType, options);
#pragma warning disable CA1305 //TODO: Options with locale

    public bool ToInt(out ParamInt paramInt)
    {
        var response = int.TryParse(Value, out var parsedInt);
        if (!response)
        {
            paramInt = null;
            return response;
        }

        paramInt = new ParamInt(ParamFile, parsedInt);
        return true;
    }

    public bool ToFloat(out ParamFloat paramFloat)
    {
        var response = float.TryParse(Value, out var parsedInt);
        if (!response)
        {
            paramFloat = null;
            return response;
        }
        paramFloat = new ParamFloat(ParamFile, parsedInt);
        return true;
    }

    public IParamFloat? ToFloat()
    {
        ToFloat(out var paramFloat);
        return paramFloat;
    }

    public IParamInt? ToInt()
    {
        ToInt(out var paramInt);
        return paramInt;
    }
#pragma warning restore CA1305

}
