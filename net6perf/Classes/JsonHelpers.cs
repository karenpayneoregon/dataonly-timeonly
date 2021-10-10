using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace net6perf.Classes
{
    public class JsonHelpers
    {
        /// <summary>
        /// Deserialize from Json string to TModel
        /// </summary>
        /// <typeparam name="TModel">Type to deserialize Json to</typeparam>
        /// <param name="json">Valid json for deserialize TModel too.</param>
        /// <returns>single instance of TModel</returns>
        public static TModel DeserializeObject<TModel>(string json) 
            => JsonSerializer.Deserialize<TModel>(json);

        /// <summary>
        /// Serialize a list to a file
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="sender">Type to serialize</param>
        /// <param name="fileName">File json to this file</param>
        /// <param name="format">true to format json, otherwise no formatting</param>
        /// <returns>Value Tuple, on success return true/null, otherwise false and the exception thrown</returns>
        public static (bool result, Exception exception) JsonToListFormatted<TModel>(List<TModel> sender, string fileName, bool format = true)
        {

            try
            {

                var options = new JsonSerializerOptions { WriteIndented = true };
                File.WriteAllText(fileName, JsonSerializer.Serialize(sender, (format ? options : null)));

                return (true, null);

            }
            catch (Exception exceptionLocal)
            {
                return (false, exceptionLocal);
            }

        }
    }
}