using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCloner.NewDB.Enum;

namespace DataBaseCloner.NewDB
{
    public class Matherial
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual MatherialType Type { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual int Number { get; set; }

        public virtual float PricePerOne { get; set; }

        public virtual float Summ { get; set; }

        public virtual Manipulation Manipulation { get; set; }

        public Matherial()
        {
        }

        public Matherial(string name, MatherialType type, DateTime date, int number,
            float pricePerOne, int manipulationId)
        {
            Name = name;
            Type = type;
            Date = date;
            Number = number;
            PricePerOne = pricePerOne;
            Summ = number * pricePerOne; 
            Manipulation.Id = manipulationId;
        }
    }
}
