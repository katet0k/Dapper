using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Task
    {
        private string connectionString; private readonly string _connectionString;
          
        public Task(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public static void TaskTwo(SqlConnection connection)
        {
            Console.WriteLine("Відображення усіх покупців.\n");
            var customers = connection.Query<Customer>("SELECT * FROM Customers");
            DatabaseOperations.DisplayCustomers(customers);

            Console.WriteLine(" ");
            Console.WriteLine("Відображення email усіх покупців.\n");
            var emails = connection.Query<string>("SELECT Email FROM Customers");
            DatabaseOperations.DisplayEmails(emails);

            Console.WriteLine(" ");
            Console.WriteLine("Відображення списку розділів.\n");
            var sections = connection.Query<Section>("SELECT * FROM Sections");
            DatabaseOperations.DisplaySections(sections);

            Console.WriteLine(" ");
            Console.WriteLine("Відображення списку акційних товарів.\n");
            var promotions = connection.Query<Promotion>("SELECT * FROM Promotions");
            DatabaseOperations.DisplayPromotions(promotions);

            Console.WriteLine(" ");
            Console.WriteLine("Відображення усіх міст.\n");
            var cities = connection.Query<string>("SELECT DISTINCT City FROM Customers");
            DatabaseOperations.DisplayCities(cities);

            Console.WriteLine(" ");
            Console.WriteLine("Відображення усіх країн.\n");
            var countries = connection.Query<string>("SELECT DISTINCT Country FROM Customers");
            DatabaseOperations.DisplayCountries(countries);
        }
        public void TaskThree(SqlConnection connection)
        {
            DatabaseOperations databaseOperations = new DatabaseOperations(connection);

            Console.WriteLine("Введіть місто для відображення покупців:");
            string city = Console.ReadLine();

            Console.WriteLine(" ");
            Console.WriteLine($"Відображення усіх покупців з міста {city}.\n");

            var customersInCity = databaseOperations.GetCustomersInCity(connection,city);
            DatabaseOperations.DisplayCustomers(customersInCity);

            Console.WriteLine(" ");
            Console.WriteLine("Введіть країну для відображення покупців:");
            string country = Console.ReadLine();

            Console.WriteLine(" ");
            Console.WriteLine($"Відображення усіх покупців з країни {country}.\n");

            var customersInCountry = databaseOperations.GetCustomersInCountry(connection,country);
            DatabaseOperations.DisplayCustomers(customersInCountry);

            Console.WriteLine(" ");
            Console.WriteLine($"Відображення усіх акцій для країни {country}.\n");

            var promotionsInCountry = databaseOperations.GetPromotionsInCountry(connection, country);
            DatabaseOperations.DisplayPromotions(promotionsInCountry);
        }

        public void TaskFour(SqlConnection connection)
        {
            Console.WriteLine("1. Вставка інформації про нових покупців.");
            Console.WriteLine("2. Вставка нових країн.");
            Console.WriteLine("3. Вставка нових міст.");
            Console.WriteLine("4. Вставка інформації про нові розділи.");
            Console.WriteLine("5. Вставка інформації про нові акційні товари.");
            Console.WriteLine("Введіть цифру опції:");

            int option = Convert.ToInt32(Console.ReadLine());

            DatabaseOperations databaseOperations = new DatabaseOperations(connection);

            switch (option)
            {
                case 1:
                    databaseOperations.InsertNewCustomers(connection);
                    break;
                case 2:
                    databaseOperations.InsertNewCountries(connection);
                    break;
                case 3:
                    databaseOperations.InsertNewCities(connection);
                    break;
                case 4:
                    databaseOperations.InsertNewSections(connection);
                    break;
                case 5:
                    databaseOperations.InsertNewPromotions(connection);
                    break;
                default:
                    Console.WriteLine("Невірна опція.");
                    break;
            }
        }


        public void TaskFive(SqlConnection connection)
        {
            Console.WriteLine("1. Оновлення інформації про покупців.");
            Console.WriteLine("2. Оновлення інформації про країни.");
            Console.WriteLine("3. Оновлення інформації про міста.");
            Console.WriteLine("4. Оновлення інформації про розділи.");
            Console.WriteLine("5. Оновлення інформації про акційні товари.");
            Console.WriteLine("Введіть цифру опції:");

            int option = Convert.ToInt32(Console.ReadLine());
            DatabaseOperations databaseOperations = new DatabaseOperations(connection);

            switch (option)
            {
                case 1:
                    databaseOperations.UpdateCustomerInfo(connection);
                    break;
                case 2:
                    databaseOperations.UpdateCountryInfo(connection);
                    break;
                case 3:
                    databaseOperations.UpdateCityInfo(connection);
                    break;
                case 4:
                    databaseOperations.UpdateSectionInfo(connection);
                    break;
                case 5:
                    databaseOperations.UpdatePromotionInfo(connection);
                    break;
                default:
                    Console.WriteLine("Невірна опція.");
                    break;
            }
        }


        public void TaskSix(SqlConnection connection)
        {
            Console.WriteLine("1. Видалення інформації про покупців.");
            Console.WriteLine("2. Видалення інформації про країни.");
            Console.WriteLine("3. Видалення інформації про міста.");
            Console.WriteLine("4. Видалення інформації про розділи.");
            Console.WriteLine("5. Видалення інформації про акційні товари.");
            Console.WriteLine("Введіть цифру опції:");

            int option = Convert.ToInt32(Console.ReadLine());
            DatabaseOperations databaseOperations = new DatabaseOperations(connection);

            switch (option)
            {
                case 1:
                    databaseOperations.DeleteCustomerInfo(connection);
                    break;
                case 2:
                    databaseOperations.DeleteCountryInfo(connection);
                    break;
                case 3:
                    databaseOperations.DeleteCityInfo(connection);
                    break;
                case 4:
                    databaseOperations.DeleteSectionInfo(connection);
                    break;
                case 5:
                    databaseOperations.DeletePromotionInfo(connection);
                    break;
                default:
                    Console.WriteLine("Невірна опція.");
                    break;
            }
        }

        public void TaskSeven(SqlConnection connection)
        {
            Console.WriteLine("1. Відображення списку міст певної країни.");
            Console.WriteLine("2. Відображення списку розділів певного покупця.");
            Console.WriteLine("3. Відображення списку акційних товарів певного розділу.");
            Console.WriteLine("Введіть цифру опції:");

            int option = Convert.ToInt32(Console.ReadLine());
            DatabaseOperations databaseOperations = new DatabaseOperations(connection);

            switch (option)
            {
                case 1:
                    databaseOperations.DisplayCitiesInCountry(connection);
                    break;
                case 2:
                    databaseOperations.DisplaySectionsOfCustomer(connection);
                    break;
                case 3:
                    databaseOperations.DisplayPromotionsOfSection(connection);
                    break;
                default:
                    Console.WriteLine("Невірна опція.");
                    break;
            }
        }

    }
}
