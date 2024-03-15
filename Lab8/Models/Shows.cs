using System.ComponentModel.DataAnnotations;

namespace Lab8.Models
{
    public class Shows
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public string Episode { get; set; }

        public string Season { get; set; }

        public int Length { get; set; }

        public string Rating {  get; set; } 

    }
}
