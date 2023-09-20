using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransactionAPI.Models
{

    public class Group
    {
        public int Id { get; set; }

        
        public string Name { get; set; }


        public string Address { get; set; }

     
        public string City { get; set; }

        public string StateOrProvince { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<Event> Events { get; set; }


    }

}