using BitArrayItemsIntersection.Library;

namespace BitArrayItemsIntersection.Testing;

public class CustomBooleanArrayTest
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CreateBooleanArray_FilledByDefault_TestCase_1()
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

    [Test]
    public void CreateBooleanArray_FilledByDefault_TestCase_2()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                dimension_X: 4, dimension_Y: 7)
                    .Content,
            expression: Is.EqualTo(new bool[,]
                {
                    { false, false, false, false },
                    { false, false, false, false },
                    { false, false, false, false },
                    { false, false, false, false },
                    { false, false, false, false },
                    { false, false, false, false },
                    { false, false, false, false }
                }
            )
        );
    }

    [Test]
    public void CreateBooleanArray_FilledByDefault_TestCase_3()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                dimension_X: 7, dimension_Y: 4)
                    .Content,
            expression: Is.EqualTo(new bool[,]
                {
                    { false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false },
                    { false, false, false, false, false, false, false }
                }
            )
        );
    }

    [Test]
    public void CreateBooleanArray_FilledTrueValue_TestCase_1()
    {
        Assert.That(
            new CustomBooleanArray(
                dimension_X: 3,
                dimension_Y: 3,
                elementPlaceholderValue: true
            ).Content,
            Is.EqualTo(
                new[,]
                {
                    { true, true, true },
                    { true, true, true },
                    { true, true, true }
                }
            )
        );
    }

    [Test]
    public void CreateBooleanArray_FilledTrueValue_TestCase_2()
    {
        Assert.That(
            new CustomBooleanArray(
                dimension_X: 6,
                dimension_Y: 3,
                elementPlaceholderValue: true
            ).Content,
            Is.EqualTo(
                new[,]
                {
                    { true, true, true, true, true, true },
                    { true, true, true, true, true, true },
                    { true, true, true, true, true, true }
                }
            )
        );
    }

    [Test]
    public void CreateBooleanArray_FilledTrueValue_TestCase_3()
    {
        Assert.That(
            new CustomBooleanArray(
                dimension_X: 3,
                dimension_Y: 6,
                elementPlaceholderValue: true
            ).Content,
            Is.EqualTo(
                new[,]
                {
                    { true, true, true },
                    { true, true, true },
                    { true, true, true },
                    { true, true, true },
                    { true, true, true },
                    { true, true, true }
                }
            )
        );
    }

    [Test]
    public void CreateBooleanArray_FilledFalseValue_TestCase_1()
    {
        Assert.That(
            new CustomBooleanArray(
                dimension_X: 3,
                dimension_Y: 3,
                elementPlaceholderValue: false
            ).Content,
            Is.EqualTo(
                new[,]
                {
                    { false, false, false },
                    { false, false, false },
                    { false, false, false }
                }
            )
        );
    }

    [Test]
    public void CreateBooleanArray_FilledFalseValue_TestCase_2()
    {
        Assert.That(
            new CustomBooleanArray(
                dimension_X: 6,
                dimension_Y: 3,
                elementPlaceholderValue: false
            ).Content,
            Is.EqualTo(
                new[,]
                {
                    { false, false, false, false, false, false },
                    { false, false, false, false, false, false },
                    { false, false, false, false, false, false }
                }
            )
        );
    }

    [Test]
    public void CreateBooleanArray_FilledFalseValue_TestCase_3()
    {
        Assert.That(
            new CustomBooleanArray(
                dimension_X: 3,
                dimension_Y: 6,
                elementPlaceholderValue: false
            ).Content,
            Is.EqualTo(
                new[,]
                {
                    { false, false, false },
                    { false, false, false },
                    { false, false, false },
                    { false, false, false },
                    { false, false, false },
                    { false, false, false }
                }
            )
        );
    }


    [Test]
    public void TestArrayLengthX_TestCase_1()
    {
        Assert.That(
            new CustomBooleanArray(
                dimension_X: 5,
                dimension_Y: 2
            ).Length_X,
            Is.EqualTo(5)
        );
    }

    [Test]
    public void TestArrayLengthX_TestCase_2()
    {
        Assert.That(
            new CustomBooleanArray(
                dimension_X: 3,
                dimension_Y: 7
            ).Length_X,
            Is.EqualTo(3)
        );
    }

    [Test]
    public void TestArrayLengthY_TestCase_1()
    {
        Assert.That(
            new CustomBooleanArray(
                dimension_X: 5,
                dimension_Y: 2
            ).Length_Y,
            Is.EqualTo(2)
        );
    }

    [Test]
    public void TestArrayLengthY_TestCase_2()
    {
        Assert.That(
            new CustomBooleanArray(
                dimension_X: 3,
                dimension_Y: 7
            ).Length_Y,
            Is.EqualTo(7)
        );
    }


    [Test]
    public void Content_Initialization_ViaUserDefinedArray_TestCase_1()
    {
        bool[,] array = new[,]
        {
            { false, false, false },
            { false, false, false },
            { false, false, false },
            { false, false, false },
            { false, false, false },
            { false, false, false }
        };

        Assert.That(
            actual: new CustomBooleanArray(array).Content,
            expression: Is.EqualTo(array)
        );
    }

    [Test]
    public void Content_Initialization_ViaUserDefinedArray_TestCase_2()
    {
        bool[,] array = new[,]
        {
            { false, false, false, false, false },
            { false, false, false, false, false },
            { false, false, false, false, false },
        };

        Assert.That(
            actual: new CustomBooleanArray(array).Content,
            expression: Is.EqualTo(array)
        );
    }


    [Test]
    public void LengthX_Initialization_ViaUserDefinedArray_TestCase_1()
    {
        Assert.That(
            actual: new CustomBooleanArray(new[,]
                {
                    { false, false, false },
                    { false, false, false },
                    { false, false, false },
                    { false, false, false },
                    { false, false, false },
                    { false, false, false }
                }).Length_X,
            expression: Is.EqualTo(3)
        );
    }

    [Test]
    public void LengthX_Initialization_ViaUserDefinedArray_TestCase_2()
    {
        Assert.That(
            actual: new CustomBooleanArray(new[,]
                {
                    { false, false, false, false, false },
                    { false, false, false, false, false },
                    { false, false, false, false, false },
                }).Length_X,
            expression: Is.EqualTo(5)
        );
    }

    [Test]
    public void LengthY_Initialization_ViaUserDefinedArray_TestCase_1()
    {
        Assert.That(
            actual: new CustomBooleanArray(new[,]
                {
                    { false, false, false },
                    { false, false, false },
                    { false, false, false },
                    { false, false, false },
                    { false, false, false },
                    { false, false, false }
                }).Length_Y,
            expression: Is.EqualTo(6)
        );
    }

    [Test]
    public void LengthXInitializationViaUserDefinedArray_TestCase_2()
    {
        Assert.That(
            actual: new CustomBooleanArray(new[,]
                {
                    { false, false, false, false, false },
                    { false, false, false, false, false },
                    { false, false, false, false, false },
                }).Length_Y,
            expression: Is.EqualTo(3)
        );
    }
}