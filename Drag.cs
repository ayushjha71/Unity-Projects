using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    Vector3 MOffset;
    public Vector3 InitialPos;
    public bool isMouseUp;

    [SerializeField] bool canDropLog;
    [SerializeField] GameObject wagon;
    [SerializeField] WagonNumber wagonNumber;
    [SerializeField] private GameObject wagonParent;

  // public Vector3 off;

    private void Start()
    {
        InitialPos = transform.position;
      //  off = new Vector3(0f, 0f, -0.009f);
    }
    public void OnMouseDown()
    {
        isMouseUp = false;
        MOffset = transform.position - MouseWorldPos();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Wagon")
        {
            wagon = other.gameObject;
            Debug.Log("iNCREASING log");
            other.GetComponent<WagonNumber>().LogCount++;
           // GameObject logs = new GameObject("logs");
            
            canDropLog = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Wagon")
        {
            wagon = null;
            canDropLog = false;
            other.GetComponent<WagonNumber>().LogCount--;
        }
    }
    public void OnMouseDrag()
    {
        transform.position = MouseWorldPos() + MOffset;
        
    }
    private void OnMouseUp()
    {
        if (canDropLog && wagon != null)
        {
            wagonNumber = wagon.GetComponent<WagonNumber>();
            transform.SetParent(wagon.transform);
           // transform.localPosition = wagonNumber.currentPos + off;
            this.transform.localPosition = wagonNumber.currentPos;
           
            wagonNumber.currentPos = wagonNumber.WagonOffsetIncrease();

        }
        else
        {
            transform.position = InitialPos;
        }
    }
    public Vector3 MouseWorldPos()
    {
       var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}
