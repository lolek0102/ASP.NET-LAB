using System;
namespace Labolatorium_2
{


    public class BirthModel
    {
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) && BirthDate.HasValue && BirthDate < DateTime.Now;
        }

        public int CalculateAge()
        {
            if (!BirthDate.HasValue)
            {
                return 0;
            }
            var age = DateTime.Now.Year - BirthDate.Value.Year;
            if (DateTime.Now < BirthDate.Value.AddYears(age)) age--;
            return age;
        }
    }
}