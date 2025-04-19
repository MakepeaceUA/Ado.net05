using System;
using System.Data.Linq;
using System.Linq;

namespace ConsoleApp50
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataContext dataContext = new DataContext("Data Source=ARSEN;Initial Catalog=LINQ_To_SQL;Integrated Security=True");
            Table<Country> countries = dataContext.GetTable<Country>();
            Table<Capital> capitals = dataContext.GetTable<Capital>();
            Table<City> cities = dataContext.GetTable<City>();
            Table<Continent> continents = dataContext.GetTable<Continent>();
            
            Console.WriteLine("Вся информация:");
            foreach (var country in countries)
            {
                Console.WriteLine($"Страна:{country.Name}\nПлощадь:{country.Area}\nНаселение:{country.Population}\n");
            }

            Console.WriteLine("\nВсе страны:");
            var СountryName = from c in countries select c.Name;
            foreach (var name in СountryName)
            {
                Console.WriteLine(name);
            }
                
            
            Console.WriteLine("\n\nВсе столицы:");
            var СapitalName = from cap in capitals select cap.Name;
            foreach (var name in СapitalName)
            {
                Console.WriteLine(name);
            }


            string Target = "Китай";
            Console.WriteLine($"\n\nГорода страны {Target}:");
            var BigCity = from city in cities
                            join c in countries on city.CountryId equals c.Id
                            where c.Name == Target
                            select city.Name;
            foreach (var name in BigCity)
            {
                Console.WriteLine(name);
            }
            
            Console.WriteLine("\n\nСтолицы с населением больше 5 млн:");
            var bigCapitals = from cap in capitals
                              where cap.Population > 5000000
                              select cap.Name;
            foreach (var name in bigCapitals)
            {
                Console.WriteLine(name);
            }
           
            Console.WriteLine("\n\nВсе страны Европы:");
            var EUCountry = from c in countries
                                    join cont in continents on c.ContinentId equals cont.Id
                                    where cont.Name == "Европа"
                                    select c.Name;
            foreach (var name in EUCountry)
            {
                Console.WriteLine(name);
            }

            double Area = 100000;
            Console.WriteLine($"\n\nСтраны с площадью больше {Area}:");
            var BigCountry = from c in countries
                                 where c.Area > Area
                                 select c.Name;
            foreach (var name in BigCountry)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine($"\n\nСтолицы в которых есть буквы 'a' и 'р':");
            var AandP = from c in capitals
                               where c.Name.ToLower().Contains("a") && c.Name.ToLower().Contains("p")
                               select c.Name;
            foreach (var name in AandP)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine($"\n\nСтолицы которые начинаются с буквы 'к':");
            var StartsK = from c in capitals
                                 where c.Name.StartsWith("К")
                                 select c.Name;
            foreach (var name in StartsK)
            {
                Console.WriteLine(name);
            }

            double min = 100000;
            double max = 1000000;
            Console.WriteLine($"\n\nСтраны с площадью от {min} до {max}:");
            var Ar_Range = from c in countries
                                   where c.Area >= min && c.Area <= max
                                   select c.Name;
            foreach (var name in Ar_Range)
            {
                Console.WriteLine(name);
            }

            int MinPopulation = 10000000;
            Console.WriteLine($"\n\nСтраны с населением больше {MinPopulation}:");
            var PopulCountry = from c in countries
                                     where c.Population > MinPopulation
                                     select c.Name;
            foreach (var name in PopulCountry)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine($"\n\nТоп 5 стран по площади:");
            var Top5_Area = countries.OrderByDescending(c => c.Area).Take(5);
            foreach (var c in Top5_Area)
            {
                Console.WriteLine($"Страна:{c.Name} - {c.Area}");
            }

            Console.WriteLine($"\n\nТоп 5 столиц по населению:");
            var Top5_Capital = capitals.OrderByDescending(c => c.Population).Take(5);
            foreach (var c in Top5_Capital)
            {
                Console.WriteLine($"Название:{c.Name} — {c.Population}");
            }
                
            var BiggestCountry = countries.OrderByDescending(c => c.Area).FirstOrDefault();
            Console.WriteLine($"\n\nСамая большая страна: {BiggestCountry?.Name} — {BiggestCountry?.Area}");
            var BiggestCapital = capitals.OrderByDescending(c => c.Population).FirstOrDefault();
            Console.WriteLine($"\n\nСамая большая столица: {BiggestCapital?.Name} — {BiggestCapital?.Population}");

            var EUSmallest = (from c in countries
                                    join cont in continents on c.ContinentId equals cont.Id
                                    where cont.Name == "Европа"
                                    orderby c.Area
                                    select c).FirstOrDefault();
            Console.WriteLine($"\n\nСамая маленькая страна в Европе: {EUSmallest?.Name} — {EUSmallest?.Area}");

            var AVG_EU = (from c in countries
                                 join cont in continents on c.ContinentId equals cont.Id
                                 where cont.Name == "Европа"
                                 select c.Area).Average();
            Console.WriteLine($"\n\nСредняя площадь стран Европы: {AVG_EU}");


            string Target_2 = "Китай";
            Console.WriteLine($"\n\nТоп 3 города по населению в стране {Target_2}:");
            var Top3_City = (from city in cities
                             join c in countries on city.CountryId equals c.Id
                             where c.Name == Target_2
                             orderby city.Population descending
                             select city).Take(3);
            foreach (var city in Top3_City)
                Console.WriteLine($"{city.Name} — {city.Population}");

            int Total = countries.Count();
            Console.WriteLine($"\n\nВсего стран: {Total}");

            var CountryRegion = (from c in countries
                                       group c by c.ContinentId into g
                                       orderby g.Count() descending
                                       select new { ContinentId = g.Key, Count = g.Count() }).FirstOrDefault();

            if (CountryRegion != null)
            {
                string contName = continents.First(x => x.Id == CountryRegion.ContinentId).Name;
                Console.WriteLine($"\n\nЧасть света с наибольшим числом стран: {contName} — {CountryRegion.Count} стран");
            }

            Console.WriteLine($"\n\nКоличество стран в каждой части света:");
            var PerContinent = from c in countries
                                        group c by c.ContinentId into g
                                        select new
                                        {
                                            ContinentName = continents.First(cont => cont.Id == g.Key).Name,
                                            Count = g.Count()
                                        };
            foreach (var item in PerContinent)
            {
                Console.WriteLine($"{item.ContinentName}: {item.Count} стран");
            }
        }
    }
}
