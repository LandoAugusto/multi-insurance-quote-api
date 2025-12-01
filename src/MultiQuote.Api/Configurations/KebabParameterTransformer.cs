using System.Text.RegularExpressions;

namespace MultiQuote.Api.Configurations
{
    /// <summary>
    /// 
    /// </summary>
    public class KebabParameterTransformer : IOutboundParameterTransformer, IParameterPolicy
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string? TransformOutbound(object? value)
        {
            if (value != null)
            {
                return Regex.Replace(value.ToString() ?? string.Empty, "([a-z])([A-Z])", "$1-$2", RegexOptions.Compiled).ToLower();
            }

            return null;
        }
    }
}
