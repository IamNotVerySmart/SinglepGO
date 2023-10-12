namespace SinglepGO
{
    internal class Board
    {
        Player player = new Player();
        Enemy enemy = new Enemy();
        public string[,] board = new string[10, 10];
        Random rnd = new Random();
        public bool isGameOn = true;
        private bool boardCreated = false;

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
            while (!boardCreated || enemy.enemy1Killed || enemy.enemy2Killed)
            {
                if (!boardCreated || player.playerKilled)
                {
                    player.playerPosition[0] = board.GetLength(0) - 1;
                    player.playerPosition[1] = rnd.Next(board.GetLength(1));
                    player.playerKilled = false;
                }
                if (!boardCreated || enemy.enemy1Killed)
                {
                    enemy.enemy1Position[0] = 1;
                    enemy.enemy1Position[1] = rnd.Next(board.GetLength(1));
                    enemy.enemy1Killed = false;
                }
                if (!boardCreated || enemy.enemy2Killed)
                {
                    enemy.enemy2Position[0] = 1;
                    while (enemy.enemy1Position[1] == enemy.enemy2Position[1]) 
                    {
                        enemy.enemy2Position[1] = rnd.Next(board.GetLength(1));
                    }
                    enemy.enemy2Killed = false;
                }
                boardCreated = true;
            }
            Console.Clear();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (i == player.playerPosition[0] && j == player.playerPosition[1])
                    {
                        board[i, j] = "@";
                    }
                    if (i == enemy.enemy1Position[0] && j == enemy.enemy1Position[1])
                    {
                        board[i, j] = "#";
                    }
                    if (i == enemy.enemy2Position[0] && j == enemy.enemy2Position[1])
                    {
                        board[i, j] = "#";
                    }
                    Console.Write("[" + board[i, j] + "]" + " ");
                }
                Console.WriteLine();
            }
        }
        
        //checks if player or enemy has reached the end
        public void checkWinConditions()
        { 
            if (player.playerPosition[0] <= 0)
            {
                Console.WriteLine("CONGRATULATIONS PLAYER WON!!!");
                isGameOn = false;
            }
            if (enemy.enemy1Position[0] >= 9 || enemy.enemy2Position[0] >= 9)
            {
                Console.WriteLine("good times never last... lybd lubdy laby lib");
                isGameOn = false;
            }
        }
    }
}
