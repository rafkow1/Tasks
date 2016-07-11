using System;

namespace Tasks
{
    /// <summary>
    /// Class with first task about brackets.
    /// </summary>
    public class FirstTask
    {
        /// <summary>
        /// Determines whether given string with brackets is valid.
        /// </summary>
        /// <param name="braces">string with brackets</param>
        /// <returns><code>True</code> if specified string has a valid brackets.</returns>
        public bool validBraces(string braces)
        {
            if (String.IsNullOrWhiteSpace(braces))
            {
                return false;
            }

            string smtBraces = String.Empty;

            while(braces.Length != smtBraces.Length)
            {
                smtBraces = braces;
                braces = braces.Replace("()", String.Empty).Replace("[]", String.Empty).Replace("{}", String.Empty);
            }

            return braces.Length != 0 ? false : true;
        }
    }
}
