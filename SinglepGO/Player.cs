using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SinglepGO
{
    public class Player
    {
        Board Board = new Board();
        Enemy enemy = new Enemy();
        public int[] playerPosition = new int[2];
        private string[] correctInputs = { "h", "j", "k", "l", "hj", "jh", "hk", "kh", "jl", "lj", "lk", "kl" };
        private bool positionChange = false;
        public bool playerTurn = true; // decide who starts (true = player start)
        public bool playerKilled = false;

        //if player can move read input from user and moves acordingly
        public void Move()
        {
            if (playerTurn)
            {
                Console.WriteLine("To move you simply write direction in which you want to move: \n(k - up, h - left, j - down, l - right)");
                string input = Console.ReadLine()!;
                if (input == "")
                {
                    Console.WriteLine("No input detected, please try again.");
                    Move();
                }
                else
                {
                    foreach (string ci in correctInputs)
                    {
                        if (input == ci)
                        {
                            if (input == "k")
                            {
                                Board.board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[0] -= 1;
                                positionChange = true;
                            }
                            if (input == "j")
                            {
                                Board.board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[0] += 1;
                                positionChange = true;
                            }
                            if (input == "h")
                            {
                                Board.board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[1] -= 1;
                                positionChange = true;
                            }
                            if (input == "l")
                            {
                                Board.board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[1] += 1;
                                positionChange = true;
                            }
                            if (input == "hj")
                            {
                                Board.board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[0] += 1;
                                playerPosition[1] -= 1;
                                positionChange = true;
                            }
                            if (input == "jh")
                            {
                                Board.board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[0] += 1;
                                playerPosition[1] -= 1;
                                positionChange = true;
                            }
                            if (input == "hk")
                            {
                                Board.board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[0] -= 1;
                                playerPosition[1] -= 1;
                                positionChange = true;
                            }
                            if (input == "kh")
                            {
                                Board.board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[0] -= 1;
                                playerPosition[1] -= 1;
                                positionChange = true;
                            }
                            if (input == "lj")
                            {
                                Board.board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[0] += 1;
                                playerPosition[1] += 1;
                                positionChange = true;
                            }
                            if (input == "jl")
                            {
                                Board.board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[0] += 1;
                                playerPosition[1] += 1;
                                positionChange = true;
                            }
                            if (input == "lk")
                            {
                                Board.board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[0] -= 1;
                                playerPosition[1] += 1;
                                positionChange = true;
                            }
                            if (input == "kl")
                            {
                                Board.board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[0] -= 1;
                                playerPosition[1] += 1;
                                positionChange = true;
                            }


                        }
                    }
                    if (!positionChange)
                    {
                        Console.WriteLine("Wrong character input, please try again.");

                        Move();
                    }
                    positionChange = false;
                }
                if (playerPosition[0] == enemy.enemy1Position[0] && playerPosition[1] == enemy.enemy1Position[1])
                {
                    enemy.enemy1Killed = true;
                    Board.generateBoard();
                }
                if (playerPosition[0] == enemy.enemy2Position[0] && playerPosition[1] == enemy.enemy2Position[1])
                {
                    enemy.enemy2Killed = true;
                    Board.generateBoard();
                }
                playerTurn = false;
            }
        }
    }
}
