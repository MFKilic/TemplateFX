using UnityEngine;

namespace TemplateFx
{
    public static class NumberExtensions
    {
        private static float Map(float number, float xMin, float xMax, float yMin, float yMax)
        {
            float dx = xMax - xMin;

            if (dx < float.Epsilon)
            {
                return number;
            }

            return yMin + (number - xMin) * (yMax - yMin) / dx;
        }

        /// <summary>
        /// Linear interpolation between float ranges.
        /// </summary>
        /// <param name="number">Given number</param>
        /// <param name="xMin">First range min value</param>
        /// <param name="xMax">First range max value</param>
        /// <param name="yMin">Result range min value</param>
        /// <param name="yMax">Result range max value</param>
        /// <param name="shouldClamp">Should clamp final result</param>
        /// <returns>Remapped final range float number.</returns>
        public static float Remap(this float number, float xMin, float xMax, float yMin, float yMax,
            bool shouldClamp = false)
        {
            var mapped = Map(number, xMin, xMax, yMin, yMax);

            if (shouldClamp)
            {
                mapped = Mathf.Clamp(mapped, yMin, yMax);
            }

            return mapped;
        }

        /// <summary>
        /// Linear interpolation between double ranges.
        /// </summary>
        /// <param name="number">Given number</param>
        /// <param name="xMin">First range min value</param>
        /// <param name="xMax">First range max value</param>
        /// <param name="yMin">Result range min value</param>
        /// <param name="yMax">Result range max value</param>
        /// <param name="shouldClamp">Should clamp final result</param>
        /// <returns>Remapped final range double number.</returns>
        public static double Remap(this double number, double xMin, double xMax, double yMin, double yMax,
            bool shouldClamp = false)
        {
            var mapped = Map((float) number, (float) xMin, (float) xMax, (float) yMin, (float) yMax);

            if (shouldClamp)
            {
                mapped = Mathf.Clamp(mapped, (float) yMin, (float) yMax);
            }

            return mapped;
        }

        /// <summary>
        /// Linear interpolation between int ranges.
        /// </summary>
        /// <param name="number">Given number</param>
        /// <param name="xMin">First range min value</param>
        /// <param name="xMax">First range max value</param>
        /// <param name="yMin">Result range min value</param>
        /// <param name="yMax">Result range max value</param>
        /// <param name="shouldClamp">Should clamp final result</param>
        /// <returns>Remapped final range int number.</returns>
        public static int Remap(this int number, int xMin, int xMax, int yMin, int yMax, bool shouldClamp = false)
        {
            var mapped = (int) Map(number, xMin, xMax, yMin, yMax);

            if (shouldClamp)
            {
                mapped = Mathf.Clamp(mapped, yMin, yMax);
            }

            return mapped;
        }

        public static string CurencyToLadder(this string currencyString)
        {
            float currentCurrency = float.Parse(currencyString);
            float divisonCurrency = currentCurrency;
            float digit = 0;
            string returnCurrencyString;
            if (currentCurrency >= 1000000000)
            {
                divisonCurrency = currentCurrency / 1000000000;
                returnCurrencyString = divisonCurrency.ToString("F1") + "B";
            }
            else if (currentCurrency >= 1000000)
            {
                divisonCurrency = currentCurrency / 1000000;
                returnCurrencyString = divisonCurrency.ToString("F1") + "M";
            }
            else if (currentCurrency >= 1000)
            {
                divisonCurrency = currentCurrency / 100;
                divisonCurrency = Mathf.FloorToInt(divisonCurrency);
                divisonCurrency /= 10;
                digit = (currentCurrency % 1000) / 100;
                if (digit > 1)
                {
                    returnCurrencyString = divisonCurrency.ToString("F1") + "K";
                }
                else
                {
                    returnCurrencyString = divisonCurrency.ToString("F0") + "K";
                }
            }
            else
            {
                returnCurrencyString = divisonCurrency.ToString();
            }
            return returnCurrencyString;
        }
    }
}