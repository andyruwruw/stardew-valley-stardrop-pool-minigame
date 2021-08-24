using System.Collections.Generic;

namespace StardropPoolMinigame.Constants
{
    class GameConstants
    {
        /// <summary>
        /// Distance traveled between orientation updates
        /// </summary>
        public static float BALL_DISTANCE_TO_ORIENTATION_CHANGE = 5;

        /// <summary>
        /// Amount of friction applied per 1 unit of distance traveled
        /// </summary>
        public static float BALL_FRICTION_ACCELERATION = (float)-.01;

        /// <summary>
        /// Amount of acceleration halt applies
        /// </summary>
        public static float BALL_HALT_ACCELERATION = (float)-.1;

        /// <summary>
        /// Ball velocity at which halt begins
        /// </summary>
        public static float BALL_HALT_BEGIN_VELOCITY = (float).8;

        /// <summary>
        /// Mass of pool ball
        /// </summary>
        public static float BALL_MASS = 1;

        /// <summary>
        /// Minimum velocity of ball
        /// </summary>
        public static float BALL_MINIMUM_VELOCITY = (float).05;

        /// <summary>
        /// Radius of pool ball
        /// </summary>
        public static float BALL_RADIUS = 5.5f;

        /// <summary>
        /// Momentum loss from bouncing off a wall
        /// </summary>
        public static float BALL_TO_BALL_BOUNCE_MOMENTUM_LOSS_MULTIPLIER = 1;

        /// <summary>
        /// Momentum loss from bouncing off a wall
        /// </summary>
        public static float BALL_WALL_BOUNCE_MOMENTUM_LOSS = 0;

        /// <summary>
        /// Transfer ration of ball momentum to cue speed
        /// </summary>
        public static float CUE_MOMENTUM_TRANSFER = 18;

        /// <summary>
        /// Speed at which the cue travels
        /// </summary>
        public static float CUE_STRIKING_SPEED = 8;

        /// <summary>
        /// Tile IDs for Pool Table on Building Layer
        /// </summary>
        public static IList<int> POOL_TABLE_TILE_ID_BUILDING = new List<int>() { 1447, 1448, 1449, 1450, 1451, 1479, 1480, 1481, 1482, 1483 };

        /// <summary>
        /// Tile IDs for Pool Table on Front Layer
        /// </summary>
        public static IList<int> POOL_TABLE_TILE_ID_FRONT = new List<int>() { 1415, 1416, 1417, 1418, 1419 };

        public static float BALL_BUTTON_HOVER_ROTATIONAL_SPEED = .2f;
    }
}
