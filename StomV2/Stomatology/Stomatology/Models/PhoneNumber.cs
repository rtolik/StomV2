namespace Stomatology.Models
{
    public class PhoneNumber : Interfaces.IEntityble
    {
        public virtual int? Id { get; set; }

        public virtual string Phone { get; set; }

        public virtual Patient Patient { get; set; }

        public PhoneNumber()
        {
            Id = null;
        }

        public PhoneNumber( string phone, Patient patient)
        {
            Id = null;
            Phone = phone;
            Patient = patient;
        }
    }
}
