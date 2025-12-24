var file = new StreamReader("C:\\Jacob\\Code\\advent-of-code\\2025\\07-25\\input.txt");
string? line = file.ReadLine();

List<string> map = [];
while (line != null)
{
    map.Add(line);
    line = file.ReadLine();
}

List<long[]> map2 = new List<long[]>(map.Select(l =>
{
    var line = new long[l.Length];
    for (int i = 0; i < l.Length; i++)
    {
        if (l[i] == '^')
        {

            line[i] = -1;
        }
        else if (l[i] == 'S')
        {
            line[i] = 1;

        }
        else
        {
            line[i] = 0;
        }
    }
    return line;
}));

//Part 1
int ans = 0;
for (int i = 1; i < map.Count; i++)
{
    var chars = map[i].ToArray();

    var prevChars = map[i - 1].ToArray();
    for (int j = 0; j < chars.Length; j++)
    {
        bool foundSplitter = chars[j] == '^';
        bool foundBeam = prevChars[j] == '|' || prevChars[j] == 'S';
        if (foundSplitter && foundBeam)
        {
            ans += 1;
            chars[j - 1] = '|';
            chars[j + 1] = '|';

        }
        else if (foundBeam)
        {
            chars[j] = '|';
        }

    }
    map[i] = new string(chars);
    Console.WriteLine(map[i]);
}

Console.WriteLine(ans);

for (int r = 1; r < map2.Count; r++)
{
    var row = map2[r];
    var prevRow = map2[r - 1];
    for (int c = 0; c < row.Length; c++)
    {
        var val = row[c];

        if (row[c] != -1)
        {
            if (c + 1 < row.Length && row[c + 1] == -1 && prevRow[c + 1] != -1)
                val += prevRow[c + 1];

            if (c - 1 > 0 && row[c - 1] == -1 && prevRow[c - 1] != -1)
                val += prevRow[c - 1];

            if (prevRow[c] != -1)
                val += prevRow[c];

        }

        map2[r][c] = val;
    }
}

long ans2 = 0;
foreach (var item in map2[map2.Count - 1])
{
    ans2 += item;
}

//map2.ForEach(r =>
//{
//    Console.WriteLine(); foreach (var item in r)
//    {
//        Console.Write(item);
//    }
//});

Console.WriteLine();
Console.WriteLine();
Console.WriteLine(ans2);