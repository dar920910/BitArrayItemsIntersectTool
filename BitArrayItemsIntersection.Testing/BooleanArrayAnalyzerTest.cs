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


    [Test]
    public void GetStraightDirectionFromSourceToTarget_WhenArrayHasMoreColsThanRows()
    {
        CustomBooleanArray array = new(new int[,]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        });

        Assert.Multiple(() =>
        {
            Assert.That(
                actual: new BooleanArrayAnalyzer(array)
                    .GetStraightDirectionFromSourceToTarget(
                        from: (Row: 2, Col: 4), to: (Row: 0, Col: 4)),
                expression: Is.EqualTo(RouteBuildDirection.Top));

            Assert.That(
                actual: new BooleanArrayAnalyzer(array)
                    .GetStraightDirectionFromSourceToTarget(
                    from: (Row: 2, Col: 4), to: (Row: 1, Col: 7)),
                expression: Is.EqualTo(RouteBuildDirection.TopRight));

            Assert.That(
                actual: new BooleanArrayAnalyzer(array)
                    .GetStraightDirectionFromSourceToTarget(
                        from: (Row: 2, Col: 4), to: (Row: 2, Col: 8)),
                expression: Is.EqualTo(RouteBuildDirection.Right));

            Assert.That(
                actual: new BooleanArrayAnalyzer(array)
                .GetStraightDirectionFromSourceToTarget(
                    from: (Row: 2, Col: 4), to: (Row: 3, Col: 6)),
                expression: Is.EqualTo(RouteBuildDirection.BottomRight));

            Assert.That(
                actual: new BooleanArrayAnalyzer(array)
                    .GetStraightDirectionFromSourceToTarget(
                        from: (Row: 2, Col: 4), to: (Row: 4, Col: 4)),
                expression: Is.EqualTo(RouteBuildDirection.Bottom));

            Assert.That(
                actual: new BooleanArrayAnalyzer(array)
                    .GetStraightDirectionFromSourceToTarget(
                        from: (Row: 2, Col: 4), to: (Row: 3, Col: 2)),
                expression: Is.EqualTo(RouteBuildDirection.BottomLeft));

            Assert.That(
                actual: new BooleanArrayAnalyzer(array)
                    .GetStraightDirectionFromSourceToTarget(
                        from: (Row: 2, Col: 4), to: (Row: 2, Col: 0)),
                expression: Is.EqualTo(RouteBuildDirection.Left));

            Assert.That(
                actual: new BooleanArrayAnalyzer(array)
                    .GetStraightDirectionFromSourceToTarget(
                    from: (Row: 2, Col: 4), to: (Row: 1, Col: 1)),
                expression: Is.EqualTo(RouteBuildDirection.TopLeft));
        });
    }

    [Test]
    public void GetStraightDirectionFromSourceToTarget_WhenArrayHasMoreRowsThanCols()
    {
        CustomBooleanArray array = new(new int[,]
        {
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 }
        });

        Assert.Multiple(() =>
        {
            Assert.That(
                actual: new BooleanArrayAnalyzer(array)
                    .GetStraightDirectionFromSourceToTarget(
                        from: (Row: 4, Col: 2), to: (Row: 0, Col: 2)),
                expression: Is.EqualTo(RouteBuildDirection.Top));

            Assert.That(
                actual: new BooleanArrayAnalyzer(array)
                    .GetStraightDirectionFromSourceToTarget(
                    from: (Row: 4, Col: 2), to: (Row: 1, Col: 3)),
                expression: Is.EqualTo(RouteBuildDirection.TopRight));

            Assert.That(
                actual: new BooleanArrayAnalyzer(array)
                    .GetStraightDirectionFromSourceToTarget(
                        from: (Row: 4, Col: 2), to: (Row: 4, Col: 4)),
                expression: Is.EqualTo(RouteBuildDirection.Right));

            Assert.That(
                actual: new BooleanArrayAnalyzer(array)
                .GetStraightDirectionFromSourceToTarget(
                    from: (Row: 4, Col: 2), to: (Row: 7, Col: 3)),
                expression: Is.EqualTo(RouteBuildDirection.BottomRight));

            Assert.That(
                actual: new BooleanArrayAnalyzer(array)
                    .GetStraightDirectionFromSourceToTarget(
                        from: (Row: 4, Col: 2), to: (Row: 8, Col: 2)),
                expression: Is.EqualTo(RouteBuildDirection.Bottom));

            Assert.That(
                actual: new BooleanArrayAnalyzer(array)
                    .GetStraightDirectionFromSourceToTarget(
                        from: (Row: 4, Col: 2), to: (Row: 7, Col: 1)),
                expression: Is.EqualTo(RouteBuildDirection.BottomLeft));

            Assert.That(
                actual: new BooleanArrayAnalyzer(array)
                    .GetStraightDirectionFromSourceToTarget(
                        from: (Row: 4, Col: 2), to: (Row: 4, Col: 0)),
                expression: Is.EqualTo(RouteBuildDirection.Left));

            Assert.That(
                actual: new BooleanArrayAnalyzer(array)
                    .GetStraightDirectionFromSourceToTarget(
                    from: (Row: 4, Col: 2), to: (Row: 1, Col: 1)),
                expression: Is.EqualTo(RouteBuildDirection.TopLeft));
        });
    }


    [Test]
    public void ConfigureRouteBuildRule_FromTopLeftToBottomRight()
    {
        CustomBooleanArray array = new(new int[,]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        });

        (byte Row, byte Col) routeSource = (1, 1);
        (byte Row, byte Col) routeTarget = (4, 8);

        RouteBuildRule actualResult = new BooleanArrayAnalyzer(array)
            .ConfigureRouteBuildRule(from: routeSource, to: routeTarget);

        RouteBuildRule expectedResult = new()
        {
            Priority_1 = RouteBuildDirection.BottomRight,
            Priority_2 = RouteBuildDirection.Right,
            Priority_3 = RouteBuildDirection.Bottom,
            Priority_4 = RouteBuildDirection.TopRight,
            Priority_5 = RouteBuildDirection.BottomLeft,
            Priority_6 = RouteBuildDirection.Left,
            Priority_7 = RouteBuildDirection.Top,
            Priority_8 = RouteBuildDirection.TopLeft
        };

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void ConfigureRouteBuildRule_FromBottomLeftToTopRight()
    {
        CustomBooleanArray array = new(new int[,]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        });

        (byte Row, byte Col) routeSource = (3, 1);
        (byte Row, byte Col) routeTarget = (1, 8);

        RouteBuildRule actualResult = new BooleanArrayAnalyzer(array)
            .ConfigureRouteBuildRule(from: routeSource, to: routeTarget);

        RouteBuildRule expectedResult = new()
        {
            Priority_1 = RouteBuildDirection.TopRight,
            Priority_2 = RouteBuildDirection.Right,
            Priority_3 = RouteBuildDirection.Top,
            Priority_4 = RouteBuildDirection.BottomRight,
            Priority_5 = RouteBuildDirection.TopLeft,
            Priority_6 = RouteBuildDirection.Left,
            Priority_7 = RouteBuildDirection.Bottom,
            Priority_8 = RouteBuildDirection.BottomLeft
        };

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void ConfigureRouteBuildRule_FromTopRightToBottomLeft()
    {
        CustomBooleanArray array = new(new int[,]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        });

        (byte Row, byte Col) routeSource = (1, 8);
        (byte Row, byte Col) routeTarget = (3, 1);

        RouteBuildRule actualResult = new BooleanArrayAnalyzer(array)
            .ConfigureRouteBuildRule(from: routeSource, to: routeTarget);

        RouteBuildRule expectedResult = new()
        {
            Priority_1 = RouteBuildDirection.BottomLeft,
            Priority_2 = RouteBuildDirection.Left,
            Priority_3 = RouteBuildDirection.Bottom,
            Priority_4 = RouteBuildDirection.TopLeft,
            Priority_5 = RouteBuildDirection.BottomRight,
            Priority_6 = RouteBuildDirection.TopLeft,
            Priority_7 = RouteBuildDirection.Top,
            Priority_8 = RouteBuildDirection.TopRight
        };

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void ConfigureRouteBuildRule_FromBottomRightToTopLeft()
    {
        CustomBooleanArray array = new(new int[,]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        });

        (byte Row, byte Col) routeSource = (3, 8);
        (byte Row, byte Col) routeTarget = (1, 1);

        RouteBuildRule actualResult = new BooleanArrayAnalyzer(array)
            .ConfigureRouteBuildRule(from: routeSource, to: routeTarget);

        RouteBuildRule expectedResult = new()
        {
            Priority_1 = RouteBuildDirection.TopLeft,
            Priority_2 = RouteBuildDirection.Left,
            Priority_3 = RouteBuildDirection.Top,
            Priority_4 = RouteBuildDirection.TopRight,
            Priority_5 = RouteBuildDirection.BottomLeft,
            Priority_6 = RouteBuildDirection.Right,
            Priority_7 = RouteBuildDirection.Bottom,
            Priority_8 = RouteBuildDirection.BottomRight
        };

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void ConfigureRouteBuildRule_FromTopToBottom()
    {
        CustomBooleanArray array = new(new int[,]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        });

        (byte Row, byte Col) routeSource = (1, 5);
        (byte Row, byte Col) routeTarget = (4, 5);

        RouteBuildRule actualResult = new BooleanArrayAnalyzer(array)
            .ConfigureRouteBuildRule(from: routeSource, to: routeTarget);

        RouteBuildRule expectedResult = new()
        {
            Priority_1 = RouteBuildDirection.Bottom,
            Priority_2 = RouteBuildDirection.BottomRight,
            Priority_3 = RouteBuildDirection.BottomLeft,
            Priority_4 = RouteBuildDirection.Right,
            Priority_5 = RouteBuildDirection.Left,
            Priority_6 = RouteBuildDirection.Top,
            Priority_7 = RouteBuildDirection.TopRight,
            Priority_8 = RouteBuildDirection.TopLeft
        };

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void ConfigureRouteBuildRule_FromBottomToTop()
    {
        CustomBooleanArray array = new(new int[,]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        });

        (byte Row, byte Col) routeSource = (3, 5);
        (byte Row, byte Col) routeTarget = (0, 5);

        RouteBuildRule actualResult = new BooleanArrayAnalyzer(array)
            .ConfigureRouteBuildRule(from: routeSource, to: routeTarget);

        RouteBuildRule expectedResult = new()
        {
            Priority_1 = RouteBuildDirection.Top,
            Priority_2 = RouteBuildDirection.TopRight,
            Priority_3 = RouteBuildDirection.TopLeft,
            Priority_4 = RouteBuildDirection.Right,
            Priority_5 = RouteBuildDirection.Left,
            Priority_6 = RouteBuildDirection.Bottom,
            Priority_7 = RouteBuildDirection.BottomRight,
            Priority_8 = RouteBuildDirection.BottomLeft
        };

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void ConfigureRouteBuildRule_FromLeftToRight()
    {
        CustomBooleanArray array = new(new int[,]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        });

        (byte Row, byte Col) routeSource = (2, 1);
        (byte Row, byte Col) routeTarget = (2, 8);

        RouteBuildRule actualResult = new BooleanArrayAnalyzer(array)
            .ConfigureRouteBuildRule(from: routeSource, to: routeTarget);

        RouteBuildRule expectedResult = new()
        {
            Priority_1 = RouteBuildDirection.Right,
            Priority_2 = RouteBuildDirection.BottomRight,
            Priority_3 = RouteBuildDirection.TopRight,
            Priority_4 = RouteBuildDirection.Bottom,
            Priority_5 = RouteBuildDirection.Top,
            Priority_6 = RouteBuildDirection.Left,
            Priority_7 = RouteBuildDirection.BottomLeft,
            Priority_8 = RouteBuildDirection.TopLeft
        };

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void ConfigureRouteBuildRule_FromRightToLeft()
    {
        CustomBooleanArray array = new(new int[,]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        });

        (byte Row, byte Col) routeSource = (2, 8);
        (byte Row, byte Col) routeTarget = (2, 1);

        RouteBuildRule actualResult = new BooleanArrayAnalyzer(array)
            .ConfigureRouteBuildRule(from: routeSource, to: routeTarget);

        RouteBuildRule expectedResult = new()
        {
            Priority_1 = RouteBuildDirection.Left,
            Priority_2 = RouteBuildDirection.BottomLeft,
            Priority_3 = RouteBuildDirection.TopLeft,
            Priority_4 = RouteBuildDirection.Bottom,
            Priority_5 = RouteBuildDirection.Top,
            Priority_6 = RouteBuildDirection.Right,
            Priority_7 = RouteBuildDirection.BottomRight,
            Priority_8 = RouteBuildDirection.TopRight
        };

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
