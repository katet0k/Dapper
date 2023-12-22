using System.Data.SqlClient;
using System.Globalization;
using System.Text;

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
                        Console.WriteLine("1 Завдання 1");
                        Console.WriteLine("2 Завдання 2\n");

                        Console.WriteLine("Завдання Домашньої роботи");

                        Console.WriteLine("");
                        Console.WriteLine("Введіть цифру:");

                        num1 = Convert.ToInt32(Console.ReadLine());
                        switch (num1)
                        {
                            case 1:
                                task.TaskOne();
                                break;
                            case 2:
                                task.TaskTwo();
                                break;
                                case 3:
                                task.TaskThree();
                                break;
                                case 4:
                                task.TaskFour();
                                break;
                                case 5:
                                task.TaskFive();
                                break;
                                case 6:
                                task.TaskSix();
                                break;
                                case 7:
                                task.TaskSSeven();
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