namespace zadanie27092024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfDices = 0;

            while (numberOfDices < 3 || numberOfDices > 10)
            {
                Console.WriteLine("Ile kostek chcesz rzucić (3 - 10)");

                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    numberOfDices = number;
                }
                else
                {
                    continue;
                }
            }

            List<int> drawnDiceNumbers = new List<int>();

            Random random = new Random();
            for (int i = 0; i < numberOfDices; i++)
            {
                drawnDiceNumbers.Add(random.Next(1, 7));
            }

            for (int i = 0; i < drawnDiceNumbers.Count; i++)
            {
                Console.WriteLine("Kostka " + (i+1) + ": " + drawnDiceNumbers[i]);
            }


            int score = 0;
            if(drawnDiceNumbers.Distinct().Count() < numberOfDices) 
            {
                foreach(int points  in drawnDiceNumbers) 
                {
                    score += points;
                }
            }
            Console.WriteLine(score);
        }
    }
}
