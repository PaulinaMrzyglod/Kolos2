using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolos2.Models;

public class Responsible
{
    [Required]
    public int BatchId { get; set; }
    
    [Required]
    public int EmployeeId { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Role { get; set; }
    
    [ForeignKey(nameof(BatchId))]
    public SeedllingBatch Batch { get; set; }
    
    [ForeignKey(nameof(EmployeeId))]
    public Employee Employee { get; set; }
}