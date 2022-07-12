using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using dataExceptions;


namespace Data
{
    public static class JsonFileUtils
    {
        private const string pathFile = "Data.JSON";
        private static FileStream fileStream = fileStream = File.Create(pathFile);
        private static readonly JsonSerializerOptions _options =
            new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

        public static void Write(object obj)
        {
            try
            {
                if (!fileStream.CanWrite)
                {
                    fileStream = File.Create(pathFile);
                }
                using var utf8JsonWriter = new Utf8JsonWriter(fileStream);
                System.Text.Json.JsonSerializer.Serialize(utf8JsonWriter, obj, _options);
            }
            catch (Exception)
            {
                throw new UnableAccessDataException("Thomethin went wrong. please try later");
            }
        }

        public static List<ObservationData> Read()
        {
            try
            {
                if (File.Exists(pathFile))
                {
                    StreamReader r = new StreamReader(pathFile);
                    string jsonString = r.ReadToEnd();
                    List<ObservationData> observationList = System.Text.Json.JsonSerializer.Deserialize<List<ObservationData>>(jsonString);

                    r.Close();
                    return observationList;
                }
                else { return new List<ObservationData>(); }
            }
            catch (Exception e)
            {
                throw new UnableAccessDataException("Thomethin went wrong. please try later");
            }
        }
    }
}
