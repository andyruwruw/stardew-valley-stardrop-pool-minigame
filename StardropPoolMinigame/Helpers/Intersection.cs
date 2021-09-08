using Microsoft.Xna.Framework;
using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Primitives;
using System;

namespace StardropPoolMinigame.Geometry
{
    class Intersection
    {
        public static bool IsIntersecting(IRange shape1, IRange shape2)
        {
            bool isRectangle = false;
            bool isCircle = false;

            if (shape1 is Primitives.Rectangle || shape2 is Primitives.Rectangle)
            {
                isRectangle = true;
            }
            if (shape1 is Circle || shape2 is Circle)
            {
                isCircle = true;
            }

            if (isRectangle && !isCircle)
            {
                return IntersectingRectangles((Primitives.Rectangle)shape1, (Primitives.Rectangle)shape2);
            }
            if (isCircle && !isRectangle)
            {
                return IntersectingCircles((Circle)shape1, (Circle)shape2);
            }
            if (isCircle && isRectangle)
            {
                return IntersectingRectangleAndCircle(
                    shape1 is Primitives.Rectangle ? (Primitives.Rectangle)shape1 : (Primitives.Rectangle)shape2,
                    shape1 is Circle ? (Circle)shape1 : (Circle)shape2);
            }
            return false;
        }

        public static bool IntersectingRectangles(Primitives.Rectangle rectangle1, Primitives.Rectangle rectangle2)
        {
            bool value = (!(
                    rectangle1.GetSouthEastCorner().Y < rectangle2.GetNorthWestCorner().Y
                    || rectangle2.GetSouthEastCorner().Y < rectangle1.GetNorthWestCorner().Y)
                && !(
                    rectangle1.GetNorthWestCorner().X > rectangle2.GetSouthEastCorner().X
                    || rectangle2.GetNorthWestCorner().X > rectangle1.GetSouthEastCorner().X));
            return value;
        }

        public static bool IntersectingCircles(Circle circle1, Circle circle2)
        {
            return Distance.Pythagorean(circle1.GetCenter(), circle2.GetCenter()) <= circle1.GetRadius() + circle2.GetRadius();
        }

        public static bool IntersectingRectangleAndCircle(Primitives.Rectangle rectangle, Circle circle)
        {
            float Xn = Math.Max(rectangle.GetNorthWestCorner().X, Math.Min(circle.GetCenter().X, rectangle.GetSouthEastCorner().X));
            float Yn = Math.Max(rectangle.GetNorthWestCorner().Y, Math.Min(circle.GetCenter().Y, rectangle.GetSouthEastCorner().Y));

            float Dx = Xn - circle.GetCenter().X;
            float Dy = Yn - circle.GetCenter().Y;
            return (Dx * Dx + Dy * Dy) <= circle.GetRadius() * circle.GetRadius();
        }
    }
}
