﻿using System.Collections.Immutable;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.Recognizers.Definitions;
using Microsoft.Recognizers.Definitions.Spanish;
using Microsoft.Recognizers.Text.Number;
using Microsoft.Recognizers.Text.Number.Spanish;

namespace Microsoft.Recognizers.Text.NumberWithUnit.Spanish
{
    public abstract class SpanishNumberWithUnitExtractorConfiguration : INumberWithUnitExtractorConfiguration
    {
        protected SpanishNumberWithUnitExtractorConfiguration(CultureInfo ci)
        {
            this.CultureInfo = ci;
            this.UnitNumExtractor = new NumberExtractor();
            this.BuildPrefix = NumbersWithUnitDefinitions.BuildPrefix;
            this.BuildSuffix = NumbersWithUnitDefinitions.BuildSuffix;
            this.ConnectorToken = NumbersWithUnitDefinitions.ConnectorToken;
            this.CompoundUnitConnectorRegex = new Regex(NumbersWithUnitDefinitions.CompoundUnitConnectorRegex, RegexOptions.IgnoreCase);
            this.PmNonUnitRegex = new Regex(BaseUnits.PmNonUnitRegex, RegexOptions.IgnoreCase);
        }

        public abstract string ExtractType { get; }

        public CultureInfo CultureInfo { get; }

        public IExtractor UnitNumExtractor { get; }

        public string BuildPrefix { get; }

        public string BuildSuffix { get; }

        public string ConnectorToken { get; }

        public Regex CompoundUnitConnectorRegex { get; set; }

        public Regex PmNonUnitRegex { get; set; }

        public abstract ImmutableDictionary<string, string> SuffixList { get; }

        public abstract ImmutableDictionary<string, string> PrefixList { get; }

        public abstract ImmutableList<string> AmbiguousUnitList { get; }
    }
}
