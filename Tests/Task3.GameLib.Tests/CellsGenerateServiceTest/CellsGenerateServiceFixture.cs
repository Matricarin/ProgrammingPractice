using Moq;
using Tasks.Task3.GameLib;
using Tasks.Task3.GameLib.Services;

namespace Task3.GameLib.Tests.CellsGenerateServiceTest;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class CellsGenerateServiceFixture
{
    private readonly CellsGenerateService _service;
    private Mock<FieldInitialSettings> _settings;

    public CellsGenerateServiceFixture()
    {
        _settings = new Mock<FieldInitialSettings>();

        _settings.SetupGet(m => m.MinesAmount).Returns(4);
        _settings.SetupGet(m => m.Rows).Returns(6);
        _settings.SetupGet(m => m.Columns).Returns(6);
        
        _service = new CellsGenerateService();
    }

    public void GenerateMinesTest()
    {
        
    }

    public void GenerateNumbersTest()
    {
        
    }

    public void GenerateEmptyCellsTest()
    {
        
    }
}