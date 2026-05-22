using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace WinFormsApp1
{

    public partial class Form1 : Form
    {

        // Both engines: Caesar (EncryptionEngine) and Morse
        private EncryptionEngine _caesarEngine = new EncryptionEngine(shift: 3);
        private MorseEncoder _morseEngine = new MorseEncoder();

        public Form1()
        {
            InitializeComponent();
            // ensure combo default
            if (comboMode != null && comboMode.Items.Count > 0)
                comboMode.SelectedIndex = 0;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {



        }

        private void B1TEST_Click(object sender, EventArgs e)
        {
            string plaintext = richTextBox1.Text;
            if (string.IsNullOrEmpty(plaintext))
            {
                MessageBox.Show("please enter text. ");
                return;
            }
            string mode = comboMode?.SelectedItem?.ToString() ?? "Show Both";
            switch (mode)
            {
                case "Caesar":
                    richTextBox1.Text = _caesarEngine.Encrypt(plaintext);
                    break;
                case "Morse":
                    richTextBox1.Text = _morseEngine.Encode(plaintext);
                    break;
                case "Caesar then Morse":
                    // Apply Caesar first then Morse
                    richTextBox1.Text = _morseEngine.Encode(_caesarEngine.Encrypt(plaintext));
                    break;
                default: // Show Both
                    string caesarCipher = _caesarEngine.Encrypt(plaintext);
                    string morseCipher = _morseEngine.Encode(plaintext);
                    richTextBox1.Text = "Caesar:\n" + caesarCipher + "\n\nMorse:\n" + morseCipher;
                    break;
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)

            {
                try
                {
                    var filePath = openFileDialog1.FileName;
                    using (Stream str = openFileDialog1.OpenFile())
                    {
                        using (StreamReader reader = new StreamReader(str))
                        {
                            Process.Start("notepad.exe", filePath);
                            string content = reader.ReadToEnd();
                            richTextBox1.Text = content;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred while loading the file: " + ex.Message);
                }
            }
        }

        
        private void button4_Click(object sender, EventArgs e)
        {
            string input = richTextBox1.Text ?? string.Empty;
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("please enter text. ");
                return;
            }

            string caesarPlain = string.Empty;
            string morsePlain = string.Empty;
            string mode = comboMode?.SelectedItem?.ToString() ?? "Show Both";

            // Helper to decode based on selected mode
            string DecodeByMode(string input)
            {
                switch (mode)
                {
                    case "Caesar":
                        return _caesarEngine.Decrypt(input);
                    case "Morse":
                        return _morseEngine.Decode(input);
                    case "Caesar then Morse":
                        // reverse order: decode Morse then decrypt Caesar
                        return _caesarEngine.Decrypt(_morseEngine.Decode(input));
                    default:
                        // Show both: try both decoders and present results below
                        return null;
                }
            }

            // If input contains both sections produced by the Encrypt button, parse them
            if (input.Contains("Caesar:") && input.Contains("Morse:") && mode == "Show Both")
            {
                try
                {
                    int caesarIdx = input.IndexOf("Caesar:", StringComparison.Ordinal);
                    int morseIdx = input.IndexOf("Morse:", StringComparison.Ordinal);

                    string caesarPart = input.Substring(caesarIdx + "Caesar:".Length, Math.Max(0, morseIdx - (caesarIdx + "Caesar:".Length)));
                    caesarPart = caesarPart.Replace("\r", "").Replace("\n", "").Trim();

                    string morsePart = input.Substring(morseIdx + "Morse:".Length).Trim();

                    if (!string.IsNullOrEmpty(caesarPart))
                        caesarPlain = _caesarEngine.Decrypt(caesarPart);

                    if (!string.IsNullOrEmpty(morsePart))
                        morsePlain = _morseEngine.Decode(morsePart);
                }
                catch
                {
                    // fall back to trying to decode whole input
                }
            }
            else
            {
                // Detect if input looks like Morse (only dots, dashes, slashes and spaces)
                bool looksLikeMorse = input.Trim().All(c => c == '.' || c == '-' || c == '/' || c == ' ');

                if (mode != "Show Both")
                {
                    // If a specific mode is chosen, use it to decode
                    string decoded = DecodeByMode(input);
                    if (mode == "Caesar") caesarPlain = decoded;
                    else if (mode == "Morse") morsePlain = decoded;
                    else if (mode == "Caesar then Morse") caesarPlain = decoded;
                }
                else
                {
                    if (looksLikeMorse)
                    {
                        morsePlain = _morseEngine.Decode(input);
                    }
                    else
                    {
                        // Not clearly Morse; attempt both decodings on the whole input
                        caesarPlain = _caesarEngine.Decrypt(input);
                        morsePlain = _morseEngine.Decode(input);
                    }
                }
            }

            richTextBox1.Text = "Caesar Decoded:\n" + caesarPlain + "\n\nMorse Decoded:\n" + morsePlain;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelMode_Click(object sender, EventArgs e)
        {

        }
    }
}

