using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class DatabaseOperations
    {
        private readonly SqlConnection _connection;

        public DatabaseOperations(SqlConnection connection)
        {
            _connection = connection;
        }


        public void DisplayCitiesInCountry(SqlConnection connection)
        {
            Console.WriteLine("Введіть назву країни:");
            string countryName = Console.ReadLine();

            var cities = connection.Query<string>("SELECT DISTINCT City FROM Customers WHERE Country = @Country", new { Country = countryName });

            Console.WriteLine($"Список міст у країні {countryName}:");
            foreach (var city in cities)
            {
                Console.WriteLine($"City: {city}");
            }
        }

        public void DisplaySectionsOfCustomer(SqlConnection connection)
        {
            Console.WriteLine("Введіть ID покупця:");
            int customerID = Convert.ToInt32(Console.ReadLine());

            var sections = connection.Query<Section>("SELECT Sections.SectionID, Sections.SectionName FROM Sections " +
                                                     "JOIN InterestedSections ON Sections.SectionID = InterestedSections.SectionID " +
                                                     "WHERE InterestedSections.CustomerID = @CustomerID", new { CustomerID = customerID });

            Console.WriteLine($"Список розділів для покупця з ID {customerID}:");
            foreach (var section in sections)
            {
                Console.WriteLine($"SectionID: {section.SectionID}, SectionName: {section.SectionName}");
            }
        }

        public void DisplayPromotionsOfSection(SqlConnection connection)
        {
            Console.WriteLine("Введіть ID розділу:");
            int sectionID = Convert.ToInt32(Console.ReadLine());

            var promotions = connection.Query<Promotion>("SELECT * FROM Promotions WHERE SectionID = @SectionID", new { SectionID = sectionID });

            Console.WriteLine($"Список акційних товарів для розділу з ID {sectionID}:");
            foreach (var promotion in promotions)
            {
                Console.WriteLine($"PromotionID: {promotion.PromotionID}, SectionID: {promotion.SectionID}, Country: {promotion.Country}, StartDate: {promotion.StartDate}, EndDate: {promotion.EndDate}");
            }
        }
        public void DeleteCustomerInfo(SqlConnection connection)
        {
            Console.WriteLine("Введіть ID покупця для видалення інформації:");
            int customerID = Convert.ToInt32(Console.ReadLine());

            // Перевірка чи покупець існує
            var existingCustomer = connection.QueryFirstOrDefault<Customer>("SELECT * FROM Customers WHERE CustomerID = @CustomerID", new { CustomerID = customerID });

            if (existingCustomer != null)
            {
                connection.Execute("DELETE FROM Customers WHERE CustomerID = @CustomerID", new { CustomerID = customerID });
                Console.WriteLine("Інформація про покупця видалена.");
            }
            else
            {
                Console.WriteLine("Покупець з вказаним ID не знайдений.");
            }
        }

        public void DeleteCountryInfo(SqlConnection connection)
        {
            Console.WriteLine("Введіть ID країни для видалення інформації:");
            int countryID = Convert.ToInt32(Console.ReadLine());
             
            var existingCountry = connection.QueryFirstOrDefault<Customer>("SELECT * FROM Countries WHERE CountryID = @CountryID", new { CountryID = countryID });

            if (existingCountry != null)
            {
                connection.Execute("DELETE FROM Countries WHERE CountryID = @CountryID", new { CountryID = countryID });
                Console.WriteLine("Інформація про країну видалена.");
            }
            else
            {
                Console.WriteLine("Країна з вказаним ID не знайдена.");
            }
        }

        public void DeleteCityInfo(SqlConnection connection)
        {
            Console.WriteLine("Введіть ID міста для видалення інформації:");
            int cityID = Convert.ToInt32(Console.ReadLine());
             
            var existingCity = connection.QueryFirstOrDefault<Customer>("SELECT * FROM Cities WHERE CityID = @CityID", new { CityID = cityID });

            if (existingCity != null)
            {
                connection.Execute("DELETE FROM Cities WHERE CityID = @CityID", new { CityID = cityID });
                Console.WriteLine("Інформація про місто видалена.");
            }
            else
            {
                Console.WriteLine("Місто з вказаним ID не знайдено.");
            }
        }

        public void DeleteSectionInfo(SqlConnection connection)
        {
            Console.WriteLine("Введіть ID розділу для видалення інформації:");
            int sectionID = Convert.ToInt32(Console.ReadLine());
             
            var existingSection = connection.QueryFirstOrDefault<Section>("SELECT * FROM Sections WHERE SectionID = @SectionID", new { SectionID = sectionID });

            if (existingSection != null)
            {
                connection.Execute("DELETE FROM Sections WHERE SectionID = @SectionID", new { SectionID = sectionID });
                Console.WriteLine("Інформація про розділ видалена.");
            }
            else
            {
                Console.WriteLine("Розділ з вказаним ID не знайдений.");
            }
        }

        public void DeletePromotionInfo(SqlConnection connection)
        {
            Console.WriteLine("Введіть ID акційного товару для видалення інформації:");
            int promotionID = Convert.ToInt32(Console.ReadLine());
             
            var existingPromotion = connection.QueryFirstOrDefault<Promotion>("SELECT * FROM Promotions WHERE PromotionID = @PromotionID", new { PromotionID = promotionID });

            if (existingPromotion != null)
            {
                connection.Execute("DELETE FROM Promotions WHERE PromotionID = @PromotionID", new { PromotionID = promotionID });
                Console.WriteLine("Інформація про акційний товар видалена.");
            }
            else
            {
                Console.WriteLine("Акційний товар з вказаним ID не знайдений.");
            }
        }

        public void UpdateCustomerInfo(SqlConnection connection)
        {
            Console.WriteLine("Введіть ID покупця для оновлення інформації:");
            int customerID = Convert.ToInt32(Console.ReadLine());
             
            var existingCustomer = connection.QueryFirstOrDefault<Customer>("SELECT * FROM Customers WHERE CustomerID = @CustomerID", new { CustomerID = customerID });

            if (existingCustomer != null)
            {
                Console.WriteLine("Введіть нові дані про покупця:");

                Customer updatedCustomer = new Customer
                {
                    CustomerID = customerID,
                    FullName = "Нове ім'я",
                    BirthDate = new DateTime(1990, 1, 1),
                    Gender = "Нова стать",
                    Email = "new_email@example.com",
                    Country = "Нова країна",
                    City = "Нове місто"
                };

                connection.Execute("UPDATE Customers SET FullName = @FullName, BirthDate = @BirthDate, Gender = @Gender, Email = @Email, Country = @Country, City = @City WHERE CustomerID = @CustomerID", updatedCustomer);

                Console.WriteLine("Інформація про покупця оновлена.");
            }
            else
            {
                Console.WriteLine("Покупець з вказаним ID не знайдений.");
            }
        }

        public void UpdateCountryInfo(SqlConnection connection)
        {
            Console.WriteLine("Введіть ID країни для оновлення інформації:");
            int countryID = Convert.ToInt32(Console.ReadLine());
             
            var existingCountry = connection.QueryFirstOrDefault<Customer>("SELECT * FROM Countries WHERE CountryID = @CountryID", new { CountryID = countryID });

            if (existingCountry != null)
            {
                Console.WriteLine("Введіть нові дані про країну:");

                Customer updatedCountry = new Customer
                {
                    CustomerID = countryID,
                    Country = "Нова країна"
                };

                connection.Execute("UPDATE Countries SET CountryName = @CountryName WHERE CountryID = @CountryID", updatedCountry);

                Console.WriteLine("Інформація про країну оновлена.");
            }
            else
            {
                Console.WriteLine("Країна з вказаним ID не знайдена.");
            }
        }

        public void UpdateCityInfo(SqlConnection connection)
        {
            Console.WriteLine("Введіть ID міста для оновлення інформації:");
            int cityID = Convert.ToInt32(Console.ReadLine());

            var existingCity = connection.QueryFirstOrDefault<Customer>("SELECT * FROM Cities WHERE CityID = @CityID", new { CityID = cityID });

            if (existingCity != null)
            {
                Console.WriteLine("Введіть нові дані про місто:");

                Customer updatedCity = new Customer
                {
                    CustomerID = cityID,
                    City = "Нове місто"
                };

                connection.Execute("UPDATE Cities SET CityName = @CityName WHERE CityID = @CityID", updatedCity);

                Console.WriteLine("Інформація про місто оновлена.");
            }
            else
            {
                Console.WriteLine("Місто з вказаним ID не знайдено.");
            }
        }

        public void UpdateSectionInfo(SqlConnection connection)
        {
            Console.WriteLine("Введіть ID розділу для оновлення інформації:");
            int sectionID = Convert.ToInt32(Console.ReadLine());

            var existingSection = connection.QueryFirstOrDefault<Section>("SELECT * FROM Sections WHERE SectionID = @SectionID", new { SectionID = sectionID });

            if (existingSection != null)
            {
                Console.WriteLine("Введіть нові дані про розділ:");

                Section updatedSection = new Section
                {
                    SectionID = sectionID,
                    SectionName = "Новий розділ"
                };

                connection.Execute("UPDATE Sections SET SectionName = @SectionName WHERE SectionID = @SectionID", updatedSection);

                Console.WriteLine("Інформація про розділ оновлена.");
            }
            else
            {
                Console.WriteLine("Розділ з вказаним ID не знайдений.");
            }
        }

        public void UpdatePromotionInfo(SqlConnection connection)
        {
            Console.WriteLine("Введіть ID акційного товару для оновлення інформації:");
            int promotionID = Convert.ToInt32(Console.ReadLine());

            var existingPromotion = connection.QueryFirstOrDefault<Promotion>("SELECT * FROM Promotions WHERE PromotionID = @PromotionID", new { PromotionID = promotionID });

            if (existingPromotion != null)
            {
                Console.WriteLine("Введіть нові дані про акційний товар:");

                Promotion updatedPromotion = new Promotion
                {
                    PromotionID = promotionID,
                    SectionID = 1, 
                    Country = "Нова країна",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(1)
                };

                connection.Execute("UPDATE Promotions SET SectionID = @SectionID, Country = @Country, StartDate = @StartDate, EndDate = @EndDate WHERE PromotionID = @PromotionID", updatedPromotion);

                Console.WriteLine("Інформація про акційний товар оновлена.");
            }
            else
            {
                Console.WriteLine("Акційний товар з вказаним ID не знайдений.");
            }
        }

        public void InsertNewCustomers(SqlConnection connection)
        {
            Console.WriteLine("Введіть інформацію про нових покупців.");

            Customer newCustomer = new Customer
            {
                FullName = "Ім'я Призвище",
                BirthDate = new DateTime(1990, 1, 1),
                Gender = "Чоловіча",
                Email = "email@example.com",
                Country = "Країна",
                City = "Місто"
            };

            connection.Execute("INSERT INTO Customers (FullName, BirthDate, Gender, Email, Country, City) VALUES (@FullName, @BirthDate, @Gender, @Email, @Country, @City)", newCustomer);
        }

        public void InsertNewCountries(SqlConnection connection)
        {
            Console.WriteLine("Введіть нові країни.");

            Customer newCountry = new Customer
            {
                Country = "Нова країна"
            };

            connection.Execute("INSERT INTO Countries (CountryName) VALUES (@CountryName)", newCountry);
        }

        public void InsertNewCities(SqlConnection connection)
        {
            Console.WriteLine("Введіть нові міста.");

            Customer newCity = new Customer
            {
                City = "Нове місто"
            };

            connection.Execute("INSERT INTO Cities (CityName) VALUES (@CityName)", newCity);
        }

        public void InsertNewSections(SqlConnection connection)
        {
            Console.WriteLine("Введіть інформацію про нові розділи.");

            Section newSection = new Section
            {
                SectionName = "Новий розділ"
            };

            connection.Execute("INSERT INTO Sections (SectionName) VALUES (@SectionName)", newSection);
        }

        public void InsertNewPromotions(SqlConnection connection)
        {
            Console.WriteLine("Введіть інформацію про нові акційні товари.");

            Promotion newPromotion = new Promotion
            {
                SectionID = 1,
                Country = "Нова країна",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(1)
            };

            connection.Execute("INSERT INTO Promotions (SectionID, Country, StartDate, EndDate) VALUES (@SectionID, @Country, @StartDate, @EndDate)", newPromotion);
        }

        public IEnumerable<Customer> GetCustomersInCity(SqlConnection connection, string city)
        {
            return connection.Query<Customer>("SELECT * FROM Customers WHERE City = @City", new { City = city });
        }

        public IEnumerable<Customer> GetCustomersInCountry(SqlConnection connection, string country)
        {
            return connection.Query<Customer>("SELECT * FROM Customers WHERE Country = @Country", new { Country = country });
        }

        public IEnumerable<Promotion> GetPromotionsInCountry(SqlConnection connection, string country)
        {
            return connection.Query<Promotion>("SELECT * FROM Promotions WHERE Country = @Country", new { Country = country });
        }
        public static void DisplayCustomers(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine($"CustomerID: {customer.CustomerID}, FullName: {customer.FullName}");
            }
        }

        public static void DisplayEmails(IEnumerable<string> emails)
        {
            foreach (var email in emails)
            {
                Console.WriteLine($"Email: {email}");
            }
        }

        public static void DisplaySections(IEnumerable<Section> sections)
        {
            foreach (var section in sections)
            {
                Console.WriteLine($"SectionID: {section.SectionID}, SectionName: {section.SectionName}");
            }
        }

        public static void DisplayPromotions(IEnumerable<Promotion> promotions)
        {
            foreach (var promotion in promotions)
            {
                Console.WriteLine($"PromotionID: {promotion.PromotionID}, SectionID: {promotion.SectionID}, Country: {promotion.Country}, StartDate: {promotion.StartDate}, EndDate: {promotion.EndDate}");
            }
        }

        public static void DisplayCities(IEnumerable<string> cities)
        {
            foreach (var city in cities)
            {
                Console.WriteLine($"City: {city}");
            }
        }

        public static void DisplayCountries(IEnumerable<string> countries)
        {
            foreach (var country in countries)
            {
                Console.WriteLine($"Country: {country}");
            }
        }
    }
}

