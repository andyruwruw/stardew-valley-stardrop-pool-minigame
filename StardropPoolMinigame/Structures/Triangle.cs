using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardropPoolMinigame.Structures
{
    class Triangle : IRange
    {
        /// <summary>
        /// Center point X value.
        /// </summary>
        private float _x;

        /// <summary>
        /// Center point Y value.
        /// </summary>
        private float _y;

        /// <summary>
        /// Width of rectangle.
        /// </summary>
        private float _width;

        /// <summary>
        /// Height of rectangle.
        /// </summary>
        private float _height;

        /// <summary>
        /// Instantiates a Triangle
        /// </summary>
        /// 
        /// <param name="x">Center point X value</param>
        /// <param name="y">Center point Y value</param>
        /// <param name="width">Width of rectangle</param>
        /// <param name="height">Height of rectangle</param>
        public Triangle(float x, float y, float width, float height)
        {
            this._x = x;
            this._y = y;
            this._width = width;
            this._height = height;
        }

        public bool Contains(Vector2 point)
        {
            // Not within horizontal bounds
            if ((this._width > 0 && (point.X < this._x || point.X > this._x + this._width)) ||
                (this._width < 0 && (point.X < this._x + this._width || point.X > this._x)))
            {
                return false;
            }

            // Not within vertical bounds
            if ((this._height > 0 && (point.Y < this._y || point.Y > this._y + this._height)) ||
                (this._height < 0 && (point.Y < this._y + this._height || point.Y > this._y)))
            {
                return false;
            }

            // Find point on hypotenuse
            double bound = (this._height / this._width) * (point.X - this._x) + this._y;

            // Further than hypotenuse
            if ((this._height > 0 && point.Y > bound) ||
                (this._height < 0 && point.Y < bound))
            {
                return false;
            }

            return true;
        }

        public bool Intersects(IRange range)
        {
            if (range is Rectangle)
            {
                return (this.Contains(((Rectangle)range).GetNorthWest()) ||
                    this.Contains(((Rectangle)range).GetNorthEast()) ||
                    this.Contains(((Rectangle)range).GetSouthWest()) ||
                    this.Contains(((Rectangle)range).GetSouthEast()));
            }
            else if (range is Circle)
            {
                if (this.Contains(((Circle)range).GetCenter()))
                {
                    return true;
                }

                // Hypotenuse
                if (VectorMath.DistanceToLine(this.GetXOffset(), this.GetYOffset(), ((Circle)range).GetCenter()) <= ((Circle)range).GetRadius() &&
                    ((this._height > 0 && ((Circle)range).GetCenter().Y <= this.GetYOffset().Y + ((Circle)range).GetRadius() && ((Circle)range).GetCenter().Y >= this.GetCenter().Y - ((Circle)range).GetRadius()) ||
                    (this._height < 0 && ((Circle)range).GetCenter().Y <= this.GetCenter().Y + ((Circle)range).GetRadius() && ((Circle)range).GetCenter().Y >= this.GetYOffset().Y - ((Circle)range).GetRadius())) &&
                    ((this._width > 0 && ((Circle)range).GetCenter().X <= this.GetXOffset().X + ((Circle)range).GetRadius() && ((Circle)range).GetCenter().X >= this.GetCenter().X - ((Circle)range).GetRadius()) ||
                    (this._width < 0 && ((Circle)range).GetCenter().X <= this.GetCenter().X + ((Circle)range).GetRadius() && ((Circle)range).GetCenter().X >= this.GetXOffset().X - ((Circle)range).GetRadius())))
                {
                    Console.Info("Detected Intersection with Hypo Line");
                    return true;
                }

                // Vertical Line
                if (((this._height > 0 && ((Circle)range).GetCenter().Y <= this.GetYOffset().Y + ((Circle)range).GetRadius() && ((Circle)range).GetCenter().Y >= this.GetCenter().Y - ((Circle)range).GetRadius()) ||
                    (this._height < 0 && ((Circle)range).GetCenter().Y <= this.GetCenter().Y + ((Circle)range).GetRadius() && ((Circle)range).GetCenter().Y >= this.GetYOffset().Y - ((Circle)range).GetRadius())) &&
                    this._x - Math.Abs(((Circle)range).GetCenter().X) <= ((Circle)range).GetRadius())
                {
                    Console.Info("Detected Intersection with Vertical Line");
                    return true;
                }

                // Horizontal Line
                if (((this._width > 0 && ((Circle)range).GetCenter().X <= this.GetXOffset().X + ((Circle)range).GetRadius() && ((Circle)range).GetCenter().X >= this.GetCenter().X - ((Circle)range).GetRadius()) ||
                    (this._width < 0 && ((Circle)range).GetCenter().X <= this.GetCenter().X + ((Circle)range).GetRadius() && ((Circle)range).GetCenter().X >= this.GetXOffset().X - ((Circle)range).GetRadius())) &&
                    this._y - Math.Abs(((Circle)range).GetCenter().Y) <= ((Circle)range).GetRadius())
                {
                    Console.Info("Detected Intersection with Horizontal Line");
                    return true;
                }

                return false;
            }

            return false;
        }

        public Vector2 Bounce(IRange range, Vector2 velocity)
        {
            // Vertical Line
            if (((this._height > 0 && ((Circle)range).GetCenter().Y <= this.GetYOffset().Y + ((Circle)range).GetRadius() && ((Circle)range).GetCenter().Y >= this.GetCenter().Y - ((Circle)range).GetRadius()) ||
                (this._height < 0 && ((Circle)range).GetCenter().Y <= this.GetCenter().Y + ((Circle)range).GetRadius() && ((Circle)range).GetCenter().Y >= this.GetYOffset().Y - ((Circle)range).GetRadius())) &&
                this._x - Math.Abs(((Circle)range).GetCenter().X) <= ((Circle)range).GetRadius())
            {
                Console.Info("Bouncing off Vertical");
                return new Vector2(velocity.X * -1, velocity.Y);
            }

            // Horizontal Line
            if (((this._width > 0 && ((Circle)range).GetCenter().X <= this.GetXOffset().X + ((Circle)range).GetRadius() && ((Circle)range).GetCenter().X >= this.GetCenter().X - ((Circle)range).GetRadius()) ||
                (this._width < 0 && ((Circle)range).GetCenter().X <= this.GetCenter().X + ((Circle)range).GetRadius() && ((Circle)range).GetCenter().X >= this.GetXOffset().X - ((Circle)range).GetRadius())) &&
                this._y - Math.Abs(((Circle)range).GetCenter().Y) <= ((Circle)range).GetRadius())
            {
                Console.Info("Bouncing off horizontal");
                return new Vector2(velocity.X, velocity.Y * -1);
            }

            if (VectorMath.DistanceToLine(this.GetXOffset(), this.GetYOffset(), ((Circle)range).GetCenter()) <= ((Circle)range).GetRadius() &&
                    ((this._height > 0 && ((Circle)range).GetCenter().Y <= this.GetYOffset().Y + ((Circle)range).GetRadius() && ((Circle)range).GetCenter().Y >= this.GetCenter().Y - ((Circle)range).GetRadius()) ||
                    (this._height < 0 && ((Circle)range).GetCenter().Y <= this.GetCenter().Y + ((Circle)range).GetRadius() && ((Circle)range).GetCenter().Y >= this.GetYOffset().Y - ((Circle)range).GetRadius())) &&
                    ((this._width > 0 && ((Circle)range).GetCenter().X <= this.GetXOffset().X + ((Circle)range).GetRadius() && ((Circle)range).GetCenter().X >= this.GetCenter().X - ((Circle)range).GetRadius()) ||
                    (this._width < 0 && ((Circle)range).GetCenter().X <= this.GetCenter().X + ((Circle)range).GetRadius() && ((Circle)range).GetCenter().X >= this.GetXOffset().X - ((Circle)range).GetRadius())))
            {
                Console.Info("Bouncing off hypo");
                Vector2 surfaceNormalUnitVector = new Vector2(this._height, this._width);
                surfaceNormalUnitVector.Normalize();

                float temp = 2 * Vector2.Dot(surfaceNormalUnitVector, velocity);
                return Vector2.Add(Vector2.Multiply(new Vector2(temp, temp), surfaceNormalUnitVector), velocity);
            }

            Console.Info("Did not intersect?");
            return new Vector2(0, 0);
        }

        public Vector2 GetCenter()
        {
            return new Vector2(this._x, this._y);
        }

        public Vector2 GetXOffset()
        {
            return new Vector2(this._x + this._width, this._y);
        }

        public Vector2 GetYOffset()
        {
            return new Vector2(this._x, this._y + this._height);
        }

        public void Draw(SpriteBatch batch)
        {
            if (this._width > 0)
            {
                batch.Draw(Game1.staminaRect, new Microsoft.Xna.Framework.Rectangle((int)Math.Round(DrawMath.InnerTableToRaw(this.GetCenter()).X), (int)Math.Round(DrawMath.InnerTableToRaw(this.GetCenter()).Y), (int)Math.Round(this._width), 10), Game1.staminaRect.Bounds, Color.Purple, 0f, Vector2.Zero, SpriteEffects.None, 0.2f);
            } else
            {
                batch.Draw(Game1.staminaRect, new Microsoft.Xna.Framework.Rectangle((int)Math.Round(DrawMath.InnerTableToRaw(this.GetCenter()).X + this._width), (int)Math.Round(DrawMath.InnerTableToRaw(this.GetCenter()).Y), (int)Math.Abs(Math.Round(this._width)), 10), Game1.staminaRect.Bounds, Color.Purple, 0f, Vector2.Zero, SpriteEffects.None, 0.2f);
            }
            
            if (this._height > 0)
            {
                batch.Draw(Game1.staminaRect, new Microsoft.Xna.Framework.Rectangle((int)Math.Round(DrawMath.InnerTableToRaw(this.GetCenter()).X), (int)Math.Round(DrawMath.InnerTableToRaw(this.GetCenter()).Y), 10, (int)Math.Round(this._height)), Game1.staminaRect.Bounds, Color.Purple, 0f, Vector2.Zero, SpriteEffects.None, 0.2f);
            } else
            {
                batch.Draw(Game1.staminaRect, new Microsoft.Xna.Framework.Rectangle((int)Math.Round(DrawMath.InnerTableToRaw(this.GetCenter()).X), (int)Math.Round(DrawMath.InnerTableToRaw(this.GetCenter()).Y + this._height), 10, (int)Math.Abs(Math.Round(this._height))), Game1.staminaRect.Bounds, Color.Purple, 0f, Vector2.Zero, SpriteEffects.None, 0.2f);
            }
            
        }
    }
}
