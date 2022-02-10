using PowerAccent.Core.Services;

namespace PowerAccent.Core.Tools
{
    internal static class Calculation
    {
        public static Point GetRawCoordinatesFromCaret(Point caret, Rect screen, Size window)
        {
            var left = caret.X - window.Width / 2;
            var top = caret.Y - window.Height - 20;

            return new Point(left < screen.X ? screen.X : (left + window.Width > (screen.X + screen.Width) ? (screen.X + screen.Width) - window.Width : left)
                , top < screen.Y ? caret.Y + 20 : top);
        }

        public static Point GetRawCoordinatesFromPosition(Position position, Rect screen, Size window)
        {
            int offset = 10;

            double pointX = position switch
            {
                var x when
                    x == Position.Top ||
                    x == Position.Bottom ||
                    x == Position.Center
                    => screen.X + screen.Width / 2 - window.Width / 2,
                var x when
                    x == Position.TopLeft ||
                    x == Position.Left ||
                    x == Position.BottomLeft
                    => screen.X + offset,
                var x when
                    x == Position.TopRight ||
                    x == Position.Right ||
                    x == Position.BottomRight
                    => screen.X + screen.Width - (window.Width + offset),
            };

            double pointY = position switch
            {
                var x when
                    x == Position.TopLeft ||
                    x == Position.Top ||
                    x == Position.TopRight
                    => screen.Y + offset,
                var x when
                    x == Position.Left ||
                    x == Position.Center ||
                    x == Position.Right
                    => screen.Y + screen.Height / 2 - window.Height / 2,
                var x when
                    x == Position.BottomLeft ||
                    x == Position.Bottom ||
                    x == Position.BottomRight
                    => screen.Y + screen.Height - (window.Height + offset),
            };

            return new Point(pointX, pointY);
        }
    }
}
