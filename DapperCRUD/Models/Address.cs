using System.ComponentModel.DataAnnotations;

namespace DapperCRUD.Models
{
    public class Address : BaseEntity
    {
        public string address { get; set; }

        [Display(Name ="Customer Name")]
        public int CustomerId { get; set; }
    }
}
