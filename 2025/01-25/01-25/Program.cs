const int min = 0;
const int max = 99;
int answer = 0;
const int startPos = 50;

void solve()
{
    var inputStream = new StreamReader("C:\\Jacob\\Code\\advent-of-code\\2025\\01-25\\01-25\\input.txt");
    var line = inputStream.ReadLine();

    int pos = startPos;
    while (line != null)
    {
        char direction = line[0];
        for (int i = 0; i < Int32.Parse(line.Substring(1, line.Length - 1)); i++)
        {
            if (direction == 'L')
            {
                pos -= 1;
                if (pos < min)
                {
                    pos = max;
                }
            }
            else if (direction == 'R')
            {
                pos += 1;
                if (pos > max)
                {
                    pos = min;
                }
            }
            if (pos == 0)
            {
                answer += 1;
            }
        }
        line = inputStream.ReadLine();
    }
    Console.WriteLine(answer);
}
solve();
