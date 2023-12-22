using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class DatabaseOperations
    {
        private readonly string _connectionString;

        public DatabaseOperations(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void GetCustomerCountPerCity()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Query("GetCustomerCountPerCity", commandType: CommandType.StoredProcedure);

                foreach (var row in result)
                {
                    Console.WriteLine($"City: {row.City}, Кількість клієнтів: {row.CustomerCount}");
                }
            }
        }


        public void GetCustomerCountPerCountry()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Query("GetCustomerCountPerCountry", commandType: CommandType.StoredProcedure);

                foreach (var row in result)
                {
                    Console.WriteLine($"Country: {row.Country}, Кількість клієнтів: {row.CustomerCount}");
                }
            }
        }

        public void GetCityCountPerCountry()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Query("GetCityCountPerCountry", commandType: CommandType.StoredProcedure);

                foreach (var row in result)
                {
                    Console.WriteLine($"Country: {row.Country}, Кількість клієнтів: {row.CityCount}");
                }
            }
        }

        public void GetAverageCityCount()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.QueryFirstOrDefault("GetAverageCityCount", commandType: CommandType.StoredProcedure);

                if (result != null)
                {
                    Console.WriteLine($"Середня кількість міст: {result.AverageCityCount}");
                }
            }
        }
        public void GetSectionsOfInterestedCustomers(string country)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Query("GetSectionsOfInterestedCustomers", new { Country = country }, commandType: CommandType.StoredProcedure);

                foreach (var row in result)
                {
                    Console.WriteLine($"SectionName: {row.SectionName}");
                }
            }
        }

        public void GetPromotionsOfSectionInTimeRange(string sectionName, DateTime startDate, DateTime endDate)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Query("GetPromotionsOfSectionInTimeRange", new { SectionName = sectionName, StartDate = startDate, EndDate = endDate }, commandType: CommandType.StoredProcedure);

                foreach (var row in result)
                {
                    Console.WriteLine($"PromotionID: {row.PromotionID}, SectionID: {row.SectionID}, Country: {row.Country}, StartDate: {row.StartDate}, EndDate: {row.EndDate}");
                }
            }
        }

        public void GetPromotionsOfCustomer(int customerID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Query("GetPromotionsOfCustomer", new { CustomerID = customerID }, commandType: CommandType.StoredProcedure);

                foreach (var row in result)
                {
                    Console.WriteLine($"PromotionID: {row.PromotionID}, SectionID: {row.SectionID}, Country: {row.Country}, StartDate: {row.StartDate}, EndDate: {row.EndDate}");
                }
            }
        }

        public void GetTop3CountriesByCustomerCount()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Query("GetTop3CountriesByCustomerCount", commandType: CommandType.StoredProcedure);

                foreach (var row in result)
                {
                    Console.WriteLine($"Country: {row.Country}, CustomerCount: {row.CustomerCount}");
                }
            }
        }

        public void GetBestCountryByCustomerCount()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Query("GetBestCountryByCustomerCount", commandType: CommandType.StoredProcedure);

                foreach (var row in result)
                {
                    Console.WriteLine($"Best Country: {row.Country}, CustomerCount: {row.CustomerCount}");
                }
            }
        }

        public void GetTop3CitiesByCustomerCount()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Query("GetTop3CitiesByCustomerCount", commandType: CommandType.StoredProcedure);

                foreach (var row in result)
                {
                    Console.WriteLine($"City: {row.City}, CustomerCount: {row.CustomerCount}");
                }
            }
        }

        public void GetBestCityByCustomerCount()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = connection.Query("GetBestCityByCustomerCount", commandType: CommandType.StoredProcedure);

                foreach (var row in result)
                {
                    Console.WriteLine($"Best City: {row.City}, CustomerCount: {row.CustomerCount}");
                }
            }
        }
        public void GetTop3PopularSections()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query("GetTop3PopularSections", commandType: CommandType.StoredProcedure);

                foreach (var row in result)
                {
                    Console.WriteLine($"Section: {row.SectionName}, SubscriberCount: {row.SubscriberCount}");
                }
            }
        }

        public void GetMostPopularSection()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query("GetMostPopularSection", commandType: CommandType.StoredProcedure);

                foreach (var row in result)
                {
                    Console.WriteLine($"Most Popular Section: {row.SectionName}, SubscriberCount: {row.SubscriberCount}");
                }
            }
        }

        public void GetTop3UnpopularSections()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query("GetTop3UnpopularSections", commandType: CommandType.StoredProcedure);

                foreach (var row in result)
                {
                    Console.WriteLine($"Section: {row.SectionName}, SubscriberCount: {row.SubscriberCount}");
                }
            }
        }

        public void GetMostUnpopularSection()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query("GetMostUnpopularSection", commandType: CommandType.StoredProcedure);

                foreach (var row in result)
                {
                    Console.WriteLine($"Most Unpopular Section: {row.SectionName}, SubscriberCount: {row.SubscriberCount}");
                }
            }
        }

        public void GetTop3SectionsByPromotionalProductsCount()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query("GetTop3SectionsByPromotionalProductsCount", commandType: CommandType.StoredProcedure);

                foreach (var row in result)
                {
                    Console.WriteLine($"Section: {row.SectionName}, ProductCount: {row.ProductCount}");
                }
            }
        }

        public void GetSectionWithMostPromotionalProducts()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query("GetSectionWithMostPromotionalProducts", commandType: CommandType.StoredProcedure);

                foreach (var row in result)
                {
                    Console.WriteLine($"Section with Most Products: {row.SectionName}, ProductCount: {row.ProductCount}");
                }
            }
        }

        public void GetTop3SectionsByLeastPromotionalProductsCount()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query("GetTop3SectionsByLeastPromotionalProductsCount", commandType: CommandType.StoredProcedure);

                foreach (var row in result)
                {
                    Console.WriteLine($"Section: {row.SectionName}, ProductCount: {row.ProductCount}");
                }
            }
        }

        public void GetSectionWithLeastPromotionalProducts()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query("GetSectionWithLeastPromotionalProducts", commandType: CommandType.StoredProcedure);

                foreach (var row in result)
                {
                    Console.WriteLine($"Section with Least Products: {row.SectionName}, ProductCount: {row.ProductCount}");
                }
            }
        }

        public void GetPromotionalProductsEndingInThreeDays()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query("GetPromotionalProductsEndingInThreeDays", commandType: CommandType.StoredProcedure);

                DisplayPromotionalProducts(result);
            }
        }

        public void GetExpiredPromotionalProducts()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query("GetExpiredPromotionalProducts", commandType: CommandType.StoredProcedure);

                DisplayPromotionalProducts(result);
            }
        }

        public void MoveExpiredPromotionalProductsToArchive()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute("MoveExpiredPromotionalProductsToArchive", commandType: CommandType.StoredProcedure);

                Console.WriteLine("Expired promotional products moved to archive successfully.");
            }
        }

        public void GetAverageCustomerAgeBySection()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query("GetAverageCustomerAgeBySection", commandType: CommandType.StoredProcedure);

                DisplayAverageAgeBySection(result);
            }
        }

        public void GetAverageCustomerAgeByCity()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query("GetAverageCustomerAgeByCity", commandType: CommandType.StoredProcedure);

                DisplayAverageAgeByLocation(result, "City");
            }
        }

        public void GetAverageCustomerAgeByCountry()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query("GetAverageCustomerAgeByCountry", commandType: CommandType.StoredProcedure);

                DisplayAverageAgeByLocation(result, "Country");
            }
        }

        private void DisplayPromotionalProducts(IEnumerable<dynamic> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"ProductName: {product.ProductName}, EndDate: {product.EndDate}");
            }
        }

        private void DisplayAverageAgeBySection(IEnumerable<dynamic> averageAges)
        {
            foreach (var averageAge in averageAges)
            {
                Console.WriteLine($"SectionName: {averageAge.SectionName}, AverageAge: {averageAge.AverageAge}");
            }
        }

        private void DisplayAverageAgeByLocation(IEnumerable<dynamic> averageAges, string locationType)
        {
            foreach (var averageAge in averageAges)
            {
                Console.WriteLine($"{locationType}: {averageAge.Location}, AverageAge: {averageAge.AverageAge}");
            }
        }

        public void GetMostPopularSectionByGender()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query("GetMostPopularSectionByGender", commandType: CommandType.StoredProcedure);

                DisplaySectionsByGender(result);
            }
        }

        public void GetTop3SectionsByGender()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query("GetTop3SectionsByGender", commandType: CommandType.StoredProcedure);

                DisplaySectionsByGender(result);
            }
        }

        public void GetCustomerCountByGender()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query("GetCustomerCountByGender", commandType: CommandType.StoredProcedure);

                DisplayCustomerCountByGender(result);
            }
        }

        public void GetCustomerCountByGenderAndCountry()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = connection.Query("GetCustomerCountByGenderAndCountry", commandType: CommandType.StoredProcedure);

                DisplayCustomerCountByGenderAndCountry(result);
            }
        }

        private void DisplaySectionsByGender(IEnumerable<dynamic> sections)
        {
            foreach (var section in sections)
            {
                Console.WriteLine($"Gender: {section.Gender}, SectionName: {section.SectionName}");
            }
        }

        private void DisplayCustomerCountByGender(IEnumerable<dynamic> customerCounts)
        {
            foreach (var customerCount in customerCounts)
            {
                Console.WriteLine($"Gender: {customerCount.Gender}, CustomerCount: {customerCount.CustomerCount}");
            }
        }

        private void DisplayCustomerCountByGenderAndCountry(IEnumerable<dynamic> customerCounts)
        {
            foreach (var customerCount in customerCounts)
            {
                Console.WriteLine($"Gender: {customerCount.Gender}, Country: {customerCount.Country}, CustomerCount: {customerCount.CustomerCount}");
            }
        }
    }
}
