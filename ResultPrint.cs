using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPrint : MonoBehaviour
{
    [SerializeField] GameObject ResultCanves;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "TriggeredPoint")
        {
            ResultCanves.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
