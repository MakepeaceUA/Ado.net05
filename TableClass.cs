using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp50
{
    [Table(Name = "Continent")]
    public class Continent
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }
    }

    [Table(Name = "Country")]
    public class Country
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public double Area { get; set; }

        [Column]
        public int Population { get; set; }

        [Column]
        public int ContinentId { get; set; }
    }

    [Table(Name = "Capital")]
    public class Capital
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public int Population { get; set; }

        [Column]
        public int CountryId { get; set; }
    }

    [Table(Name = "City")]
    public class City
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public int Population { get; set; }

        [Column]
        public int CountryId { get; set; }
    }
}
