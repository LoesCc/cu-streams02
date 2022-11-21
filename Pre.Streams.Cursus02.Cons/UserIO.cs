namespace Pre.Streams.Cursus02.Cons;

using System;

public class UserIO
{
    private ConsoleColor color;

    public void SetColor(ConsoleColor color)
    {
        this.color = color;
    }

    public ConsoleColor GetColor()
    {
        return this.color;
    }

    public int ReadInt(string prompt, int min, int max)
    {
        DisplayPrompt(prompt);
        return ReadInt(min, max);
    }

    public int ReadInt(int min, int max)
    {
        int value = ReadInt();
        while (value < min || value > max)
        {
            DisplayPrompt("Please enter an integer between {0} and {1} (inclusive)",
                min, max);
            value = ReadInt();
        }

        return value;
    }

    public int ReadInt()
    {
        return this.ReadInt("Please enter an integer");
    }

    public int ReadInt(string prompt)
    {
        string input = String.Empty;
        int value;
        do
        {
            DisplayPrompt(prompt);
            input = Console.ReadLine();
        } while (!int.TryParse(input, out value));

        return value;
    }

    public string ReadString(string prompt)
    {
        DisplayPrompt(prompt);
        return Console.ReadLine();
    }

    public bool ReadYesNo(string prompt)
    {
        ConsoleKey response;
        do
        {
            DisplayPrompt($"{prompt} [y/n]");
            response = Console.ReadKey(false).Key;
            if (response != ConsoleKey.Enter)
            {
                Console.WriteLine();
            }
        } while (response != ConsoleKey.Y && response != ConsoleKey.N);

        return (response == ConsoleKey.Y);
    }

    public void DisplayPrompt(string prompt)
    {
        DisplayPrompt(prompt, null);
    }

    private void DisplayPrompt(string prompt, params object[] promptParams)
    {
        Console.ForegroundColor = this.color;
        Console.Write($"{prompt} ", promptParams);
    }

    public void ResetColor()
    {
        Console.ResetColor();
        this.color = Console.ForegroundColor;
    }
}