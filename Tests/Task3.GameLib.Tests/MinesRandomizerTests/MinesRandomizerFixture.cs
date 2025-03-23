using Tasks.Task3.GameLib;
using Tasks.Task3.GameLib.Exceptions;
using Tasks.Task3.GameLib.Handlers;

namespace Task3.GameLib.Tests.MinesRandomizerTests;

[TestFixture]
[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public sealed class MinesRandomizerFixture
{
    private readonly MinesRandomizer _randomizer;

    public MinesRandomizerFixture()
    {
        _randomizer = new MinesRandomizer(4, 101);
    }
    
    [TestCaseSource(typeof(MinesRandomizerTestData), nameof(MinesRandomizerTestData.FieldSettings))]
    public void GenerateRandomMinesTestMinesAmount(FieldInitialSettings settings)
    {
        var mines = _randomizer.GenerateRandomMines(settings);
        
        Assert.Multiple(() =>
        {
            Assert.NotNull(mines);
            Assert.That(mines.Count, Is.EqualTo(settings.MinesAmount));
        });
    }
    
    [TestCaseSource(typeof(MinesRandomizerTestData), nameof(MinesRandomizerTestData.FieldSettings))]
    public void GenerateRandomMinesTestCellsCoordinates(FieldInitialSettings settings)
    {
        var mines = _randomizer.GenerateRandomMines(settings);
        
        Assert.Multiple(() =>
        {
            foreach (var mine in mines)
            {
                Assert.That(mine.X, Is.LessThan(settings.Rows));
                Assert.That(mine.X, Is.GreaterThanOrEqualTo(0));
                
                Assert.That(mine.Y, Is.LessThan(settings.Columns));
                Assert.That(mine.Y, Is.GreaterThanOrEqualTo(0));
            }
        });
    }
    
    [TestCaseSource(typeof(MinesRandomizerTestData), nameof(MinesRandomizerTestData.FieldExceptions))]
    public void GenerateRandomMinesTestExceptions(FieldInitialSettings settings)
    {
        Assert.Catch<GenerateMinesException>(() =>
        {
            _randomizer.GenerateRandomMines(settings);
        });
    }
}