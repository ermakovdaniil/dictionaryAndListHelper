using System;

public class TextCreator
{

    public static void Main(string[] args)
    {
        // Creates templates for dictionary and list from txt file which contains values

        //CreateTXT("\t\t\t{ \"\", \"", "\" },", @"C:\Users\Даня\Desktop\Список номенклатуры из 1C.txt", @"C:\Users\Даня\Desktop\Номенклатура для словаря.txt");

        //CreateTXT("\t\t\t\"", "\",", @"C:\Users\Даня\Desktop\Список номенклатуры из 1C.txt", @"C:\Users\Даня\Desktop\Номенклатура для списка.txt");

        CreateTXT("  \"\": \"", "\",", @"C:\Users\Даня\Desktop\Список номенклатуры из 1C.txt", @"C:\Users\Даня\Desktop\Номенклатура для словаря.txt");

        CreateTXT("  \"", "\",", @"C:\Users\Даня\Desktop\Список номенклатуры из 1C.txt", @"C:\Users\Даня\Desktop\Номенклатура для списка.txt");
    }

    private static void CreateTXT(string before, string after, string inputPath, string outputPath)
    {
        string[] text = File.ReadAllLines(inputPath);

        string temp;
        List<string> list = new List<string>();
        string[] dictionary;
        var foundIndexes = new List<int>();
        foreach (string line in text)
        {
            string modified = line;

            if (line.ToLower().Contains('"'))
            {

                for (int i = line.IndexOf('"'); i > -1; i = line.IndexOf('"', i + 1))
                {
                    foundIndexes.Add(i);
                }

                for (int i = 0; i < foundIndexes.Count; i++)
                {
                    foundIndexes[i] += i;
                }

                foreach (int i in foundIndexes)
                {
                    modified = modified.Insert(i, @"\");
                }
                foundIndexes.Clear();
            }
            temp = before + modified + after;
            list.Add(temp);
        }
        dictionary = list.ToArray();
        File.WriteAllLines(outputPath, dictionary);
    }
}