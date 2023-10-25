using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoWebApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30,ErrorMessage ="Category Name is Need Only 30 Words!")]
        public string Name { get; set; }
        [Range(1,100,ErrorMessage ="This Value is Between 1 to 100")]
        [DisplayName("Display Orders")]
        public int DisplayOrder { get; set; }
    }
}
