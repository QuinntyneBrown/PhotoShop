using PhotoShop.Core.Framework;

namespace PhotoShop.Core.Models
{
    public class Address: Value<Address>
    {        
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }     
    }
}
