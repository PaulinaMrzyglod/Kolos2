namespace Kolos2.DTOs;

public class AddTreesDTO
{
    public int quantity { get; set; }
    public string species { get; set; }
    public string nursery { get; set; }
    public List<ResponsibleRequestDTO> responsible { get; set; }
}

public class ResponsibleRequestDTO
{
    public int employeeId { get; set; }
    public string role { get; set; }
}