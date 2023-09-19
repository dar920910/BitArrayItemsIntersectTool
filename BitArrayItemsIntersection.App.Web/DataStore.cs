using Microsoft.AspNetCore.Mvc;

public static class DataStore
{
    public static byte ArrayDimension_X { get; set; }
    public static byte ArrayDimension_Y { get; set; }

    public static MatrixModel CurrentMatrixModel { get; set; }

    public static byte CurrentElementRow { get; set; }
    public static byte CurrentElementCol { get; set; }

    static DataStore()
    {
        ArrayDimension_X = default;
        ArrayDimension_Y = default;
        CurrentMatrixModel = default;
        CurrentElementRow = default;
        CurrentElementCol = default;
    }
}
