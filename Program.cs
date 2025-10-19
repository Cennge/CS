using System;
using System.Globalization;

public class Programm
{
    void Task1()
    {
        Console.WriteLine("enter a number from 1 to 100:");
        int a = int.Parse(Console.ReadLine());
        if (a >= 1 && a <= 100)
        {
            if (a % 3 == 0 && a % 5 == 0)
            {
                Console.WriteLine("fizzbuzz");
            }
            else if (a % 3 == 0)
            {
                Console.WriteLine("fizz");
            }
            else if (a % 5 == 0)
            {
                Console.WriteLine("buzz");
            }
            else
            {
                Console.WriteLine(a);
            }
        }
        else
        {
            Console.WriteLine("error: the number must be from 1 to 100.");
        }
    }

    void Task2()
    {
        Console.WriteLine("enter a number:");
        double num = double.Parse(Console.ReadLine());

        Console.WriteLine("enter the percentage:");
        double percent = double.Parse(Console.ReadLine());

        double result = num * percent / 100;
        Console.WriteLine($"{percent}% of {num} is {result}");
    }

    void Task3()
    {
        Console.WriteLine("enter the first digit:");
        string d1 = Console.ReadLine();
        Console.WriteLine("enter the second digit:");
        string d2 = Console.ReadLine();
        Console.WriteLine("enter the third digit:");
        string d3 = Console.ReadLine();
        Console.WriteLine("enter the fourth digit:");
        string d4 = Console.ReadLine();

        string combined = d1 + d2 + d3 + d4;
        int result = int.Parse(combined);
        Console.WriteLine($"here's your number: {result}");
    }

    void Task4()
    {
        Console.WriteLine("enter a six-digit number:");
        string numberStr = Console.ReadLine();

        if (numberStr.Length != 6)
        {
            Console.WriteLine("error: that's not a six-digit number.");
            return;
        }

        Console.WriteLine("first position to swap (1-6):");
        int pos1 = int.Parse(Console.ReadLine()) - 1;

        Console.WriteLine("second position to swap (1-6):");
        int pos2 = int.Parse(Console.ReadLine()) - 1;

        if (pos1 >= 0 && pos1 < 6 && pos2 >= 0 && pos2 < 6)
        {
            char[] digits = numberStr.ToCharArray();

            char temp = digits[pos1];
            digits[pos1] = digits[pos2];
            digits[pos2] = temp;

            Console.WriteLine($"result: {new string(digits)}");
        }
        else
        {
            Console.WriteLine("error: positions should be between 1 and 6.");
        }
    }

    void Task5()
    {
        Console.WriteLine("enter a date like dd.mm.yyyy:");
        string dateInput = Console.ReadLine();

        DateTime date = DateTime.ParseExact(dateInput, "dd.MM.yyyy", CultureInfo.InvariantCulture);

        string season = "";
        int month = date.Month;

        if (month == 12 || month == 1 || month == 2)
        {
            season = "winter";
        }
        else if (month >= 3 && month <= 5)
        {
            season = "spring";
        }
        else if (month >= 6 && month <= 8)
        {
            season = "summer";
        }
        else if (month >= 9 && month <= 11)
        {
            season = "autumn";
        }

        string dayOfWeek = date.ToString("dddd", new CultureInfo("en-US"));

        Console.WriteLine($"it's {season} {dayOfWeek}");
    }

    void Task6()
    {
        Console.WriteLine("what do you want to convert?");
        Console.WriteLine("1. celsius to fahrenheit");
        Console.WriteLine("2. fahrenheit to celsius");

        int choice = int.Parse(Console.ReadLine());
        Console.WriteLine("enter the temperature:");
        double temp = double.Parse(Console.ReadLine());
        double convertedTemp;

        if (choice == 1)
        {
            convertedTemp = (temp * 1.8) + 32;
            Console.WriteLine($"{temp}°c is {convertedTemp:F2}°f");
        }
        else if (choice == 2)
        {
            convertedTemp = (temp - 32) / 1.8;
            Console.WriteLine($"{temp}°f is {convertedTemp:F2}°c");
        }
        else
        {
            Console.WriteLine("error: invalid choice.");
        }
    }

    void Task7()
    {
        Console.WriteLine("enter the start of the range:");
        int start = int.Parse(Console.ReadLine());

        Console.WriteLine("enter the end of the range:");
        int end = int.Parse(Console.ReadLine());

        if (start > end)
        {
            int temp = start;
            start = end;
            end = temp;
            Console.WriteLine($"range normalized to: {start} and {end}");
        }

        Console.WriteLine($"even numbers from {start} to {end}:");
        for (int i = start; i <= end; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write(i + " ");
            }
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        var app = new Programm();
        app.Task1();
        app.Task2();
        app.Task3();
        app.Task4();
        app.Task5();
        app.Task6();
        app.Task7();
    }
}

