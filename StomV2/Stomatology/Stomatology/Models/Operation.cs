namespace Stomatology.Models
{
    public class Operation : Interfaces.IEntityble
    {
        public virtual int? Id { get; set; }

        public virtual int Number { get; set; }

        public virtual float Sale { get; set; }

        public virtual float Summ { get; set; }

        public virtual bool IsMade { get; set; }

        public virtual Manipulation Manipulation { get; set; }

        public virtual Visit Visit { get; set; }

        public Operation()
        {
            Id = null;
        }

        public Operation(int number,float sale, float summ, bool isMade, Visit visit, Manipulation manipulation)
        {
            Id = null;
            Visit = visit;
            Manipulation = manipulation;
            Number = number;
            Sale = sale;
            Summ = summ;
            IsMade = isMade;
        }
    }
}
