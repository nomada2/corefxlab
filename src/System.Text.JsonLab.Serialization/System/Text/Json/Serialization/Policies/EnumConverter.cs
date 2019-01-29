﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Text.Json.Serialization.Policies
{
    internal class EnumConverter
    {
        //todo: support [Flags]?
        public static bool TryGetFromJson(ReadOnlySpan<byte> span, Type type, out Enum value)
        {
            string enumString = JsonConverter.s_utf8Encoding.GetString(span);
            if (Enum.TryParse(type, enumString, out object objValue))
            {
                value = (Enum)objValue;
                return true;
            }

            throw new InvalidOperationException($"todo:could not convert value to string-based Enum {type}");
        }

        public static bool TrySetToJson(Enum value, out Span<byte> span)
        {
            string stringVal;
            stringVal = value.ToString();
            span = JsonConverter.s_utf8Encoding.GetBytes(stringVal);
            return true;
        }
    }
}
