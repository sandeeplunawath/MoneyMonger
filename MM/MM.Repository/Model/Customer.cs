using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MM.Repository.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FatherOrHusbandName { get; set; }
        public string? NationalityOrReligion { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AadharNumber { get; set; }
        
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public byte[]? CustomerImage { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string? LastUpdateBy { get; set; }

    }
}
