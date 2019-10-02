using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stomatology.Models.DTO
{
    class OperationDTO
    {
        public virtual string Name { get; set; }

        public virtual int Number { get; set; }

        public virtual float Price { get; set; }

        public virtual float Sale { get; set; }

        public virtual float Summ { get; set; }

        public virtual bool IsMade { get; set; }

        public OperationDTO() { }

        public OperationDTO(string name, int number, float price, float sale, float summ, bool isMade)
        {
            Name = name;
            Number = number;
            Price = price;
            Sale = sale;
            Summ = summ;
            IsMade = isMade;
        }
    }
}
