using System;
using System.Collections.Generic;

namespace StardropPoolMinigame.Constants
{
    internal class GameConstants
    {
        public class Ball
        {
            /// <summary>
            /// Momentum loss from bouncing off a wall
            /// </summary>
            public static float BOUNCE_MOMENTUM_LOSS_MULTIPLIER = 1;

            /// <summary>
            /// Distance traveled between orientation updates
            /// </summary>
            public static float DISTANCE_TO_ORIENTATION_CHANGE = 5;

            /// <summary>
            /// Amount of friction applied per 1 unit of distance traveled
            /// </summary>
            public static float FRICTION_ACCELERATION = (float)-.005;

            /// <summary>
            /// Amount of acceleration halt applies
            /// </summary>
            public static float HALT_ACCELERATION = (float)-.005;

            /// <summary>
            /// Ball velocity at which halt begins
            /// </summary>
            public static float HALT_BEGIN_VELOCITY = (float).05;

            /// <summary>
            /// Mass of pool ball
            /// </summary>
            public static float MASS = 1;

            public static float MINIMUM_BOUNCE_VELOCITY = .05f;

            /// <summary>
            /// Minimum velocity of ball
            /// </summary>
            public static float MINIMUM_VELOCITY = (float).05;

            /// <summary>
            /// Radius of pool ball
            /// </summary>
            public static float RADIUS = 5.5f;

            /// <summary>
            /// Momentum loss from bouncing off a wall
            /// </summary>
            public static float WALL_BOUNCE_MOMENTUM_LOSS = 0;
        }

        public class BallButton
        {
            public static float HOVER_ROTATIONAL_SPEED = -.4f;
        }

        public class Cue
        {
            public static int MAXIMUM_DISTANCE_FROM_BALL = (int)Math.Round((Ball.RADIUS + 85) * RenderConstants.TileScale());

            public static int MINIMUM_DISTANCE_FROM_BALL = (int)Math.Round((Ball.RADIUS + 5) * RenderConstants.TileScale());

            /// <summary>
            /// Transfer ration of ball momentum to cue speed
            /// </summary>
            public static float MOMENTUM_TRANSFER = 4;

            public static float PARTICLE_MINIMUM_POWER_TRIGGER = 0.85f;

            public static float PARTICLE_RATE_PER_POWER = 3f;

            public static int POWER_TO_WIGGLE_AMPLITUDE_SCALAR = 75;

            /// <summary>
            /// Time the cue takes to hit the ball.
            /// </summary>
            public static float STRIKING_SPEED = 10;

            public static float WIGGLE_FREQUENCY = 800;
        }

        public class Particle
        {
            public class Glimmer
            {
                public static float ALIGNMENT_STRENGTH = 0.04f;

                public static float COHESION_STRENGTH = 0.005f;

                public static int LIFESPAN = 50;

                public static float MAXIMUM_FORCE = 0.1f;

                public static float MAXIMUM_INITIAL_VELOCITY_SCOLAR = 1.5f;

                public static float MAXIMUM_VELOCITY = 1.5f;

                public static float MINIMUM_INITIAL_VELOCITY_SCOLAR = 0.3f;

                public static float PERCEPTION_RADIUS = 5f;

                public static float SEPARATION_STRENGTH = 0.08f;
            }

            public class PurpleWhisp
            {
                public static float ALIGNMENT_STRENGTH = 0.04f;

                public static float COHESION_STRENGTH = 0.005f;

                public static int LIFESPAN = 50;

                public static float MAXIMUM_FORCE = 0.1f;

                public static float MAXIMUM_INITIAL_VELOCITY_SCOLAR = 1.5f;

                public static float MAXIMUM_VELOCITY = 1.5f;

                public static float MINIMUM_INITIAL_VELOCITY_SCOLAR = 0.3f;

                public static float PERCEPTION_RADIUS = 5f;

                public static float SEPARATION_STRENGTH = 0.08f;
            }

            public class Spark
            {
                public static float ALIGNMENT_STRENGTH = 0.02f;

                public static float COHESION_STRENGTH = 0.03f;

                public static int LIFESPAN = 50;

                public static float MAXIMUM_FORCE = 0.2f;

                public static float MAXIMUM_INITIAL_VELOCITY_SCOLAR = 1.5f;

                public static float MAXIMUM_VELOCITY = 1.5f;

                public static float MINIMUM_INITIAL_VELOCITY_SCOLAR = 0.3f;

                public static float PERCEPTION_RADIUS = 8f;

                public static float SEPARATION_STRENGTH = 0.04f;
            }

            public class Sparkle
            {
                public static float ALIGNMENT_STRENGTH = 0.04f;

                public static float COHESION_STRENGTH = 0.005f;

                public static int LIFESPAN = 50;

                public static float MAXIMUM_FORCE = 0.1f;

                public static float MAXIMUM_INITIAL_VELOCITY_SCOLAR = 1.5f;

                public static float MAXIMUM_VELOCITY = 1.5f;

                public static float MINIMUM_INITIAL_VELOCITY_SCOLAR = 0.3f;

                public static float PERCEPTION_RADIUS = 5f;

                public static float SEPARATION_STRENGTH = 0.08f;
            }
        }

        public class PoolTable
        {
            public static int LIP_CONTACT = 2;

            /// <summary>
            /// Tile IDs for Pool Table on Building Layer
            /// </summary>
            public static IList<int> TILE_ID_BUILDING = new List<int>() { 1447, 1448, 1449, 1450, 1451, 1479, 1480, 1481, 1482, 1483 };

            /// <summary>
            /// Tile IDs for Pool Table on Front Layer
            /// </summary>
            public static IList<int> TILE_ID_FRONT = new List<int>() { 1415, 1416, 1417, 1418, 1419 };
        }
    }
}