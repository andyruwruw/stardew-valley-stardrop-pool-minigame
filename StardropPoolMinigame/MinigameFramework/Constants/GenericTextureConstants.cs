using Microsoft.Xna.Framework;

namespace MinigameFramework.Constants
{
    /// <summary>
    /// Locations of textures.
    /// </summary>
    static class GenericTextureConstants
    {
        /// <summary>
        /// Bounds for all font <see cref="Entities.Character">Characters</see>
        /// </summary>
        public class Characters
        {
            public static Rectangle LowercaseA = new Rectangle(
                0,
                0,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseA = new Rectangle(
                LowercaseA.X + LowercaseA.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                0,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseB = new Rectangle(
                UppercaseA.X + UppercaseA.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                0,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseB = new Rectangle(
                LowercaseB.X + LowercaseB.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                0,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseC = new Rectangle(
                UppercaseB.X + UppercaseB.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                0,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseC = new Rectangle(
                LowercaseC.X + LowercaseC.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                0,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseD = new Rectangle(
                UppercaseC.X + UppercaseC.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                0,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseD = new Rectangle(
                LowercaseD.X + LowercaseD.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                0,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseE = new Rectangle(
                UppercaseD.X + UppercaseD.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                0,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseE = new Rectangle(
                LowercaseE.X + LowercaseE.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                0,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseF = new Rectangle(
                UppercaseE.X + UppercaseE.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                0,
                5,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseF = new Rectangle(
                LowercaseF.X + LowercaseF.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                0,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseG = new Rectangle(
                UppercaseF.X + UppercaseF.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                0,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseG = new Rectangle(
                LowercaseG.X + LowercaseG.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                0,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseH = new Rectangle(
                UppercaseG.X + UppercaseG.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                0,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseH = new Rectangle(
                LowercaseH.X + LowercaseH.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                0,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseI = new Rectangle(
                UppercaseH.X + UppercaseH.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                0,
                2,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseI = new Rectangle(
                LowercaseI.X + LowercaseI.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                0,
                6,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseJ = new Rectangle(
                UppercaseI.X + UppercaseI.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                0,
                4,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseJ = new Rectangle(
                0,
                GenericRenderConstants.Font.CharacterHeight,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseK = new Rectangle(
                UppercaseJ.X + UppercaseJ.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight,
                6,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseK = new Rectangle(
                LowercaseK.X + LowercaseK.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseL = new Rectangle(
                UppercaseK.X + UppercaseK.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight,
                2,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseL = new Rectangle(
                LowercaseL.X + LowercaseL.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseM = new Rectangle(
                UppercaseL.X + UppercaseL.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseM = new Rectangle(
                LowercaseM.X + LowercaseM.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseN = new Rectangle(
                UppercaseM.X + UppercaseM.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight,
                6,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseN = new Rectangle(
                LowercaseN.X + LowercaseN.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseO = new Rectangle(
                UppercaseN.X + UppercaseN.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseO = new Rectangle(
                LowercaseO.X + LowercaseO.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseP = new Rectangle(
                UppercaseO.X + UppercaseO.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseP = new Rectangle(
                LowercaseP.X + LowercaseP.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseQ = new Rectangle(
                UppercaseP.X + UppercaseP.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseQ = new Rectangle(
                LowercaseQ.X + LowercaseQ.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseR = new Rectangle(
                UppercaseQ.X + UppercaseQ.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight,
                5,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseR = new Rectangle(
                LowercaseR.X + LowercaseR.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseS = new Rectangle(
                UppercaseR.X + UppercaseR.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseS = new Rectangle(
                LowercaseS.X + LowercaseS.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseT = new Rectangle(
                0,
                GenericRenderConstants.Font.CharacterHeight * 2,
                5,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseT = new Rectangle(
                LowercaseT.X + LowercaseT.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 2,
                6,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseU = new Rectangle(
                UppercaseT.X + UppercaseT.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 2,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseU = new Rectangle(
                LowercaseU.X + LowercaseU.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 2,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseV = new Rectangle(
                UppercaseU.X + UppercaseU.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 2,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseV = new Rectangle(
                LowercaseV.X + LowercaseV.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 2,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseW = new Rectangle(
                UppercaseV.X + UppercaseV.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 2,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseW = new Rectangle(
                LowercaseW.X + LowercaseW.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 2,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseX = new Rectangle(
                UppercaseW.X + UppercaseW.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 2,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseX = new Rectangle(
                LowercaseX.X + LowercaseX.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 2,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseY = new Rectangle(
                UppercaseX.X + UppercaseX.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 2,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseY = new Rectangle(
                LowercaseY.X + LowercaseY.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 2,
                6,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseZ = new Rectangle(
                UppercaseY.X + UppercaseY.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 2,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseZ = new Rectangle(
                LowercaseZ.X + LowercaseZ.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 2,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle Period = new Rectangle(
                UppercaseZ.X + UppercaseZ.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 2,
                2,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle Comma = new Rectangle(
                Period.X + Period.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 2,
                3,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle ExclamationPoint = new Rectangle(
                Comma.X + Comma.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 2,
                2,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle QuestionMark = new Rectangle(
                ExclamationPoint.X + ExclamationPoint.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 2,
                6,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle Apostrophe
                = new Rectangle(
                    QuestionMark.X + QuestionMark.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                    GenericRenderConstants.Font.CharacterHeight * 2,
                    2,
                    GenericRenderConstants.Font.CharacterHeight
                );

            public static Rectangle Colon = new Rectangle(
                Apostrophe.X + Apostrophe.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 2,
                2,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseAGrave = new Rectangle(
                Colon.X + Colon.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 2,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseAGrave = new Rectangle(
                0,
                GenericRenderConstants.Font.CharacterHeight * 3,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseAAcute = new Rectangle(
                UppercaseAGrave.X + UppercaseAGrave.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 3,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseAAcute = new Rectangle(
                LowercaseAAcute.X + LowercaseAAcute.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 3,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseACircumflex = new Rectangle(
                UppercaseAAcute.X + UppercaseAAcute.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 3,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseACircumflex = new Rectangle(
                LowercaseACircumflex.X + LowercaseACircumflex.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 3,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseADiaerisis = new Rectangle(
                UppercaseACircumflex.X + UppercaseACircumflex.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 3,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseADiaerisis = new Rectangle(
                LowercaseADiaerisis.X + LowercaseADiaerisis.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 3,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseAELigature = new Rectangle(
                UppercaseADiaerisis.X + UppercaseADiaerisis.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 3,
                12,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseAELigature = new Rectangle(
                LowercaseAELigature.X + LowercaseAELigature.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 3,
                11,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseCCedilla = new Rectangle(
                UppercaseAELigature.X + UppercaseAELigature.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 3,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseCCedilla = new Rectangle(
                LowercaseCCedilla.X + LowercaseCCedilla.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 3,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseEAcute = new Rectangle(
                UppercaseCCedilla.X + UppercaseCCedilla.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 3,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseEAcute = new Rectangle(
                LowercaseEAcute.X + LowercaseEAcute.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 3,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseEGrave = new Rectangle(
                UppercaseEAcute.X + UppercaseEAcute.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 3,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseEGrave = new Rectangle(
                LowercaseEGrave.X + LowercaseEGrave.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 3,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseECircumflex = new Rectangle(
                UppercaseEGrave.X + UppercaseEGrave.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 3,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseECircumflex = new Rectangle(
                LowercaseECircumflex.X + LowercaseECircumflex.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 3,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseEDiaerisis = new Rectangle(
                0,
                GenericRenderConstants.Font.CharacterHeight * 4,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseEDiaerisis = new Rectangle(
                LowercaseEDiaerisis.X + LowercaseEDiaerisis.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 4,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseIGrave = new Rectangle(
                UppercaseEDiaerisis.X + UppercaseEDiaerisis.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 4,
                2,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseIGrave = new Rectangle(
                LowercaseIGrave.X + LowercaseIGrave.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 4,
                6,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseIAcute = new Rectangle(
                UppercaseIGrave.X + UppercaseIGrave.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 4,
                2,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseIAcute = new Rectangle(
                LowercaseIAcute.X + LowercaseIAcute.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 4,
                6,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseICircumflex = new Rectangle(
                UppercaseIAcute.X + UppercaseIAcute.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 4,
                3,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseICircumflex = new Rectangle(
                LowercaseICircumflex.X + LowercaseICircumflex.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 4,
                6,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseIDiaerisis = new Rectangle(
                UppercaseICircumflex.X + UppercaseICircumflex.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 4,
                4,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseIDiaerisis = new Rectangle(
                LowercaseIDiaerisis.X + LowercaseIDiaerisis.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 4,
                6,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseOAcute = new Rectangle(
                UppercaseIDiaerisis.X + UppercaseIDiaerisis.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 4,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseOAcute = new Rectangle(
                LowercaseOAcute.X + LowercaseOAcute.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 4,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseOGrave = new Rectangle(
                UppercaseOAcute.X + UppercaseOAcute.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 4,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseOGrave = new Rectangle(
                LowercaseOGrave.X + LowercaseOGrave.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 4,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseOCircumflex = new Rectangle(
                UppercaseOGrave.X + UppercaseOGrave.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 4,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseOCircumflex = new Rectangle(
                LowercaseOCircumflex.X + LowercaseOCircumflex.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 4,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseODiaerisis = new Rectangle(
                UppercaseOCircumflex.X + UppercaseOCircumflex.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 4,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseODiaerisis = new Rectangle(
                LowercaseODiaerisis.X + LowercaseODiaerisis.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 4,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseOELigature = new Rectangle(
                UppercaseODiaerisis.X + UppercaseODiaerisis.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 4,
                12,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseOELigature = new Rectangle(
                0,
                GenericRenderConstants.Font.CharacterHeight * 5,
                12,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseUAcute = new Rectangle(
                UppercaseOELigature.X + UppercaseOELigature.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 5,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseUAcute = new Rectangle(
                LowercaseUAcute.X + LowercaseUAcute.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 5,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseUGrave = new Rectangle(
                UppercaseUAcute.X + UppercaseUAcute.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 5,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseUGrave = new Rectangle(
                LowercaseUGrave.X + LowercaseUGrave.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 5,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseUCircumflex = new Rectangle(
                UppercaseUGrave.X + UppercaseUGrave.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 5,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseUCircumflex = new Rectangle(
                LowercaseUCircumflex.X + LowercaseUCircumflex.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 5,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseUDiaerisis = new Rectangle(
                UppercaseUCircumflex.X + UppercaseUCircumflex.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 5,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseUDiaerisis = new Rectangle(
                LowercaseUDiaerisis.X + LowercaseUDiaerisis.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 5,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseYDiaerisis = new Rectangle(
                UppercaseUDiaerisis.X + UppercaseUDiaerisis.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 5,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseYDiaerisis = new Rectangle(
                LowercaseYDiaerisis.X + LowercaseYDiaerisis.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 5,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle Eszett = new Rectangle(
                UppercaseYDiaerisis.X + UppercaseYDiaerisis.Width +
                GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 5,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle LowercaseNTilde = new Rectangle(
                Eszett.X + Eszett.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 5,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle UppercaseNTilde = new Rectangle(
                LowercaseNTilde.X + LowercaseNTilde.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 5,
                7,
                GenericRenderConstants.Font.CharacterHeight
            );

            public static Rectangle InvertedQuestionMark = new Rectangle(
                UppercaseNTilde.X + UppercaseNTilde.Width + GenericRenderConstants.Font.SpaceBetweenCharactersOnTileset,
                GenericRenderConstants.Font.CharacterHeight * 5,
                6,
                GenericRenderConstants.Font.CharacterHeight
            );
        }

        /// <summary>
        /// Static <see cref="Microsoft.Xna.Framework.Color"/> values
        /// </summary>
        public class Color
        {
            public class Shader
            {
                public static Microsoft.Xna.Framework.Color Shadow = new Microsoft.Xna.Framework.Color(
                    0,
                    0,
                    0,
                    100
                );

                public static Microsoft.Xna.Framework.Color Shadowed = new Microsoft.Xna.Framework.Color(
                    50,
                    50,
                    50
                );
            }

            public class Solid
            {
                public static Microsoft.Xna.Framework.Color Background = new Microsoft.Xna.Framework.Color(
                    0.01f,
                    0.01f,
                    0.01f
                );

                public static Microsoft.Xna.Framework.Color Disabled = new Microsoft.Xna.Framework.Color(
                    50,
                    50,
                    5
                );

                public static Microsoft.Xna.Framework.Color HoverAccent = new Microsoft.Xna.Framework.Color(
                    255,
                    217,
                    104
                );

                public static Microsoft.Xna.Framework.Color Margin = new Microsoft.Xna.Framework.Color(
                    5,
                    3,
                    4
                );
            }
        }

        /// <summary>
		/// Bounds for all <see cref="Entities.Portrait"/> characters and emotions
		/// </summary>
		public class Portrait
        {
            public class Abigail
            {
                public static Rectangle Blush = new Rectangle(
                    0,
                    GenericRenderConstants.TileSize * 8,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );

                public static Rectangle Confused = new Rectangle(
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );

                public static Rectangle Default =
                    new Rectangle(
                        0,
                        0,
                        GenericRenderConstants.TileSize * 4,
                        GenericRenderConstants.TileSize * 4
                    );

                public static Rectangle Glare = new Rectangle(
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 8,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );

                public static Rectangle Laugh = new Rectangle(
                    GenericRenderConstants.TileSize * 4,
                    0,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );

                public static Rectangle Sad = new Rectangle(
                    0,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );

                public static Rectangle Suprised = new Rectangle(
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 12,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );
            }

            public class Gus
            {
                public static Rectangle Blush = new Rectangle(
                    0,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );

                public static Rectangle Default =
                    new Rectangle(
                        0,
                        0,
                        GenericRenderConstants.TileSize * 4,
                        GenericRenderConstants.TileSize * 4
                    );

                public static Rectangle Glare = new Rectangle(
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );

                public static Rectangle Laugh = new Rectangle(
                    GenericRenderConstants.TileSize * 4,
                    0,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );
            }

            public class Sam
            {
                public static Rectangle Default =
                    new Rectangle(
                        0,
                        0,
                        GenericRenderConstants.TileSize * 4,
                        GenericRenderConstants.TileSize * 4
                    );

                public static Rectangle Embarassed = new Rectangle(
                    0,
                    GenericRenderConstants.TileSize * 20,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );

                public static Rectangle Frustrated = new Rectangle(
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );

                public static Rectangle Glare = new Rectangle(
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 8,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );

                public static Rectangle Laugh = new Rectangle(
                    GenericRenderConstants.TileSize * 4,
                    0,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );

                public static Rectangle Oops = new Rectangle(
                    0,
                    GenericRenderConstants.TileSize * 8,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );

                public static Rectangle Sad = new Rectangle(
                    0,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );

                public static Rectangle SHOCK = new Rectangle(
                    0,
                    GenericRenderConstants.TileSize * 16,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );

                public static Rectangle STRAIGHT_FACE = new Rectangle(
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 12,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );
            }

            public class Sebastian
            {
                public static Rectangle Blush = new Rectangle(
                    0,
                    GenericRenderConstants.TileSize * 8,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );

                public static Rectangle Default =
                    new Rectangle(
                        0,
                        0,
                        GenericRenderConstants.TileSize * 4,
                        GenericRenderConstants.TileSize * 4
                    );

                public static Rectangle Glad = new Rectangle(
                    GenericRenderConstants.TileSize * 4,
                    0,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );

                public static Rectangle Glare = new Rectangle(
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 8,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );

                public static Rectangle Sad = new Rectangle(
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );

                public static Rectangle Smurk = new Rectangle(
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 12,
                    GenericRenderConstants.TileSize * 4,
                    GenericRenderConstants.TileSize * 4
                );
            }
        }
    }
}
