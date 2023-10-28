using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    internal class Program
    {

         
        
            static void Task1()
            {
                // Для цілочисельних значень
                Calculator<int> intCalculator = new Calculator<int>((a, b) => a + b, (a, b) => a - b, (a, b) => a * b, (a, b) => a / b);

                int result = intCalculator.PerformOperation(5, 3, intCalculator.Add);
                Console.WriteLine($"5 + 3 = {result}");

                result = intCalculator.PerformOperation(5, 3, intCalculator.Subtract);
                Console.WriteLine($"5 - 3 = {result}");

                result = intCalculator.PerformOperation(5, 3, intCalculator.Multiply);
                Console.WriteLine($"5 * 3 = {result}");

                result = intCalculator.PerformOperation(6, 3, intCalculator.Divide);
                Console.WriteLine($"6 / 3 = {result}");

                // Для дробових значень
                Calculator<double> doubleCalculator = new Calculator<double>((a, b) => a + b, (a, b) => a - b, (a, b) => a * b, (a, b) => a / b);

                double doubleResult = doubleCalculator.PerformOperation(5.5, 2.2, doubleCalculator.Add);
                Console.WriteLine($"5.5 + 2.2 = {doubleResult}");

                doubleResult = doubleCalculator.PerformOperation(5.5, 2.2, doubleCalculator.Subtract);
                Console.WriteLine($"5.5 - 2.2 = {doubleResult}");

                doubleResult = doubleCalculator.PerformOperation(5.5, 2.2, doubleCalculator.Multiply);
                Console.WriteLine($"5.5 * 2.2 = {doubleResult}");

                doubleResult = doubleCalculator.PerformOperation(6.6, 3.3, doubleCalculator.Divide);
                Console.WriteLine($"6.6 / 3.3 = {doubleResult}");
            }

            static void Task2()
            {
                // Створюємо репозиторій для рядків
                Repository<string> stringRepository = new Repository<string>();

                // Додаємо рядки до репозиторію
                stringRepository.Add("apple");
                stringRepository.Add("banana");
                stringRepository.Add("cherry");
                stringRepository.Add("date");

                // Створюємо критерій для пошуку
                Criteria<string> criteria = s => s.Length == 5; // Знайти рядки з довжиною 5 символів

                // Виконуємо пошук
                List<string> result = stringRepository.Find(criteria);

                // Виводимо результат
                Console.WriteLine("Результат пошуку:");
                foreach (string item in result)
                {
                    Console.WriteLine(item);
                }
                {
                }
            }

            private static void Task3()
            {
                // Створюємо кеш з терміном зберігання результатів 1 хвилина
                var cache = new FunctionCache<string, int>(TimeSpan.FromMinutes(1));

                // Користувацька функція для обчислення довжини рядка
                Func<string, int> calculateLength = s =>
                {
                    Console.WriteLine("Calculating length for: " + s);
                    return s.Length;
                };

                // Використання кешу для обчислення довжини рядка
                string input = "Hello, World!";
                int length = cache.GetOrAdd(input, calculateLength);
                Console.WriteLine("Length of '{0}': {1}", input, length);

                // Використання кешу для повторного обчислення довжини рядка (результат повинен бути взятий із кешу)
                length = cache.GetOrAdd(input, calculateLength);
                Console.WriteLine("Length of '{0}': {1}", input, length);
            }

            static void Task4()
            {
                // Створюємо планувальник завдань для рядків з пріоритетами типу int
                var scheduler = new TaskScheduler<string, int>(ExecuteStringTask);

                // Додавання завдань з консолі
                Console.WriteLine("Enter tasks (format: task priority), or press Enter to execute:");
                while (true)
                {
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        scheduler.ExecuteNext();
                    }
                    else
                    {
                        string[] parts = input.Split(' ');
                        if (parts.Length == 2 && int.TryParse(parts[1], out int priority))
                        {
                            scheduler.AddTask(parts[0], priority);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Use format: task priority");
                        }
                    }
                }
            }

            // Метод для виконання завдань типу string
            private static void ExecuteStringTask(string task)
            {
                Console.WriteLine("Executing task: " + task);
            }
            private static void Main(string[] args)
            {
                //Task1();
                //Task2();
                //Task3();
                //Task4();

                // delay to read from screen
                Console.WriteLine("Press any key to finnish this program...");
                Console.Read();
            }
        }
    }
