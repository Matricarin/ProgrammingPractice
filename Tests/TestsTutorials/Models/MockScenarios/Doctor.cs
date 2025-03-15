namespace TestsTutorials.Models.MockScenarios;

public sealed class Doctor
{
    public int TimesCured { get; set; }
    public Doctor(ICitizen citizen)
    {
        citizen.FallsIll += (sender, args) =>
        {
            this.TimesCured++;
        };
    }
}