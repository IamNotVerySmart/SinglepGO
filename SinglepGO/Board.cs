using System;

using System.Timers;

namespace SinglepGO
{
    internal class Board
    {
        public string[,] board = new string[10, 10];
        Random rnd = new Random();
        public bool isGameOn = true;
        private bool boardCreated = false;
        public int[] playerPosition = new int[2];
        //private string[] correctInputs = { "h", "j", "k", "l", "hj", "jh", "hk", "kh", "jl", "lj", "lk", "kl" };
        private bool positionChange = false;
        public bool playerTurn = true; // decide who starts (true = player start)
        public bool playerKilled = false;
        public int[] enemy1Position = new int[2];
        public int[] enemy2Position = new int[2];
        public bool enemy1Killed = false;
        public bool enemy2Killed = false;
        public int bonus = 0;
        public CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public Board()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = "-";
                }
            }
            generateBoard();
            System.Timers.Timer timer = new System.Timers.Timer(2000);
            timer.Elapsed += TimerElapsed;
            timer.AutoReset = true;
            timer.Start();
        }

        //generates board and works as respawn for enemy
        public void generateBoard()
        {
            if (!boardCreated || enemy1Killed || enemy2Killed || playerKilled)
            {
                if (!boardCreated || playerKilled)
                {
                    playerPosition[0] = board.GetLength(0) - 1;
                    playerPosition[1] = rnd.Next(board.GetLength(1));
                    playerKilled = false;
                }
                if (!boardCreated || enemy1Killed)
                {
                    enemy1Position[0] = 1;
                    while (enemy1Position[1] == enemy2Position[1] || playerPosition[1] == enemy1Position[1])
                    {
                        enemy1Position[1] = rnd.Next(board.GetLength(1));
                    }
                    enemy1Killed = false;
                }
                if (!boardCreated || enemy2Killed)
                {
                    enemy2Position[0] = 1;
                    while (enemy1Position[1] == enemy2Position[1] || playerPosition[1] == enemy2Position[1])
                    {
                        enemy2Position[1] = rnd.Next(board.GetLength(1));
                    }
                    enemy2Killed = false;
                }
            }
            Console.Clear();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (i == playerPosition[0] && j == playerPosition[1])
                    {
                        board[i, j] = "P";
                    }
                    if (i == enemy1Position[0] && j == enemy1Position[1])
                    {
                        board[i, j] = "E";
                    }
                    if (i == enemy2Position[0] && j == enemy2Position[1])
                    {
                        board[i, j] = "E";
                    }
                    Console.Write("[" + board[i, j] + "]" + "");
                }
                Console.WriteLine();
                boardCreated = true;
            }
            
            //MoveEnemyPosition();
            //CheckIfPlayerKilled();
            //if(bonus)
            //{
            //    cancellationTokenSource.Cancel();
            //    Move();
            //    bonus = false;
            //    cancellationTokenSource = new CancellationTokenSource();
            //}
            //Thread.Sleep(100);
        }

        //checks if player or enemy has reached the end
        public void checkWinConditions()
        {
            if (playerPosition[0] <= 0)
            {
                Console.WriteLine("CONGRATULATIONS PLAYER WON!!!");
                isGameOn = false;
            }
            if (enemy1Position[0] >= 9 || enemy2Position[0] >= 9)
            {
                Console.WriteLine("good times never last... lybd lubdy laby lib");
                isGameOn = false;
            }
        }

        private async Task<string> GetUserInputAsync()
        {
            return await Console.In.ReadLineAsync();
        }

        //if player can move read input from user and moves acordingly
        public async void Move()
        {
            await Console.Out.WriteLineAsync("To move you simply write direction in which you want to move: \n(k - up, h - left, j - down, l - right)");
            string input = await GetUserInputAsync();
            if (input == "")
            {
                Console.WriteLine("No input detected, please try again.");
                Move();
            }
            else
            {
                switch(input)
                {
                    case "k":
                        board[playerPosition[0], playerPosition[1]] = "-";
                        playerPosition[0] -= 1;
                        positionChange = true;
                        if (bonus > 0)
                        {
                            bonus--;
                        }
                        break;
                    case "j":
                        board[playerPosition[0], playerPosition[1]] = "-";
                        playerPosition[0] += 1;
                        positionChange = true;
                        if (bonus > 0)
                        {
                            bonus--;
                        }
                        break;
                    case "h":
                        board[playerPosition[0], playerPosition[1]] = "-";
                        playerPosition[1] -= 1;
                        positionChange = true;
                        if (bonus > 0)
                        {
                            bonus--;
                        }
                        break;
                    case "l":
                        board[playerPosition[0], playerPosition[1]] = "-";
                        playerPosition[1] += 1;
                        positionChange = true;
                        if (bonus > 0)
                        {
                            bonus--;
                        }
                        break;
                    case "hj":
                        board[playerPosition[0], playerPosition[1]] = "-";
                        playerPosition[0] += 1;
                        playerPosition[1] -= 1;
                        positionChange = true;
                        if (bonus > 0)
                        {
                            bonus--;
                        }
                        break;
                    case "jh":
                        board[playerPosition[0], playerPosition[1]] = "-";
                        playerPosition[0] += 1;
                        playerPosition[1] -= 1;
                        positionChange = true;
                        if (bonus > 0)
                        {
                            bonus--;
                        }
                        break;
                    case "hk":
                        board[playerPosition[0], playerPosition[1]] = "-";
                        playerPosition[0] -= 1;
                        playerPosition[1] -= 1;
                        positionChange = true;
                        if(bonus > 0)
                        {
                            bonus--;
                        }
                        break;
                    case "kh":
                        board[playerPosition[0], playerPosition[1]] = "-";
                        playerPosition[0] -= 1;
                        playerPosition[1] -= 1;
                        positionChange = true;
                        if (bonus > 0)
                        {
                            bonus--;
                        }
                        break;
                    case "lj":
                        board[playerPosition[0], playerPosition[1]] = "-";
                        playerPosition[0] += 1;
                        playerPosition[1] += 1;
                        positionChange = true;
                        if (bonus > 0)
                        {
                            bonus--;
                        }
                        break;
                    case "jl":
                        board[playerPosition[0], playerPosition[1]] = "-";
                        playerPosition[0] += 1;
                        playerPosition[1] += 1;
                        positionChange = true;
                        if (bonus > 0)
                        {
                            bonus--;
                        }
                        break;
                    case "lk":
                        board[playerPosition[0], playerPosition[1]] = "-";
                        playerPosition[0] -= 1;
                        playerPosition[1] += 1;
                        positionChange = true;
                        if (bonus > 0)
                        {
                            bonus--;
                        }
                        break;
                    case "kl":
                        board[playerPosition[0], playerPosition[1]] = "-";
                        playerPosition[0] -= 1;
                        playerPosition[1] += 1;
                        positionChange = true;
                        if (bonus > 0)
                        {
                            bonus--;
                        }
                        break;
                }
                if (!positionChange)
                {
                    Console.WriteLine("Wrong character input, please try again.");

                    Move();
                }
                positionChange = false;
            }
            if (playerPosition[0] == enemy1Position[0] && playerPosition[1] == enemy1Position[1])
            {
                enemy1Killed = true;
                bonus += 2;
                generateBoard();
            }
            if (playerPosition[0] == enemy2Position[0] && playerPosition[1] == enemy2Position[1])
            {
                enemy2Killed = true;
                bonus += 2;
                generateBoard();
            }
            generateBoard();
        }

        //moves enemy if player made move
        public void MoveEnemyPosition()
        {
            MoveEnemy(enemy1Position, 0);
            MoveEnemy(enemy2Position, 1);
            CheckIfPlayerKilled();
            generateBoard();
        }

        private void MoveEnemy(int[] enemyPosition, int enemyIndex)
        {
            int newX = enemyPosition[0];
            int newY = enemyPosition[1];

            if (enemyPosition[0] < playerPosition[0])
            {
                newX++;
            }
            else if (enemyPosition[0] > playerPosition[0])
            {
                newX--;
            }

            if (enemyPosition[1] < playerPosition[1])
            {
                newY++;
            }
            else if (enemyPosition[1] > playerPosition[1])
            {
                newY--;
            }

            if (IsCellEmpty(newX, newY) || IsPlayerCell(newX, newY))
            {
                board[enemyPosition[0], enemyPosition[1]] = "-";
                enemyPosition[0] = newX;
                enemyPosition[1] = newY;
                board[newX, newY] = "E" + enemyIndex;
            }
        }

        private bool IsCellEmpty(int x, int y)
        {
            return board[x, y] == "-";
        }

        private bool IsPlayerCell(int x, int y)
        {
            return board[x, y] == "P";
        }

        public void CheckIfPlayerKilled()
        {
            if (enemy1Position[0] == playerPosition[0] && enemy1Position[1] == playerPosition[1])
            {
                playerKilled = true;
            }
            if (enemy2Position[0] == playerPosition[0] && enemy2Position[1] == playerPosition[1])
            {
                playerKilled = true;
            }
        }

        public void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (isGameOn && !cancellationTokenSource.Token.IsCancellationRequested)
            {
                if (bonus == 0)
                {
                    MoveEnemyPosition();
                }
            }
        }
    }
}