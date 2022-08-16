using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonNumber : MonoBehaviour
{
    [SerializeField] public int LogCount;
    [SerializeField] Vector3 logOffset;
    [SerializeField] Vector3 firstPosition;
    [SerializeField] public Vector3 currentPos;
    //float z = -0.1452f;
   

    private void Start()
    {
        LogCount = 0;
        logOffset = new Vector3(0f, 0f, 0.008f); 
    }
    public Vector3 WagonOffsetIncrease()
    {   
        if(LogCount < 4)
        {
            return currentPos + logOffset;
          // return currentPos = new Vector3(currentPos.x, currentPos.y, z);
        }
        else if(LogCount == 4)
        {
            currentPos = new Vector3(currentPos.x, currentPos.y + 0.00621f, firstPosition.z);
            return currentPos ;
        }
        else if(LogCount == 9)
        {
            return logOffset;
        }
        else
        {
            return currentPos + logOffset;
        }  
    }
}
