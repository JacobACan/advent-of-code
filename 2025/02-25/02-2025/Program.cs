StreamReader reader = new StreamReader("C:\\Jacob\\Code\\advent-of-code\\2025\\02-25\\input.txt");


string line = reader.ReadLine();
//string line = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,\r\n1698522-1698528,446443-446449,38593856-38593862,565653-565659,\r\n824824821-824824827,2121212118-2121212124";

string[] ranges = line.Split(",");
// split line into list of ranges

List<string> fakeIds1 = [];
HashSet<string> fakeIds2 = [];
long sum = 0;

foreach (string range in ranges)
{
    long start = long.Parse(range.Split("-")[0]);
    long end = Convert.ToInt64(range.Split("-")[1]);

    // for each range, loop through the range
    for (long id = start; id <= end; id++)
    {
        // Part 1
        string idString = id.ToString();
        int l = 0;
        int r = idString.Length / 2;


        while (r < idString.Length)
        {
            if (idString.Length % 2 == 1) break;
            if (idString[l] != idString[r]) break;
            if (r == idString.Length - 1)
            {
                fakeIds1.Add(idString);
                sum += long.Parse(idString);
            }
            ;
            l++;
            r++;
        }

        //Part 2
        if (idString.Length == 1) continue;
        for (int compareSize = 1; compareSize <= idString.Length / 2; compareSize++)
        {
            string firstCompareString = idString.Substring(0, compareSize);
            for (int partitionIteration = 0; partitionIteration < idString.Length / compareSize; partitionIteration++)
            {
                int partitionIndex = partitionIteration * compareSize;
                string nthCompareString = idString.Substring(partitionIndex, compareSize);

                if (!firstCompareString.Equals(nthCompareString)) break;
                if (partitionIndex == idString.Length - compareSize)
                {
                    fakeIds2.Add(idString);
                }

            }
        }
    }

}

long sum2 = 0;
foreach (var fakeId in fakeIds2)
{
    sum2 += long.Parse(fakeId);
}

Console.WriteLine(sum);
Console.WriteLine();
Console.WriteLine(sum2);