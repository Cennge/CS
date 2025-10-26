using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n--- HOMEWORK (Main Menu) ---");
            Console.WriteLine("1. Run Task 1 (Arrays A and B)");
            Console.WriteLine("2. Run Task 2 (Sum between Min/Max)");
            Console.WriteLine("3. Run Task 3 (Caesar Cipher)");
            Console.WriteLine("4. Run Task 4 (Matrix Operations)");
            Console.WriteLine("5. Run Task 5 (Simple Calculator + and -)");
            Console.WriteLine("6. Run Task 6 (Capitalize Sentences)");
            Console.WriteLine("7. Run Task 7 (Censor)");
            Console.WriteLine("0. Exit");
            Console.Write("Enter task number (1-7) or 0 to exit: ");

            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    HW_Task1();
                    break;
                case "2":
                    HW_Task2();
                    break;
                case "3":
                    HW_Task3();
                    break;
                case "4":
                    HW_Task4();
                    break;
                case "5":
                    HW_Task5();
                    break;
                case "6":
                    HW_Task6();
                    break;
                case "7":
                    HW_Task7();
                    break;
                case "0":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Error: Invalid task number. Please try again.");
                    break;
            }
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
            Console.Clear();
        }
    }

    public static void HW_Task1()
    {
        int[] A = new int[5];
        double[,] B = new double[3, 4];

        Console.WriteLine("--- Task 1 ---");

        Console.WriteLine("\nEnter 5 integer numbers for array A:");
        for (int i = 0; i < A.Length; i++)
        {
            Console.Write($"Element A[{i}]: ");
            A[i] = int.Parse(Console.ReadLine());
        }

        Random rnd = new Random();
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                B[i, j] = rnd.NextDouble() * 10;
            }
        }

        Console.WriteLine("\nArray A (in one line):");
        foreach (var item in A)
        {
            Console.Write(item + "  ");
        }
        Console.WriteLine();

        Console.WriteLine("\nArray B (as a matrix):");
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                Console.Write(B[i, j].ToString("F2") + "\t");
            }
            Console.WriteLine();
        }

        double maxElementA = A[0];
        foreach (var item in A)
        {
            if (item > maxElementA) maxElementA = item;
        }

        double maxElementB = B[0, 0];
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                if (B[i, j] > maxElementB) maxElementB = B[i, j];
            }
        }

        double overallMax = Math.Max(maxElementA, maxElementB);
        Console.WriteLine($"\nOverall Maximum Element: {overallMax.ToString("F2")}");

        double minElementA = A[0];
        foreach (var item in A)
        {
            if (item < minElementA) minElementA = item;
        }

        double minElementB = B[0, 0];
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                if (B[i, j] < minElementB) minElementB = B[i, j];
            }
        }

        double overallMin = Math.Min(minElementA, minElementB);
        Console.WriteLine($"Overall Minimum Element: {overallMin.ToString("F2")}");

        int sumA = 0;
        foreach (var item in A)
        {
            sumA += item;
        }

        double sumB = 0;
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                sumB += B[i, j];
            }
        }
        Console.WriteLine($"Overall Sum of all elements: {(sumA + sumB).ToString("F2")}");

        long productA = 1;
        foreach (var item in A)
        {
            productA *= item;
        }

        double productB = 1.0;
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                productB *= B[i, j];
            }
        }
        Console.WriteLine($"Overall Product of all elements: {(productA * productB).ToString("F2")}");

        int sumEvenA = 0;
        foreach (var item in A)
        {
            if (item % 2 == 0)
            {
                sumEvenA += item;
            }
        }
        Console.WriteLine($"Sum of even elements in A: {sumEvenA}");

        double sumOddColsB = 0;
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                if (j % 2 != 0)
                {
                    sumOddColsB += B[i, j];
                }
            }
        }
        Console.WriteLine($"Sum of elements in odd columns of B: {sumOddColsB.ToString("F2")}");
    }

    public static void HW_Task2()
    {
        Console.WriteLine("--- Task 2 ---");

        int[,] A = new int[5, 5];
        Random rnd = new Random();
        for (int i = 0; i < A.GetLength(0); i++)
        {
            for (int j = 0; j < A.GetLength(1); j++)
            {
                A[i, j] = rnd.Next(-100, 101);
            }
        }

        Console.WriteLine("Generated Matrix:");
        for (int i = 0; i < A.GetLength(0); i++)
        {
            for (int j = 0; j < A.GetLength(1); j++)
            {
                Console.Write(A[i, j] + "\t");
            }
            Console.WriteLine();
        }

        int min = A[0, 0];
        int max = A[0, 0];

        int min_i = 0;
        int min_j = 0;
        int max_i = 0;
        int max_j = 0;

        for (int i = 0; i < A.GetLength(0); i++)
        {
            for (int j = 0; j < A.GetLength(1); j++)
            {
                if (A[i, j] > max)
                {
                    max = A[i, j];
                    max_i = i;
                    max_j = j;
                }

                if (A[i, j] < min)
                {
                    min = A[i, j];
                    min_i = i;
                    min_j = j;
                }
            }
        }

        Console.WriteLine($"\nMin Element: {min} [at {min_i},{min_j}]");
        Console.WriteLine($"Max Element: {max} [at {max_i},{max_j}]");

        int min_pos = min_i * A.GetLength(1) + min_j;
        int max_pos = max_i * A.GetLength(1) + max_j;

        int start_pos = Math.Min(min_pos, max_pos);
        int end_pos = Math.Max(min_pos, max_pos);
        int sum = 0;

        for (int i = 0; i < A.GetLength(0); i++)
        {
            for (int j = 0; j < A.GetLength(1); j++)
            {
                int current_pos = i * A.GetLength(1) + j;
                if (current_pos > start_pos && current_pos < end_pos)
                {
                    sum += A[i, j];
                }
            }
        }

        Console.WriteLine($"Sum between min and max: {sum}");
    }

    public static void HW_Task3()
    {
        Console.WriteLine("\n--- Task 3: Caesar Cipher ---");

        Console.Write("Enter text to encrypt: ");
        string text = Console.ReadLine();

        Console.Write("Enter key (shift), e.g., 3: ");
        int shift = int.Parse(Console.ReadLine());

        string encryptedText = CaesarCipher_Process(text, shift);
        Console.WriteLine($"Encrypted text: {encryptedText}");

        string decryptedText = CaesarCipher_Process(encryptedText, -shift);
        Console.WriteLine($"Decrypted text: {decryptedText}");
    }

    private static string CaesarCipher_Process(string text, int shift)
    {
        StringBuilder result = new StringBuilder();

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                char baseChar = char.IsUpper(c) ? 'А' : 'а';

                if ((c >= 'А' && c <= 'Я') || (c >= 'а' && c <= 'я'))
                {
                    int alphabetSize = 32;
                    char newChar = (char)(((c - baseChar + shift) % alphabetSize + alphabetSize) % alphabetSize + baseChar);
                    result.Append(newChar);
                }
                else if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    baseChar = char.IsUpper(c) ? 'A' : 'a';
                    int alphabetSize = 26;
                    char newChar = (char)(((c - baseChar + shift) % alphabetSize + alphabetSize) % alphabetSize + baseChar);
                    result.Append(newChar);
                }
                else
                {
                    result.Append(c);
                }
            }
            else
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }

    public static void HW_Task4()
    {
        Console.WriteLine("\n--- Task 4: Matrix Operations ---");

        int[,] matrixA = Matrix_CreateRandom(3, 3);
        int[,] matrixB = Matrix_CreateRandom(3, 3);
        int number = 5;

        Console.WriteLine("Matrix A:");
        Matrix_Print(matrixA);
        Console.WriteLine("Matrix B:");
        Matrix_Print(matrixB);

        Console.WriteLine($"\n1. Multiplying Matrix A by {number}:");
        int[,] resultMultNum = Matrix_MultiplyByNumber(matrixA, number);
        Matrix_Print(resultMultNum);

        Console.WriteLine("\n2. Addition of Matrix A and Matrix B:");
        try
        {
            int[,] resultAdd = Matrix_Add(matrixA, matrixB);
            Matrix_Print(resultAdd);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Addition Error: {ex.Message}");
        }

        Console.WriteLine("\n3. Multiplication of Matrix A by Matrix B:");
        try
        {
            int[,] resultMultMatrix = Matrix_Multiply(matrixA, matrixB);
            Matrix_Print(resultMultMatrix);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Multiplication Error: {ex.Message}");
        }
    }

    private static int[,] Matrix_CreateRandom(int rows, int cols)
    {
        Random rnd = new Random();
        int[,] matrix = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rnd.Next(1, 10);
            }
        }
        return matrix;
    }

    private static void Matrix_Print(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    private static int[,] Matrix_MultiplyByNumber(int[,] matrix, int number)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix[i, j] * number;
            }
        }
        return result;
    }

    private static int[,] Matrix_Add(int[,] A, int[,] B)
    {
        if (A.GetLength(0) != B.GetLength(0) || A.GetLength(1) != B.GetLength(1))
        {
            throw new Exception("Matrices have different dimensions!");
        }

        int rows = A.GetLength(0);
        int cols = A.GetLength(1);
        int[,] result = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = A[i, j] + B[i, j];
            }
        }
        return result;
    }

    private static int[,] Matrix_Multiply(int[,] A, int[,] B)
    {
        int rowsA = A.GetLength(0);
        int colsA = A.GetLength(1);
        int rowsB = B.GetLength(0);
        int colsB = B.GetLength(1);

        if (colsA != rowsB)
        {
            throw new Exception("Number of columns in Matrix A must equal number of rows in Matrix B!");
        }

        int[,] result = new int[rowsA, colsB];

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                int sum = 0;
                for (int k = 0; k < colsA; k++)
                {
                    sum += A[i, k] * B[k, j];
                }
                result[i, j] = sum;
            }
        }
        return result;
    }

    public static void HW_Task5()
    {
        Console.WriteLine("\n--- Task 5: Simple Calculator (+ and -) ---");
        Console.WriteLine("Enter an arithmetic expression (only + and -).");
        Console.WriteLine("Example: 10 + 5 - 3 - 2 + 15");
        Console.Write("Expression: ");
        string expression = Console.ReadLine();

        expression = expression.Replace(" ", "");

        string[] parts = expression.Replace("-", "+-").Split('+');

        int totalSum = 0;

        foreach (string part in parts)
        {
            if (!string.IsNullOrEmpty(part))
            {
                totalSum += int.Parse(part);
            }
        }

        Console.WriteLine($"Result: {totalSum}");
    }

    public static void HW_Task6()
    {
        Console.WriteLine("\n--- Task 6: Capitalize Sentences ---");
        Console.WriteLine("Enter text. The first letter of each sentence will be capitalized.");
        Console.WriteLine("Example: today is a good day. i will try to walk.");
        Console.Write("Text: ");
        string text = Console.ReadLine();

        StringBuilder result = new StringBuilder();

        bool isNewSentence = true;

        foreach (char c in text)
        {
            if (isNewSentence && char.IsLetter(c))
            {
                result.Append(char.ToUpper(c));
                isNewSentence = false;
            }
            else
            {
                result.Append(c);
            }

            if (c == '.' || c == '!' || c == '?')
            {
                isNewSentence = true;
            }
        }

        Console.WriteLine($"Result: {result.ToString()}");
    }

    public static void HW_Task7()
    {
        Console.WriteLine("\n--- Task 7: Censor ---");

        string text = @"To be, or not to be, that is the question,
Whether 'tis nobler in the mind to suffer
The slings and arrows of outrageous fortune,
Or to take arms against a sea of troubles,
And by opposing end them? To die: to sleep;
No more; and by a sleep to say we end
The heart-ache and the thousand natural shocks
That flesh is heir to, 'tis a consummation
Devoutly to be wish'd. To die, to sleep";

        List<string> badWords = new List<string> { "die" };

        Dictionary<string, int> stats = new Dictionary<string, int>();

        Console.WriteLine("--- Original Text ---");
        Console.WriteLine(text);

        string censoredText = text;

        foreach (string badWord in badWords)
        {
            string pattern = $@"\b{badWord}\b";

            int count = Regex.Matches(censoredText, pattern, RegexOptions.IgnoreCase).Count;

            if (count > 0)
            {
                string stars = new string('*', badWord.Length);

                censoredText = Regex.Replace(censoredText, pattern, stars, RegexOptions.IgnoreCase);

                stats.Add(badWord, count);
            }
        }

        Console.WriteLine("\n--- Censored Text ---");
        Console.WriteLine(censoredText);

        Console.WriteLine("\n--- Replacement Statistics ---");
        if (stats.Count == 0)
        {
            Console.WriteLine("No forbidden words found.");
        }
        else
        {
            foreach (var pair in stats)
            {
                Console.WriteLine($"The word '{pair.Key}' was replaced {pair.Value} time(s).");
            }
        }
    }
}