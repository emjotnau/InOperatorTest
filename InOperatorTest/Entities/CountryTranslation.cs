using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Ewl.Platform.Geo.Storage.Entities
{
    public class CountryTranslation 
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Country")]
        public Guid CountryId { get; set; }
       
        public string Name { get; set; } = null!;    
    }
}
