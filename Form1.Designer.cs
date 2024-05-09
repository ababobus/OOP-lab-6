namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            PictureBox = new PictureBox();
            CtrlCheckBox = new CheckBox();
            OverlayCheckBox = new CheckBox();
            CircleBtn = new Button();
            SquareBtn = new Button();
            TriangleBtn = new Button();
            colorDialog1 = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
            SuspendLayout();
            // 
            // PictureBox
            // 
            PictureBox.Location = new Point(1, 169);
            PictureBox.Margin = new Padding(3, 5, 3, 5);
            PictureBox.Name = "PictureBox";
            PictureBox.Size = new Size(1224, 851);
            PictureBox.TabIndex = 1;
            PictureBox.TabStop = false;
            PictureBox.Paint += PictureBox_Paint;
            PictureBox.MouseClick += PictureBox_MouseClick;
            // 
            // CtrlCheckBox
            // 
            CtrlCheckBox.AutoSize = true;
            CtrlCheckBox.Location = new Point(66, 35);
            CtrlCheckBox.Margin = new Padding(3, 5, 3, 5);
            CtrlCheckBox.Name = "CtrlCheckBox";
            CtrlCheckBox.Size = new Size(77, 29);
            CtrlCheckBox.TabIndex = 2;
            CtrlCheckBox.Text = "CTRL";
            CtrlCheckBox.UseVisualStyleBackColor = true;
            CtrlCheckBox.CheckedChanged += new System.EventHandler(CtrlCheckBox_CheckedChanged);
            // 
            // OverlayCheckBox
            // 
            OverlayCheckBox.AutoSize = true;
            OverlayCheckBox.Location = new Point(66, 95);
            OverlayCheckBox.Margin = new Padding(3, 5, 3, 5);
            OverlayCheckBox.Name = "OverlayCheckBox";
            OverlayCheckBox.Size = new Size(113, 29);
            OverlayCheckBox.TabIndex = 3;
            OverlayCheckBox.Text = "OVERLAY";
            OverlayCheckBox.UseVisualStyleBackColor = true;
            OverlayCheckBox.CheckedChanged += new System.EventHandler(OverlayCheckBox_CheckedChanged);
            //OverlayCheckBox.Click += new System.EventHandler(OverlayCheckBox_Click);
            // 
            // CircleBtn
            // 
            CircleBtn.Location = new Point(281, 30);
            CircleBtn.Name = "CircleBtn";
            CircleBtn.Size = new Size(93, 94);
            CircleBtn.TabIndex = 4;
            CircleBtn.Text = "Circle";
            CircleBtn.UseVisualStyleBackColor = true;
            CircleBtn.Click += new System.EventHandler(CircleBtn_Click);
            // 
            // SquareBtn
            // 
            SquareBtn.Location = new Point(380, 30);
            SquareBtn.Name = "SquareBtn";
            SquareBtn.Size = new Size(93, 94);
            SquareBtn.TabIndex = 5;
            SquareBtn.Text = "Square";
            SquareBtn.UseVisualStyleBackColor = true;
            SquareBtn.Click += new System.EventHandler(SquareBtn_Click);
            // 
            // TriangleBtn
            // 
            TriangleBtn.Location = new Point(479, 30);
            TriangleBtn.Name = "TriangleBtn";
            TriangleBtn.Size = new Size(90, 93);
            TriangleBtn.TabIndex = 6;
            TriangleBtn.Text = "Triangle";
            TriangleBtn.UseVisualStyleBackColor = true;
            TriangleBtn.Click += new System.EventHandler(TriangleBtn_Click);


            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1228, 1020);
            Controls.Add(TriangleBtn);
            Controls.Add(SquareBtn);
            Controls.Add(CircleBtn);
            Controls.Add(OverlayCheckBox);
            Controls.Add(CtrlCheckBox);
            Controls.Add(PictureBox);
            KeyPreview = true;
            Margin = new Padding(3, 5, 3, 5);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            //KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PictureBox;
        private CheckBox CtrlCheckBox;
        private CheckBox OverlayCheckBox;
        private Button CircleBtn;
        private Button SquareBtn;
        private Button TriangleBtn;
        private ColorDialog colorDialog1;
    }
}

