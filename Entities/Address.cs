using System.ComponentModel.DataAnnotations;

namespace DevWebsCourseProjectApp.Entities
{
    public class Address
    {
        [Key] // defines primary key
        public int AddressId { get; set; }

        [ConcurrencyCheck] // AKA a concurrency token - checks no values have changed whilst ef core makes changes to db
        public string StreetName { get; set; }

        [Timestamp] // this adds a row each save and is also by default a concurrency token
        public byte[] TimeStamp { get; set; }

        public string City { get; set; }
        public string PostCode { get; set; }
        public int PersonId { get; set; }
        public Person MyPerson { get; set; }
    }
}
