using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SinglepGO
{
    internal class Enemy
    {
        Board Board = new Board();
        Player player = new Player();
        public int[] enemy1Position = new int[2];
        public int[] enemy2Position = new int[2];
        public bool enemy1Killed = false;
        public bool enemy2Killed = false;

        //moves enemy if player made move
        public void moveEnemyPosition()
        {
            if (!player.playerTurn)
            {
                Board.board[enemy1Position[0], enemy1Position[1]] = "-";
                enemy1Position[0] += 1;
                Board.board[enemy2Position[0], enemy2Position[1]] = "-";
                enemy2Position[0] += 1;
                player.playerTurn = true;
                if (player.playerPosition[0] == enemy1Position[0] && player.playerPosition[1] == enemy1Position[1])
                {
                    player.playerKilled = true;
                    Board.generateBoard();
                }
                if (player.playerPosition[0] == enemy2Position[0] && player.playerPosition[1] == enemy2Position[1])
                {
                    player.playerKilled = true;
                    Board.generateBoard();
                }
            }
        }
    }
}
