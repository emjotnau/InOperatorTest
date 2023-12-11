using System.ComponentModel.DataAnnotations;

namespace InOperatorTest.Dto
{
    public class CountryListDto
    {
        public Guid Id { get; set; }

        [MaxLength(64)]
        [MinLength(2)]
        [Required]
        public string Name { get; set; } = null!;      
    }
}
