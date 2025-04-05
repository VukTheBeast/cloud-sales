namespace Crayon.TechExercise.CloudSales.Domain;

public class PurchasedSoftware
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public SoftwareState State { get; set; }
    public DateTime ValidTo { get; set; }

    public bool CanExtendLicense(DateTime newDate) 
    {
        return newDate > ValidTo;
    }

    public void ExtendLicense(DateTime newDate)
    {
        if (newDate < ValidTo) 
        {
            throw new ArgumentException("Can not extend license, new date should be greater then old license date");
        }
        
        ValidTo = newDate;
    }
}

public enum SoftwareState
{
    Uknown = 0,
    Active = 1,
    Suspended = 2,
    Canceled = 3,
}