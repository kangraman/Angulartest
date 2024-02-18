namespace Angularapi.Models
{
    public class State
    {
        public int stateId { get; set; }
        public string stateName { get; set; }
        public int countryId { get; set; } // Foreign key
        public string countryName { get; set; }
        //public Country Country { get; set; } // Navigation property
    }
}
