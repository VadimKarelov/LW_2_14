using LW_2_13;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LW_2_14
{
    public class Program
    {
        private static Random rn = new();

        public static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {
            List<Continent> l = new();
            for (int i = 0; i < 3; i++) l.Add(new Continent(5, rn));

            Print(l);

            Console.WriteLine("Организации с зарплатой выше 9000");
            Print(Request1(l));

            Console.WriteLine("\nВсего книг во всех библиотеках:" + Request2(l));

            Console.WriteLine($"\nКоличество организаций с зарплатой больше 9000: {Request3(l)}\n");

            Console.WriteLine("Все организации из Magadan");
            Print(Request4(l));

            Console.WriteLine($"\nКоличество страховых с количеством клиентов больше 80: {Request5(l)}\n");

            Console.WriteLine("\nВсе библиотеки");
            Print(Request6(l));

            Console.WriteLine("\nБиблиотеки с зарплатой больше 9000");
            Print(Request8(l));

            Console.WriteLine("\nВсе заводы с группировкой по городам");
            Print(Request7(l));
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

            return continents.Sum(continent => continent.Countries.Sum(
                country => country.OrganizationList.Values.ToList().Where(org => org.AverageSalary > 9000).Count()));
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

        private static List<Organization> Request6(List<Continent> continents)
        {
            // выборка LINQ 
            // все библиотеки

            return (from continent in continents
                    from country in continent.Countries
                    from org in country.OrganizationList.Values
                    where org is Library
                    select org).ToList();
        }

        private static List<IGrouping<string, Organization>> Request7(List<Continent> continents)
        {
            // выборка и группировка LINQ и методы расширения
            // все заводы с группировкой по городам

            return (from continent in continents
                    from country in continent.Countries
                    from org in country.OrganizationList.Values
                    where org is Factory
                    select org).GroupBy(x => x.City).ToList();
        }

        private static List<Organization> Request8(List<Continent> continents)
        {
            // пересечение методами расширения 
            // библиотеки с зарплатой больше 9000

            return Request1(continents).Intersect(Request6(continents)).ToList();
        }

        private static void Part2()
        {
            Console.WriteLine("\n\n<<<Часть 2>>>");

            MyNewStack<Organization> st = new();

            for (int i = 0; i < 10; i++)
            {
                switch (rn.Next(0, 5))
                {
                    case 0: var org0 = new Organization(ref rn); st.Push(org0); break;
                    case 1: var org1 = new Factory(ref rn); st.Push(org1); break;
                    case 2: var org2 = new Library(ref rn); st.Push(org2); break;
                    case 3: var org3 = new InsuranceCompany(ref rn); st.Push(org3); break;
                    case 4: var org4 = new ShipConstructingCompany(ref rn); st.Push(org4); break;
                }
            }

            Print(st);

            Console.WriteLine($"\nКоличество элементов {st.Count()}");
            Console.WriteLine($"Средняя зарплата {st.Average()}");
            Console.WriteLine($"Минимальная зарплата {st.Min()}");
            Console.WriteLine($"Максимальная зарплата {st.Max()}");
            Console.WriteLine($"Сумма всех зарплат {st.Sum()}");

            Console.WriteLine($"\nОрганизации с зарплатой выше среднего c группировкой по городу");
            Print(st.Select(x => x.AverageSalary > st.Average()).ToMyNewStack().Group());
        }

        private static void Print<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        private static void Print(List<IGrouping<string, Organization>> collection)
        {
            foreach (var item in collection)
            {
                foreach (var item2 in item)
                {
                    Console.WriteLine(item2);
                }                
            }
        }
    }
}