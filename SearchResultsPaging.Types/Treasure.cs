using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchResultsPaging.Types
{
    public class Treasure
    {
        private static int _id = 1;

        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }

        public Treasure()
        {
            Id = _id++;
        }

        public Treasure(string name, double value)
            : this()
        {
            Name = name;
            Value = value;
        }
    }
}
