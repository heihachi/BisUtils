﻿namespace BisUtils.Param.Models.Statements;

using System.Text;
using Core.Family;
using Core.IO;
using FResults;
using Options;
using Stubs;

// ReSharper disable once PossibleInterfaceMemberAmbiguity
public interface IParamClass : IParamExternalClass, IParamStatementHolder
{
    string? InheritedClassname { get; }
    Result LocateParamParent(out IParamExternalClass? clazz);

    string IParamStatementHolder.GetStatements(ParamOptions options)
    {
        GetStatements(out var str, options);
        return str;
    }

    Result IParamStatementHolder.WriteStatements(StringBuilder builder, ParamOptions options)
    {
        var result = ToParam(out var str, options);
        builder.Append(str);
        return result;
    }

    StringBuilder IParamStatementHolder.WriteStatements(out Result result, ParamOptions options)
    {
        var builder = new StringBuilder();
        result = WriteParam(builder, options);
        return builder;
    }

    Result IParamStatementHolder.GetStatements(out string str, ParamOptions options)
    {
        str = string.Join('\n', Statements.Select(s => s.ToParam(options)));
        return Result.Ok();
    }
}

public class ParamClass : ParamExternalClass, IParamClass
{
    public string? InheritedClassname { get; set; }
    public List<IParamStatement> Statements { get; set; } = new();
    public IFamilyParent? Parent { get; set; }

    public ParamClass(
        IParamFile? file,
        IParamStatementHolder? parent,
        string className,
        string? inheritedClassname = null,
        List<IParamStatement>? statements = null
    ) : base(file, parent, className)
    {
        InheritedClassname = inheritedClassname;
        Statements = statements ?? new List<IParamStatement>();
    }

    public ParamClass(BisBinaryReader reader, ParamOptions options) : base(reader, options)
    {
    }

    public Result LocateParamParent(out IParamExternalClass? clazz)
    {
        if (InheritedClassname == string.Empty)
        {
            clazz = null;
            return LastResult = Result.ImmutableOk();
        }
        //TODO

        clazz = null;
        return LastResult = Result.Fail($"Could not locate parent class of {ClassName}");
    }
}
