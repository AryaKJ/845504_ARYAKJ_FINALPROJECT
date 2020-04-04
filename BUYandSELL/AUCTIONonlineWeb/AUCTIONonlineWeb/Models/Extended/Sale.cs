using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace AUCTIONonlineWeb.Models
{
    [MetadataType(typeof(SaleMetadata))]
    public partial class Sale
    {
        public HttpPostedFileBase ImageFile { get; set; }
    }
    public class SaleMetadata
    {
        [Display(Name = "Product Name")]

        [Required(AllowEmptyStrings = false, ErrorMessage = "Required Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Product Description")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        public string ProductDiscription { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        public string Category { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [Display(Name = "Base Amount")]
        public float InitialAmount { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        [Display(Name = "Sale Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SaleDate { get; set; }

        [Display(Name = "Upload Image")]
        public string Image { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

    }
}

