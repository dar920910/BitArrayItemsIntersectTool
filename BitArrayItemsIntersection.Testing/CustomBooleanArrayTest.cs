using BitArrayItemsIntersection.Library;

namespace BitArrayItemsIntersection.Testing;

public class CustomBooleanArrayTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestContentByDefault()
    {
        const byte dimensionLength_X = 3;
        const byte dimensionLength_Y = 3;

        bool[,] actualResult = new CustomBooleanArray(
            dimensionLength_X, dimensionLength_Y).Content;

        bool[,] expectedResult = new[,]
        {
            { false, false, false },
            { false, false, false },
            { false, false, false }
        };

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}