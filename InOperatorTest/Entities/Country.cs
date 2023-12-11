
using System.ComponentModel.DataAnnotations;



namespace Ewl.Platform.Geo.Storage.Entities;


public class Country
{
    [Key]
    public Guid Id { get; set; }
    public ICollection<CountryTranslation> Translations { get; set; } = null!;
}
