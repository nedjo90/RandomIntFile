using static System.Int32;

namespace RandomIntFile;

class Program
{
    static void Main(string[] args)
    {
        int[] testArray = new[] { 0, 1, 2, 3, 4, 5, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 150, 200, 250, 300, 350, 400, 450, 500 };
        foreach (int sizer in testArray)
        {
            string path = $"../../../tester_sizeof_{sizer}";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            for (int j = 0; j < 100; j++)
            {
                List<int> list = new List<int>();
                while (list.Count != sizer)
                    list.Add(GenerateRandom(list));
                string output = listToString(list);
                //Console.WriteLine(output);
                File.WriteAllText($"{path}/test_{j}.txt", output);
            }
        }
    }
    
    static string listToString(List<int> list)
    {
        int size = list.Count;
        string output = "";
        for (int i = 0; i < size; i++)
        {
            output += $"{list[i]}";
            if (i != size - 1)
                output += " ";
        }
        // Console.WriteLine(size);
        // Console.WriteLine(output);
        return output;
    }
    static int GenerateRandom(List<int> list)
    {
        Random random = new Random();
        int n = random.Next(MinValue, MaxValue);
        while (list.Contains(n))
            n = random.Next(MinValue, MaxValue);
        return n;
    }
}