using System.Diagnostics;

var reader = new StreamReader("C:\\Jacob\\Code\\advent-of-code\\2025\\06-25\\input.txt");
var line = reader.ReadLine();
List<string[]> rows1 = [];
List<string> rows2 = [];

while (line != null)
{
    //Part 1
    rows1.Add(line.Split().Where(s => !String.IsNullOrWhiteSpace(s)).ToArray());
    rows2.Add(line);

    line = reader.ReadLine();
}

//Part 1
string[] operations = rows1[rows1.Count - 1];
for (int r = 1; r < rows1.Count - 1; r++)
{
    var row = rows1[r];
    var prevRow = rows1[r - 1];
    for (int c = 0; c < rows1[0].Length; c++)
    {
        var operation = operations[c];
        var col = row[c];
        var prevCol = prevRow[c];
        var colVal = long.Parse(col);
        var prevColVal = long.Parse(prevCol);

        if (operation == "*")
        {
            rows1[r][c] = (colVal * prevColVal).ToString();
        }
        else if (operation == "+")
        {
            rows1[r][c] = (colVal + prevColVal).ToString();
        }
    }
}

//Part 2
long total = 0;
int operationIndex = 0;
long colTotal = 0;
bool newCol = true;
for (int c = 0; c < rows2.First().Length; c++)
{
    string innerColTotal = "";

    for (int r = 0; r < rows2.Count - 1; r++)
    {
        innerColTotal += rows2[r][c];
    }

    if (string.IsNullOrWhiteSpace(innerColTotal))
    {
        total += colTotal;
        colTotal = 0;
        operationIndex++;
        newCol = true;
    }
    else
    {

        switch (operations[operationIndex])
        {
            case "*":
                if (newCol)
                {
                    colTotal = long.Parse(innerColTotal);
                }
                else
                {

                    colTotal *= long.Parse(innerColTotal);
                }
                break;
            case "+":
                colTotal += long.Parse(innerColTotal);
                break;
        }
        newCol = false;
    }

    if (c == rows2.First().Length - 1)
    {
        total += colTotal;
    }
}



Console.WriteLine(rows1[rows1.Count - 2].Aggregate((a, b) => (long.Parse(a) + long.Parse(b)).ToString()));
Console.WriteLine();
Console.WriteLine(total);