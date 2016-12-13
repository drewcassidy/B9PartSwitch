﻿using System;

namespace B9PartSwitch.Fishbones.Parsers
{
    public class ValueParser<T> : IParseType
    {
        private Func<string, T> parseFunction;
        private Func<T, string> formatFunction;

        public ValueParser(Func<string, T> parseFunction, Func<T, string> formatFunction)
        {
            parseFunction.RaiseIfNullArgument(nameof(parseFunction));
            formatFunction.RaiseIfNullArgument(nameof(formatFunction));

            this.parseFunction = parseFunction;
            this.formatFunction = formatFunction;
        }

        public object Parse(string value)
        {
            value.RaiseIfNullArgument(nameof(value));

            return parseFunction(value);
        }

        public string Format(object value)
        {
            value.RaiseIfNullArgument(nameof(value));

            return formatFunction((T)value);
        }
    }
}
