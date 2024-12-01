int[] hedgehogPopulation = { 2, 6, 6 }; 
int targetColor = 0;        

int result = MinMeetings(hedgehogPopulation, targetColor);

Console.WriteLine(result);

static int MinMeetings(int[] population, int targetColor)
{
    int targetSum = population.Sum();
    int firstNonTarget = (targetColor + 1) % 3;
    int secondNonTarget = (targetColor + 2) % 3;

    int steps = 0;

    if ((population[firstNonTarget] + population[secondNonTarget]) % 3 != 0)
    {
        return -1;
    }

    while (population[targetColor] != targetSum)
    {
        if (population[firstNonTarget] > 0 && population[secondNonTarget] > 0)
        {
            population[firstNonTarget]--;
            population[secondNonTarget]--;
            population[targetColor] = population[targetColor] + 2;
            steps++;
        }
        else
        {
            if (population[firstNonTarget] > 0)
            {
                population[firstNonTarget]--;
                population[targetColor]--;
                population[secondNonTarget] += 2;
                steps++;
            }
            else if (population[secondNonTarget] > 0)
            {
                population[secondNonTarget]--;
                population[targetColor]--;
                population[firstNonTarget] += 2;
                steps++;
            }
            else
            {
               return -1;
            }
        }
    }

    return steps;
}

