using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCloner.NewDB.Enum;
using DataBaseCloner.OldDB;

namespace DataBaseCloner.NewDB
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

        public Matherial(material material, sl_op_op op, Paragraph paragraph)
        {
            Id = material.id;
            Name = op.n_op;
            Number = material.kol;
            PricePerOne = material.cena;
            Summ = material.suma;
            Date = material.data;
            if (material.tip == "Прихід")
                Type = MatherialType.Arrival;
            Type = MatherialType.Consumption;
            Paragraph = paragraph;
        }
    }
}
