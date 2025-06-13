using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolos2.Models;


public class SeedllingBatch
{
    [Key]
    public int BatchId { get; set; }
    
    [Required]
    public int NurseryId { get; set; }
    
    [Required]
    public int SpeciesId { get; set; }
    
    [Required]
    public int Quantity { get; set; }
    
    [Required]
    public DateTime SownDate { get; set; }
    
    public DateTime? ReadyDate { get; set; }
    
    [ForeignKey(nameof(NurseryId))]
    public Nursery Nursery { get; set; }
    
    [ForeignKey(nameof(SpeciesId))]
    public TreeSpecies Species { get; set; }
    
    public ICollection<Responsible> Responsibles { get; set; }
}