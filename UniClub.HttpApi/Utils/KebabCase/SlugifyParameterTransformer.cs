using Microsoft.AspNetCore.Routing;
using System.Text.RegularExpressions;

namespace UniClub.Helper.KebabCase
{
    public class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        // Slugify value
        public string TransformOutbound(object value)
            => value == null ? null : Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
    }
}
