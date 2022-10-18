using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tic_tac_toe {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private int clickCounter, counterForWinningA, counterForWinningB, playerNum, _num;
        private string message, winner;
        private List<int> player1 = new List<int>();
        private List<int> player2 = new List<int>();
        private List<Button> buttons;
        private List<string> combinatsions = new List<string>()
            {"123", "456", "789", "147", "258", "369", "159", "357"};

        private bool gameEndingHasBeenCalled = false;

        private void button1_Click(object sender, EventArgs e) {
            playGame(button1, 1);
        }
        
        private void button2_Click(object sender, EventArgs e) {
            playGame(button2, 2);
        }

        private void button3_Click(object sender, EventArgs e) {
            playGame(button3, 3);
        }
        private void button4_Click(object sender, EventArgs e) {
            playGame(button4, 4);
        }

        private void button5_Click(object sender, EventArgs e) {
            playGame(button5, 5);
        }

        private void button6_Click(object sender, EventArgs e) {
            playGame(button6, 6);
        }

        private void button7_Click(object sender, EventArgs e) {
            playGame(button7, 7);
        }

        private void button8_Click(object sender, EventArgs e) {
            playGame(button8, 8);
        }

        private void button9_Click(object sender, EventArgs e) {
            playGame(button9, 9);
        }

        private void playGame(Button button, int num) {
            if (button.Text == "") {
                MarkButton(num);
                button.Text = message;
                SetResults();
                CheckIfGameEndedWithNoWinners();
            }
        }

        private void CheckIfGameEndedWithNoWinners() {
            int counter = 0;
            if (gameEndingHasBeenCalled==false) {
                buttons = new List<Button>() { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

                foreach (Button button in buttons) {
                    if (button.Text == "X" || button.Text == "O") counter ++;
                    else { break; }
                }

                if (counter==9) {
                    winner = "Nobody";
                    AskToPlayAgain();
                }
            }
        }

        private void MarkButton(int num) {
            _num = num;
            clickCounter++;
            if (clickCounter % 2 == 0) {
                message = "O";
                playerNum = 2;
            }
            else {
                message = "X";
                playerNum = 1;
            }
        }

        private void SetResults() {
            if (playerNum==2) {
                player2.Add(_num);
                ControlResults(player2);
            }
            else {
                player1.Add(_num);
                ControlResults(player1);
            }
        }

        private void ControlResults(List<int> list) {
            foreach (string combinatsion in combinatsions) {
                foreach (int place in list) {
                    if (combinatsion.Contains(place.ToString())==true) {
                        if (clickCounter%2==0) counterForWinningB++;
                        else { counterForWinningA++; }
                    }
                }
                FindWinner();
            }
        }

        private void FindWinner() {
            if (counterForWinningA != 3 && counterForWinningB != 3) {
                counterForWinningB = 0;
                counterForWinningA = 0;
            }
            else {
                if (counterForWinningA == 3) winner = "X";
                else { winner = "O"; }

                gameEndingHasBeenCalled = true;
                AskToPlayAgain();
            }
        }

        private void AskToPlayAgain() {
            string message = winner + " won! Do you want to play again?";
            string caption = "Game over!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            if (MessageBox.Show(message, caption, buttons) == DialogResult.Yes) ResetGame();
            else { Application.Exit(); }
        }

        private void ResetGame() {
            buttons = new List<Button>() { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

            player1.Clear();
            player2.Clear();

            foreach (Button button in buttons) button.Text = "";

            clickCounter = 0;
            counterForWinningB = 0;
            counterForWinningA = 0;
        }
    }
}
