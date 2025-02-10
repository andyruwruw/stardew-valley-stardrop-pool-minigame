using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using MinigameFramework.Constants;
using MinigameFramework.Utilities;
using static MinigameFramework.Constants.GenericTextureConstants;

namespace MinigameFramework.Render
{
    class GenericTextures
    {
        /// <summary>
        /// References to tilesets.
        /// </summary>
        public class Tileset
        {
            public static Texture2D? Default;
        }

        /// <summary>
		/// Loads tilesheets.
		/// </summary>
		public static void LoadTextures()
        {
            Logger.Debug("MinigameFramework: Loading Tilesets");

            Tileset.Default = Game1.content.Load<Texture2D>("Minigames\\MinigameFramework");
        }

        /// <summary>
        /// Retrives font <see cref="Entities.Character"/> texture based on character
        /// </summary>
        /// <param name="orientation">Character to retrieve></param>
        /// <returns>Custom font texture</returns>
        public static Rectangle GetCharacterBoundsFromChar(char character)
        {
            switch (character)
            {
                case 'A':
                    return GenericTextureConstants.Characters.UppercaseA;
                case 'b':
                    return GenericTextureConstants.Characters.LowercaseB;
                case 'B':
                    return GenericTextureConstants.Characters.UppercaseB;
                case 'c':
                    return GenericTextureConstants.Characters.LowercaseC;
                case 'C':
                    return GenericTextureConstants.Characters.UppercaseC;
                case 'd':
                    return GenericTextureConstants.Characters.LowercaseD;
                case 'D':
                    return GenericTextureConstants.Characters.UppercaseD;
                case 'e':
                    return GenericTextureConstants.Characters.LowercaseE;
                case 'E':
                    return GenericTextureConstants.Characters.UppercaseE;
                case 'f':
                    return GenericTextureConstants.Characters.LowercaseF;
                case 'F':
                    return GenericTextureConstants.Characters.UppercaseF;
                case 'g':
                    return GenericTextureConstants.Characters.LowercaseG;
                case 'G':
                    return GenericTextureConstants.Characters.UppercaseG;
                case 'h':
                    return GenericTextureConstants.Characters.LowercaseH;
                case 'H':
                    return GenericTextureConstants.Characters.UppercaseH;
                case 'i':
                    return GenericTextureConstants.Characters.LowercaseI;
                case 'I':
                    return GenericTextureConstants.Characters.UppercaseI;
                case 'j':
                    return GenericTextureConstants.Characters.LowercaseJ;
                case 'J':
                    return GenericTextureConstants.Characters.UppercaseJ;
                case 'k':
                    return GenericTextureConstants.Characters.LowercaseK;
                case 'K':
                    return GenericTextureConstants.Characters.UppercaseK;
                case 'l':
                    return GenericTextureConstants.Characters.LowercaseL;
                case 'L':
                    return GenericTextureConstants.Characters.UppercaseL;
                case 'm':
                    return GenericTextureConstants.Characters.LowercaseM;
                case 'M':
                    return GenericTextureConstants.Characters.UppercaseM;
                case 'n':
                    return GenericTextureConstants.Characters.LowercaseN;
                case 'N':
                    return GenericTextureConstants.Characters.UppercaseN;
                case 'o':
                    return GenericTextureConstants.Characters.LowercaseO;
                case 'O':
                    return GenericTextureConstants.Characters.UppercaseO;
                case 'p':
                    return GenericTextureConstants.Characters.LowercaseP;
                case 'P':
                    return GenericTextureConstants.Characters.UppercaseP;
                case 'q':
                    return GenericTextureConstants.Characters.LowercaseQ;
                case 'Q':
                    return GenericTextureConstants.Characters.UppercaseQ;
                case 'r':
                    return GenericTextureConstants.Characters.LowercaseR;
                case 'R':
                    return GenericTextureConstants.Characters.UppercaseR;
                case 's':
                    return GenericTextureConstants.Characters.LowercaseS;
                case 'S':
                    return GenericTextureConstants.Characters.UppercaseS;
                case 't':
                    return GenericTextureConstants.Characters.LowercaseT;
                case 'T':
                    return GenericTextureConstants.Characters.UppercaseT;
                case 'u':
                    return GenericTextureConstants.Characters.LowercaseU;
                case 'U':
                    return GenericTextureConstants.Characters.UppercaseU;
                case 'v':
                    return GenericTextureConstants.Characters.LowercaseV;
                case 'V':
                    return GenericTextureConstants.Characters.UppercaseV;
                case 'w':
                    return GenericTextureConstants.Characters.LowercaseW;
                case 'W':
                    return GenericTextureConstants.Characters.UppercaseW;
                case 'x':
                    return GenericTextureConstants.Characters.LowercaseX;
                case 'X':
                    return GenericTextureConstants.Characters.UppercaseX;
                case 'y':
                    return GenericTextureConstants.Characters.LowercaseY;
                case 'Y':
                    return GenericTextureConstants.Characters.UppercaseY;
                case 'z':
                    return GenericTextureConstants.Characters.LowercaseZ;
                case 'Z':
                    return GenericTextureConstants.Characters.UppercaseZ;
                case '.':
                    return GenericTextureConstants.Characters.Period;
                case ',':
                    return GenericTextureConstants.Characters.Comma;
                case '!':
                    return GenericTextureConstants.Characters.ExclamationPoint;
                case '?':
                    return GenericTextureConstants.Characters.QuestionMark;
                case '\'':
                    return GenericTextureConstants.Characters.Apostrophe;
                case ':':
                    return GenericTextureConstants.Characters.Colon;
                case 'à':
                    return Characters.LowercaseAGrave;
                case 'À':
                    return Characters.UppercaseAGrave;
                case 'á':
                    return Characters.LowercaseAAcute;
                case 'Á':
                    return Characters.UppercaseAAcute;
                case 'â':
                    return Characters.LowercaseACircumflex;
                case 'Â':
                    return Characters.UppercaseACircumflex;
                case 'ä':
                    return Characters.LowercaseADiaerisis;
                case 'Ä':
                    return Characters.UppercaseADiaerisis;
                case 'æ':
                    return Characters.LowercaseAELigature;
                case 'Æ':
                    return Characters.UppercaseAELigature;
                case 'ç':
                    return Characters.LowercaseCCedilla;
                case 'Ç':
                    return Characters.UppercaseCCedilla;
                case 'é':
                    return Characters.LowercaseEAcute;
                case 'É':
                    return Characters.UppercaseEAcute;
                case 'è':
                    return Characters.LowercaseEGrave;
                case 'È':
                    return Characters.UppercaseEGrave;
                case 'ê':
                    return Characters.LowercaseECircumflex;
                case 'Ê':
                    return Characters.UppercaseECircumflex;
                case 'ë':
                    return Characters.LowercaseEDiaerisis;
                case 'Ë':
                    return Characters.UppercaseEDiaerisis;
                case 'ì':
                    return Characters.LowercaseIGrave;
                case 'Ì':
                    return Characters.UppercaseIGrave;
                case 'í':
                    return Characters.LowercaseIAcute;
                case 'Í':
                    return Characters.UppercaseIAcute;
                case 'î':
                    return Characters.LowercaseICircumflex;
                case 'Î':
                    return Characters.UppercaseICircumflex;
                case 'ï':
                    return Characters.LowercaseIDiaerisis;
                case 'Ï':
                    return Characters.UppercaseIDiaerisis;
                case 'ó':
                    return Characters.LowercaseOAcute;
                case 'Ó':
                    return Characters.UppercaseOAcute;
                case 'ò':
                    return Characters.LowercaseOGrave;
                case 'Ò':
                    return Characters.UppercaseOGrave;
                case 'ô':
                    return Characters.LowercaseOCircumflex;
                case 'Ô':
                    return Characters.UppercaseOCircumflex;
                case 'ö':
                    return Characters.LowercaseODiaerisis;
                case 'Ö':
                    return Characters.UppercaseODiaerisis;
                case 'ú':
                    return Characters.LowercaseUAcute;
                case 'Ú':
                    return Characters.UppercaseUAcute;
                case 'ù':
                    return Characters.LowercaseUGrave;
                case 'Ù':
                    return Characters.UppercaseUGrave;
                case 'û':
                    return Characters.LowercaseUCircumflex;
                case 'Û':
                    return Characters.UppercaseUCircumflex;
                case 'ü':
                    return Characters.LowercaseUDiaerisis;
                case 'Ü':
                    return Characters.UppercaseUDiaerisis;
                case 'ÿ':
                    return Characters.LowercaseYDiaerisis;
                case '':
                    return Characters.UppercaseYDiaerisis;
                case 'ß':
                    return Characters.Eszett;
                case 'ñ':
                    return Characters.LowercaseNTilde;
                case 'Ñ':
                    return Characters.UppercaseNTilde;
                case '¿':
                    return Characters.InvertedQuestionMark;
                default:
                    return GenericTextureConstants.Characters.LowercaseA;
            }
        }
        
        /// <summary>
        /// Retrieves the center of the screen.
        /// </summary>
        public static Vector2 GetMinigameScreenCenter() {
            return new Vector2(
                GenericRenderConstants.MinigameScreen.Width / 2,
                GenericRenderConstants.MinigameScreen.Height / 2
            );
        }
    }
}
