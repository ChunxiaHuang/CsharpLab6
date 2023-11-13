using System.Text.Json;

namespace Lab6Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create object e
            Event e = new Event(1, "Calgary");

            Console.WriteLine(e.EventNumber);
            Console.WriteLine(e.Location);


            // Serialize object e
            string path = "event.json";
            string encoded = JsonSerializer.Serialize(e);
            
            File.WriteAllText(path, encoded);

            Console.WriteLine("Wrote to JSON file.");

            // Deserialize previous info encoded which is called contents now read from file
            string contents = File.ReadAllText(path);
            //JsonSerializer.Deserialize(encoded, typeof(Event));
            Event decoded = JsonSerializer.Deserialize<Event>(contents);

            Console.WriteLine("\nRead from JSON file:");
            Console.WriteLine(decoded.EventNumber);
            Console.WriteLine(decoded.Location);

            SerializeDeserializeStream();
        }

        static void SerializeDeserializeStream()
        {
            string path = "name.bin";
            StreamWriter streamWriter = File.CreateText(path);

            string word = "Hackathon";

            streamWriter.Write(word);
            streamWriter.Close();

            StreamReader streamReader = File.OpenText(path);

            // Seek the first char and read it
            streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            int charNum = streamReader.Read();

            char firstChar = (char)charNum;
            streamReader.Close();

            // Seek the middle char position and read it
            streamReader = File.OpenText(path);

            int middleCharPos = (int)(streamReader.BaseStream.Length / 2);
            streamReader.BaseStream.Seek(middleCharPos, SeekOrigin.Begin);
            int middleCharNum = streamReader.Read();

            char middleChar = (char)middleCharNum;
            streamReader.Close();

            // Seek the last char position and read it
            streamReader = File.OpenText(path);

            int lastCharPos = (int)(streamReader.BaseStream.Length - 1);
            streamReader.BaseStream.Seek(lastCharPos, SeekOrigin.Begin);
            int lastCharNum = streamReader.Read();

            char lastChar = (char)lastCharNum;
            streamReader.Close();

            Console.WriteLine($"In Word: {word}");
            Console.WriteLine($"The First Character is: \"{firstChar}\"");
            Console.WriteLine($"The Middle Character is: \"{middleChar}\"");
            Console.WriteLine($"The Last Character is: \"{lastChar}\"");
        }
    }
}