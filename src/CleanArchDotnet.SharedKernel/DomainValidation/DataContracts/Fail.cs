namespace CleanArchDotnet.SharedKernel.DomainValidation.DataContracts;

public class Fail
{
    public string Description { get; }
    public string Field { get; }
    public FailType Type { get; }
    
    private Fail(
        string description,
        string field,
        FailType type    
    )
    {
        Description = description;
        Field = field;
        Type = type;
    }

    public static Fail NotFound(string description = "Not Found") => 
        new(description, "Default", FailType.NotFound);

    public static Fail FailValidation(string description, string field) =>
        new(description, field, FailType.FailValidation);
}