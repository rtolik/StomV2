using System;
using Stomatology.Models.Enum;

namespace Stomatology.Models
{
    public class Matherial : Interfaces.IEntityble
    {
        public virtual int? Id { get; set; }

        public virtual string Name { get; set; }

        public virtual MatherialType Type { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual int Number { get; set; }

        public virtual float PricePerOne { get; set; }

        public virtual float Summ { get; set; }

        //public virtual  Manipulation Manipulation { get; set; }

        public virtual Paragraph Paragraph { get; set; }

        public Matherial()
        {
            Id = null;
        }

        public Matherial(string name, MatherialType type, DateTime date, int number,
            float pricePerOne, int manipulationId)
        {
            Id = null;
            Name = name;
            Type = type;
            Date = date;
            Number = number;
            PricePerOne = pricePerOne;
            Summ = number * pricePerOne; 
            //Manipulation.Id = manipulationId;
        }
    }
}
