using System;
using System.Globalization;
using System.Text;
using System.Data.SqlClient;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CultureInfo culture = new CultureInfo("uk-UA");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            Console.OutputEncoding = Encoding.UTF8;

            string connectionString = @"Data Source=Gryhoriy\SQLEXPRESS;Initial Catalog=Mailing_list;Integrated Security=True;Encrypt=False";
            Task task = new Task(connectionString);

            int num1;
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Підключено до бази даних.\n");

                    do
                    {
                        Console.WriteLine("Завдання Практичної роботи");
                        Console.WriteLine("3 Завдання 3");
                        Console.WriteLine("4 Завдання 4");

                        Console.WriteLine("Завдання Домашньої роботи");
                        Console.WriteLine("5 Завдання 5");
                        Console.WriteLine("6 Завдання 6");

                        Console.WriteLine("");
                        Console.WriteLine("Введіть цифру:");

                        num1 = Convert.ToInt32(Console.ReadLine());
                        switch (num1)
                        {
                            case 3:
                                Task.TaskTwo(connection);
                                break;
                            case 4:
                                task.TaskThree(connection);
                                break;
                            case 5:
                                task.TaskFour(connection);
                                break;
                            case 6:
                                task.TaskFive(connection);
                                break;
                            case 7:
                                task.TaskSix(connection);
                                break;
                            case 8:
                                task.TaskSix(connection);
                                break;
                        }

                    } while (num1 != 0);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка при підключенні до бази даних: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                    Console.WriteLine("\nВідключено від бази даних.");
                }
            }
        }
    }
}
