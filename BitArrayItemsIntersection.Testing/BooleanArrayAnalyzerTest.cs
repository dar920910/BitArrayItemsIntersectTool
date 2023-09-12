using BitArrayItemsIntersection.Library;

namespace BitArrayItemsIntersection.Testing;

public class BooleanArrayAnalyzerTest
{
    [Test]
    public void CanTryToMakeRouteBetweenArrayElements_FromTrueToTrue()
    {
        CustomBooleanArray array = new(new int[,]
        {
            { 1, 0, 0, 0, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 0, 1, 0, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 0, 0, 0, 1 }
        });

        (byte Row, byte Col) source = (0, 0);
        (byte Row, byte Col) target = (4, 4);

        bool actualResult = new BooleanArrayAnalyzer(array)
            .CanTryToMakeRouteBetweenArrayElements(
                from: source, to: target);

        Assert.That(actualResult, Is.True);
    }

    [Test]
    public void CanTryToMakeRouteBetweenArrayElements_FromFalseToFalse()
    {
        CustomBooleanArray array = new(new int[,]
        {
            { 1, 0, 0, 0, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 0, 1, 0, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 0, 0, 0, 1 }
        });

        (byte Row, byte Col) source = (0, 2);
        (byte Row, byte Col) target = (4, 2);

        bool actualResult = new BooleanArrayAnalyzer(array)
            .CanTryToMakeRouteBetweenArrayElements(
                from: source, to: target);

        Assert.That(actualResult, Is.True);
    }

    [Test]
    public void CanTryToMakeRouteBetweenArrayElements_FromTrueToFalse()
    {
        CustomBooleanArray array = new(new int[,]
        {
            { 1, 0, 0, 0, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 0, 1, 0, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 0, 0, 0, 1 }
        });

        Assert.Multiple(() =>
        {
            Assert.That(actual: new BooleanArrayAnalyzer(array)
                .CanTryToMakeRouteBetweenArrayElements(from: (2, 2), to: (0, 2)), expression: Is.False);

            Assert.That(actual: new BooleanArrayAnalyzer(array)
                .CanTryToMakeRouteBetweenArrayElements(from: (2, 2), to: (4, 2)), expression: Is.False);

            Assert.That(actual: new BooleanArrayAnalyzer(array)
                .CanTryToMakeRouteBetweenArrayElements(from: (2, 2), to: (2, 1)), expression: Is.False);

            Assert.That(actual: new BooleanArrayAnalyzer(array)
                .CanTryToMakeRouteBetweenArrayElements(from: (2, 2), to: (2, 3)), expression: Is.False);
        });
    }

    [Test]
    public void CanTryToMakeRouteBetweenArrayElements_FromFalseToTrue()
    {
        CustomBooleanArray array = new(new int[,]
        {
            { 1, 0, 0, 0, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 0, 1, 0, 1 },
            { 1, 1, 0, 1, 1 },
            { 1, 0, 0, 0, 1 }
        });

        Assert.Multiple(() =>
        {
            Assert.That(actual: new BooleanArrayAnalyzer(array)
                .CanTryToMakeRouteBetweenArrayElements(from: (0, 2), to: (2, 2)), expression: Is.False);

            Assert.That(actual: new BooleanArrayAnalyzer(array)
                .CanTryToMakeRouteBetweenArrayElements(from: (0, 2), to: (2, 0)), expression: Is.False);

            Assert.That(actual: new BooleanArrayAnalyzer(array)
                .CanTryToMakeRouteBetweenArrayElements(from: (0, 2), to: (2, 4)), expression: Is.False);

            Assert.That(actual: new BooleanArrayAnalyzer(array)
                .CanTryToMakeRouteBetweenArrayElements(from: (4, 2), to: (2, 2)), expression: Is.False);

            Assert.That(actual: new BooleanArrayAnalyzer(array)
                .CanTryToMakeRouteBetweenArrayElements(from: (4, 2), to: (2, 0)), expression: Is.False);

            Assert.That(actual: new BooleanArrayAnalyzer(array)
                .CanTryToMakeRouteBetweenArrayElements(from: (4, 2), to: (2, 4)), expression: Is.False);
        });
    }
}
