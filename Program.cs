using System;

class CaesarCipher
{
    private int shift;

    public CaesarCipher(int shift)
    {
        this.shift = shift;
    }

    public string Encrypt(string plainText)
    {
        char[] plainTextArray = plainText.ToCharArray();

        for (int i = 0; i < plainTextArray.Length; i++)
        {
            if (char.IsLetter(plainTextArray[i]))
            {
                char baseChar = char.IsUpper(plainTextArray[i]) ? 'A' : 'a';
                plainTextArray[i] = (char)((plainTextArray[i] - baseChar + shift) % 26 + baseChar);
            }
        }

        return new string(plainTextArray);
    }

    public string Decrypt(string cipherText)
    {
        char[] cipherTextArray = cipherText.ToCharArray();

        for (int i = 0; i < cipherTextArray.Length; i++)
        {
            if (char.IsLetter(cipherTextArray[i]))
            {
                char baseChar = char.IsUpper(cipherTextArray[i]) ? 'A' : 'a';
                int shiftedIndex = (cipherTextArray[i] - baseChar - shift + 26) % 26;
                cipherTextArray[i] = (char)(shiftedIndex + baseChar);
            }
        }

        return new string(cipherTextArray);
    }
}

class NumberManager
{
    private int p;

    public NumberManager()
    {
        p = 0;
    }

    public bool SetNumber(int number)
    {
        if (number == p + 1)
        {
            p = number;
            return true;
        }
        else
        {
            p = 0;
            return false;
        }
    }

    public int GetExpectedNumber()
    {
        return p + 1;
    }
}

class QuadraticEquationSolver
{
    private double a;
    private double b;
    private double c;
    private double discriminant;
    private double root1;
    private double root2;

    public QuadraticEquationSolver(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
        discriminant = 0;
        root1 = 0;
        root2 = 0;
    }

    private void CalculateDiscriminant()
    {
        discriminant = b * b - 4 * a * c;
    }

    public void CalculateRoots()
    {
        CalculateDiscriminant();

        if (discriminant > 0)
        {
            root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
        }
        else if (discriminant == 0)
        {
            root1 = -b / (2 * a);
        }
    }

    public double GetA()
    {
        return a;
    }

    public double GetB()
    {
        return b;
    }

    public double GetC()
    {
        return c;
    }

    public double GetRoot1()
    {
        return root1;
    }

    public double GetRoot2()
    {
        return root2;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int choice;
        do
        {
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Encryption and decryption of text");
            Console.WriteLine("2. Number management");
            Console.WriteLine("3. Solving a quadratic equation");
            Console.WriteLine("4. Exit");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        RunCaesarCipherDemo();
                        break;
                    case 2:
                        RunNumberManagerDemo();
                        break;
                    case 3:
                        RunQuadraticEquationSolverDemo();
                        break;
                    case 4:
                        Console.WriteLine("Exit the program.");
                        break;
                    default:
                        Console.WriteLine("Incorrect choice. Try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid selection format. Try again.");
            }

        } while (choice != 4);
    }

    static void RunCaesarCipherDemo()
    {
        int shift = 3;

        CaesarCipher cipher = new CaesarCipher(shift);

        Console.WriteLine("Enter the encryption string:");
        string plainText = Console.ReadLine();

        string encryptedText = cipher.Encrypt(plainText);
        Console.WriteLine("Encrypted string: " + encryptedText);

        string decryptedText = cipher.Decrypt(encryptedText);
        Console.WriteLine("Decrypted string: " + decryptedText);
    }

    static void RunNumberManagerDemo()
    {
        NumberManager numberManager = new NumberManager();

        while (true)
        {
            Console.Write($"Enter the number {numberManager.GetExpectedNumber()}: ");
            if (int.TryParse(Console.ReadLine(), out int inputNumber))
            {
                if (numberManager.SetNumber(inputNumber))
                {
                    Console.WriteLine("Correct number. Continue..");
                }
                else
                {
                    Console.WriteLine("Wrong number. The algorithm starts again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid number format. Try again.");
            }
        }
    }

    static void RunQuadraticEquationSolverDemo()
    {
        double a, b, c;

        Console.Write("Enter coefficient a: ");
        a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter coefficient b: ");
        b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter coefficient c: ");
        c = Convert.ToDouble(Console.ReadLine());

        QuadraticEquationSolver equationSolver = new QuadraticEquationSolver(a, b, c);
        equationSolver.CalculateRoots();

        Console.WriteLine("Equation coefficients: a = " + equationSolver.GetA() + ", b = " + equationSolver.GetB() + ", c = " + equationSolver.GetC());
        Console.WriteLine("Root 1: " + equationSolver.GetRoot1());
        Console.WriteLine("Root 2: " + equationSolver.GetRoot2());
    }
}
