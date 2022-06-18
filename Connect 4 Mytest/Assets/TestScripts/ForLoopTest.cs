using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForLoopTest : MonoBehaviour
{
    public Transform prefab;
    int[,] board = new int[6, 6]
    {
        {1,0,0,0,0,0 },
         {2,0,0,0,0,0 },
          {3,0,0,0,0,0 },
           {4,0,0,0,0,0 },
            {5,0,0,0,0,0 },
             {6,0,0,0,0,0 },

    };

    // Start is called before the first frame update
    void Start()
    {
     Debug.Log(   DebugBoard());


        ForLoopBool();

        Debug.Log(board[4, 0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void ForLoopBool()
    {
        for (int i = 5; i > 0; i--)
        {
            for (int j = 5; j >0; j--)
            {
                Transform cube = Instantiate(prefab, new Vector3(i, j,0), Quaternion.identity);
                cube.name = (1 * j).ToString();
            } 
        }
        
    }

    //void Count2dArray()
    //{
    //    for (int i = 0; i < 6; i++)
    //    {
    //        for (int j = 0; j < 6; j++)
    //        {
    //            Debug.Log(board[i, j]);
    //        }
    //    }

    //}
    string DebugBoard()
    {
        string s = "";
        string seperator = ",";
        string border = "|";

        for (int x = 0; x < 6; x++)
        {
            s += border;
            for (int y = 0; y < 6; y++)
            {
                s += board[x, y];
                s += seperator;
            }
            s += border + "\n";
        }
        return s;
    }

}
