using System;
using System.ComponentModel.DataAnnotations;

namespace MsmqDemo.Web.Models
{
    public class Order
    {
        [Display(Name = "Vendor Number")]
        [Required]
        public string VenderNumber { get; set; }

        [Display(Name = "Requested Delivery Date")]
        [Required]
        public DateTime RequestedDeliveryDate { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Display(Name = "Confirm your email address")]
        [Required]
        [EmailAddress]
        [Compare("EmailAddress")]
        public string ConfirmEmailAddress { get; set; }

        [Display(Name = "# of Powdered Unicorn Horns")]
        [Range(0, 100)]
        public int QuantityPowderedUnicornHorns { get; set; }

        [Display(Name = "# of Essence of Bacon")]
        [Range(0, 100)]
        public int QuantityEsessenceOfBacon { get; set; }

        [Display(Name = "# of Bottled Rainbows")]
        [Range(0, 100)]
        public int QuantityBottledRainbows { get; set; }
    }
}