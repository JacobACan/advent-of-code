var reader = new StreamReader("C:\\Jacob\\Code\\advent-of-code\\2025\\03-25\\input.txt");
var line = reader.ReadLine();

int sumMax = 0;
long sumMax2 = 0;
while (line != null)
{
    //Part 1
    HashSet<int> numbers = [];
    for (int i = 0; i < line.Length - 1; i++)
    {
        char outterChar = line[i];
        for (int j = i + 1; j < line.Length; j++)
        {
            char innerChar = line[j];
            string num = $"{outterChar}{innerChar}";
            numbers.Add(int.Parse(num));
        }
    }
    int max = numbers.Max();
    sumMax += max;
    //Console.WriteLine(max);

    // Part 2
    string max2 = "";
    int start = 0;
    int lengthOfNumber = 12;
    while (max2.Length < lengthOfNumber)
    {
        int maxDigit = 0;
        int end = line.Length - (12 - max2.Length) + 1;// number of digits selected
        if (end > line.Length) end = line.Length - 1;
        for (int i = start; i < end; i++)
        {
            int digit = int.Parse(line.ElementAt(i).ToString());
            if (maxDigit < digit)
            {
                maxDigit = digit;
                start = i + 1;
            }
        }
        max2 += maxDigit;
    }
    //Console.WriteLine(max2);
    sumMax2 += long.Parse(max2);

    line = reader.ReadLine();
}


Console.WriteLine(sumMax);
Console.WriteLine(sumMax2);