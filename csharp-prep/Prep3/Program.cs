using System;

class Program
{
    static void Main(string[] args)
    {
        // For steps 1 and 2 where the user specified the magic number
        // Console.Write("What is the magic number? ");
        // string firstAnswer = Console.ReadLine();
        // int magicNumber = int.Parse(firstAnswer);

        // For the step 3 where we have to use a random number
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}