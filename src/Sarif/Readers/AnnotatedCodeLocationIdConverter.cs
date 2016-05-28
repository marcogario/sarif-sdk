﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Microsoft.CodeAnalysis.Sarif.Readers
{
    public class AnnotatedCodeLocationIdConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string) || objectType == typeof(long);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            int intValue;
            object value = reader.Value;

            // We have to look at the type of the object returned by reader.Value, rather
            // than looking at objectType, because Newtonsoft does something a bit odd
            // when the input is a string that parses as a valid integer, such as "1". In
            // that case, objectType is Int32, but the object returned by reader.Value is
            // a string!
            Type valueType = value.GetType();

            if (valueType == typeof(string))
            {
                var stringValue = (string)value;
                if (!int.TryParse((string)value, out intValue))
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format(
                            CultureInfo.InvariantCulture, SdkResources.AnnotatedCodeLocationIdMustBePositive, stringValue));
                }
            }
            else
            {
                // Also, when the input is an integer, objectType is Int32, but
                // reader.Value actually returns an Int64.
                intValue = Convert.ToInt32((long)reader.Value);
            }

            if (intValue < 1)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format(
                        CultureInfo.InvariantCulture, SdkResources.AnnotatedCodeLocationIdMustBePositive, intValue));
            }

            return intValue;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(value.ToString());
        }
    }
}
