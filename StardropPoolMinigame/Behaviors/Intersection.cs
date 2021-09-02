﻿using StardropPoolMinigame.Helpers;
using StardropPoolMinigame.Primitives;

namespace StardropPoolMinigame.Geometry
{
    class Intersection
    {
        public static bool IsIntersecting(IRange shape1, IRange shape2)
        {
            bool isRectangle = false;
            bool isCircle = false;

            if (shape1 is Rectangle || shape2 is Rectangle)
            {
                isRectangle = true;
            }
            if (shape1 is Circle || shape2 is Circle)
            {
                isCircle = true;
            }

            if (isRectangle && !isCircle)
            {
                return IntersectingRectangles((Rectangle)shape1, (Rectangle)shape2);
            }
            if (isCircle && !isRectangle)
            {
                return IntersectingCircles((Circle)shape1, (Circle)shape2);
            }
            if (isCircle && isRectangle)
            {
                return IntersectingRectangleAndCircle(
                    shape1 is Rectangle ? (Rectangle)shape1 : (Rectangle)shape2,
                    shape1 is Circle ? (Circle)shape1 : (Circle)shape2);
            }
            return false;
        }

        public static bool IntersectingRectangles(Rectangle rectangle1, Rectangle rectangle2)
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

        public static bool IntersectingRectangleAndCircle(Rectangle rectangle, Circle circle)
        {
            return true;
        }
    }
}
