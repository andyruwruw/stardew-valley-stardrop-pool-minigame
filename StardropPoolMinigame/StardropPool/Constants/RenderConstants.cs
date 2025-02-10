using MinigameFramework.Constants;

namespace StardopPoolMinigame.Constants
{
    static class RenderConstants
    {
        public static class MainMenuScene
        {
            public static class Portraits
            {
                public static float TopMargin = TextureConstants.BarShelves.Height - GenericTextureConstants.Portrait.Sam.Default.Height;

                public static float Gap = GenericTextureConstants.Portrait.Sam.Default.Width;
            }

            public static class Buttons
            {
                public static float TopMargin = (((GenericRenderConstants.MinigameScreen.Height - TextureConstants.BarShelves.Height) - (GenericRenderConstants.Font.CharacterHeight * 4)  - RenderConstants.MainMenuScene.Buttons.Gap * 3) + TextureConstants.BarShelves.Height);

                public static float Gap = 4f;

                public static float Height = GenericRenderConstants.Font.CharacterHeight + RenderConstants.MainMenuScene.Buttons.Gap;
            }

            public static class  GameTitle
            {
                public static float TopMargin = 6f;
            }
        }

        public static class Entities
        {
            public class Ball
            {
                public static float MarginLeft = 1f;

                public static float MarginTop = 0f;
            }

            public static class BallButton
            {
                public static float InnerPadding = 12f;

                public static float LeftOffset = 4f;
            }

            public class Particle
            {
                public class Spark
                {
                    public static int FrameDuration = 4;

                    public static int Frames = 3;

                    public static float MarginLeft = 3f;

                    public static float MarginTop = 3f;
                }
            }

            public class PortraitFire
            {
                public static int FrameDuration = 4;

                public static int Frames = 8;
            }

            public class TableSegment
            {
                public static int AngledPocketBareEdgeLength = 6;

                public static int AngledPocketBorderOffset = 3;

                public static int Border = 10;

                public static int FlatPocketBareEdgeLength = 3;

                public static int FlatPocketBorderOffset = -2;

                public static int Lip = 5;

                public static int Margin = 3;

                public static int PassableLip = 2;

                public static int PocketAngledEdgeHeight = 3;

                public static int PocketRadius = 7;

                public static int UnpassableLip = 3;

                public static int SpaceToBounceableSurface = Margin + Border + UnpassableLip;

                public static int VerticalPocketStraightEdgeHeight = 2;
            }
        }
    }
}





