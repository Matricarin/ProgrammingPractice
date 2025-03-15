namespace TestsTutorials.Models.MockScenarios;

public interface ICitizen
{
    event EventHandler FallsIll;
    void CallTheHospital();
}