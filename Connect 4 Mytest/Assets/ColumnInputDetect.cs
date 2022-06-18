using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnInputDetect : MonoBehaviour
{
     
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //GameManager.Instance.PlayCoin(column);
            GameManager.Instance.PlayCoin(System.Convert.ToInt32(gameObject.name));
        }
    }



}
