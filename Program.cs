namespace zadanie27092024
{
    internal class Program
    {
        /************************************************
            nazwa: DrawNumbers
            opis: Funkcja losuje liczby z zakresu 1 - 6 w ilości podanej w parametrze numberOfDices funkcji.
            parametry: numberOfDices - zmienna typu int przechowywująca inforamcje o ilości liczb do wylosowania.
            zwracany typ i opis: List<int> (lista losowych liczb od 1 - 6 w ilości podanej jako parametr funkcji).
            autor: PESEL
        *************************************************/
        static List<int> DrawNumbers(int numberOfDices)
        {
            List<int> drawnDiceNumbers = new List<int>();

            Random random = new Random();
            for (int i = 0; i < numberOfDices; i++)
            {
                drawnDiceNumbers.Add(random.Next(1, 7));
            }

            return drawnDiceNumbers;
        }

        static int CalculateScore(List<int> drawnDiceNumbers)
        {
            List<int> distinctDiceNumbers = drawnDiceNumbers.Distinct().ToList();

            int score = 0;
            foreach (int distinctDiceNumber in distinctDiceNumbers)
            {
                int numberOfOccurances = 0;
                foreach (int drawnDiceNumber in drawnDiceNumbers)
                {
                    if (drawnDiceNumber == distinctDiceNumber)
                    {
                        numberOfOccurances++;
                    }
                }

                if (numberOfOccurances > 1)
                {
                    score += numberOfOccurances * distinctDiceNumber;
                }
            }

            return score;
        }
        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain == true)
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

                List<int> drawnDiceNumbers = DrawNumbers(numberOfDices);

                for (int i = 0; i < drawnDiceNumbers.Count; i++)
                {
                    Console.WriteLine("Kostka " + (i + 1) + ": " + drawnDiceNumbers[i]);
                }

                int score = CalculateScore(drawnDiceNumbers);

                Console.WriteLine("Liczba uzyskanych punktów: " + score);

                
                var answer = String.Empty;
                while(answer != "t" || answer != "n")
                {

                    Console.WriteLine("Jeszcze raz? (t/n)");
                    answer = Console.ReadLine();

                    if(answer == "t")
                    {
                        playAgain = true;
                    }
                    else
                    {
                        playAgain = false;
                    }   
                }
            }
        }
    }
}
