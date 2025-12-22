var reader = new StreamReader("C:\\Jacob\\Code\\advent-of-code\\2025\\04-25\\input.txt");
var line = reader.ReadLine();

List<string> wall = [];
while (line != null)
{
    wall.Add(line);
    line = reader.ReadLine();
}


int length = wall[0].Length;
int height = wall.Count();


int answer = 0;
int removed = 1;

while (removed > 0)
{
    removed = 0;
    int[,] tpAnswerMap = new int[length, height]; // fixed array

    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < length; x++)
        {
            int n = y - 1;
            int e = x + 1;
            int s = y + 1;
            int w = x - 1;
            bool canN = n >= 0;
            bool canE = e < length;
            bool canS = s < length;
            bool canW = w >= 0;
            bool canNE = canN && canE;
            bool canSE = canS && canE;
            bool canSW = canS && canW;
            bool canNW = canN && canW;

            if (y == 1 && x == 1)
            {

            }

            if (wall[y][x] == '@')
            {
                if (canN && wall[n][x] == '@') tpAnswerMap[n, x] += 1;
                if (canE && wall[y][e] == '@') tpAnswerMap[y, e] += 1;
                if (canS && wall[s][x] == '@') tpAnswerMap[s, x] += 1;
                if (canW && wall[y][w] == '@') tpAnswerMap[y, w] += 1;
                if (canNE && wall[n][e] == '@') tpAnswerMap[n, e] += 1;
                if (canNW && wall[n][w] == '@') tpAnswerMap[n, w] += 1;
                if (canSE && wall[s][e] == '@') tpAnswerMap[s, e] += 1;
                if (canSW && wall[s][w] == '@') tpAnswerMap[s, w] += 1;
            }

        }
    }
    for (int j = 0; j < height; j++)
    {
        for (int i = 0; i < length; i++)
        {
            if (wall[j][i] == '@' && tpAnswerMap[j, i] < 4)
            {
                Console.Write(tpAnswerMap[j, i]);
                var a = wall[j];
                var newString = wall[j].ToCharArray();
                newString[i] = '.';
                wall[j] = new string(newString);
                removed += 1;
            }
            else
            {
                Console.Write(wall[j][i]);
            }
            ;
        }
        Console.WriteLine();
    }
    answer += removed;
    Console.WriteLine(removed);
}

Console.WriteLine(answer);