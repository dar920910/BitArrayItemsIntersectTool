using Microsoft.AspNetCore.Mvc;

public static class DataStore
{
    public static byte ArrayDimension_X { get; set; }
    public static byte ArrayDimension_Y { get; set; }

    public static MatrixModel CurrentMatrixModel { get; set; }

    [BindProperty]
    public static byte SelectedElementRow { get; set; }

    [BindProperty]
    public static byte SelectedElementColumn { get; set; }

    static DataStore()
    {
        ArrayDimension_X = default;
        ArrayDimension_Y = default;
        CurrentMatrixModel = default;
        SelectedElementRow = default;
        SelectedElementColumn = default;
    }
}
