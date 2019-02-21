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

        public Operation(int visitId, int manipulationId, int number,
            float sale, float summ, bool isMade)
        {
            Id = null;
            Visit.Id = visitId;
            Manipulation.Id = manipulationId;
            Number = number;
            Sale = sale;
            Summ = summ;
            IsMade = isMade;
        }
    }
}
