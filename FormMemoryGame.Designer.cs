namespace B20_Ex05_Itay_311446876_Alex_322038399
{
    public partial class FormMemoryGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_CurrentPlayerLabel = new System.Windows.Forms.Label();
            this.m_Player1ScoreLabel = new System.Windows.Forms.Label();
            this.m_Player2ScoreLabel = new System.Windows.Forms.Label();
            this.m_prototypeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_CurrentPlayerLabel
            // 
            this.m_CurrentPlayerLabel.AutoSize = true;
            this.m_CurrentPlayerLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_CurrentPlayerLabel.Location = new System.Drawing.Point(10, 357);
            this.m_CurrentPlayerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_CurrentPlayerLabel.Name = "m_CurrentPlayerLabel";
            this.m_CurrentPlayerLabel.Size = new System.Drawing.Size(107, 17);
            this.m_CurrentPlayerLabel.TabIndex = 0;
            this.m_CurrentPlayerLabel.Text = "Current Player: ";
            // 
            // m_Player1ScoreLabel
            // 
            this.m_Player1ScoreLabel.AutoSize = true;
            this.m_Player1ScoreLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_Player1ScoreLabel.Location = new System.Drawing.Point(10, 385);
            this.m_Player1ScoreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_Player1ScoreLabel.Name = "m_Player1ScoreLabel";
            this.m_Player1ScoreLabel.Size = new System.Drawing.Size(68, 17);
            this.m_Player1ScoreLabel.TabIndex = 1;
            this.m_Player1ScoreLabel.Text = "Player1 : ";
            this.m_Player1ScoreLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // m_Player2ScoreLabel
            // 
            this.m_Player2ScoreLabel.AutoSize = true;
            this.m_Player2ScoreLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.m_Player2ScoreLabel.Location = new System.Drawing.Point(10, 413);
            this.m_Player2ScoreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.m_Player2ScoreLabel.Name = "m_Player2ScoreLabel";
            this.m_Player2ScoreLabel.Size = new System.Drawing.Size(64, 17);
            this.m_Player2ScoreLabel.TabIndex = 2;
            this.m_Player2ScoreLabel.Text = "Player2: ";
            // 
            // m_prototypeButton
            // 
            this.m_prototypeButton.BackColor = System.Drawing.Color.Silver;
            this.m_prototypeButton.FlatAppearance.BorderSize = 5;
            this.m_prototypeButton.Location = new System.Drawing.Point(15, 15);
            this.m_prototypeButton.Margin = new System.Windows.Forms.Padding(2);
            this.m_prototypeButton.Name = "m_prototypeButton";
            this.m_prototypeButton.Size = new System.Drawing.Size(70, 72);
            this.m_prototypeButton.TabIndex = 3;
            this.m_prototypeButton.UseVisualStyleBackColor = false;
            this.m_prototypeButton.Click += new System.EventHandler(this.button_Click);
            // 
            // FormMemoryGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(351, 445);
            this.Controls.Add(this.m_prototypeButton);
            this.Controls.Add(this.m_Player2ScoreLabel);
            this.Controls.Add(this.m_Player1ScoreLabel);
            this.Controls.Add(this.m_CurrentPlayerLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormMemoryGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_CurrentPlayerLabel;
        private System.Windows.Forms.Label m_Player1ScoreLabel;
        private System.Windows.Forms.Label m_Player2ScoreLabel;
        private System.Windows.Forms.Button m_prototypeButton;
    }
}