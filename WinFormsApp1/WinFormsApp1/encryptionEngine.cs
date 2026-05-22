namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
    public class EncryptionEngine
    {
        private int _shift;
        public EncryptionEngine(int shift = 3) { _shift = shift; }
        public string Encrypt(string plainText)
        {
            string result = string.Empty;
            foreach (char c in plainText)
            {
                if (char.IsLetter(c))
                {
                    char basechr = char.IsUpper(c) ? 'A' : 'a';
                    result += (char)((c - basechr + _shift) % 26 + basechr);
                }
                else { result += c; }
            }
            return result;
        }

        public string Decrypt(string cipherText)
        {
            string result = string.Empty;
            foreach (char c in cipherText)
            {
                    if (char.IsLetter(c))
                    {
                        char basechr = char.IsUpper(c) ? 'A' : 'a';
                        result += (char)((c - basechr - _shift + 26) % 26 + basechr);
                    }
                    else { result += c; }
            }
            return result;
        }

    }
}