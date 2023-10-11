namespace SinglepGO
{
    internal class Board
    {
        //make fing class for those i cant look at them anymore!!!!!!!
        //make fing class for those i cant look at them anymore!!!!!!!
        //make fing class for those i cant look at them anymore!!!!!!!
        //make fing class for those i cant look at them anymore!!!!!!!
        //make fing class for those i cant look at them anymore!!!!!!!
        //make fing class for those i cant look at them anymore!!!!!!!
        //make fing class for those i cant look at them anymore!!!!!!!
        //make fing class for those i cant look at them anymore!!!!!!!
        //player and enemy at least should have own classes
        //make fing class for those i cant look at them anymore!!!!!!!
        private string[,] board = new string[10, 10];
        Random rnd = new Random();
        private int[] playerPosition = new int[2];
        private int[] enemy1Position = new int[2];
        private int[] enemy2Position = new int[2];
        public bool isGameOn = true;
        private bool boardCreated = false;
        private string[] correctInputs = { "h", "j", "k", "l", "hj", "jh", "hk", "kh", "jl", "lj", "lk", "kl" };
        private bool positionChange = false;
        private bool playerTurn = true; // decide who starts (true = player start)
        private bool enemy1killed = false;
        private bool enemy2killed = false;

        public Board()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = "-";
                }
            }
        }
        //generates board and works as respawn for enemy
        public void generateBoard()
        {
            while (!boardCreated || enemy1killed || enemy2killed)
            {
                if (!boardCreated)
                {
                    playerPosition[0] = board.GetLength(0) - 1;
                    playerPosition[1] = rnd.Next(board.GetLength(1));
                }
                if (!boardCreated || enemy1killed)
                {
                    enemy1Position[0] = 1;
                    enemy1Position[1] = rnd.Next(board.GetLength(1));
                    enemy1killed = false;
                }
                if (!boardCreated || enemy2killed)
                {
                    enemy2Position[0] = 1;
                    while (enemy1Position[1] == enemy2Position[1]) 
                    { 
                        enemy2Position[1] = rnd.Next(board.GetLength(1));
                    }
                    enemy2killed = false;
                }
                boardCreated = true;
            }
            Console.Clear();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (i == playerPosition[0] && j == playerPosition[1])
                    {
                        board[i, j] = "@";
                    }
                    if (i == enemy1Position[0] && j == enemy1Position[1])
                    {
                        board[i, j] = "#";
                    }
                    if (i == enemy2Position[0] && j == enemy2Position[1])
                    {
                        board[i, j] = "#";
                    }
                    Console.Write("[" + board[i, j] + "]" + " ");
                }
                Console.WriteLine();
            }
        }
        //if player can move read input from user and moves acordingly
        public void movePlayerPosition()
        {
            if (playerTurn)
            { 
                Console.WriteLine("To move you simply write direction in which you want to move: \n(k - up, h - left, j - down, l - right)");
                string input = Console.ReadLine()!;
                if (input == "")
                {
                    Console.WriteLine("No input detected, please try again.");
                    movePlayerPosition();
                }
                else
                {
                    foreach (string ci in correctInputs)
                    {
                        if (input == ci)
                        {
                            if (input == "k")
                            {
                                board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[0] -= 1;
                                positionChange = true;
                            }
                            if (input == "j")
                            {
                                board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[0] += 1;
                                positionChange = true;
                            }
                            if (input == "h")
                            {
                                board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[1] -= 1;
                                positionChange = true;
                            }
                            if (input == "l")
                            {
                                board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[1] += 1;
                                positionChange = true;
                            }
                            if (input == "hj")
                            {
                                board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[0] += 1;
                                playerPosition[1] -= 1;
                                positionChange = true;
                            }
                            if (input == "jh")
                            {
                                board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[0] += 1;
                                playerPosition[1] -= 1;
                                positionChange = true;
                            }
                            if (input == "hk")
                            {
                                board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[0] -= 1;
                                playerPosition[1] -= 1;
                                positionChange = true;
                            }
                            if (input == "kh")
                            {
                                board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[0] -= 1;
                                playerPosition[1] -= 1;
                                positionChange = true;
                            }
                            if (input == "lj")
                            {
                                board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[0] += 1;
                                playerPosition[1] += 1;
                                positionChange = true;
                            }
                            if (input == "jl")
                            {
                                board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[0] += 1;
                                playerPosition[1] += 1;
                                positionChange = true;
                            }
                            if (input == "lk")
                            {
                                board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[0] -= 1;
                                playerPosition[1] += 1;
                                positionChange = true;
                            }
                            if (input == "kl")
                            {
                                board[playerPosition[0], playerPosition[1]] = "-";
                                playerPosition[0] -= 1;
                                playerPosition[1] += 1;
                                positionChange = true;
                            }


                        }
                    }
                    if (!positionChange)
                    {
                        Console.WriteLine("Wrong character input, please try again.");

                        movePlayerPosition();
                    }
                    positionChange = false;
                }
                playerTurn = false;
            }
        }
        //moves enemy if player made move
        public void moveEnemyPosition()
        {
            if (!playerTurn)
            {
                board[enemy1Position[0], enemy1Position[1]] = "-";
                enemy1Position[0] += 1;
                board[enemy2Position[0], enemy2Position[1]] = "-";
                enemy2Position[0] += 1;
                playerTurn = true;
            }
        }
        //checks if game ended or if position of player is same as enemy
        //if so marks enemy as killed and generate board again
        public void checkPositions()
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
            if (playerPosition[0] == enemy1Position[0] && playerPosition[1] == enemy1Position[1])
            {
                enemy1killed = true;
                generateBoard();
            }
            if (playerPosition[0] == enemy2Position[0] && playerPosition[1] == enemy2Position[1])
            {
                enemy2killed = true;
                generateBoard();
            }
        }
    }
}
