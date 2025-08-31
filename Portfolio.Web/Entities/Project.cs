using System.ComponentModel.DataAnnotations;

namespace Portfolio.Web.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }

        [MinLength(5,ErrorMessage = "Proje Adı en az 5 karakter olmalıdır.")]
        [MaxLength(50,ErrorMessage = "Proje Adı en az 50 karakter olmalıdır.")]
        [Required(ErrorMessage = "Proje adı boş geçilemez.")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Proje açıklaması boş bırakılamaz.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Proje görsel boş bırakılamaz.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Github Url boş geçilemez.")]
        public string GithubUrl { get; set; }

        //navigation property

        [Required(ErrorMessage = "Category Id boş geçilemez.")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
