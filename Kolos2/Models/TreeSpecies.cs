using System.ComponentModel.DataAnnotations;

namespace Kolos2.Models;

public class TreeSpecies
{
    [Key]
    public int SpeciesId { get; set; }
    
    [Required]
    [StringLength(100)]
    public string LatinName { get; set; }
    
    [Required]
    public int GrowthTimeInYears { get; set; }
    
    public ICollection<SeedllingBatch> SeedllingBatches { get; set; }
}