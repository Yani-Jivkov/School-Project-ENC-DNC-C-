using System;

namespace CryptoApp
{
    // Клас, който съдържа основната логика за криптиране и декриптиране
    class Encryptor
    {
        // Метод, който стартира потребителския интерфейс (меню в конзолата)
        public void Start()
        {
            Console.WriteLine("Здравей!");
            Console.WriteLine("Тази програма криптира и декриптира думи чрез ASCII таблицата.");
            Console.WriteLine("Ако искаш да криптираш - въведи 'ENC', ако искаш да декриптираш - въведи 'DNC'.");
            Console.WriteLine("За край напиши 'Exit'.");

            // Главен цикъл за взаимодействие с потребителя
            while (true)
            {
                Console.Write("\nВъведи команда (ENC, DNC или Exit) => ");
                string command = Console.ReadLine()?.Trim();

                // Проверка за край на програмата
                if (string.Equals(command, "Exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Изход от програмата...");
                    break;
                }
                // Криптиране
                else if (string.Equals(command, "ENC", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Въведи дума за криптиране => ");
                    string word = Console.ReadLine();
                    string encrypted = Encrypt(word);
                    Console.WriteLine($"Криптирана дума => {encrypted}");
                }
                // Декриптиране
                else if (string.Equals(command, "DNC", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Въведи криптирана дума за декриптиране => ");
                    string word = Console.ReadLine();
                    string decrypted = Decrypt(word);
                    Console.WriteLine($"Декриптирана дума => {decrypted}");
                }
                // Невалидна команда
                else
                {
                    Console.WriteLine("Грешка: Моля въведи валидна команда (ENC, DNC или Exit).");
                }
            }
        }

        // Метод за криптиране на дума чрез намаляване на ASCII стойностите
        public string Encrypt(string word)
        {
            // Създаваме масив от символи, където ще запазим резултата
            char[] result = new char[word.Length];

            // За всеки символ изчисляваме новата му стойност чрез изваждане на позицията му (i + 1)
            for (int i = 0; i < word.Length; i++)
            {
                result[i] = (char)(word[i] - (i + 1));
            }

            // Връщаме новата дума като string
            return new string(result);
        }

        // Метод за декриптиране на дума чрез увеличаване на ASCII стойностите
        public string Decrypt(string word)
        {
            char[] result = new char[word.Length];

            for (int i = 0; i < word.Length; i++)
            {
                result[i] = (char)(word[i] + (i + 1));
            }

            return new string(result);
        }
    }

    // Главен клас, от който стартира програмата
    class Program
    {
        static void Main(string[] args)
        {
            // Създаваме обект от класа Encryptor и стартираме менюто
            Encryptor app = new Encryptor();
            app.Start();
        }
    }
}
