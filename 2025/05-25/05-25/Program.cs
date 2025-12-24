var reader = new StreamReader("C:\\Jacob\\Code\\advent-of-code\\2025\\05-25\\input.txt");
List<long[]> ranges = [];
List<long> foodIds = [];

var line = reader.ReadLine();
int phase = 1;
while (line != null)
{
    if (line == "")
    {
        phase = 2;
        line = reader.ReadLine();
        continue;
    }

    if (phase == 1)
    {
        long lowerb = long.Parse(line.Split("-")[0]);
        long upperb = long.Parse(line.Split("-")[1]);

        ranges.Add([lowerb, upperb]);
    }

    if (phase == 2)
    {
        long id = long.Parse(line);
        foodIds.Add(id);
    }

    line = reader.ReadLine();
}

//Part 1
int answer = 0;
foreach (var id in foodIds)
{
    foreach (var range in ranges)
    {
        if (id <= range[1] && id >= range[0])
        {
            answer += 1;
            break;
        }
    }
}

//Part 2
int noGroup = -1;
long answer2 = 0;

var intervalGroups = ranges.Select((r, i) => new IntervalGroup { Range = new long[2] { r[0], r[1] }, Group = noGroup }).ToList();


bool allGroupsAssigned = false;
int currentGroup = 0;
while (!allGroupsAssigned)
{
    var minEntryNotInGroup = intervalGroups.Where(g => g.Group == noGroup).MinBy(g => g.Range[0]);
    var maxEntryInCurrentGroup = intervalGroups.Where(g => g.Group == currentGroup).MaxBy(g => g.Range[1]);
    if (minEntryNotInGroup == null) { continue; }
    else if (maxEntryInCurrentGroup == null)
    {
        minEntryNotInGroup.Group = currentGroup;
    }
    else if (minEntryNotInGroup.Range[0] > maxEntryInCurrentGroup.Range[1])
    {
        // Current Range apart of a new range
        currentGroup += 1;
        minEntryNotInGroup.Group = currentGroup;
    }
    else
    {
        // Current Range apart of next closest range
        minEntryNotInGroup.Group = currentGroup;
    }
    allGroupsAssigned = intervalGroups.All(g => g.Group != noGroup);
}

for (int group = 0; group <= currentGroup; group++)
{
    long min = intervalGroups.Where(g => g.Group == group).Min(g => g.Range[0]);
    long max = intervalGroups.Where(g => g.Group == group).Max(g => g.Range[1]);
    answer2 += max - min + 1;
}



Console.WriteLine(answer);
Console.WriteLine(answer2);

class IntervalGroup
{
    public long[] Range { get; set; } = new long[2];
    public int Group { get; set; } = -1;

}