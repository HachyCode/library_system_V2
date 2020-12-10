using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;

namespace library_system
{
    class FileType
    {
        protected string filetype = "JSON";
        protected List<Book> books;

        protected void FileTypeSeting()
        {
            switch (filetype) //Take file type
            {
                case "JSON": //if file type is JSON, take the info and store it as books list
                    if (File.Exists(@"library.json"))
                    {
                        string exisitingData;

                        using (StreamReader reader = new StreamReader(@"library.json", Encoding.Default))
                        {
                            exisitingData = reader.ReadToEnd();
                        }
                        books = JsonConvert.DeserializeObject<List<Book>>(exisitingData);
                    }
                    else
                    {
                        books = new List<Book>();
                    }
                    break;

                case "XML": //if file type is XML, take the info and store it as books list
                    if (File.Exists(@"library.xml"))
                    {
                        var serializer = new XmlSerializer(typeof(List<Book>));
                        using (var reader = new StreamReader(@"library.xml"))
                        {
                            try
                            {
                                books = (List<Book>)serializer.Deserialize(reader);
                            }
                            catch
                            {
                                Console.WriteLine("Could not load file");
                            } // Could not be deserialized to this type.
                        }
                    }
                    else
                    {
                        books = new List<Book>();
                    }
                    break;
            }
        }

        protected void FileTypeSaving()
        {
            if (filetype == "JSON")
            {
                using (StreamWriter file = File.CreateText(@"library.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(file, books);
                }
            }

            if (filetype == "XML")
            {
                var serializer = new XmlSerializer(typeof(List<Book>));
                using (var writer = new StreamWriter(@"library.xml"))
                {
                    serializer.Serialize(writer, books);
                }

            }
        }
    }
}
