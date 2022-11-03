// Copyright (c) Microsoft.  All Rights Reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    /// Defines methods to support the comparison of objects of type Artifact for sorting.
    /// </summary>
    [GeneratedCode("Microsoft.Json.Schema.ToDotNet", "2.1.0.0")]
    internal sealed class ArtifactComparer : IComparer<Artifact>
    {
        internal static readonly ArtifactComparer Instance = new ArtifactComparer();

        public int Compare(Artifact left, Artifact right)
        {
            int compareResult = 0;

            // TryReferenceCompares is an autogenerated extension method
            // that will properly handle the case when 'left' is null.
            if (left.TryReferenceCompares(right, out compareResult))
            {
                return compareResult;
            }

            compareResult = MessageComparer.Instance.Compare(left.Description, right.Description);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ArtifactLocationComparer.Instance.Compare(left.Location, right.Location);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.ParentIndex.CompareTo(right.ParentIndex);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Offset.CompareTo(right.Offset);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Length.CompareTo(right.Length);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Roles.CompareTo(right.Roles);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.MimeType, right.MimeType);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = ArtifactContentComparer.Instance.Compare(left.Contents, right.Contents);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.Encoding, right.Encoding);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = string.Compare(left.SourceLanguage, right.SourceLanguage);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Hashes.DictionaryCompares(right.Hashes);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.LastModifiedTimeUtc.CompareTo(right.LastModifiedTimeUtc);
            if (compareResult != 0)
            {
                return compareResult;
            }

            compareResult = left.Properties.DictionaryCompares(right.Properties, SerializedPropertyInfoComparer.Instance);
            if (compareResult != 0)
            {
                return compareResult;
            }

            return compareResult;
        }
    }
}