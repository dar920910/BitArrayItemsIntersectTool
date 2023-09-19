using Microsoft.AspNetCore.Mvc;

public static class DataStore
{
    public static byte ArrayDimension_X { get; set; }
    public static byte ArrayDimension_Y { get; set; }

    public static MatrixModel CurrentMatrixModel { get; set; }

    public static byte CurrentElementRow { get; set; }
    public static byte CurrentElementCol { get; set; }

    public static (byte Row, byte Col) RouteElement_A { get; set; }
    public static (byte Row, byte Col) RouteElement_B { get; set; }

    static DataStore()
    {
        ArrayDimension_X = default;
        ArrayDimension_Y = default;
        CurrentMatrixModel = default;
        CurrentElementRow = default;
        CurrentElementCol = default;
        RouteElement_A = default;
        RouteElement_B = default;
    }
}
