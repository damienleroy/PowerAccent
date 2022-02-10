namespace PowerAccent.Core;

public struct Rect
{
    public Rect()
    {
        X = 0;
        Y = 0;
        Width = 0;
        Height = 0;
    }

    public Rect(int x, int y, int width, int height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public Rect(double x, double y, double width, double height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public Rect(Point coord, Size size)
    {
        X = coord.X;
        Y = coord.Y;
        Width = size.Width;
        Height = size.Height;
    }

    public double X { get; init; }
    public double Y { get; init; }
    public double Width { get; init; }
    public double Height { get; init; }

}
