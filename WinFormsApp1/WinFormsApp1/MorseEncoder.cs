using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1
{
    /// <summary>
    /// Simple utility class for encoding plain text to Morse code and decoding Morse code back to text.
    /// Supports letters, digits and several common punctuation marks. Words are represented by '/'.
    /// </summary>
    public class MorseEncoder
    {
        // Lookup table mapping characters to their Morse code representations.
        // Stored as uppercase letters and common symbols; space is mapped to '/'.
        private readonly Dictionary<char, string> _morseCode = new Dictionary<char, string>()
        {
        {'A', ".-"},
        {'B', "-..."},
        {'C', "-.-."},
        {'D', "-.."},
        {'E', "."},
        {'F', "..-."},
        {'G', "--."},
        {'H', "...."},
        {'I', ".."},
        {'J', ".---"},
        {'K', "-.-"},
        {'L', ".-.."},
        {'M', "--"},
        {'N', "-."},
        {'O', "---"},
        {'P', ".--."},
        {'Q', "--.-"},
        {'R', ".-."},
        {'S', "..."},
        {'T', "-"},
        {'U', "..-"},
        {'V', "...-"},
        {'W', ".--"},
        {'X', "-..-"},
        {'Y', "-.--"},
        {'Z', "--.."},
        {'0', "-----"},
        {'1', ".----"},
        {'2', "..---"},
        {'3', "...--"},
        {'4', "....-"},
        {'5', "....."},
        {'6', "-...."},
        {'7', "--..."},
        {'8', "---.."},
        {'9', "----."},
        {'.', ".-.-.-"},
        {',', "--..--"},
        {'?', "..--.."},
        {'\'', ".----."},
        {'!', "-.-.--"},
        {'/', "-..-."},
        {'(', "-.--."},
        {')', "-.--.-"},
        {'&', ".-..."},
        {':', "---..."},
        {';', "-.-.-."},
        {'=', "-...-"},
        {'+', ".-.-."},
        {'-', "-....-"},
        {'_', "..--.-"},
        {'\"', ".-..-."},
        {'$', "...-..-"},
        {'@', ".--.-."},
        {' ', "/"}
    };

        /// <summary>
        /// Encode a plain-text message into Morse code.
        /// Each encoded character is separated by a single space; words are separated by '/'.
        /// Unknown characters are emitted as-is (followed by a space).
        public string Encode(string message)
        {
            if (string.IsNullOrEmpty(message))
                return string.Empty;

            // Normalize to upper case because the table keys are uppercase letters.
            message = message.ToUpper();
            var sb = new StringBuilder();

            // Iterate each character and append the Morse equivalent or the raw character if unknown.
            foreach (char character in message)
            {
                if (_morseCode.ContainsKey(character))
                {
                    sb.Append(_morseCode[character]);
                    sb.Append(' '); // separate Morse letters with a space
                }
                else
                {
                    // If a character isn't in the table, preserve it so caller can decide how to handle it
                    sb.Append(character);
                    sb.Append(' ');
                }
            }

            // Trim trailing space
            return sb.ToString().Trim();
        }

        /// <summary>
        /// Decode a Morse code string into plain text.
        /// Expects letters separated by spaces and words separated by '/'.
        /// Unknown Morse tokens are replaced with '?'.
        
        public string Decode(string message)
        {
            if (string.IsNullOrEmpty(message))
                return string.Empty;

            // Split on '/' to separate words (caller uses '/' as word separator)
            string[] words = message.Split('/');
            var sb = new StringBuilder();

            foreach (string word in words)
            {
                string trimmed = word.Trim();
                if (string.IsNullOrEmpty(trimmed))
                {
                    // preserve word boundary
                    sb.Append(' ');
                    continue;
                }

                // Split the word into morse-letter tokens (separated by spaces)
                string[] letters = trimmed.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                foreach (string letter in letters)
                {
                    bool found = false;
                    // Linear search in the table to find the matching Morse value.
               
                    foreach (KeyValuePair<char, string> kvp in _morseCode)
                    {
                        if (letter == kvp.Value)
                        {
                            sb.Append(kvp.Key);
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        sb.Append('?'); // indicate unknown token
                    }
                }
                // Add a space between words
                sb.Append(' ');
            }

            return sb.ToString().Trim();
        }
    }
}
