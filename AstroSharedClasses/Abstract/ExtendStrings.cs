// <copyright file="ExtendStrings.cs" company="J.K.R.">
// Copyright (c) 2012 All Right Reserved
// </copyright>
// <author></author>
// <email></email>
// <date>2009-02-01</date>
// <summary>ExtendStrings</summary>

namespace AstroSharedClasses.Abstract {
    using JetBrains.Annotations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Provides some essential extension methods for the string class.
    /// </summary>
    public static class ExtendStrings {
        //// FULL DISCLOSURE - I found this method on StackOverflow, but I neglected to make 
        //// note of the person that posted it. I only changed it to match my formatting style.

        #region Strings
        /// <summary>
        /// Right givenNumber characters of given string.
        /// </summary>
        /// <param name="value">Given Value.</param>
        /// <param name="givenNumber">Given Number.</param>
        /// <returns>Returns string value.</returns>
        [Pure]
        public static string Right(this string value, int givenNumber) {
            if (givenNumber <= 0 || value == null) {
                return string.Empty;
            }

            return givenNumber >= value.Length ? value : value.Substring(value.Length - givenNumber);
        }

        /// <summary>
        /// Lefts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="givenNumber">The given number.</param>
        /// <returns>Returns string value.</returns>
        [UsedImplicitly]
        public static string Left(this string value, int givenNumber) {
            if (givenNumber <= 0 || value == null) {
                return string.Empty;
            }

            return givenNumber >= value.Length ? value : value.Substring(0, givenNumber);
        }

        /// <summary>
        /// Clear Special Chars.
        /// </summary>
        /// <param name="value">String value.</param>
        /// <returns> Returns value. </returns>
        [Pure]
        [UsedImplicitly]
        public static string ClearSpecialChars(this string value) {
            var sb = new StringBuilder(value);
            sb.Replace("?", string.Empty);
            sb.Replace('(', '_');
            sb.Replace(')', '_');
            sb.Replace('/', '_');
            sb.Replace('*', '_');
            sb.Replace('#', '_');
            sb.Replace("*", "_");
            sb.Replace(".", "_");
            sb.Replace(",", "_");
            sb.Replace("-", "_");
            sb.Replace(" ", string.Empty);
            sb.Replace("__", "_");
            return sb.ToString();
        }
        #endregion

        /// <summary>
        /// Determines whether this string is "like" the specified string. Performs a SQL "LIKE"
        /// comparison.
        /// </summary>
        /// <param name="str">This string.</param>
        /// <param name="pattern">The pattern.</param>
        /// <returns>
        /// True if the string is like the specified pattern
        /// </returns>
        /// <remarks>
        /// Full disclosure - I got this method off StackOverflow, but I do not recall the
        /// name of the guy that posted it in response to a question.
        /// </remarks>
        [UsedImplicitly]
        public static bool IsLike(this string str, string pattern) {
            // This code is much faster than a regular expression that performs the 
            // same comparison.
            bool isMatch = true;
            bool isWildCardOn = false;
            bool isCharWildCardOn = false;
            bool isCharSetOn = false;
            bool isNotCharSetOn = false;
            bool endOfPattern;
            int lastWildCard = -1;
            int patternIndex = 0;
            char p = '\0';
            List<char> set = new List<char>();

            // ReSharper disable once ForCanBeConvertedToForeach
            for (int i = 0; i < str.Length; i++) {
                char c = str[i];
                endOfPattern = patternIndex >= pattern.Length;
                if (!endOfPattern) {
                    p = pattern[patternIndex];
                    if (!isWildCardOn && p == '%') {
                        lastWildCard = patternIndex;
                        isWildCardOn = true;
                        while (patternIndex < pattern.Length && pattern[patternIndex] == '%') {
                            patternIndex++;
                        }

                        p = (patternIndex >= pattern.Length) ? '\0' : pattern[patternIndex];
                    }
                    else if (p == '_') {
                        isCharWildCardOn = true;
                        patternIndex++;
                    }
                    else if (p == '[') {
                        if (pattern[++patternIndex] == '^') {
                            isNotCharSetOn = true;
                            patternIndex++;
                        }
                        else {
                            isCharSetOn = true;
                        }

                        set.Clear();
                        if (pattern[patternIndex + 1] == '-' && pattern[patternIndex + 3] == ']') {
                            char start = char.ToUpper(pattern[patternIndex]);
                            patternIndex += 2;
                            char end = char.ToUpper(pattern[patternIndex]);
                            if (start <= end) {
                                for (char ci = start; ci <= end; ci++) {
                                    set.Add(ci);
                                }
                            }

                            patternIndex++;
                        }

                        while (patternIndex < pattern.Length && pattern[patternIndex] != ']') {
                            set.Add(pattern[patternIndex]);
                            patternIndex++;
                        }

                        patternIndex++;
                    }
                }

                if (isWildCardOn) {
                    if (char.ToUpper(c) == char.ToUpper(p)) {
                        isWildCardOn = false;
                        patternIndex++;
                    }
                }
                else if (isCharWildCardOn) {
                    isCharWildCardOn = false;
                }
                else if (isCharSetOn || isNotCharSetOn) {
                    bool charMatch = set.Contains(char.ToUpper(c));
                    if ((isNotCharSetOn && charMatch) || (isCharSetOn && !charMatch)) {
                        if (lastWildCard >= 0) {
                            patternIndex = lastWildCard;
                        }
                        else {
                            isMatch = false;
                            break;
                        }
                    }

                    isNotCharSetOn = isCharSetOn = false;
                }
                else {
                    if (char.ToUpper(c) == char.ToUpper(p)) {
                        patternIndex++;
                    }
                    else {
                        if (lastWildCard >= 0) {
                            patternIndex = lastWildCard;
                        }
                        else {
                            isMatch = false;
                            break;
                        }
                    }
                }
            }

            endOfPattern = patternIndex >= pattern.Length;

            if (isMatch && !endOfPattern) {
                bool isOnlyWildCards = true;
                for (int i = patternIndex; i < pattern.Length; i++) {
                    if (pattern[i] != '%') {
                        isOnlyWildCards = false;
                        break;
                    }
                }

                if (isOnlyWildCards) {
                    endOfPattern = true;
                }
            }

            return isMatch && endOfPattern;
        }

        /// <summary>
        /// Reverses the string
        /// </summary>
        /// <param name="text">The string to be reversed</param>
        /// <returns>
        /// The reversed string
        /// </returns>
        [UsedImplicitly]
        public static string ReverseText(this string text) {
            if (!string.IsNullOrEmpty(text)) {
                int pivotPos = text.Length / 2;
                for (int i = 0; i < pivotPos; i++) {
                    text = text.Insert(text.Length - i, text.Substring(i, 1)).Remove(i, 1);
                    text = text.Insert(i, text.Substring(text.Length - (i + 2), 1)).Remove(text.Length - (i + 1), 1);
                }
            }

            return text;
        }

        /// <summary>
        /// Determines whether the string is a substring of the specified container
        /// </summary>
        /// <param name="str">The string to be checked</param>
        /// <param name="container">A comma-delimited string containing interesting values</param>
        /// <returns>
        /// True if the string is in the container
        /// </returns>
        [UsedImplicitly]
        public static bool IsInExact(this string str, string container) {
            //// split the container into its component parts
            string[] parts = container.Split(',');
            //// look for a match
            var result = parts.FirstOrDefault(x => x == str);
            //// return the results
            return result != null;
        }

        /// <summary>
        /// Starts the with single double quote.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>Returns value.</returns>
        public static bool StartsWithSingleDoubleQuote(this string text) {
            bool result;
            switch (text.Length) {
                case 0: result = false; 
                    break;

                case 1:

                case 2:

                case 3: result = text[0] == '"'; 
                    break;
                default: result = text.StartsWith("\"") && text[1] != '"'; 
                    break;
            }

            return result;
        }

        /// <summary>
        /// Ends with single double quote.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>Returns value.</returns>
        public static bool EndsWithSingleDoubleQuote(this string text) {
            bool result;
            switch (text.Length) {
                case 0:
                case 1:
                case 2:
                case 3: result = false; 
                    break;
                default: result = text.EndsWith("\"") && text[text.Length - 2] != '"'; 
                    break;
            }

            return result;
        }

        /// <summary>
        /// Escaped with quotes.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>
        /// Returns value.
        /// </returns>
        [UsedImplicitly]
        public static bool EscapedWithQuotes(this string text) {
            bool result = text.StartsWithSingleDoubleQuote() && text.EndsWithSingleDoubleQuote();
            return result;
        }

        /// <summary>
        /// Determines whether [is probably string].
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public static bool IsProbablyString(this string text) {
            text = text.Trim().Replace("$", string.Empty).Replace(",", string.Empty);
#pragma warning disable IDE0018 // Vložená deklarace proměnné
            int i;
#pragma warning restore IDE0018 // Vložená deklarace proměnné
#pragma warning disable IDE0018 // Vložená deklarace proměnné
            double d;
#pragma warning restore IDE0018 // Vložená deklarace proměnné
#pragma warning disable IDE0018 // Vložená deklarace proměnné
            DateTime date;
#pragma warning restore IDE0018 // Vložená deklarace proměnné
            bool result = !string.IsNullOrEmpty(text) && !int.TryParse(text, out i) && !double.TryParse(text, out d) && !DateTime.TryParse(text, out date);
            return result;
        }

        /// <summary>
        /// Determines whether [is quoted string].
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public static bool IsQuotedString(this string text) {
            return text.StartsWithSingleDoubleQuote() && text.EndsWithSingleDoubleQuote();
        }

        /// <summary>
        /// Lasts the available slot.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public static int LastAvailableSlot(this List<string> list) {
            int index = -1;
            int count = list.Count(string.IsNullOrEmpty);
            if (count > 0) {
                for (int i = list.Count - 1; i >= 0; i--) {
                    if (string.IsNullOrEmpty(list[i])) {
                        index = i;
                        break;
                    }
                }
            }

            return index;
        }

        /// <summary>
        /// Firsts the available slot.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public static int FirstAvailableSlot(this List<string> list) {
            int index = -1;
            int count = list.Count(string.IsNullOrEmpty);
            if (count > 0) {
                for (int i = 0; i < list.Count; i++) {
                    if (string.IsNullOrEmpty(list[i])) {
                        index = i;
                        break;
                    }
                }
            }

            return index;
        }

        /// <summary>
        /// Available slots.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public static int AvailableSlots(this List<string> list) {
            int count = list.Count(string.IsNullOrEmpty);
            return count;
        }

        /// <summary>
        /// Commas the separated.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>Returns value.</returns>
        [UsedImplicitly]
        public static string CommaSeparated(this List<string> list) {
            string result = string.Empty;
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (string item in list) {
                result = (result.Length == 0) ? item : string.Concat(result, ",", item);
            }

            return result;
        }
    }
}
