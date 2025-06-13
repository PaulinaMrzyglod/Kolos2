using System.ComponentModel.DataAnnotations;

namespace Kolos2.Models;

public class Employee
{
    [Key]
    public int EmployeeId { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    
    [Required]
    public DateTime HireDate { get; set; }
    
    public ICollection<Responsible> Responsibles { get; set; }
}