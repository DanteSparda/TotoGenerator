using System;
using TotoGenerator.Combinations;
using TotoGenerator.Common;

namespace TotoGenerator.Engine
{
    public class Startup
    {
        public static void Main()
        {                        
            WelcomeMessage();
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();
                Console.Clear();
                WelcomeMessage();
                switch (keyinfo.KeyChar)
                {
                    case '1':
                        DisplayStandartCombination(new StandardCombination(NumericConstants.CombinationsMinValue, NumericConstants.SixFromFortyNineMaxValue, NumericConstants.SixFromFortyNineTotalNumbers));
                        break;
                    case '2':
                        DisplayStandartCombination(new StandardCombination(NumericConstants.CombinationsMinValue, NumericConstants.SixFromFortyTwoMaxValue, NumericConstants.SixFromFortyTwoTotalNumbers));
                        break;
                    case '3':
                        DisplayStandartCombination(new StandardCombination(NumericConstants.CombinationsMinValue, NumericConstants.FiveFromThirtyFiveMaxValue, NumericConstants.FiveFromThirtyFiveTotalNumbers));
                        break;
                    case '4':
                        DisplayZodiactCombination(new ZodiacCombination(NumericConstants.CombinationsMinValue, NumericConstants.ZodiacMaxValue, NumericConstants.ZodiacTotalNumbers));
                        break;
                    default: break;
                }
            }
            while (keyinfo.KeyChar != 'q');  
        }

        private static void WelcomeMessage()
        {
            MessageOutput("Welcome to our Toto Generator", ConsoleColor.Cyan);
            Console.WriteLine();
            MessageOutput("For 6/49 press ", ConsoleColor.White);
            MessageOutput("1", ConsoleColor.Red);
            Console.WriteLine();
            MessageOutput("For 6/42 press ", ConsoleColor.White);
            MessageOutput("2", ConsoleColor.Red);
            Console.WriteLine();
            MessageOutput("For 5/35 press ", ConsoleColor.White);
            MessageOutput("3", ConsoleColor.Red);
            Console.WriteLine();
            MessageOutput("For 5/50 + Zodiac press ", ConsoleColor.White);
            MessageOutput("4", ConsoleColor.Red);
            Console.WriteLine();
            MessageOutput("To clear the console press ", ConsoleColor.White);
            MessageOutput("w", ConsoleColor.Red);
            Console.WriteLine();
            MessageOutput("To exit the program ", ConsoleColor.White);
            MessageOutput("q", ConsoleColor.Red);
            Console.WriteLine();
        }
        private static void DisplayStandartCombination(StandardCombination combination)
        {
            Console.WriteLine();
            var randomGenerator = new RandomCombinationGenerator();
            var result = string.Join(" ", randomGenerator.GetNumbers(combination));
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Your combination for {combination.TotalNumbers}/{combination.MaximumValue} is {result}");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        private static void DisplayZodiactCombination(ZodiacCombination combination)
        {
            Console.WriteLine();
            var randomGenerator = new RandomCombinationGenerator();
            var numberResult = string.Join(" ", randomGenerator.GetNumbers(combination));
            var zodiac = (ZodiacType)randomGenerator.GetZodiac(NumericConstants.ZodiacTotalZodiacNumbers);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Your combination for {combination.TotalNumbers}/{combination.MaximumValue} + Zodiac is {numberResult} {zodiac}");
            Console.BackgroundColor = ConsoleColor.Black;
        }
        private static void MessageOutput(string input, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(input);
        }
    }
}
