using System;
using System.Drawing;
using System.Windows.Forms;

namespace B20_Ex05_Itay_311446876_Alex_322038399
{
    public partial class FormMemoryGame : Form
    {
        // form members
        private readonly Button[,] r_ButtonsBoard;
        private readonly Image[] r_ArrayImages;
        private readonly FormGameSettings r_Settings;
        // game members
        private readonly MemoryGameLogic r_MemoryGame;
        private Tuple<int, int> m_FirstChoiceButtonIndexs;
        private Tuple<int, int> m_SecondChoiceButtonIndexs;
        // score members
        private int m_TotalScore;        
        private int m_Player1Score;
        private int m_Player2Score;
        // turn and choice members
        private bool m_Player1Playing;
        private bool m_IsFirstChoice;
        private bool m_IsComputerPlaying;
        private bool m_IsGameOver;


        public FormMemoryGame()
        {
            // open the settings form
            r_Settings = new FormGameSettings();
            r_Settings.ShowDialog();
            r_MemoryGame = new MemoryGameLogic(r_Settings.RowSize, r_Settings.ColumnSize, r_Settings.IsComputerPlaying);
            r_ButtonsBoard = new Button[r_Settings.RowSize, r_Settings.ColumnSize];
            r_ArrayImages = new Image[r_Settings.RowSize * r_Settings.ColumnSize / 2];
            initializeNewGame();
        }

        public FormMemoryGame(FormGameSettings i_SettingsForm)
        {
            r_Settings = i_SettingsForm;
            r_MemoryGame = new MemoryGameLogic(r_Settings.RowSize, r_Settings.ColumnSize, r_Settings.IsComputerPlaying);
            r_ButtonsBoard = new Button[r_Settings.RowSize, r_Settings.ColumnSize];
            r_ArrayImages = new Image[r_Settings.RowSize * r_Settings.ColumnSize / 2];
            initializeNewGame();
        }

        // initiazlize the visualization of the form according to size and etc
        private void initializeNewGame()
        {
            // creates a logic level of the memory game
            r_MemoryGame.GenerateRandomizedBoard();
            // auto initialize + relevant memory game components initialize
            InitializeComponent();
            initializeGameComponents();
            // initialize image data and create the user interface level board
            initiazlizeImgArray();
            initiazlizeButtonsBoard(r_Settings.RowSize, r_Settings.ColumnSize);

            m_CurrentPlayerLabel.Top = r_ButtonsBoard[r_Settings.RowSize - 1, 0].Bottom + 8;
            m_Player1ScoreLabel.Top = m_CurrentPlayerLabel.Bottom + 8;
            m_Player2ScoreLabel.Top = m_Player1ScoreLabel.Bottom + 8;

            m_CurrentPlayerLabel.Text += r_Settings.Player1Name;
            m_Player1ScoreLabel.Text = string.Format("{0}: 0 Pairs", r_Settings.Player1Name);
            m_Player2ScoreLabel.Text = string.Format("{0}: 0 Pairs", r_Settings.Player2Name);

            // Adjust window size
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Padding = new System.Windows.Forms.Padding(0, 0, 8, 8);
        }

        // initiazlize relevant components of the memory game
        private void initializeGameComponents()
        {
            m_Player1Score = 0;
            m_Player2Score = 0;
            m_TotalScore = (r_Settings.ColumnSize * r_Settings.RowSize) /  2;
            m_Player1Playing = true;
            m_IsFirstChoice = true;
            m_IsGameOver = false;
            m_IsComputerPlaying = r_Settings.IsComputerPlaying;
        }

        // creates the board of buttons to the m_ButtonBoard member
        private void initiazlizeButtonsBoard(int i_RowSize , int i_ColumnSize)
        {
            

            for (int i = 0; i < i_RowSize; i++)
            {
                for (int j = 0; j < i_ColumnSize; j++)
                {
                    Button currentButton = new Button();
                    currentButton.BackColor = m_prototypeButton.BackColor;
                    currentButton.Size = m_prototypeButton.Size;
                    currentButton.Tag = r_MemoryGame.GetBoard.GetCellValue(i, j);
                    Point tempPoint = m_prototypeButton.Location;
                    tempPoint.Y += (tempPoint.Y + 8 + currentButton.Width) * i;

                    if (j != 0)
                    {
                        tempPoint.X += (tempPoint.X + 8 + currentButton.Width) * j;
                    }

                    currentButton.Location = tempPoint;
                    currentButton.Click += button_Click;
                    r_ButtonsBoard[i, j] = currentButton;
                    this.Controls.Add(r_ButtonsBoard[i, j]);
                }
            }

            this.Controls.Remove(m_prototypeButton);
        }

        // creates the image array that interacts with each button
        private void initiazlizeImgArray()
        {
            for (int i = 0; i < r_ArrayImages.Length; i++)
            {
                Image tempImage = DownloadImageFromUrl();

                while (tempImage == null)
                {
                    tempImage = DownloadImageFromUrl();
                }

                r_ArrayImages[i] = tempImage;
            }
        }

        /// <summary>
        /// go to the url: https://picsum.photos/80 and gets a random picture from there
        /// </summary>
        /// <returns> image </returns>
        private System.Drawing.Image DownloadImageFromUrl()
        {
                System.Drawing.Image image = null;

                try
                {
                    System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create("https://picsum.photos/80");
                    webRequest.AllowWriteStreamBuffering = true;
                    webRequest.Timeout = 10000;

                    System.Net.WebResponse webResponse = webRequest.GetResponse();

                    System.IO.Stream stream = webResponse.GetResponseStream();

                    image = System.Drawing.Image.FromStream(stream);

                    webResponse.Close();
                }
                catch (Exception ex)
                {
                    image = null;
                }

                return image;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button senderButton = sender as Button;            
            // set relevant image, draw border in playing player color, disable button
            senderButton.BackgroundImage = r_ArrayImages[(char)senderButton.Tag - 'A'];
            senderButton.BackColor = m_Player1Playing ? m_Player1ScoreLabel.BackColor : m_Player2ScoreLabel.BackColor;
            senderButton.Enabled = !senderButton.Enabled;

            if (m_IsFirstChoice)
            {
                m_FirstChoiceButtonIndexs = getButtonIndex(senderButton);
                r_MemoryGame.ExposeCell(m_FirstChoiceButtonIndexs.Item1, m_FirstChoiceButtonIndexs.Item2);
                m_IsFirstChoice = !m_IsFirstChoice;
            }
            else 
            {
                m_SecondChoiceButtonIndexs = getButtonIndex(senderButton);
                r_MemoryGame.ExposeCell(m_SecondChoiceButtonIndexs.Item1, m_SecondChoiceButtonIndexs.Item2);
                m_IsFirstChoice = !m_IsFirstChoice;
                doAfterSecondChoice();
            }
        }

        private void doAfterSecondChoice()
        {
            if (r_MemoryGame.CellsAreEquals(m_FirstChoiceButtonIndexs.Item1, m_FirstChoiceButtonIndexs.Item2, m_SecondChoiceButtonIndexs.Item1, m_SecondChoiceButtonIndexs.Item2))
            {
                if (m_Player1Playing)
                {
                    m_Player1Score++;
                    m_Player1ScoreLabel.Text = string.Format("{0}: {1} Pairs", r_Settings.Player1Name, m_Player1Score);
                }
                else
                {
                    m_Player2Score++;
                    m_Player2ScoreLabel.Text = string.Format("{0}: {1} Pairs", r_Settings.Player2Name, m_Player2Score);
                }
            }
            else
            {
                m_Player1Playing = !m_Player1Playing;
                System.Threading.Thread.Sleep(1500);
                displayButtonBefore(r_ButtonsBoard[m_FirstChoiceButtonIndexs.Item1, m_FirstChoiceButtonIndexs.Item2]);
                displayButtonBefore(r_ButtonsBoard[m_SecondChoiceButtonIndexs.Item1, m_SecondChoiceButtonIndexs.Item2]);
                

                string currentName = m_Player1Playing ? r_Settings.Player1Name : r_Settings.Player2Name;
                m_CurrentPlayerLabel.Text = string.Format("Current Player: {0}", currentName);
                m_CurrentPlayerLabel.BackColor = m_Player1Playing ? m_Player1ScoreLabel.BackColor : m_Player2ScoreLabel.BackColor;
               
                r_MemoryGame.UnExposeCell(m_FirstChoiceButtonIndexs.Item1, m_FirstChoiceButtonIndexs.Item2);
                r_MemoryGame.UnExposeCell(m_SecondChoiceButtonIndexs.Item1, m_SecondChoiceButtonIndexs.Item2);
            }

            m_IsGameOver = checkIfEndGame();
            this.Update();
            // if we are playing against the computer we need switch turn to the computer
            // and not let the human player click the board and touch anything
            if (m_IsComputerPlaying && !m_Player1Playing && !m_IsGameOver)
            {
                activeComputerTurn();
            }
        }

        private void displayButtonBefore(Button i_Button)
        {
            i_Button.BackColor = m_prototypeButton.BackColor;
            i_Button.BackgroundImage = null;
            i_Button.Enabled = !i_Button.Enabled;
        }

        private bool checkIfEndGame()
        {
            bool retVal = m_TotalScore == (m_Player1Score + m_Player2Score);

            if (retVal)
            {
                string msg;

                if (m_Player1Score == m_Player2Score)
                {
                    msg = string.Format(@"There was a tie!");
                }
                else if (m_Player1Score > m_Player2Score)
                {
                    msg = string.Format(@"The winner of the game is: {0}
Score: {1}",r_Settings.Player1Name, m_Player1Score);
                }
                else
                {
                    msg = string.Format(@"The winner of the game is: {0}
with score of: {1}", r_Settings.Player2Name, m_Player2Score);
                }

                msg = string.Format(@"{0}
Do you want to play again?", msg);
                
                DialogResult dialogResult = MessageBox.Show(msg, "End of game" ,MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    FormMemoryGame newGame = new FormMemoryGame(r_Settings);   
                    this.Dispose();
                    newGame.ShowDialog();
                }
                else if (dialogResult == DialogResult.No)
                {
                    this.Dispose();
                    this.Close();
                }
            }

            return retVal;
        }

        private void activeComputerTurn()
        {
            // first choice
            System.Threading.Thread.Sleep(500);
            m_FirstChoiceButtonIndexs = r_MemoryGame.ComputerFirstChoice();
            Button firstChoice = r_ButtonsBoard[m_FirstChoiceButtonIndexs.Item1, m_FirstChoiceButtonIndexs.Item2];
            firstChoice.BackColor = m_Player2ScoreLabel.BackColor;
            firstChoice.BackgroundImage = r_ArrayImages[(char)firstChoice.Tag - 'A'];
            firstChoice.Enabled = !firstChoice.Enabled;
            // second choice
            System.Threading.Thread.Sleep(1000);
            Tuple<int, int, int> secondChoiceAndResult = r_MemoryGame.ComputerSecondChoice(m_FirstChoiceButtonIndexs);
            m_SecondChoiceButtonIndexs = new Tuple<int, int>(secondChoiceAndResult.Item1, secondChoiceAndResult.Item2);
            Button secondChoice = r_ButtonsBoard[m_SecondChoiceButtonIndexs.Item1, m_SecondChoiceButtonIndexs.Item2];
            secondChoice.BackColor = m_Player2ScoreLabel.BackColor;
            secondChoice.BackgroundImage = r_ArrayImages[(char)secondChoice.Tag - 'A'];
            secondChoice.Enabled = !secondChoice.Enabled;
            // do after choice
            System.Threading.Thread.Sleep(1000);
            doAfterSecondChoice();
        }

        private Tuple<int,int> getButtonIndex(Button i_SenderButton)
        {
            Tuple<int, int> retVal = null;
            
            for (int i = 0; i < r_ButtonsBoard.GetLength(0); i++)
            {
                for (int j = 0; j < r_ButtonsBoard.GetLength(1); j++)
                {
                    if (r_ButtonsBoard[i, j] == i_SenderButton)
                    {
                        retVal = new Tuple<int, int>(i, j);
                        break;
                    }
                }
            }

            return retVal;
        }
    }
}
