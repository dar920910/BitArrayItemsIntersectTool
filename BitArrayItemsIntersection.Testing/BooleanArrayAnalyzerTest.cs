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


    [Test]
    public void GetStraightDirectionFromSourceToTarget_WhenNone()
    {
        Assert.That(
            actual: new BooleanArrayAnalyzer(new CustomBooleanArray(new int[,]
            {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            })).GetStraightDirectionFromSourceToTarget(
                from: (Row: 2, Col: 2), to: (Row: 2, Col: 2)),
            expression: Is.EqualTo(RouteBuildDirection.None)
        );
    }

    [Test]
    public void GetStraightDirectionFromSourceToTarget_WhenTop()
    {
        Assert.That(
            actual: new BooleanArrayAnalyzer(new CustomBooleanArray(new int[,]
            {
                { 0, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            })).GetStraightDirectionFromSourceToTarget(
                from: (Row: 2, Col: 2), to: (Row: 0, Col: 2)),
            expression: Is.EqualTo(RouteBuildDirection.Top)
        );
    }

    [Test]
    public void GetStraightDirectionFromSourceToTarget_WhenTopRight()
    {
        Assert.That(
            actual: new BooleanArrayAnalyzer(new CustomBooleanArray(new int[,]
            {
                { 0, 0, 0, 0, 1 },
                { 0, 0, 0, 1, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            })).GetStraightDirectionFromSourceToTarget(
                from: (Row: 2, Col: 2), to: (Row: 0, Col: 4)),
            expression: Is.EqualTo(RouteBuildDirection.TopRight)
        );
    }

    [Test]
    public void GetStraightDirectionFromSourceToTarget_WhenRight()
    {
        Assert.That(
            actual: new BooleanArrayAnalyzer(new CustomBooleanArray(new int[,]
            {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 1, 1, 1 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            })).GetStraightDirectionFromSourceToTarget(
                from: (Row: 2, Col: 2), to: (Row: 2, Col: 4)),
            expression: Is.EqualTo(RouteBuildDirection.Right)
        );
    }

    [Test]
    public void GetStraightDirectionFromSourceToTarget_WhenBottomRight()
    {
        Assert.That(
            actual: new BooleanArrayAnalyzer(new CustomBooleanArray(new int[,]
            {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 0, 1, 0 },
                { 0, 0, 0, 0, 1 }
            })).GetStraightDirectionFromSourceToTarget(
                from: (Row: 2, Col: 2), to: (Row: 4, Col: 4)),
            expression: Is.EqualTo(RouteBuildDirection.BottomRight)
        );
    }

    [Test]
    public void GetStraightDirectionFromSourceToTarget_WhenBottom()
    {
        Assert.That(
            actual: new BooleanArrayAnalyzer(new CustomBooleanArray(new int[,]
            {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 0 }
            })).GetStraightDirectionFromSourceToTarget(
                from: (Row: 2, Col: 2), to: (Row: 4, Col: 2)),
            expression: Is.EqualTo(RouteBuildDirection.Bottom)
        );
    }

    [Test]
    public void GetStraightDirectionFromSourceToTarget_WhenBottomLeft()
    {
        Assert.That(
            actual: new BooleanArrayAnalyzer(new CustomBooleanArray(new int[,]
            {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 1, 0, 0, 0 },
                { 1, 0, 0, 0, 0 }
            })).GetStraightDirectionFromSourceToTarget(
                from: (Row: 2, Col: 2), to: (Row: 4, Col: 0)),
            expression: Is.EqualTo(RouteBuildDirection.BottomLeft)
        );
    }

    [Test]
    public void GetStraightDirectionFromSourceToTarget_WhenLeft()
    {
        Assert.That(
            actual: new BooleanArrayAnalyzer(new CustomBooleanArray(new int[,]
            {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 1, 1, 1, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            })).GetStraightDirectionFromSourceToTarget(
                from: (Row: 2, Col: 2), to: (Row: 2, Col: 0)),
            expression: Is.EqualTo(RouteBuildDirection.Left)
        );
    }

    [Test]
    public void GetStraightDirectionFromSourceToTarget_WhenTopLeft()
    {
        Assert.That(
            actual: new BooleanArrayAnalyzer(new CustomBooleanArray(new int[,]
            {
                { 1, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0 },
                { 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 }
            })).GetStraightDirectionFromSourceToTarget(
                from: (Row: 2, Col: 2), to: (Row: 0, Col: 0)),
            expression: Is.EqualTo(RouteBuildDirection.TopLeft)
        );
    }
}
