namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            B1TEST = new Button();
            richTextBox1 = new RichTextBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog2 = new OpenFileDialog();
            labelMode = new Label();
            comboMode = new ComboBox();
            SuspendLayout();
            // 
            // B1TEST
            // 
            B1TEST.Location = new Point(486, 9);
            B1TEST.Margin = new Padding(4, 5, 4, 5);
            B1TEST.Name = "B1TEST";
            B1TEST.Size = new Size(137, 45);
            B1TEST.TabIndex = 1;
            B1TEST.Text = "encrypt\r\n";
            B1TEST.UseVisualStyleBackColor = true;
            B1TEST.Click += B1TEST_Click;
            B1TEST.MouseClick += button1_MouseClick;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(0, 64);
            richTextBox1.Margin = new Padding(4, 5, 4, 5);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1741, 666);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // button2
            // 
            button2.Location = new Point(997, 5);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(125, 49);
            button2.TabIndex = 3;
            button2.Text = "save";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(802, 5);
            button3.Margin = new Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new Size(127, 49);
            button3.TabIndex = 4;
            button3.Text = "load";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(651, 9);
            button4.Margin = new Padding(4, 5, 4, 5);
            button4.Name = "button4";
            button4.Size = new Size(127, 45);
            button4.TabIndex = 5;
            button4.Text = "decrypt";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // labelMode
            // 
            labelMode.Location = new Point(131, 17);
            labelMode.Name = "labelMode";
            labelMode.Size = new Size(66, 25);
            labelMode.TabIndex = 0;
            labelMode.Text = "Mode:";
            labelMode.Click += labelMode_Click;
            // 
            // comboMode
            // 
            comboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboMode.FormattingEnabled = true;
            comboMode.Items.AddRange(new object[] { "Show Both", "Caesar", "Morse", "Caesar then Morse" });
            comboMode.Location = new Point(203, 12);
            comboMode.Name = "comboMode";
            comboMode.Size = new Size(200, 33);
            comboMode.TabIndex = 0;
            comboMode.SelectedIndexChanged += comboMode_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1743, 727);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(richTextBox1);
            Controls.Add(B1TEST);
            Controls.Add(labelMode);
            Controls.Add(comboMode);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion
        private Button B1TEST;
        private RichTextBox richTextBox1;
        private Button button2;
        private Button button3;
        private Button button4;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog2;
        private Label labelMode;
        private ComboBox comboMode;
    }
}
