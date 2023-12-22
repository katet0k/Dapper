using System.Data.SqlClient;

namespace ConsoleApp3
{
    internal class Task
    {
        private string connectionString;

        public Task(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void TaskOne()
        {
            DatabaseOperations databaseOperations = new DatabaseOperations(connectionString);

            databaseOperations.GetCustomerCountPerCity();
            databaseOperations.GetCustomerCountPerCountry();
            databaseOperations.GetCityCountPerCountry();
            databaseOperations.GetAverageCityCount();
        }
        public void TaskTwo()
        {
            DatabaseOperations databaseOperations = new DatabaseOperations(connectionString);


            DateTime specificDate = new DateTime(2023, 01, 01);
            DateTime specificDate1 = new DateTime(2023, 01, 31);

            Console.WriteLine("Відображення списку міст певної країни.");
            databaseOperations.GetSectionsOfInterestedCustomers("Україна");
            Console.WriteLine("Відображення списку розділів певного покупця.");
            databaseOperations.GetPromotionsOfSectionInTimeRange("Мобільні телефони", specificDate, specificDate1);
            Console.WriteLine("Відображення списку акційних товарів певного розділу.");
            databaseOperations.GetPromotionsOfCustomer(1);

        }
        public void TaskThree()
        {
            DatabaseOperations databaseOperations = new DatabaseOperations(connectionString);

            Console.WriteLine("Відображення Топ-3 країн за кількістю покупців.");
            databaseOperations.GetTop3CountriesByCustomerCount();
            Console.WriteLine("Показати найкращу країну за кількістю покупців.");
            databaseOperations.GetBestCountryByCustomerCount();
            Console.WriteLine("Показати Топ-3 міст за кількістю покупців.");
            databaseOperations.GetTop3CitiesByCustomerCount();
            Console.WriteLine("Показати найкраще місто за кількістю покупців.");
            databaseOperations.GetBestCityByCustomerCount();
        }
        public void TaskFour()
        {

            DatabaseOperations databaseOperations = new DatabaseOperations(connectionString);
            Console.WriteLine("Показати Топ-3 найпопулярніших розділів розсилки.");
            databaseOperations.GetTop3PopularSections();
            Console.WriteLine("Показати найпопулярніший розділ розсилки.");
            databaseOperations.GetMostPopularSection();
            Console.WriteLine("Показати Топ-3 найнепопулярніших розділів розсилки.");
            databaseOperations.GetTop3UnpopularSections();
            Console.WriteLine("Показати найнепопулярніший розділ розсилки.");
            databaseOperations.GetMostUnpopularSection();
        }
        public void TaskFive()
        {

            DatabaseOperations databaseOperations = new DatabaseOperations(connectionString);

            Console.WriteLine("Показати Топ-3 розділів розсилки за кількістю акційних товарів.");
            databaseOperations.GetTop3SectionsByPromotionalProductsCount();
            Console.WriteLine("Показати розділ розсилки з найбільшою кількістю акційних товарів.");
            databaseOperations.GetSectionWithMostPromotionalProducts();
            Console.WriteLine("Показати Топ-3 розділів розсилки з найменшою кількістю акційних товарів.");
            databaseOperations.GetTop3SectionsByLeastPromotionalProductsCount();
            Console.WriteLine("Показати розділ розсилки з найменшою кількістю акційних товарів.");
            databaseOperations.GetSectionWithLeastPromotionalProducts();

        }
        public void TaskSix()
        {
            DatabaseOperations databaseOperations = new DatabaseOperations(connectionString);

            Console.WriteLine("Відобразіть усі акційні товари, які мають три дні до кінця акції.");
            databaseOperations.GetPromotionalProductsEndingInThreeDays();
            Console.WriteLine("Відобразіть усі акційні товари, в яких закінчився термін дії акції.");
            databaseOperations.GetExpiredPromotionalProducts();
            Console.WriteLine("Перенесіть усі товари, в яких закінчився термін дії акції, до таблиці під назвою «Архів акцій».");
            databaseOperations.MoveExpiredPromotionalProductsToArchive();
            Console.WriteLine("Відобразіть середній вік покупців по кожному розділу.");
            databaseOperations.GetAverageCustomerAgeBySection();
            Console.WriteLine("Відобразіть середній вік покупця по кожному місту.");
            databaseOperations.GetAverageCustomerAgeByCity();
            Console.WriteLine("Відобразіть середній вік покупця по кожній країні.");
            databaseOperations.GetAverageCustomerAgeByCountry();
        }
        public void TaskSSeven()
        {
            DatabaseOperations databaseOperations = new DatabaseOperations(connectionString);

            Console.WriteLine("Відобразіть найпопулярніший розділ для кожної статі.");
            databaseOperations.GetMostPopularSectionByGender();
            Console.WriteLine("Відобразіть Топ-3 розділи для кожної статі.");
            databaseOperations.GetTop3SectionsByGender();
            Console.WriteLine("Відобразіть кількість покупців кожної статі.");
            databaseOperations.GetCustomerCountByGender();
            Console.WriteLine("Відобразіть кількість покупців кожної статі з кожної країни.");
            databaseOperations.GetCustomerCountByGenderAndCountry();
        }

    }
}
    
 
