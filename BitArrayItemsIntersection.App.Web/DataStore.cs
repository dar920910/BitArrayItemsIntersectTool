//-----------------------------------------------------------------------
// <copyright file="DataStore.cs" company="Demo Projects Workshop">
//     Copyright (c) Demo Projects Workshop. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

#pragma warning disable SA1600 // ElementsMustBeDocumented

public static class DataStore
{
    static DataStore()
    {
        ArrayRowsDimension = default;
        ArrayColsDimension = default;
        CurrentMatrixModel = default;
        CurrentElementRow = default;
        CurrentElementCol = default;
        RouteElement_A = default;
        RouteElement_B = default;
    }

    public static byte ArrayRowsDimension { get; set; }

    public static byte ArrayColsDimension { get; set; }

    public static MatrixModel CurrentMatrixModel { get; set; }

    public static byte CurrentElementRow { get; set; }

    public static byte CurrentElementCol { get; set; }

    public static (byte Row, byte Col) RouteElement_A { get; set; }

    public static (byte Row, byte Col) RouteElement_B { get; set; }
}
