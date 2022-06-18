using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject redCoin;
    public GameObject yellowCoin;
    public Transform startPoint;
    bool isActiveTurn=true;
    int currentPlayer = 1;

    private void Awake()
    {
        Instance = this;
    }
    public void PlayCoin(int column)
    {
        
        if (!isActiveTurn) { return; };

        int row =PlayField.Instance.ValidSpotCheck(column);

        if(row != -1)
        {
          StartCoroutine(  DropActualCoin(column, row));

        }

    }

    IEnumerator DropActualCoin(int column, int row)
    {
        isActiveTurn = false;
        GameObject coin = Instantiate((currentPlayer == 1) ? redCoin : yellowCoin) as GameObject;
        coin.transform.position = new Vector3(startPoint.transform.position.x + column, startPoint.transform.position.y + 1, startPoint.position.z);

        Vector3 goalPos = new Vector3(startPoint.transform.position.x + column, startPoint.transform.position.y - row, startPoint.position.z);

        while (MoveToGoal(goalPos, coin)) { yield return null; };

        
        
        PlayField.Instance.DropCoinData(row, column, currentPlayer);
        
    }

     bool MoveToGoal(Vector3 goalPos,GameObject coin)
    {
        return goalPos != (coin.transform.position = Vector3.MoveTowards(coin.transform.position, goalPos, 5 * Time.deltaTime));
    }

    public bool WinCondition(bool winner)
    {
        if (winner)
        {
            //win effect;  
        }

        if (!winner)
        {
            isActiveTurn = true;
            currentPlayer = (currentPlayer == 1) ? 2 : 1;
        }
        return true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
