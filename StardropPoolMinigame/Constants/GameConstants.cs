using System.Collections.Generic;

namespace StardropPoolMinigame.Constants
{
    class GameConstants
    {
        public class Ball
        {
            /// <summary>
            /// Distance traveled between orientation updates
            /// </summary>
            public static float DISTANCE_TO_ORIENTATION_CHANGE = 5;

            /// <summary>
            /// Amount of friction applied per 1 unit of distance traveled
            /// </summary>
            public static float FRICTION_ACCELERATION = (float)-.01;

            /// <summary>
            /// Amount of acceleration halt applies
            /// </summary>
            public static float HALT_ACCELERATION = (float)-.1;

            /// <summary>
            /// Ball velocity at which halt begins
            /// </summary>
            public static float HALT_BEGIN_VELOCITY = (float).8;

            /// <summary>
            /// Mass of pool ball
            /// </summary>
            public static float MASS = 1;

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
            public static float BOUNCE_MOMENTUM_LOSS_MULTIPLIER = 1;

            /// <summary>
            /// Momentum loss from bouncing off a wall
            /// </summary>
            public static float WALL_BOUNCE_MOMENTUM_LOSS = 0;
        }

        public class Cue
        {
            /// <summary>
            /// Transfer ration of ball momentum to cue speed
            /// </summary>
            public static float MOMENTUM_TRANSFER = 18;

            /// <summary>
            /// Speed at which the cue travels
            /// </summary>
            public static float STRIKING_SPEED = 8;
        }

        public class PoolTable
        {
            /// <summary>
            /// Tile IDs for Pool Table on Building Layer
            /// </summary>
            public static IList<int> TILE_ID_BUILDING = new List<int>() { 1447, 1448, 1449, 1450, 1451, 1479, 1480, 1481, 1482, 1483 };

            /// <summary>
            /// Tile IDs for Pool Table on Front Layer
            /// </summary>
            public static IList<int> TILE_ID_FRONT = new List<int>() { 1415, 1416, 1417, 1418, 1419 };

            public static int LIP_CONTACT = 2;
        }
        
        public class BallButton
        {
            public static float HOVER_ROTATIONAL_SPEED = -.4f;
        }
    }
}
