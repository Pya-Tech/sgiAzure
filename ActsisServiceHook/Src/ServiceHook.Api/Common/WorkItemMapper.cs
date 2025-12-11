using System.Globalization;
using System.Text.RegularExpressions;

namespace ServiceHook.Api.Common
{
    public static class WorkItemMapper
    {

        /// <summary>
        /// Convierte un valor en DateTime, manejando valores nulos o inválidos.
        /// </summary>
        /// <param name="value">El valor a convertir.</param>
        /// <returns>Un DateTime si la conversión es exitosa, o DateTime.MinValue si no lo es.</returns>
        public static DateTime ConvertToDateTime(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return DateTime.MinValue;

            string[] formatos = {
                "yyyy-MM-dd",
                "dd/MM/yyyy",
                "MM/dd/yyyy",
                "yyyyMMdd",
                "dd-MM-yyyy",
                "yyyy-MM-dd HH:mm:ss",
                "yyyy-MM-ddTHH:mm:ssZ",
                "yyyy-MM-ddTHH:mm:ss.fffZ",
                "o" 
            };
            if (DateTime.TryParseExact(value, formatos, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
                return result;

            throw new FormatException($"El valor '{value}' no se pudo convertir en DateTime.");
        }

        /// <summary>
        /// Verifica si una cadena contiene etiquetas &lt;div&gt; y, si es así, las elimina.
        /// </summary>
        /// <param name="input">La cadena de entrada que puede contener etiquetas HTML.</param>
        /// <returns>La cadena sin etiquetas &lt;div&gt; o la cadena original si no contiene dichas etiquetas.</returns>
        public static string RemoveDivTags(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            string pattern = @"<\/?div.*?>";

            if (Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase))
            {
                return Regex.Replace(input, pattern, string.Empty, RegexOptions.IgnoreCase);
            }
            return input;
        }

        public static string RemoveSystemDescription(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            var system = input.Split(" - ")[0];
            return system;
        }

        public static string? MapCollection(string? collection)
        {
            if (string.IsNullOrEmpty(collection)) return null;

            var collectionSplit = collection.Split("/");
            if (collectionSplit.Length > 0)
                return collectionSplit[collectionSplit.Length - 2];
            return null;
        }
    }
}
