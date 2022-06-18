using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropTest : MonoBehaviour
{
    const int numRows = 6;
    const int numCols = 7;
    //0== no coin,1 = player1,2=player2
    int[,] board = new int[numRows, numCols]
    {
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0},
    };

    void Start()
    {
        
        DropCoin(1,5);
        
    }

    bool DropCoin(int column, int player)
    {
        for (int i = numRows - 1; i>= 0; i--)
        {
            if (board[i, column] ==0)
            {
                board[i, column] = player;
                print(DebugBoard());
                return true;
            }
        }
        return false;
    }

    string DebugBoard()
    {
        string s = "";
        string seperator = ",";
        string border = "|";

        for (int x = 0; x < numRows; x++)
        {
            s += border;
            for (int y = 0; y < numCols; y++)
            {
                s += board[x, y];
                s += seperator;
            }
            s += border + "\n";
        }
        return s;
    }
}
