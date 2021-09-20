using System;
using System.Collections.Generic;

namespace StardropPoolMinigame.Constants
{
    internal class GameConstants
    {
        public class Ball
        {
            /// <summary>
            /// Momentum loss from bouncing off a wall.
            /// </summary>
            public static float BounceMomentumLossMultiplier = 1;

            /// <summary>
            /// Distance traveled between <see cref="Attributes.Orientation"/> updates.
            /// </summary>
            public static float DistanceToOrientationChange = 5;

            /// <summary>
            /// Amount of friction applied per 1 unit of distance traveled.
            /// </summary>
            public static float FrictionAcceleration = (float)-.005;

            /// <summary>
            /// Amount of acceleration halt applies.
            /// </summary>
            public static float HaltAcceleration = (float)-.03;

            /// <summary>
            /// <see cref="Entities.Ball"/> velocity at which halt begins.
            /// </summary>
            public static float HaltBeginVelocity = (float).08;

            /// <summary>
            /// Mass of pool <see cref="Entities.Ball"/>.
            /// </summary>
            public static float Mass = 1;

            /// <summary>
            /// Minimum velocity for a <see cref="Entities.Ball"/> to bounce.
            /// </summary>
            public static float MinimumBounceVelocity = .02f;

            /// <summary>
            /// Minimum velocity of <see cref="Entities.Ball"/>.
            /// </summary>
            public static float MinimumVelocity = (float).05;

            /// <summary>
            /// Radius of pool <see cref="Entities.Ball"/>.
            /// </summary>
            public static float Radius = 5.5f;

            /// <summary>
            /// Momentum loss from bouncing off a wall.
            /// </summary>
            public static float WallBounceMomentumLoss = 0;
        }

        public class BallButton
        {
            /// <summary>
            /// Rotation speed of <see cref="Entities.BallButton"/> <see cref="Entities.Ball"/>.
            /// </summary>
            public static float HoverRotationalSpeed = -.4f;
        }

        public class Cue
        {
            /// <summary>
            /// Maximum distance <see cref="Entities.Cue"/> can be dragged away from the cue <see cref="Entities.Ball"/> while striking.
            /// </summary>
            public static int MaximumDistanceFromCueBall = (int)Math.Round((Ball.Radius + 85) * RenderConstants.TileScale());

            /// <summary>
            /// Minimum distance <see cref="Entities.Cue"/> can be dragged away from the cue <see cref="Entities.Ball"/> while striking.
            /// </summary>
            public static int MinimumDistanceFromCueBall = (int)Math.Round((Ball.Radius + 5) * RenderConstants.TileScale());

            /// <summary>
            /// Multiplier from <see cref="Entities.Cue"/> power to <see cref="Entities.Ball"/> speed.
            /// </summary>
            public static float MomentumTransfer = 4;

            /// <summary>
            /// Minimum <see cref="Entities.Cue"/> power to trigger <see cref="Entities.ParticleEmitter"/>.
            /// </summary>
            public static float ParticleMinimumPowerTrigger = 0.85f;

            /// <summary>
            /// <see cref="Entities.Cue"/>'s effect on <see cref="Entities.ParticleEmitter"/> rate.
            /// </summary>
            public static float ParticleRatePerPower = 3f;

            /// <summary>
            /// <see cref="Entities.Cue"/> power effect on <see cref="Render.Filters.Wiggle"/> <see cref="Render.Filters.Animation"/>.
            /// </summary>
            public static int PowerToWiggleAmplitudeScalar = 75;

            /// <summary>
            /// Time the <see cref="Entities.Cue"/> takes to hit the <see cref="Entities.Ball"/>.
            /// </summary>
            public static float StrikingSpeed = 10;

            /// <summary>
            /// Rate of <see cref="Render.Filters.Wiggle"/> <see cref="Render.Filters.Animation"/> frequency.
            /// </summary>
            public static float WiggleFrequency = 800;
        }

        public class Particle
        {
            public class Glimmer
            {
                public static float AlignmentStrength = 0.04f;

                public static float CohesionStrength = 0.005f;

                public static int Lifespan = 50;

                public static float MaximumForce = 0.1f;

                public static float MaximumInitialVelocityScholar = 1.5f;

                public static float MaximumVelocity = 1.5f;

                public static float MinimumInitialVelocityScholar = 0.3f;

                public static float PerceptionRadius = 5f;

                public static float SeparationStrength = 0.08f;
            }

            public class PurpleWisp
            {
                public static float AlignmentStrength = 0.04f;

                public static float CohesionStrength = 0.005f;

                public static int Lifespan = 50;

                public static float MaximumForce = 0.1f;

                public static float MaximumInitialVelocityScholar = 1.5f;

                public static float MaximumVelocity = 1.5f;

                public static float MinimumInitialVelocityScholar = 0.3f;

                public static float PerceptionRadius = 5f;

                public static float SeparationStrength = 0.08f;
            }

            public class Spark
            {
                public static float AlignmentStrength = 0.02f;

                public static float CohesionStrength = 0.03f;

                public static int Lifespan = 50;

                public static float MaximumForce = 0.2f;

                public static float MaximumInitialVelocityScholar = 1.5f;

                public static float MaximumVelocity = 1.5f;

                public static float MinimumInitialVelocityScholar = 0.3f;

                public static float PerceptionRadius = 8f;

                public static float SeparationStrength = 0.04f;
            }

            public class Sparkle
            {
                public static float AlignmentStrength = 0.04f;

                public static float CohesionStrength = 0.005f;

                public static int Lifespan = 50;

                public static float MaximumForce = 0.1f;

                public static float MaximumInitialVelocityScholar = 1.5f;

                public static float MaximumVelocity = 1.5f;

                public static float MinimumInitialVelocityScholar = 0.3f;

                public static float PerceptionRadius = 5f;

                public static float SeparationStrength = 0.08f;
            }
        }

        public class PoolTable
        {
            public static int LipContact = 2;

            /// <summary>
            /// Tile IDs for Pool Table on Building Layer
            /// </summary>
            public static IList<int> TileIdBuilding = new List<int>() { 1447, 1448, 1449, 1450, 1451, 1479, 1480, 1481, 1482, 1483 };

            /// <summary>
            /// Tile IDs for Pool Table on Front Layer
            /// </summary>
            public static IList<int> TileIdFront = new List<int>() { 1415, 1416, 1417, 1418, 1419 };
        }
    }
}