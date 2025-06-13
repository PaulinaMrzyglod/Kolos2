using System.ComponentModel.DataAnnotations;

namespace Kolos2.Models;

public class Nursery
{
    [Key]
    public int NurseryID { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    
    [Required]
    public DateTime EstablishedDate { get; set; }
    
    public ICollection<SeedllingBatch> SeedllingBatches { get; set; }
}