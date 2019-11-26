using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public static class Utils
    {
        /** Indicates whether in debug mode */
        private static bool debug = false;

        /**
         * Returns true if the character is a digit
         * 
         * @param c The digit to test
         */
        public static bool isDigit(char c) {
            return (c >= '0' && c <= '9');
        }

        /** Converts a value from one range into a new range. Parameters speak for themselves */
        public static float GetValueInNewRange(float oldValue, float oldMin, float oldMax, float newMin, float newMax) {
            return (((oldValue - oldMin) * (newMax - newMin)) / (oldMax - oldMin) + newMin);
        }

        /**
         * If debug mode set then print the given string else do nothing
         * 
         * @param s The string to print
         */
        public static void PrintDebug(string s) {
            if (debug) {
                Debug.Log(s);
            }
        }
    }
}
