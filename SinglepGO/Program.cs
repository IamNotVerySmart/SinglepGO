using System.Threading;
using SinglepGO;

Board board = new Board();

while (board.isGameOn)
{
    board.Move();
    board.generateBoard();
    board.CheckIfPlayerKilled();
    board.checkWinConditions();
}