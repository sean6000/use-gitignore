using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayField : MonoBehaviour
{
    public static PlayField Instance;

    const int numCols = 7;
    const int numRows = 6;

    int[,] board = new int[numRows, numCols]

    {

        {0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0 },
         {0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0 },
         {0,0,0,0,0,0,0 },


    };
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

        print(DebugBoard());

       // WinCheck();
    }
    
    public int ValidSpotCheck(int column)
    {
        for (int row = numRows - 1; row >= 0; row--)
        {

            if (board[row, column] == 0)
            {
               
                return row;
            }


        }
        Debug.Log("The column is full");
        return -1;


    }

    public void DropCoinData(int row, int column, int player)
    {
        board[row, column] = player;
        print(DebugBoard());
      GameManager.Instance.WinCondition(  WinCheck());
    }


    bool WinCheck()
    {
        if (HorizontalCheck()|| VerticalCheck() || DigonalCheck())
        {
            return true;
        }
        return false;
       
    }

    bool HorizontalCheck()
    {
        for (int row = numRows - 1; row >= 0; row--)
        {
            for (int column = 0; column < 4; column++)
            {
                if (board[row, column] > 0)
                {
                    if (board[row, column] == board[row, column + 1] &&
                  board[row, column] == board[row, column + 2] &&
                  board[row, column] == board[row, column + 3])
                    {
                        Debug.Log("Horizontol win: "+board[row,column]);
                        return true;
                    }
                }

            }
        }
        return false;
    }
    bool VerticalCheck()
    {
        for (int column = 0; column <numCols; column++)

            for (int row = 0; row <3; row++)
            {
                if (board[row, column] > 0)
                {
                    if (board[row, column] == board[row + 1, column] &&
                  board[row, column] == board[row + 2, column] &&
                  board[row, column] == board[row + 3, column])
                    {
                        Debug.Log("Vertical win: " + board[row, column]);

                        return true;
                    }
                }
            }return false;
    }
    bool DigonalCheck()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 4; column++)
            {

                if (board[row, column] > 0)
                {
                    if (board[row, column] == board[row + 1, column+1] &&
                      board[row, column] == board[row +2, column+2] &&
                      board[row, column] == board[row +3, column+3])
                    {
                        Debug.Log("Digonal win : " + board[row, column]);
                        return true;

                    }
                }
            }
        }

        for (int row =0; row <3; row++)
        {
            for (int column = 3; column <numCols; column++)
            {

                if (board[row, column] > 0)
                {
                    if (board[row, column] == board[row + 1, column - 1] &&
                      board[row, column] == board[row + 2, column - 2] &&
                      board[row, column] == board[row + 3, column - 3])
                    {
                        Debug.Log("Digonal win : " + board[row, column]);


                    }
                }
            }
        }
        return false;
    }
    
       string DebugBoard()
        {
            string s = "";
            string separator = ",";
            string border = "|";

            for (int i = 0; i < numRows; i++)
            {
                s += border;
                for (int j = 0; j < numCols; j++)
                {
                    s += board[i, j];
                    s += separator;
                }
                s += border + "\n";
            }
            return s;
        }
   
}
