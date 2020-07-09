using System;
using System.Drawing;
using System.Windows.Forms;

namespace B20_Ex05_Itay_311446876_Alex_322038399
{
    public partial class FormGameSettings : Form
    {
        private int m_ColumnSize = 0;
        private int m_RowSize = 0;

        public int ColumnSize
        {
            get { return m_ColumnSize + 4; }
        }

        public int RowSize
        {
            get { return m_RowSize + 4; }
        }

        public string Player1Name
        {
            get { return m_Player1TextBox.Text; }
        }

        public string Player2Name
        {
            get
            {
                // check if play against computer or a friend
                return m_Player2TextBox.Text.Equals("-computer-") ? "Computer" : m_Player2TextBox.Text;
            }
        }

        public bool IsComputerPlaying
        {
            get { return !m_Player2TextBox.Enabled; }
        }

        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void againstButton_Click(object sender, EventArgs e)
        {
            m_Player2TextBox.Enabled = !m_Player2TextBox.Enabled;
            
            if (m_Player2TextBox.Enabled)
            {
                m_AgainstButton.Text = "Against Computer";
                m_Player2TextBox.Text = "";
                m_Player2TextBox.BackColor = Color.White;   
            } 
            else
            {
                m_AgainstButton.Text = "Against a Friend";
                m_Player2TextBox.Text = "-computer-";
                m_Player2TextBox.BackColor = Color.LightGray;
            }
            
        }

        // keep track of possible board size
        private void boardSizeButton_Click(object sender, EventArgs e)
        {
            // check the speical case of 5 x 5
            if (!(m_RowSize == 1) || !(m_ColumnSize == 0))
            {
                m_ColumnSize = (m_ColumnSize + 1) % 3;
            }
            else
            {
                m_ColumnSize += 2;
            }

            if (m_ColumnSize == 0)
            {
                m_RowSize = (m_RowSize + 1) % 3;
            }

            m_BoardSizeButton.Text = string.Format("{0} x {1}", m_RowSize + 4, m_ColumnSize + 4);
        }
    }
}
