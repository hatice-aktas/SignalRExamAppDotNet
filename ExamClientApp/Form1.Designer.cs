namespace ExamClientApp
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
            groupBox1 = new GroupBox();
            radioButton4 = new RadioButton();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            btnNext = new Button();
            lblResult = new Label();
            lblQuestion = new Label();
            btnPrev = new Button();
            btnFinish = new Button();
            btnCheckAnswers = new Button();
            lblCountDown = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton4);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(25, 74);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(800, 171);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Location = new Point(16, 130);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(14, 13);
            radioButton4.TabIndex = 3;
            radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(16, 95);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(14, 13);
            radioButton3.TabIndex = 2;
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(16, 60);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(14, 13);
            radioButton2.TabIndex = 1;
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(16, 25);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(14, 13);
            radioButton1.TabIndex = 0;
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.PowderBlue;
            btnNext.Location = new Point(199, 252);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(155, 33);
            btnNext.TabIndex = 2;
            btnNext.Text = "SONRAKİ SORUYA GİT";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(670, 303);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(0, 15);
            lblResult.TabIndex = 3;
            // 
            // lblQuestion
            // 
            lblQuestion.AutoSize = true;
            lblQuestion.Location = new Point(25, 32);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(0, 15);
            lblQuestion.TabIndex = 4;
            // 
            // btnPrev
            // 
            btnPrev.BackColor = Color.PowderBlue;
            btnPrev.Location = new Point(25, 252);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(155, 33);
            btnPrev.TabIndex = 5;
            btnPrev.Text = "ÖNCEKİ SORUYA GİT";
            btnPrev.UseVisualStyleBackColor = false;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnFinish
            // 
            btnFinish.BackColor = Color.LightSalmon;
            btnFinish.Location = new Point(670, 252);
            btnFinish.Name = "btnFinish";
            btnFinish.Size = new Size(155, 33);
            btnFinish.TabIndex = 6;
            btnFinish.Text = "SINAVI BİTİR";
            btnFinish.UseVisualStyleBackColor = false;
            btnFinish.Click += btnFinish_Click;
            // 
            // btnCheckAnswers
            // 
            btnCheckAnswers.BackColor = Color.OliveDrab;
            btnCheckAnswers.Location = new Point(670, 336);
            btnCheckAnswers.Name = "btnCheckAnswers";
            btnCheckAnswers.Size = new Size(155, 33);
            btnCheckAnswers.TabIndex = 7;
            btnCheckAnswers.Text = "CEVAPLARI KONTROL ET";
            btnCheckAnswers.UseVisualStyleBackColor = false;
            btnCheckAnswers.Visible = false;
            btnCheckAnswers.Click += btnCheckAnswers_Click;
            // 
            // lblCountDown
            // 
            lblCountDown.AutoSize = true;
            lblCountDown.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblCountDown.ForeColor = Color.Red;
            lblCountDown.Location = new Point(25, 336);
            lblCountDown.Name = "lblCountDown";
            lblCountDown.Size = new Size(0, 25);
            lblCountDown.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 386);
            Controls.Add(lblCountDown);
            Controls.Add(btnCheckAnswers);
            Controls.Add(btnFinish);
            Controls.Add(btnPrev);
            Controls.Add(lblQuestion);
            Controls.Add(lblResult);
            Controls.Add(btnNext);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "SINAV SORULARI";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button btnNext;
        private Label lblResult;
        private Label lblQuestion;
        private Button btnPrev;
        private Button btnFinish;
        private Button btnCheckAnswers;
        private Label lblCountDown;
    }
}
