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
            return true;
        }

        public static bool IntersectingCircles(Circle circle1, Circle circle2)
        {
            return true;
        }

        public static bool IntersectingRectangleAndCircle(Rectangle rectangle, Circle circle)
        {
            return true;
        }
    }
}
