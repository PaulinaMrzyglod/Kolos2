namespace Kolos2.DTOs;

public class NurseriesDTO
{
    public int nurseryId { get; set; }
    public string name { get; set; }
    public DateTime establishedDate { get; set; }
    public List<BatchDTO> batches { get; set; }
}

public class BatchDTO
{
    public int batchId { get; set; }
    public int quantity { get; set; }
    public DateTime sownDate { get; set; }
    public DateTime? readyDate { get; set; }
    public SpeciesDTO species { get; set; }
    public List<ResponsibleDTO> responsibles { get; set; }
}

public class SpeciesDTO
{
    public string latinName { get; set; }
    public int growthTimeInYears { get; set; }
}

public class ResponsibleDTO
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string role { get; set; }
}