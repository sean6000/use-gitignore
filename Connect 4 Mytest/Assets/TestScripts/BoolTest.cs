using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolTest : MonoBehaviour
{
    Vector3 goalpos = new Vector3(3,3,3);
    public Transform cube;
    float number = 10;
    float countup=0;
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine( WhileTest());
    }

    IEnumerator WhileTest()
    {
       
        while (test())
        {
         
            yield return new WaitForSeconds(5f);
               print("what"); 
        }  

       
    }
           
     

    // Update is called once per frame
    bool test()
    
    {
        cube.transform.position = goalpos;
        countup += Time.deltaTime;
        return number !>= countup;
    }
}
