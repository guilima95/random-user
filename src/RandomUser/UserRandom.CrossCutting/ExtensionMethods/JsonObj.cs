using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserRandom.CrossCutting.ExtensionMethods
{
    static class JsonObj
    {
        /// <summary>
        /// Deserializes a json file into an object list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<T> DeSerializeObject<T>(string json)
        {
            List<T> objectOut = new List<T>();

            if (string.IsNullOrEmpty(json)) { return objectOut; }

            try
            {
                // reading in full file as text
                string ss = File.ReadAllText(json);

                // went with <dynamic> over <T> or <List<T>> to avoid error..
                //  unexpected character at line 1 column 2
                var output = JsonConvert.DeserializeObject<dynamic>(ss);

                foreach (var Record in output)
                {
                    foreach (T data in Record)
                    {
                        objectOut.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                //Log exception here
                Console.Write(ex.Message);
            }

            return objectOut;
        }
    }
}