using StardropPoolMinigame.Primitives;
using System;

namespace StardropPoolMinigame.Helpers
{
    /// <summary>
    /// Classifies two <see cref="IRange"/> and checks for intersection
    /// </summary>
    class IntersectionHelper
    {
        /// <summary>
        /// Checks if two <see cref="IRange"/> intersect
        /// </summary>
        /// <param name="shape1">First <see cref="IRange"/> to check</param>
        /// <param name="shape2">Second <see cref="IRange"/> to check</param>
        /// <returns>Whether both <see cref="IRange"/> intersect</returns>
        public static bool IsIntersecting(IRange shape1, IRange shape2)
        {
            bool isRectangle = shape1 is Rectangle || shape2 is Rectangle;
            bool isCircle = shape1 is Circle || shape2 is Circle;
            bool isLine = shape1 is Line || shape2 is Line;

            if (isRectangle && !isCircle && !isLine)
            {
                return IsIntersectingRectangles(
                    (Rectangle)shape1,
                    (Rectangle)shape2);
            }
            if (isCircle && !isRectangle && !isLine)
            {
                return IsIntersectingCircles(
                    (Circle)shape1,
                    (Circle)shape2);
            }
            if (isLine && !isCircle && !isRectangle)
            {
                return IsIntersectingLines(
                    (Line)shape1,
                    (Line)shape2);
            }
            if (isCircle && isRectangle && !isLine)
            {
                return IsIntersectingCircleAndRectangle(
                    (Circle)(shape1 is Circle ? shape1 : shape2),
                    (Rectangle)(shape1 is Rectangle ? shape1 : shape2));
            }
            if (isCircle && isLine && !isRectangle)
            {
                return IsIntersectingCircleAndLine(
                    (Circle)(shape1 is Circle ? shape1 : shape2),
                    (Line)(shape1 is Line ? shape1 : shape2));
            }
            if (isLine && isRectangle && !isCircle)
            {
                return IsIntersectingLineAndRectangle(
                    (Line)(shape1 is Line ? shape1 : shape2),
                    (Rectangle)(shape1 is Rectangle ? shape1 : shape2));
            }
            return false;
        }

        /// <summary>
        /// Checks if two <see cref="Rectangle"/> intersect
        /// </summary>
        /// <param name="rectangle1">First <see cref="Rectangle"/> to check</param>
        /// <param name="rectangle2">Second <see cref="Rectangle"/> to check</param>
        /// <returns>Whether both <see cref="Rectangle"/> intersect</returns>
        private static bool IsIntersectingRectangles(Rectangle rectangle1, Rectangle rectangle2)
        {
            bool value = (!(
                    rectangle1.GetSouthEastCorner().Y < rectangle2.GetNorthWestCorner().Y
                    || rectangle2.GetSouthEastCorner().Y < rectangle1.GetNorthWestCorner().Y)
                && !(
                    rectangle1.GetNorthWestCorner().X > rectangle2.GetSouthEastCorner().X
                    || rectangle2.GetNorthWestCorner().X > rectangle1.GetSouthEastCorner().X));
            return value;
        }

        /// <summary>
        /// Checks if two <see cref="Circle"/> intersect
        /// </summary>
        /// <param name="circle1">First <see cref="Circle"/> to check</param>
        /// <param name="circle2">Second <see cref="Circle"/> to check</param>
        /// <returns>Whether both <see cref="Circle"/> intersect</returns>
        public static bool IsIntersectingCircles(Circle circle1, Circle circle2)
        {
            return VectorHelper.Pythagorean(circle1.GetCenter(), circle2.GetCenter()) <= circle1.GetRadius() + circle2.GetRadius();
        }

        /// <summary>
        /// Checks if two <see cref="Line"/> intersect
        /// </summary>
        /// <param name="line1">First <see cref="Line"/> to check</param>
        /// <param name="line2">Second <see cref="Line"/> to check</param>
        /// <returns>Whether both <see cref="Line"/> intersect</returns>
        public static bool IsIntersectingLines(Line line1, Line line2)
        {
            return true;
        }

        /// <summary>
        /// Checks if a <see cref="Circle"/> and <see cref="Rectangle"/> intersect
        /// </summary>
        /// <param name="circle"><see cref="Circle"/> to check</param>
        /// <param name="rectangle"><see cref="Rectangle"/> to check</param>
        /// <returns>Whether the <see cref="Circle"/> and <see cref="Rectangle"/> intersect</returns>
        public static bool IsIntersectingCircleAndRectangle(Circle circle, Rectangle rectangle)
        {
            float Xn = Math.Max(rectangle.GetNorthWestCorner().X, Math.Min(circle.GetCenter().X, rectangle.GetSouthEastCorner().X));
            float Yn = Math.Max(rectangle.GetNorthWestCorner().Y, Math.Min(circle.GetCenter().Y, rectangle.GetSouthEastCorner().Y));

            float Dx = Xn - circle.GetCenter().X;
            float Dy = Yn - circle.GetCenter().Y;
            return (Dx * Dx + Dy * Dy) <= circle.GetRadius() * circle.GetRadius();
        }

        /// <summary>
        /// Checks if a <see cref="Circle"/> and <see cref="Line"/> intersect
        /// </summary>
        /// <param name="circle"><see cref="Circle"/> to check</param>
        /// <param name="line"><see cref="Line"/> to check</param>
        /// <returns>Whether the <see cref="Circle"/> and <see cref="Line"/> intersect</returns>
        public static bool IsIntersectingCircleAndLine(Circle circle, Line line)
        {
            return true;
        }

        /// <summary>
        /// Checks if a <see cref="Line"/> and <see cref="Rectangle"/> intersect
        /// </summary>
        /// <param name="line"><see cref="Line"/> to check</param>
        /// <param name="rectangle"><see cref="Rectangle"/> to check</param>
        /// <returns>Whether the <see cref="Line"/> and <see cref="Rectangle"/> intersect</returns>
        public static bool IsIntersectingLineAndRectangle(Line line, Rectangle rectangle)
        {
            return true;
        }
    }
}
