    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace Tic_Tac_Toe_Game
    {
        public partial class Form1 : Form
        {
            bool isPlayer1 = true;
            int xBits = 0;
            int oBits = 0;
            int winningPattern = 0;

            int[] winPatterns = {
                 0b000000111, // Row 1
                 0b000111000, // Row 2
                 0b111000000, // Row 3
                 0b001001001, // Column 1
                 0b010010010, // Column 2
                 0b100100100, // Column 3
                 0b100010001, // Main Diagonal (\)
                 0b001010100  // Anti-Diagonal (/)
            };

            void AssignCellToPlayer(int cell, bool isPlayer1)
            {
                if (isPlayer1)
                {
                    xBits |= (1 << cell);
                }

                else { 
                
                 oBits |= (1 << cell); 
                }
            }

            bool CheckWinner(bool isPlayer1)
            {
                int bits = isPlayer1 ? xBits : oBits;

                foreach (int pattern in winPatterns)
                {
                    if ((bits & pattern) == pattern) {
                        winningPattern = pattern;
                        return true;
                    }
                }
                return false;
            }

            void ColorTheButtons()
            {
                switch (winningPattern)
                {
                    case 0b000000111: // Row 1
                        btn1.BackColor = Color.Yellow;
                        btn2.BackColor = Color.Yellow;
                        btn3.BackColor = Color.Yellow;
                        break;

                    case 0b000111000: // Row 2
                        btn4.BackColor = Color.Yellow;
                        btn5.BackColor = Color.Yellow;
                        btn6.BackColor = Color.Yellow;
                        break;

                    case 0b111000000: // Row 3
                        btn7.BackColor = Color.Yellow;
                        btn8.BackColor = Color.Yellow;
                        btn9.BackColor = Color.Yellow;
                        break;

                    case 0b001001001: // Column 1
                        btn1.BackColor = Color.Yellow;
                        btn4.BackColor = Color.Yellow;
                        btn7.BackColor = Color.Yellow;
                        break;

                    case 0b010010010: // Column 2
                        btn2.BackColor = Color.Yellow;
                        btn5.BackColor = Color.Yellow;
                        btn8.BackColor = Color.Yellow;
                        break;

                    case 0b100100100: // Column 3
                        btn3.BackColor = Color.Yellow;
                        btn6.BackColor = Color.Yellow;
                        btn9.BackColor = Color.Yellow;
                        break;

                    case 0b100010001: // Main Diagonal (\)
                        btn1.BackColor = Color.Yellow;
                        btn5.BackColor = Color.Yellow;
                        btn9.BackColor = Color.Yellow;
                        break;

                    case 0b001010100: // Anti-Diagonal (/)
                        btn3.BackColor = Color.Yellow;
                        btn5.BackColor = Color.Yellow;
                        btn7.BackColor = Color.Yellow;
                        break;
                }
            }

            public Form1()
            {
                InitializeComponent();
            }

            private void LockButtons()
            {
                btn1.Enabled = false;
                btn2.Enabled = false;
                btn3.Enabled = false;
                btn4.Enabled = false;
                btn5.Enabled = false;
                btn6.Enabled = false;
                btn7.Enabled = false;
                btn8.Enabled = false;
                btn9.Enabled = false;
            }

            private void UnlockButtons()
            {
                btn1.Enabled = true;
                btn2.Enabled = true;
                btn3.Enabled = true;
                btn4.Enabled = true;
                btn5.Enabled = true;
                btn6.Enabled = true;
                btn7.Enabled = true;
                btn8.Enabled = true;
                btn9.Enabled = true;
            }

            void SetInitialCharacter()
            {

                btn1.Text = "?";
                btn2.Text = "?";
                btn3.Text = "?";
                btn4.Text = "?";
                btn5.Text = "?";
                btn6.Text = "?";
                btn7.Text = "?";
                btn8.Text = "?";
                btn9.Text = "?";
            }

            private void Form1_Load(object sender, EventArgs e)
            {
                lblCurrentPlayer.Text = isPlayer1 ? "Player1" : "Player2";

                SetInitialCharacter();
            }

            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                Color color = Color.Black;

                Pen pen = new Pen(color);
                pen.Width = 5;
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                int startX = 25;
                int startY = 25;
                int cellSize = 100; 

           
                e.Graphics.DrawLine(pen, startX, startY + cellSize, startX + cellSize * 3, startY + cellSize);       
                e.Graphics.DrawLine(pen, startX, startY + cellSize * 2, startX + cellSize * 3, startY + cellSize * 2); 

                e.Graphics.DrawLine(pen, startX + cellSize, startY, startX + cellSize, startY + cellSize * 3);      
                e.Graphics.DrawLine(pen, startX + cellSize * 2, startY, startX + cellSize * 2, startY + cellSize * 3); 
            }

            private void ChooseCell(object sender, EventArgs e)
            {
                Button btn = (Button)sender;

                if (btn.Text== "X"|| btn.Text == "O")
                {
                    MessageBox.Show("Invalid choice, choose another one", "Wrong");
                    return;
                }


                bool currentPlayer = isPlayer1; 

                if (isPlayer1)
                {
                    btn.Text = "X";
                }
                else
                {
                    btn.Text = "O";
                }
                int cell = Convert.ToInt32(btn.Tag);
                AssignCellToPlayer(cell, currentPlayer);
                isPlayer1 = !isPlayer1; 
                lblCurrentPlayer.Text = isPlayer1 ? "Player1" : "Player2";

                if (CheckWinner(currentPlayer))
                {
                    ColorTheButtons();
                    MessageBox.Show(currentPlayer ? "Player1 wins!" : "Player2 wins!");
                    lblWinner.Text = currentPlayer ? "Player1" : "Player2";
                    LockButtons();
                    return;
                }

                if ((xBits | oBits) == 0b111111111)
                {
                    MessageBox.Show("It's a Draw!", "Draw");
                }

            }
       
            private void button1_Click(object sender, EventArgs e)
            {
                ChooseCell(sender, e);

            }

            private void button2_Click(object sender, EventArgs e)
            {
                ChooseCell(sender, e);
            }

            private void button3_Click(object sender, EventArgs e)
            {
                ChooseCell(sender, e);
            }

            private void button6_Click(object sender, EventArgs e)
            {
                ChooseCell(sender, e);
            }

            private void button5_Click(object sender, EventArgs e)
            {
                ChooseCell(sender, e);
            }

            private void button4_Click(object sender, EventArgs e)
            {
                ChooseCell(sender, e);
            }

            private void button9_Click(object sender, EventArgs e)
            {
                ChooseCell(sender, e);
            }

            private void button8_Click(object sender, EventArgs e)
            {
                ChooseCell(sender, e);
            }

            private void button7_Click(object sender, EventArgs e)
            {
                ChooseCell(sender, e);
            }

            private void btnRestartGame_Click(object sender, EventArgs e)
            {
                xBits = 0;
                oBits = 0;
                winningPattern = 0;
                lblWinner.Text = "";
                isPlayer1 = true;
                lblCurrentPlayer.Text = "Player1";

                btn1.BackColor = Color.White;
                btn2.BackColor = Color.White;
                btn3.BackColor = Color.White;
                btn4.BackColor = Color.White;
                btn5.BackColor = Color.White;
                btn6.BackColor = Color.White;
                btn7.BackColor = Color.White;
                btn8.BackColor = Color.White;
                btn9.BackColor = Color.White;

                SetInitialCharacter();
                UnlockButtons();
            }

      
        }
    }
