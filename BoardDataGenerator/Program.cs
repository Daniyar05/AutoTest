using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using TestProject1;

namespace BoardDataGenerator
{
    public class Program
    {
        private static readonly Random Random = new Random();

        public static void Main(string[] args)
        {
            if (args.Length != 4)
            {
                Console.WriteLine("Usage: BoardDataGenerator.exe b <count> <file> <format>");
                return;
            }

            string dataType = args[0];
            int count = Convert.ToInt32(args[1]);
            string fileName = args[2];
            string format = args[3];

            if (dataType != "b" && dataType != "boards")
            {
                Console.WriteLine("Unknown data type. Use b or boards.");
                return;
            }

            List<BoardData> boards = GenerateBoards(count);

            if (format == "xml")
            {
                SaveBoardsToXmlFile(boards, fileName);
            }
            else
            {
                Console.WriteLine("Unknown format. Use xml.");
            }
        }

        private static List<BoardData> GenerateBoards(int count)
        {
            List<BoardData> boards = new List<BoardData>();

            for (int i = 0; i < count; i++)
            {
                boards.Add(new BoardData(GenerateRandomString(12)));
            }

            return boards;
        }

        private static string GenerateRandomString(int max)
        {
            int length = Random.Next(1, max);
            char[] chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                chars[i] = Convert.ToChar(Random.Next(32, 122));
            }

            return new string(chars);
        }

        private static void SaveBoardsToXmlFile(List<BoardData> boards, string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<BoardData>));

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, boards);
            }
        }
    }
}