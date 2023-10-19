// See https://aka.ms/new-console-template for more information
using SinglepGO;

Board board = new Board();

while (board.isGameOn)
{
    board.generateBoard();
    board.checkWinConditions();
    if (board.isGameOn)
    {
        board.generateBoard();
        board.Move();
        //board.MoveEnemyPosition();
        board.CheckIfPlayerKilled();
    }
}
/***********************************************************
 *
 *      Trzeba dodać jeszcze real-time poruszanie 
 *      oraz dać możliwość 2 ruchów z czekaniem na ruch gracza
 *      bo narazie nie da sie tego wygrać.
 *
 **********************************************************/