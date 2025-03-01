﻿using Microsoft.Xna.Framework;
using MinigameFramework.Structures.Primitives;

namespace MinigameFramework.Helpers
{
    /// <summary>
    /// Classifies two <see cref="IRange"/> and checks for intersection
    /// </summary>
    static class RangeIntersection
    {
        /// <summary>
        /// Checks if two <see cref="IRange"/> intersect
        /// </summary>
        /// <param name="shape1">First <see cref="IRange"/> to check</param>
        /// <param name="shape2">Second <see cref="IRange"/> to check</param>
        /// <returns>Whether both <see cref="IRange"/> intersect</returns>
        public static bool IsIntersecting(
            IRange shape1,
            IRange shape2
        ) {
            bool isRectangle = shape1 is Structures.Primitives.Rectangle || shape2 is Structures.Primitives.Rectangle;
            bool isCircle = shape1 is Circle || shape2 is Circle;
            bool isLine = shape1 is Line || shape2 is Line;

            if (isRectangle && !isCircle && !isLine)
            {
                return IsIntersectingRectangles(
                    (Structures.Primitives.Rectangle)shape1,
                    (Structures.Primitives.Rectangle)shape2
                );
            }
            if (isCircle && !isRectangle && !isLine)
            {
                return IsIntersectingCircles(
                    (Circle)shape1,
                    (Circle)shape2
                );
            }
            if (isLine && !isCircle && !isRectangle)
            {
                return IsIntersectingLines(
                    (Line)shape1,
                    (Line)shape2
                );
            }
            if (isCircle && isRectangle && !isLine)
            {
                return IsIntersectingCircleAndRectangle(
                    (Circle)(shape1 is Circle ? shape1 : shape2),
                    (Structures.Primitives.Rectangle)(shape1 is Structures.Primitives.Rectangle ? shape1 : shape2)
                );
            }
            if (isCircle && isLine && !isRectangle)
            {
                return IsIntersectingCircleAndLine(
                    (Circle)(shape1 is Circle ? shape1 : shape2),
                    (Line)(shape1 is Line ? shape1 : shape2)
                );
            }
            if (isLine && isRectangle && !isCircle)
            {
                return IsIntersectingLineAndRectangle(
                    (Line)(shape1 is Line ? shape1 : shape2),
                    (Structures.Primitives.Rectangle)(shape1 is Structures.Primitives.Rectangle ? shape1 : shape2)
                );
            }
            return false;
        }

        /// <summary>
        /// Checks if two <see cref="Rectangle"/> intersect
        /// </summary>
        /// <param name="rectangle1">First <see cref="Rectangle"/> to check</param>
        /// <param name="rectangle2">Second <see cref="Rectangle"/> to check</param>
        /// <returns>Whether both <see cref="Rectangle"/> intersect</returns>
        private static bool IsIntersectingRectangles(
            Structures.Primitives.Rectangle rectangle1,
            Structures.Primitives.Rectangle rectangle2
        ) {
            return !(rectangle1.GetSouthEastCorner().Y < rectangle2.GetNorthWestCorner().Y
                || rectangle2.GetSouthEastCorner().Y < rectangle1.GetNorthWestCorner().Y)
                && !(rectangle1.GetNorthWestCorner().X > rectangle2.GetSouthEastCorner().X
                || rectangle2.GetNorthWestCorner().X > rectangle1.GetSouthEastCorner().X);
        }

        /// <summary>
        /// Checks if two <see cref="Circle"/> intersect
        /// </summary>
        /// <param name="circle1">First <see cref="Circle"/> to check</param>
        /// <param name="circle2">Second <see cref="Circle"/> to check</param>
        /// <returns>Whether both <see cref="Circle"/> intersect</returns>
        private static bool IsIntersectingCircles(
            Circle circle1,
            Circle circle2
        ) {
            return DistanceHelpers.Pythagorean(
                circle1.GetCenter(),
                circle2.GetCenter()
            ) <= circle1.GetRadius() + circle2.GetRadius();
        }

        /// <summary>
        /// Checks if two <see cref="Line"/> intersect
        /// </summary>
        /// <param name="line1">First <see cref="Line"/> to check</param>
        /// <param name="line2">Second <see cref="Line"/> to check</param>
        /// <returns>Whether both <see cref="Line"/> intersect</returns>
        private static bool IsIntersectingLines(
            Line line1,
            Line line2
        ) {
            float o1 = RangeIntersection.Orientation(
                line1.GetStart(),
                line2.GetStart(),
                line1.GetEnd()
            );
            float o2 = RangeIntersection.Orientation(
                line1.GetStart(),
                line2.GetStart(),
                line2.GetEnd()
            );
            float o3 = RangeIntersection.Orientation(
                line1.GetEnd(),
                line2.GetEnd(),
                line1.GetStart()
            );
            float o4 = RangeIntersection.Orientation(
                line1.GetEnd(),
                line2.GetEnd(),
                line2.GetStart()
            );

            if (o1 != o2 && o3 != o4)
            {
                return true;
            }

            if (o1 == 0 && OnSegment(
                line1.GetStart(),
                line1.GetEnd(),
                line2.GetStart()
            ))
            {
                return true;
            }

            if (o2 == 0 && OnSegment(
                line1.GetStart(),
                line2.GetEnd(),
                line2.GetStart()
            ))
            {
                return true;
            }

            if (o3 == 0 && OnSegment(
                line1.GetEnd(),
                line1.GetStart(),
                line2.GetEnd()
            ))
            {
                return true;
            }

            if (o4 == 0 && OnSegment(
                line1.GetEnd(),
                line2.GetStart(),
                line2.GetEnd()
            ))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if a <see cref="Circle"/> and <see cref="Rectangle"/> intersect
        /// </summary>
        /// <param name="circle"><see cref="Circle"/> to check</param>
        /// <param name="rectangle"><see cref="Rectangle"/> to check</param>
        /// <returns>Whether the <see cref="Circle"/> and <see cref="Rectangle"/> intersect</returns>
        private static bool IsIntersectingCircleAndRectangle(
            Circle circle,
            Structures.Primitives.Rectangle rectangle
        ) {
            float Xn = Math.Max(
                rectangle.GetNorthWestCorner().X,
                Math.Min(
                    circle.GetCenter().X,
                    rectangle.GetSouthEastCorner().X
                )
            );
            float Yn = Math.Max(
                rectangle.GetNorthWestCorner().Y,
                Math.Min(circle.GetCenter().Y, rectangle.GetSouthEastCorner().Y)
            );

            float Dx = Xn - circle.GetCenter().X;
            float Dy = Yn - circle.GetCenter().Y;

            return Dx * Dx + Dy * Dy <= circle.GetRadius() * circle.GetRadius();
        }

        /// <summary>
        /// Checks if a <see cref="Circle"/> and <see cref="Line"/> intersect
        /// </summary>
        /// <param name="circle"><see cref="Circle"/> to check</param>
        /// <param name="line"><see cref="Line"/> to check</param>
        /// <returns>Whether the <see cref="Circle"/> and <see cref="Line"/> intersect</returns>
        private static bool IsIntersectingCircleAndLine(
            Circle circle,
            Line line
        )
        {
            bool startInCircle = DistanceHelpers.Pythagorean(
                line.GetStart(),
                circle.GetCenter()
            ) <= circle.GetRadius();
            bool endInCircle = DistanceHelpers.Pythagorean(
                line.GetEnd(),
                circle.GetCenter()
            ) <= circle.GetRadius();

            if (startInCircle || endInCircle)
            {
                return true;
            }

            float dotProduct = (float)(((circle.GetCenter().X - line.GetStart().X) * (line.GetEnd().X - line.GetStart().X) + (circle.GetCenter().Y - line.GetStart().Y) * (line.GetEnd().Y - line.GetStart().Y)) / Math.Pow(line.GetLength(), 2));

            Vector2 closestPoint = new Vector2(
                line.GetStart().X + dotProduct * (line.GetEnd().X - line.GetStart().X),
                line.GetStart().Y + dotProduct * (line.GetEnd().Y - line.GetStart().Y)
            );

            return DistanceHelpers.Pythagorean(
                closestPoint,
                circle.GetCenter()
            ) <= circle.GetRadius();
        }

        /// <summary>
        /// Checks if a <see cref="Line"/> and <see cref="Rectangle"/> intersect
        /// </summary>
        /// <param name="line"><see cref="Line"/> to check</param>
        /// <param name="rectangle"><see cref="Rectangle"/> to check</param>
        /// <returns>Whether the <see cref="Line"/> and <see cref="Rectangle"/> intersect</returns>
        private static bool IsIntersectingLineAndRectangle(
            Line line,
            Structures.Primitives.Rectangle rectangle
        ) {
            // Not implemented, got lazy.
            return true;
        }

        /// <summary>
        /// Just some stolen code from StackOverflow
        /// </summary>
        private static bool OnSegment(
            Vector2 p,
            Vector2 q,
            Vector2 r
        ) {
            return q.X <= Math.Max(p.X, r.X)
                && q.X >= Math.Min(p.X, r.X)
                && q.Y <= Math.Max(p.Y, r.Y)
                && q.Y >= Math.Min(p.Y, r.Y);
        }

        /// <summary>
        /// Just some stolen code from StackOverflow.
        /// </summary>
        private static float Orientation(
            Vector2 p,
            Vector2 q,
            Vector2 r
        ) {
            float value = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);

            if (value == 0f)
            {
                return value;
            }

            return value > 0f ? 1f : 2f;
        }
    }
}
