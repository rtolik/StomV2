using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCloner.NewDB.Enum;

namespace DataBaseCloner.NewDB
{
    class Matherial
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual MatherialType Type { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual int Number { get; set; }

        public virtual float PricePerOne { get; set; }

        public virtual float Summ { get; set; }

        public virtual int ManipulationId { get; set; }

        public Matherial()
        {
        }

        public Matherial(int id, string name, MatherialType type, DateTime date, int number,
            float pricePerOne, float summ, int manipulationId)
        {
            Id = id;
            Name = name;
            Type = type;
            Date = date;
            Number = number;
            PricePerOne = pricePerOne;
            Summ = summ;
            ManipulationId = manipulationId;
        }
    }
}
