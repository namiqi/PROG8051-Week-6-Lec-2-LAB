using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorials
{
    class Program
    {

        static void displayBoard(string[,] Board)
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                Console.WriteLine("");
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Console.Write(Board[i, j] + "  ");
                }
            }
        }

        static void getTurn(int turn)
        {
            if (turn % 2 == 0)
            {
                Console.WriteLine("\nPlayer 1's turn: ");
            }
            else
            {
                Console.WriteLine("\nPlayer 2's turn: ");
            }
        }

        static string GetPosition(string userposition)
        {
            int r = 0;
            int c = 0;

            switch (userposition)
            {
                case "1":
                    r = 0;
                    c = 0;
                    break;
                case "2":
                    r = 0;
                    c = 1;
                    break;
                case "3":
                    r = 0;
                    c = 2;
                    break;
                case "4":
                    r = 1;
                    c = 0;
                    break;
                case "5":
                    r = 1;
                    c = 1;
                    break;
                case "6":
                    r = 1;
                    c = 2;
                    break;
                case "7":
                    r = 2;
                    c = 0;
                    break;
                case "8":
                    r = 2;
                    c = 1;
                    break;
                case "9":
                    r = 2;
                    c = 2;
                    break;


            }
            return r.ToString() + " " + c.ToString();
        }

        static int userinput(string[,] Board, int r, int c, int turn)
        {


            if (turn % 2 == 0)
            {
                Board[r, c] = "X";
            }
            else
            {
                Board[r, c] = "O";
            }
            turn++;
            return turn;
        }

        static bool checkWinner(string[,] Board)
        {
            bool winnerfound = false;
            // check for winner
            if (Board[0, 0] == Board[0, 1] && Board[0, 1] == Board[0, 2])
            {
                Console.WriteLine(Board[0, 0] + " won");
                winnerfound = true;
            }
            else if (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2])
            {
                Console.WriteLine(Board[0, 0] + " won");
                winnerfound = true;
            }

            return winnerfound;
        }

        static void Main(string[] args)
        {
            // Board

            string[,] Board = { { "-", "-", "-" }, { "-", "-", "-" }, { "-", "-", "-" } };

            // Display the board
            displayBoard(Board);



            int turn = 0;
            // User inputs
            for (int n = 0; n < 8; n++)
            {

                getTurn(turn);

                Console.WriteLine("Enter your Position: ");
                string userposition = Console.ReadLine();

                string pos = GetPosition(userposition);

                int r = Convert.ToInt32(pos.Split(" ")[0]);
                int c = Convert.ToInt32(pos.Split(" ")[1]);
                if (Board[r, c] != "-")
                {
                    continue;
                }

                turn = userinput(Board, r, c, turn);
                displayBoard(Board);



                bool winner = checkWinner(Board);
                if (winner)
                {
                    Console.WriteLine("Game ended");
                    break;
                }



            }
        }
    }
}