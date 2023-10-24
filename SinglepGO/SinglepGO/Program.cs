
using SinglepGO;

Board board = new Board();



while (board.isGameOn)
{
    //board.MoveEnemyPosition();
    board.generateBoard();

}
/***********************************************************
 *
 *      Trzeba dodać jeszcze real-time poruszanie 
 *      oraz dać możliwość 2 ruchów z czekaniem na ruch gracza
 *      bo narazie nie da sie tego wygrać.
 *
 **********************************************************/