﻿namespace BisUtils.Core.Extensions;

using Binarize;
using BisUtils.Core.Binarize.Options;
using Binarize.Utils;
using Binarize.Validatable;
using IO;
using FResults;

public static class BinarizableExtensions
{
    public static Result BinarizeValidated<TBinarizationOptions>(
        this IStrictBinarizable<TBinarizationOptions> binarizable,
        BisBinaryWriter writer,
        TBinarizationOptions options
    ) where TBinarizationOptions : IBinarizationOptions
    {
        var validatable = (IValidatable<TBinarizationOptions>) binarizable;
        if (options.IgnoreValidation || validatable.Validate(options))
        {
            return binarizable.Binarize(writer, options);
        }

        if (
            binarizable.GetType()
                .GetMethod(nameof(IBinarizable<TBinarizationOptions>.Binarize))?
                .GetCustomAttributes(typeof(MustBeValidatedAttribute), true)
                .FirstOrDefault() is MustBeValidatedAttribute attribute
            )
        {
            binarizable.Validate(options); //TODO: Validation result;; merge

        }
        return binarizable.Binarize(writer, options);

    }
}
