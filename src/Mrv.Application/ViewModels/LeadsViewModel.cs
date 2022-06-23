using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mrv.Application.ViewModels
{
    public class LeadsViewModel
    {
        public Guid Id { get; set; }
        
        public int categoryId { get; set; }
        
        public int contactId { get; set; }     

        [Required(ErrorMessage = "The Address is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Address")]
        public string suburb { get; set; }

        [Required(ErrorMessage = "The Price is Required")]
        [DisplayName("Price")]
        public decimal price { get; set; }

        [DisplayName("Status")]
        public string status { get; set; }

        public string description { get; set; }

        [Required(ErrorMessage = "The Date Created is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Date Created")]
        public DateTime dateCreated { get; set; }
    }
}
