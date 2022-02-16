namespace PowerAccent.Core;

public struct Size
{
    public Size()
    {
        Width = 0;
        Height = 0;
    }

    public Size(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public Size(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public double Width { get; init; }
    public double Height { get; init; }

    public static implicit operator Size(System.Drawing.Size size) => new Size(size.Width, size.Height);
}
