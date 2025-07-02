using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace SportEvents
{
    internal class Data
    {
        public static List<Events> events { get; private set; }

        private StreamReader reader;
        private StreamWriter writer;

        public Data()
        {
            LoadEvents();
        }

        public static void Save()
        {
            StreamWriter writer = new StreamWriter(Constants.filePath);
            using (writer)
            {
                string jsonData = JsonSerializer.Serialize(events);
                writer.Write(jsonData);
            }
        }

        private void LoadEvents()
        {
            events = new List<Events>();
            reader = new StreamReader(Constants.filePath);
            using (reader)
            {
                string jsonData = reader.ReadToEnd();
                if (!string.IsNullOrEmpty(jsonData))
                {
                    events = JsonSerializer.Deserialize<List<Events>>(jsonData)!;
                }
            }
        }

    }
    
}
