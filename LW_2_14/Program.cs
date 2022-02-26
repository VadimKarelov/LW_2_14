using LW_2_13;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LW_2_14
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Random rn = new();

            List<Continent> l = new();
            for (int i = 0; i < 2; i++) l.Add(new Continent(5, rn));

            Print(l);

            Print(Request1(l));

            Console.WriteLine("\nTotal number of books:" + Request2(l));

            Console.WriteLine($"\nOrganizations with salary over 9000: {Request3(l)}\n");

            Print(Request4(l));

            Console.WriteLine($"\nInsurance with number of clients over 80: {Request5(l)}\n");

            MyNewStack<int> st = new();
            st.Push(10);
            st.Push(15);
            st.Push(10);

            Console.WriteLine(st.Sum(x => x));
            st.Select(x => x == 5);
            Print(st.Select(x => x == 10));
        }

        private static List<Organization> Request1(List<Continent> continents)
        {
            // выборка LINQ 
            // организации с зарплатой выше 9000

            return (from continent in continents
                    from country in continent.Countries
                    from org in country.OrganizationList.Values
                    where org.AverageSalary > 9000
                    select org).ToList();
        }

        private static int Request2(List<Continent> continents)
        {
            // агрегирование: LINQ и методы расширения
            // подсчет всех книг во всех билиотеках, на всех континентах

            return (from continent in continents
                    from country in continent.Countries
                    from org in country.OrganizationList.Values
                    where org is Library
                    select ((Library)org).NumberOfBooks).Sum();
        }

        private static int Request3(List<Continent> continents)
        {
            // получение счетчика методами расширения
            // подсчет количества организаций с зарплатой выше 9000

            return continents.Select(continent => continent.Countries.Select(country => country.OrganizationList.Values.ToList().Where(org => org.AverageSalary > 9000))).Count();
        }

        private static List<string> Request4(List<Continent> continents)
        {
            // выборка LINQ 
            // имена всех организаций из Magadan со всех континентов

            return (from continent in continents
                    from country in continent.Countries
                    from organization in country.OrganizationList.Values
                    where organization.City == "Magadan"
                    select organization.Name).ToList();
        }

        private static int Request5(List<Continent> continents)
        {
            // агрегирование: LINQ и методы расширения
            // подсчет страховых с колвом клиентов больше 80

            return (from continent in continents
                    from country in continent.Countries
                    from org in country.OrganizationList.Values
                    where org is InsuranceCompany ins && ins.NumberOfClients > 80
                    select org).Count();
        }

        private static void Print<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}