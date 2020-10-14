﻿#region Imports

using System;
using System.Drawing;
using static Conforyon.Conforyon;

#endregion

namespace Conforyon
{
    /// <summary>
    /// 
    /// </summary>
    public static class Color
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Hex"></param>
        /// <param name="Type"></param>
        /// <param name="Error"></param>
        /// <returns></returns>
        public static string HEXtoRGB(string Hex, ColorType Type = ColorType.RGB1, string Error = ErrorMessage)
        {
            try
            {
                if ((Hex.Length == 6 && UseCheck(Hex)) || (Hex.Length == 7 && Hex.StartsWith("#") && UseCheck(Hex.Substring(1, Hex.Length - 1))))
                {
                    System.Drawing.Color HexColor;
                    if (Hex.StartsWith("#"))
                        HexColor = ColorTranslator.FromHtml(Hex);
                    else
                        HexColor = ColorTranslator.FromHtml("#" + Hex);
                    switch (Type)
                    {
                        case ColorType.RGB1:
                            return HexColor.R + ", " + HexColor.G + ", " + HexColor.B;
                        case ColorType.RGB2:
                            return HexColor.R + " " + HexColor.G + " " + HexColor.B;
                        case ColorType.RGB3:
                            return HexColor.R + " - " + HexColor.G + " - " + HexColor.B;
                        case ColorType.RRGGBB1:
                            return "R: " + HexColor.R + ", G: " + HexColor.G + ", B: " + HexColor.B;
                        case ColorType.RRGGBB2:
                            return "R: " + HexColor.R + " G: " + HexColor.G + " B: " + HexColor.B;
                        case ColorType.RRGGBB3:
                            return "R: " + HexColor.R + " - G: " + HexColor.G + " - B: " + HexColor.B;
                        case ColorType.RR:
                            return "R: " + HexColor.R;
                        case ColorType.GG:
                            return "G: " + HexColor.G;
                        case ColorType.BB:
                            return "B: " + HexColor.B;
                        case ColorType.OnlyR:
                            return HexColor.R.ToString();
                        case ColorType.OnlyG:
                            return HexColor.G.ToString();
                        case ColorType.OnlyB:
                            return HexColor.B.ToString();
                        default:
                            return Error;
                    }
                }
                else
                    return Error;
            }
            catch
            {
                return Error + ErrorTitle + "CR-HTR1!)";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="R"></param>
        /// <param name="G"></param>
        /// <param name="B"></param>
        /// <param name="Sharp"></param>
        /// <param name="Error"></param>
        /// <returns></returns>
        public static string RGBtoHEX(int R, int G, int B, bool Sharp = false, string Error = ErrorMessage)
        {
            try
            {
                if (R <= 255 && R >= 0 && G <= 255 && G >= 0 && B <= 255 && B >= 0)
                {
                    System.Drawing.Color RGBColor = System.Drawing.Color.FromArgb(Convert.ToInt32(R), Convert.ToInt32(G), Convert.ToInt32(B));
                    if (Sharp)
                        return "#" + RGBColor.R.ToString("X2") + RGBColor.G.ToString("X2") + RGBColor.B.ToString("X2");
                    else
                        return RGBColor.R.ToString("X2") + RGBColor.G.ToString("X2") + RGBColor.B.ToString("X2");
                }
                else
                    return Error;
            }
            catch
            {
                return Error + ErrorTitle + "CR-RTH1!)";
            }
        }
    }
}