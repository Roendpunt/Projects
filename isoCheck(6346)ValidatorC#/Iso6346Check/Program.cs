int[] letterValues = new int[26]
{
    10, 12, 13, 14, 15, 16, 17, 18, 19, 20, // A-J
    21, 23, 24, 25, 26, 27, 28, 29, 30, 31, // K-T
    32, 34, 35, 36, 37, 38                 // U-Z
};


while (true)
{
    Console.Write("Voer een nummer in (bijv. ABCD1234567) of typ 'exit' om te stoppen: ");
    string input = Console.ReadLine();

    if (input == "exit")
    {
        Environment.Exit(0);
    }
    break;

    if (ValidateContainerNumber(input))
    {
        Console.WriteLine("| {0,-20} | {1,-10} |", input, "Geldig");
    }
    else
    {
        Console.WriteLine("| {0,-20} | {1,-10} |", input, "Ongeldig");
    }
}

bool ValidateContainerNumber(string input)
{
    if (!System.Text.RegularExpressions.Regex.IsMatch(input, @"^[A-Z]{4}\d{7}$"))
    {
        return false;
    }

    int sum = 0;

    for (int i = 0; i < 4; i++)
    {
        char letter = input[i];
        if (letter >= 'A' && letter <= 'Z')
        {
            sum += letterValues[letter - 'A'];
        }
    }

    for (int i = 4; i < 11; i++)
    {
        sum += input[i] - '0'; // De cijferwaarde
    }

    int controlDigit = input[10] - '0'; // Het laatste cijfer is het controlecijfer
    return (sum % 11) == controlDigit; // Vergelijk de som met het controlecijfer
}
