using Newtonsoft.Json.Serialization;
using UniClub.Helpers;

namespace UniClub.HttpApi.Utils.KebabCase
{
    public class KebabCaseNamingStrategy : NamingStrategy
    {
        public KebabCaseNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames)
        {
            base.ProcessDictionaryKeys = processDictionaryKeys;
            base.OverrideSpecifiedNames = overrideSpecifiedNames;
        }
        public KebabCaseNamingStrategy(bool processDictionaryKeys, bool overrideSpecifiedNames, bool processExtensionDataNames)
            : this(processDictionaryKeys, overrideSpecifiedNames)
        {
            base.ProcessExtensionDataNames = processExtensionDataNames;
        }
        public KebabCaseNamingStrategy()
        {
        }
        protected override string ResolvePropertyName(string name)
        {
            return name.FromPascalToKebabCase();
        }
    }
}
