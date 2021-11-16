using System.ComponentModel.DataAnnotations;

namespace WebAppAspNetMvcExportExcel.Models
{
    public enum Gender
    {
        [Display(Name = "Женский")]
        Female = 1,

        [Display(Name = "Мужской")]
        Male = 2,
    }
}