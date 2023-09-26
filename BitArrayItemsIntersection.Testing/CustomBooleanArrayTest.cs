//-----------------------------------------------------------------------
// <copyright file="CustomBooleanArrayTest.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented
#pragma warning disable SA1413 // UseTrailingCommasInMultiLineInitializers
#pragma warning disable SA1009 // ClosingParenthesisMustBeSpacedCorrectly
#pragma warning disable SA1110 // OpeningParenthesisMustBeOnDeclarationLine
#pragma warning disable SA1111 // ClosingParenthesisMustBeOnLineOfLastParameter
#pragma warning disable SA1117 // ParametersMustBeOnSameLineOrSeparateLines

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
        bool[,] actualResult = new CustomBooleanArray(
            rowsDimension: 3,
            columnsDimension: 3
        ).Content;

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
                rowsDimension: 7,
                columnsDimension: 4
            ).Content,
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
                rowsDimension: 4,
                columnsDimension: 7)
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
                rowsDimension: 3,
                columnsDimension: 3,
                hasChargedElements: true
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
                rowsDimension: 3,
                columnsDimension: 6,
                hasChargedElements: true
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
                rowsDimension: 6,
                columnsDimension: 3,
                hasChargedElements: true
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
                rowsDimension: 3,
                columnsDimension: 3,
                hasChargedElements: false
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
                rowsDimension: 3,
                columnsDimension: 6,
                hasChargedElements: false
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
                rowsDimension: 6,
                columnsDimension: 3,
                hasChargedElements: false
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
    public void TestArrayColumns_TestCase_1()
    {
        Assert.That(
            new CustomBooleanArray(
                rowsDimension: 5,
                columnsDimension: 2
            ).CountOfColumns,
            Is.EqualTo(2)
        );
    }

    [Test]
    public void TestArrayColumns_TestCase_2()
    {
        Assert.That(
            new CustomBooleanArray(
                rowsDimension: 7,
                columnsDimension: 3
            ).CountOfColumns,
            Is.EqualTo(3)
        );
    }

    [Test]
    public void TestArrayRows_TestCase_1()
    {
        Assert.That(
            new CustomBooleanArray(
                rowsDimension: 5,
                columnsDimension: 2
            ).CountOfRows,
            Is.EqualTo(5)
        );
    }

    [Test]
    public void TestArrayRows_TestCase_2()
    {
        Assert.That(
            new CustomBooleanArray(
                rowsDimension: 7,
                columnsDimension: 3
            ).CountOfRows,
            Is.EqualTo(7)
        );
    }

    [Test]
    public void ContentInitialization_ViaUserDefinedArray_TestCase_1()
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
    public void ContentInitialization_ViaUserDefinedArray_TestCase_2()
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
    public void ColumnsInitialization_ViaUserDefinedArray_TestCase_1()
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
                }).CountOfColumns,
            expression: Is.EqualTo(3)
        );
    }

    [Test]
    public void ColumnsInitialization_ViaUserDefinedArray_TestCase_2()
    {
        Assert.That(
            actual: new CustomBooleanArray(new[,]
                {
                    { false, false, false, false, false },
                    { false, false, false, false, false },
                    { false, false, false, false, false },
                }).CountOfColumns,
            expression: Is.EqualTo(5)
        );
    }

    [Test]
    public void RowsInitialization_ViaUserDefinedArray_TestCase_1()
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
                }).CountOfRows,
            expression: Is.EqualTo(6)
        );
    }

    [Test]
    public void RowsInitializationViaUserDefinedArray_TestCase_2()
    {
        Assert.That(
            actual: new CustomBooleanArray(new[,]
                {
                    { false, false, false, false, false },
                    { false, false, false, false, false },
                    { false, false, false, false, false },
                }).CountOfRows,
            expression: Is.EqualTo(3)
        );
    }

    [Test]
    public void CreateBooleanArray_FromIntegerArray_TestCase_1()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 1, 0, 0, 0, 1 },
                    { 0, 1, 0, 1, 0 },
                    { 0, 0, 1, 0, 0 },
                    { 0, 1, 0, 1, 0 },
                    { 1, 0, 0, 0, 1 }
                }
            ).Content,
            expression: Is.EqualTo(
                new bool[,]
                {
                    { true, false, false, false, true },
                    { false, true, false, true, false },
                    { false, false, true, false, false },
                    { false, true, false, true, false },
                    { true, false, false, false, true }
                }
            )
        );
    }

    [Test]
    public void CreateBooleanArray_FromIntegerArray_TestCase_2()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 0, 1, 1, 1, 0 },
                    { 1, 0, 1, 0, 1 },
                    { 1, 1, 0, 1, 1 },
                    { 1, 0, 1, 0, 1 },
                    { 0, 1, 1, 1, 0 }
                }
            ).Content,
            expression: Is.EqualTo(
                new bool[,]
                {
                    { false, true, true, true, false },
                    { true, false, true, false, true },
                    { true, true, false, true, true },
                    { true, false, true, false, true },
                    { false, true, true, true, false }
                }
            )
        );
    }

    [Test]
    public void FindAllChargedElements_TestCase_1()
    {
        Assert.That(
            actual: new CustomBooleanArray(new int[,]
                {
                    { 1, 0, 1 },
                    { 0, 1, 0 },
                    { 1, 0, 1 }
                }
            ).FindAllChargedElements(),
            expression: Is.EqualTo(
                new List<BooleanElementInfo>()
                {
                    new (row: 0, column: 0, charged: true),
                    new (row: 0, column: 2, charged: true),
                    new (row: 1, column: 1, charged: true),
                    new (row: 2, column: 0, charged: true),
                    new (row: 2, column: 2, charged: true)
                }
            )
        );
    }

    [Test]
    public void FindAllChargedElements_TestCase_2()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 0, 1, 0 },
                    { 1, 0, 1 },
                    { 0, 1, 0 }
                }
            ).FindAllChargedElements(),
            expression: Is.EqualTo(
                new List<BooleanElementInfo>()
                {
                    new (row: 0, column: 1, charged: true),
                    new (row: 1, column: 0, charged: true),
                    new (row: 1, column: 2, charged: true),
                    new (row: 2, column: 1, charged: true)
                }
            )
        );
    }

    [Test]
    public void FindAllNonChargedElements_TestCase_1()
    {
        Assert.That(
            actual: new CustomBooleanArray(new int[,]
                {
                    { 1, 0, 1 },
                    { 0, 1, 0 },
                    { 1, 0, 1 }
                }
            ).FindAllNonChargedElements(),
            expression: Is.EqualTo(
                new List<BooleanElementInfo>()
                {
                    new (row: 0, column: 1),
                    new (row: 1, column: 0),
                    new (row: 1, column: 2),
                    new (row: 2, column: 1)
                }
            )
        );
    }

    [Test]
    public void FindAllNonChargedElements_TestCase_2()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 0, 1, 0 },
                    { 1, 0, 1 },
                    { 0, 1, 0 }
                }
            ).FindAllNonChargedElements(),
            expression: Is.EqualTo(
                new List<BooleanElementInfo>()
                {
                    new (row: 0, column: 0),
                    new (row: 0, column: 2),
                    new (row: 1, column: 1),
                    new (row: 2, column: 0),
                    new (row: 2, column: 2)
                }
            )
        );
    }

    [Test]
    public void FindNeighbourElements_TopBound_TestCase()
    {
        Assert.That(
            actual: new CustomBooleanArray(new int[,]
                {
                    { 0, 1, 0 },
                    { 0, 0, 0 },
                    { 0, 0, 0 }
                }
            ).FindNeighbourElementsAt(
                elementRow: 0, elementColumn: 1),
            expression: Is.EqualTo(
                new List<BooleanElementInfo>()
                {
                    new (row: 0, column: 2),
                    new (row: 1, column: 2),
                    new (row: 1, column: 1),
                    new (row: 1, column: 0),
                    new (row: 0, column: 0)
                }
            )
        );
    }

    [Test]
    public void FindNeighbourElements_TopRightBound_TestCase()
    {
        Assert.That(
            actual: new CustomBooleanArray(new int[,]
                {
                    { 0, 0, 1 },
                    { 0, 0, 0 },
                    { 0, 0, 0 }
                }
            ).FindNeighbourElementsAt(
                elementRow: 0, elementColumn: 2),
            expression: Is.EqualTo(
                new List<BooleanElementInfo>()
                {
                    new (row: 1, column: 2),
                    new (row: 1, column: 1),
                    new (row: 0, column: 1)
                }
            )
        );
    }

    [Test]
    public void FindNeighbourElements_RightBound_TestCase()
    {
        Assert.That(
            actual: new CustomBooleanArray(new int[,]
                {
                    { 0, 0, 0 },
                    { 0, 0, 1 },
                    { 0, 0, 0 }
                }
            ).FindNeighbourElementsAt(
                elementRow: 1, elementColumn: 2),
            expression: Is.EqualTo(
                new List<BooleanElementInfo>()
                {
                    new (row: 0, column: 2),
                    new (row: 2, column: 2),
                    new (row: 2, column: 1),
                    new (row: 1, column: 1),
                    new (row: 0, column: 1)
                }
            )
        );
    }

    [Test]
    public void FindNeighbourElements_BottomRightBound_TestCase()
    {
        Assert.That(
            actual: new CustomBooleanArray(new int[,]
                {
                    { 0, 0, 0 },
                    { 0, 0, 0 },
                    { 0, 0, 1 }
                }
            ).FindNeighbourElementsAt(
                elementRow: 2, elementColumn: 2),
            expression: Is.EqualTo(
                new List<BooleanElementInfo>()
                {
                    new (row: 1, column: 2),
                    new (row: 2, column: 1),
                    new (row: 1, column: 1)
                }
            )
        );
    }

    [Test]
    public void FindNeighbourElements_BottomBound_TestCase()
    {
        Assert.That(
            actual: new CustomBooleanArray(new int[,]
                {
                    { 0, 0, 0 },
                    { 0, 0, 0 },
                    { 0, 1, 0 }
                }
            ).FindNeighbourElementsAt(
                elementRow: 2, elementColumn: 1),
            expression: Is.EqualTo(
                new List<BooleanElementInfo>()
                {
                    new (row: 1, column: 1),
                    new (row: 1, column: 2),
                    new (row: 2, column: 2),
                    new (row: 2, column: 0),
                    new (row: 1, column: 0)
                }
            )
        );
    }

    [Test]
    public void FindNeighbourElements_BottomLeftBound_TestCase()
    {
        Assert.That(
            actual: new CustomBooleanArray(new int[,]
                {
                    { 0, 0, 0 },
                    { 0, 0, 0 },
                    { 1, 0, 0 }
                }
            ).FindNeighbourElementsAt(
                elementRow: 2, elementColumn: 0),
            expression: Is.EqualTo(
                new List<BooleanElementInfo>()
                {
                    new (row: 1, column: 0),
                    new (row: 1, column: 1),
                    new (row: 2, column: 1)
                }
            )
        );
    }

    [Test]
    public void FindNeighbourElements_LeftBound_TestCase()
    {
        Assert.That(
            actual: new CustomBooleanArray(new int[,]
                {
                    { 0, 0, 0 },
                    { 1, 0, 0 },
                    { 0, 0, 0 }
                }
            ).FindNeighbourElementsAt(
                elementRow: 1, elementColumn: 0),
            expression: Is.EqualTo(
                new List<BooleanElementInfo>()
                {
                    new (row: 0, column: 0),
                    new (row: 0, column: 1),
                    new (row: 1, column: 1),
                    new (row: 2, column: 1),
                    new (row: 2, column: 0)
                }
            )
        );
    }

    [Test]
    public void FindNeighbourElements_TopLeftBound_TestCase()
    {
        Assert.That(
            actual: new CustomBooleanArray(new int[,]
                {
                    { 1, 0, 0 },
                    { 0, 0, 0 },
                    { 0, 0, 0 }
                }
            ).FindNeighbourElementsAt(
                elementRow: 0, elementColumn: 0),
            expression: Is.EqualTo(
                new List<BooleanElementInfo>()
                {
                    new (row: 0, column: 1),
                    new (row: 1, column: 1),
                    new (row: 1, column: 0)
                }
            )
        );
    }

    [Test]
    public void FindNeighbourElements_WithinMatrix_TestCase()
    {
        Assert.That(
            actual: new CustomBooleanArray(new int[,]
                {
                    { 0, 0, 0 },
                    { 0, 1, 0 },
                    { 0, 0, 0 }
                }
            ).FindNeighbourElementsAt(
                elementRow: 1, elementColumn: 1),
            expression: Is.EqualTo(
                new List<BooleanElementInfo>()
                {
                    new (row: 0, column: 1),
                    new (row: 0, column: 2),
                    new (row: 1, column: 2),
                    new (row: 2, column: 2),
                    new (row: 2, column: 1),
                    new (row: 2, column: 0),
                    new (row: 1, column: 0),
                    new (row: 0, column: 0)
                }
            )
        );
    }

    [Test]
    public void FindItemsIntersectionsTest_OnTopIntersection_TrueToTrue()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 0, 1, 0 },
                    { 0, 1, 0 },
                    { 0, 0, 0 }
                }
            ).FindItemsIntersectionsAt(
                elementRow: 1, elementColumn: 1),
            expression: Is.EqualTo(
                new List<ItemsIntersectionInfo>()
                {
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1, charged: true
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 0, column: 1, charged: true
                        )
                    )
                }
            )
        );
    }

    [Test]
    public void FindItemsIntersectionsTest_OnTopIntersection_FalseToFalse()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 1, 0, 1 },
                    { 1, 0, 1 },
                    { 1, 1, 1 }
                }
            ).FindItemsIntersectionsAt(
                elementRow: 1, elementColumn: 1,
                hasNonChargedNodeItems: true),
            expression: Is.EqualTo(
                new List<ItemsIntersectionInfo>()
                {
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 0, column: 1
                        )
                    )
                }
            )
        );
    }

    [Test]
    public void FindItemsIntersectionsTest_OnTopToRightIntersection_TrueToTrue()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 0, 0, 1 },
                    { 0, 1, 0 },
                    { 0, 0, 0 }
                }
            ).FindItemsIntersectionsAt(
                elementRow: 1, elementColumn: 1),
            expression: Is.EqualTo(
                new List<ItemsIntersectionInfo>()
                {
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1, charged: true
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 0, column: 2, charged: true
                        )
                    )
                }
            )
        );
    }

    [Test]
    public void FindItemsIntersectionsTest_OnTopToRightIntersection_FalseToFalse()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 1, 1, 0 },
                    { 1, 0, 1 },
                    { 1, 1, 1 }
                }
            ).FindItemsIntersectionsAt(
                elementRow: 1, elementColumn: 1,
                hasNonChargedNodeItems: true),
            expression: Is.EqualTo(
                new List<ItemsIntersectionInfo>()
                {
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 0, column: 2
                        )
                    )
                }
            )
        );
    }

    [Test]
    public void FindItemsIntersectionsTest_ToRightIntersection_TrueToTrue()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 0, 0, 0 },
                    { 0, 1, 1 },
                    { 0, 0, 0 }
                }
            ).FindItemsIntersectionsAt(
                elementRow: 1, elementColumn: 1),
            expression: Is.EqualTo(
                new List<ItemsIntersectionInfo>()
                {
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1, charged: true
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 2, charged: true
                        )
                    )
                }
            )
        );
    }

    [Test]
    public void FindItemsIntersectionsTest_ToRightIntersection_FalseToFalse()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 1, 1, 1 },
                    { 1, 0, 0 },
                    { 1, 1, 1 }
                }
            ).FindItemsIntersectionsAt(
                elementRow: 1, elementColumn: 1,
                hasNonChargedNodeItems: true),
            expression: Is.EqualTo(
                new List<ItemsIntersectionInfo>()
                {
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 2
                        )
                    )
                }
            )
        );
    }

    [Test]
    public void FindItemsIntersectionsTest_OnBottomToRightIntersection_TrueToTrue()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 0, 0, 0 },
                    { 0, 1, 0 },
                    { 0, 0, 1 }
                }
            ).FindItemsIntersectionsAt(
                elementRow: 1, elementColumn: 1),
            expression: Is.EqualTo(
                new List<ItemsIntersectionInfo>()
                {
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1, charged: true
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 2, column: 2, charged: true
                        )
                    )
                }
            )
        );
    }

    [Test]
    public void FindItemsIntersectionsTest_OnBottomToRightIntersection_FalseToFalse()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 1, 1, 1 },
                    { 1, 0, 1 },
                    { 1, 1, 0 }
                }
            ).FindItemsIntersectionsAt(
                elementRow: 1, elementColumn: 1,
                hasNonChargedNodeItems: true),
            expression: Is.EqualTo(
                new List<ItemsIntersectionInfo>()
                {
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 2, column: 2
                        )
                    )
                }
            )
        );
    }

    [Test]
    public void FindItemsIntersectionsTest_OnBottomIntersection_TrueToTrue()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 0, 0, 0 },
                    { 0, 1, 0 },
                    { 0, 1, 0 }
                }
            ).FindItemsIntersectionsAt(
                elementRow: 1, elementColumn: 1),
            expression: Is.EqualTo(
                new List<ItemsIntersectionInfo>()
                {
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1, charged: true
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 2, column: 1, charged: true
                        )
                    )
                }
            )
        );
    }

    [Test]
    public void FindItemsIntersectionsTest_OnBottomIntersection_FalseToFalse()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 1, 1, 1 },
                    { 1, 0, 1 },
                    { 1, 0, 1 }
                }
            ).FindItemsIntersectionsAt(
                elementRow: 1, elementColumn: 1,
                hasNonChargedNodeItems: true),
            expression: Is.EqualTo(
                new List<ItemsIntersectionInfo>()
                {
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 2, column: 1
                        )
                    )
                }
            )
        );
    }

    [Test]
    public void FindItemsIntersectionsTest_OnBottomToLeftIntersection_TrueToTrue()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 0, 0, 0 },
                    { 0, 1, 0 },
                    { 1, 0, 0 }
                }
            ).FindItemsIntersectionsAt(
                elementRow: 1, elementColumn: 1),
            expression: Is.EqualTo(
                new List<ItemsIntersectionInfo>()
                {
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1, charged: true
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 2, column: 0, charged: true
                        )
                    )
                }
            )
        );
    }

    [Test]
    public void FindItemsIntersectionsTest_OnBottomToLeftIntersection_FalseToFalse()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 1, 1, 1 },
                    { 1, 0, 1 },
                    { 0, 1, 1 }
                }
            ).FindItemsIntersectionsAt(
                elementRow: 1, elementColumn: 1,
                hasNonChargedNodeItems: true),
            expression: Is.EqualTo(
                new List<ItemsIntersectionInfo>()
                {
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 2, column: 0
                        )
                    )
                }
            )
        );
    }

    [Test]
    public void FindItemsIntersectionsTest_ToLeftIntersection_TrueToTrue()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 0, 0, 0 },
                    { 1, 1, 0 },
                    { 0, 0, 0 }
                }
            ).FindItemsIntersectionsAt(
                elementRow: 1, elementColumn: 1),
            expression: Is.EqualTo(
                new List<ItemsIntersectionInfo>()
                {
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1, charged: true
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 0, charged: true
                        )
                    )
                }
            )
        );
    }

    [Test]
    public void FindItemsIntersectionsTest_ToLeftIntersection_FalseToFalse()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 1, 1, 1 },
                    { 0, 0, 1 },
                    { 1, 1, 1 }
                }
            ).FindItemsIntersectionsAt(
                elementRow: 1, elementColumn: 1,
                hasNonChargedNodeItems: true),
            expression: Is.EqualTo(
                new List<ItemsIntersectionInfo>()
                {
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 0
                        )
                    )
                }
            )
        );
    }

    [Test]
    public void FindItemsIntersectionsTest_OnTopToLeftIntersection_TrueToTrue()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 1, 0, 0 },
                    { 0, 1, 0 },
                    { 0, 0, 0 }
                }
            ).FindItemsIntersectionsAt(
                elementRow: 1, elementColumn: 1),
            expression: Is.EqualTo(
                new List<ItemsIntersectionInfo>()
                {
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1, charged: true
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 0, column: 0, charged: true
                        )
                    )
                }
            )
        );
    }

    [Test]
    public void FindItemsIntersectionsTest_OnTopToLeftIntersection_FalseToFalse()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 0, 1, 1 },
                    { 1, 0, 1 },
                    { 1, 1, 1 }
                }
            ).FindItemsIntersectionsAt(
                elementRow: 1, elementColumn: 1,
                hasNonChargedNodeItems: true),
            expression: Is.EqualTo(
                new List<ItemsIntersectionInfo>()
                {
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 0, column: 0
                        )
                    )
                }
            )
        );
    }

    [Test]
    public void FindItemsIntersectionsTest_ManyIntersections_TrueToTrue()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 1, 0, 1 },
                    { 0, 1, 0 },
                    { 1, 0, 1 }
                }
            ).FindItemsIntersectionsAt(
                elementRow: 1, elementColumn: 1),
            expression: Is.EqualTo(
                new List<ItemsIntersectionInfo>()
                {
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1, charged: true
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 0, column: 2, charged: true
                        )
                    ),
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1, charged: true
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 2, column: 2, charged: true
                        )
                    ),
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1, charged: true
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 2, column: 0, charged: true
                        )
                    ),
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1, charged: true
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 0, column: 0, charged: true
                        )
                    )
                }
            )
        );
    }

    [Test]
    public void FindItemsIntersectionsTest_ManyIntersections_FalseToFalse()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 1, 0, 1 },
                    { 0, 0, 0 },
                    { 1, 0, 1 }
                }
            ).FindItemsIntersectionsAt(
                elementRow: 1, elementColumn: 1,
                hasNonChargedNodeItems: true),
            expression: Is.EqualTo(
                new List<ItemsIntersectionInfo>()
                {
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 0, column: 1
                        )
                    ),
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 2
                        )
                    ),
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 2, column: 1
                        )
                    ),
                    new
                    (
                        firstNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 1
                        ),
                        lastNodeItem: new BooleanElementInfo
                        (
                            row: 1, column: 0
                        )
                    )
                }
            )
        );
    }

    [Test]
    public void FindItemsIntersectionsTest_NoIntersections_TrueToTrue()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 0, 0, 0 },
                    { 0, 1, 0 },
                    { 0, 0, 0 }
                }
            ).FindItemsIntersectionsAt(
                elementRow: 1, elementColumn: 1),
            expression: Is.EqualTo(new List<ItemsIntersectionInfo>())
        );
    }

    [Test]
    public void FindItemsIntersectionsTest_NoIntersections_FalseToFalse()
    {
        Assert.That(
            actual: new CustomBooleanArray(
                new int[,]
                {
                    { 1, 1, 1 },
                    { 1, 0, 1 },
                    { 1, 1, 1 }
                }
            ).FindItemsIntersectionsAt(
                elementRow: 1, elementColumn: 1,
                hasNonChargedNodeItems: true),
            expression: Is.EqualTo(new List<ItemsIntersectionInfo>())
        );
    }
}
