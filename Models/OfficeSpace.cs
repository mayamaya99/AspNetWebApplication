using System.ComponentModel.DataAnnotations;

namespace AspNetWebApplication.Models
{
    public class OfficeSpace
    {
        public int Id { get; set; }
        [Display(Name ="Property Type")]
        public string PropertyType { get; set; }
        [Display(Name ="Property Price")]
        public string PropertyPrice { get; set; }

        public OfficeSpace()
        {

        }

    }
}
