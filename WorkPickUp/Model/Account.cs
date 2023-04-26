using SampSharp.Entities.SAMP;

namespace WorkPickUp.Model;

public class Account
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int Money { get; set; }

    public int WorkExp { get; set; }

    public int WorkLevel { get; set; }

    public string Password { get; set; }

    public bool IsWork { get; set; }
}
