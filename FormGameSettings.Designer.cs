using System.Windows.Forms;

namespace B20_Ex05_Itay_311446876_Alex_322038399
{
    public partial class FormGameSettings
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
            this.m_AgainstButton = new System.Windows.Forms.Button();
            this.m_StartButton = new System.Windows.Forms.Button();
            this.m_BoardSizeButton = new System.Windows.Forms.Button();
            this.m_Player1TextBox = new System.Windows.Forms.TextBox();
            this.m_Player2TextBox = new System.Windows.Forms.TextBox();
            this.m_Player1Label = new System.Windows.Forms.Label();
            this.m_Player2Label = new System.Windows.Forms.Label();
            this.m_BoardSizeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_AgainstButton
            // 
            this.m_AgainstButton.AutoSize = true;
            this.m_AgainstButton.Location = new System.Drawing.Point(316, 59);
            this.m_AgainstButton.Margin = new System.Windows.Forms.Padding(4);
            this.m_AgainstButton.Name = "m_AgainstButton";
            this.m_AgainstButton.Size = new System.Drawing.Size(133, 28);
            this.m_AgainstButton.TabIndex = 0;
            this.m_AgainstButton.Text = "Against a Friend";
            this.m_AgainstButton.UseVisualStyleBackColor = true;
            this.m_AgainstButton.Click += new System.EventHandler(this.againstButton_Click);
            // 
            // m_StartButton
            // 
            this.m_StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_StartButton.Location = new System.Drawing.Point(332, 198);
            this.m_StartButton.Margin = new System.Windows.Forms.Padding(4);
            this.m_StartButton.Name = "m_StartButton";
            this.m_StartButton.Size = new System.Drawing.Size(100, 28);
            this.m_StartButton.TabIndex = 1;
            this.m_StartButton.Text = "Start!";
            this.m_StartButton.UseVisualStyleBackColor = false;
            this.m_StartButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // m_BoardSizeButton
            // 
            this.m_BoardSizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.m_BoardSizeButton.Location = new System.Drawing.Point(22, 140);
            this.m_BoardSizeButton.Margin = new System.Windows.Forms.Padding(4);
            this.m_BoardSizeButton.Name = "m_BoardSizeButton";
            this.m_BoardSizeButton.Size = new System.Drawing.Size(138, 91);
            this.m_BoardSizeButton.TabIndex = 2;
            this.m_BoardSizeButton.Text = "4 x 4";
            this.m_BoardSizeButton.UseVisualStyleBackColor = false;
            this.m_BoardSizeButton.Click += new System.EventHandler(this.boardSizeButton_Click);
            // 
            // m_Player1TextBox
            // 
            this.m_Player1TextBox.Location = new System.Drawing.Point(172, 15);
            this.m_Player1TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.m_Player1TextBox.Name = "m_Player1TextBox";
            this.m_Player1TextBox.Size = new System.Drawing.Size(132, 22);
            this.m_Player1TextBox.TabIndex = 3;
            // 
            // m_Player2TextBox
            // 
            this.m_Player2TextBox.BackColor = System.Drawing.Color.LightGray;
            this.m_Player2TextBox.Enabled = false;
            this.m_Player2TextBox.Location = new System.Drawing.Point(172, 63);
            this.m_Player2TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.m_Player2TextBox.Name = "m_Player2TextBox";
            this.m_Player2TextBox.Size = new System.Drawing.Size(132, 22);
            this.m_Player2TextBox.TabIndex = 4;
            this.m_Player2TextBox.Text = "-computer-";
            // 
            // m_Player1Label
            // 
            this.m_Player1Label.AutoSize = true;
            this.m_Player1Label.Location = new System.Drawing.Point(16, 17);
            this.m_Player1Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_Player1Label.Name = "m_Player1Label";
            this.m_Player1Label.Size = new System.Drawing.Size(124, 17);
            this.m_Player1Label.TabIndex = 5;
            this.m_Player1Label.Text = "First Player Name:";
            // 
            // m_Player2Label
            // 
            this.m_Player2Label.AutoSize = true;
            this.m_Player2Label.Location = new System.Drawing.Point(16, 65);
            this.m_Player2Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_Player2Label.Name = "m_Player2Label";
            this.m_Player2Label.Size = new System.Drawing.Size(145, 17);
            this.m_Player2Label.TabIndex = 6;
            this.m_Player2Label.Text = "Second Player Name:";
            // 
            // m_BoardSizeLabel
            // 
            this.m_BoardSizeLabel.AutoSize = true;
            this.m_BoardSizeLabel.Location = new System.Drawing.Point(20, 114);
            this.m_BoardSizeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_BoardSizeLabel.Name = "m_BoardSizeLabel";
            this.m_BoardSizeLabel.Size = new System.Drawing.Size(81, 17);
            this.m_BoardSizeLabel.TabIndex = 7;
            this.m_BoardSizeLabel.Text = "Board Size:";
            // 
            // FormGameSettings
            // 
            this.AcceptButton = this.m_StartButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(468, 255);
            this.Controls.Add(this.m_BoardSizeLabel);
            this.Controls.Add(this.m_Player2Label);
            this.Controls.Add(this.m_Player1Label);
            this.Controls.Add(this.m_Player2TextBox);
            this.Controls.Add(this.m_Player1TextBox);
            this.Controls.Add(this.m_BoardSizeButton);
            this.Controls.Add(this.m_StartButton);
            this.Controls.Add(this.m_AgainstButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game - Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_AgainstButton;
        private System.Windows.Forms.Button m_StartButton;
        private System.Windows.Forms.Button m_BoardSizeButton;
        private System.Windows.Forms.TextBox m_Player1TextBox;
        private System.Windows.Forms.TextBox m_Player2TextBox;
        private System.Windows.Forms.Label m_Player1Label;
        private System.Windows.Forms.Label m_Player2Label;
        private System.Windows.Forms.Label m_BoardSizeLabel;
    }
}