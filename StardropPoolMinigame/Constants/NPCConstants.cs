namespace StardropPoolMinigame.Constants
{
    /// <summary>
    /// <see cref="Players.ComputerOpponent"/> AI values.
    /// </summary>
    internal class NPCConstants
    {
        /// <summary>
        /// <see cref="Players.Abigail"/> AI values.
        /// </summary>
        public class Abigail
        {
            /// <summary>
            /// <see cref="Players.ComputerOpponent"/> accuracy when picking a <see cref="Cue"/> angle to take a shot.
            /// </summary>
            public static int AngleAccuracy = 1;

            /// <summary>
            /// <see cref="Players.ComputerOpponent"/> ability to check for combo / complex shots.
            /// </summary>
            public static int Complexity = 1;

            /// <summary>
            /// <see cref="Players.ComputerOpponent"/> desire to take difficult shots.
            /// </summary>
            public static int Confidence = 1;

            /// <summary>
            /// <see cref="Players.ComputerOpponent"/> accuracy when picking a <see cref="Cue"/> power to take a shot.
            /// </summary>
            public static int PowerAccuracy = 1;
        }

        /// <summary>
        /// <see cref="Players.Gus"/> AI values.
        /// </summary>
        public class Gus
        {
            /// <inheritdoc cref="Abigail.AngleAccuracy"/>
            public static int AngleAccuracy = 1;

            /// <inheritdoc cref="Abigail.Complexity"/>
            public static int Complexity = 1;

            /// <inheritdoc cref="Abigail.Confidence"/>
            public static int Confidence = 1;

            /// <inheritdoc cref="Abigail.PowerAccuracy"/>
            public static int PowerAccuracy = 1;
        }

        /// <summary>
        /// <see cref="Players.Sam"/> AI values.
        /// </summary>
        public class Sam
        {
            /// <inheritdoc cref="Abigail.AngleAccuracy"/>
            public static int AngleAccuracy = 1;

            /// <inheritdoc cref="Abigail.Complexity"/>
            public static int Complexity = 1;

            /// <inheritdoc cref="Abigail.Confidence"/>
            public static int Confidence = 1;

            /// <inheritdoc cref="Abigail.PowerAccuracy"/>
            public static int PowerAccuracy = 1;
        }

        /// <summary>
        /// <see cref="Players.Sebastian"/> AI values.
        /// </summary>
        public class Sebastian
        {
            /// <inheritdoc cref="Abigail.AngleAccuracy"/>
            public static int AngleAccuracy = 1;

            /// <inheritdoc cref="Abigail.Complexity"/>
            public static int Complexity = 1;

            /// <inheritdoc cref="Abigail.Confidence"/>
            public static int Confidence = 1;

            /// <inheritdoc cref="Abigail.PowerAccuracy"/>
            public static int PowerAccuracy = 1;
        }
    }
}