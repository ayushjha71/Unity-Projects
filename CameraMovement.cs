using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float speed = 0.1f;
    [SerializeField] private Animator animator;

    [SerializeField] GameObject CheckMsg;
  
    [SerializeField] GameObject startMovingButton;
    [SerializeField] GameObject PreviousWagonButton;
    [SerializeField] GameObject InFoCanves;

    public GameObject[] wagonNumber;

    private Vector3 currentPos;
    public GameObject[] StartPos;
    public int currIndex;       // current index of the pos array
    enum ItemType { LogCOunt}
    [SerializeField] List <int> correctLog = new List<int>();

    [SerializeField] private AudioSource TrainHorn;

    [SerializeField] private Camera cameraOne;
    [SerializeField] private Camera cameraTwo;

    private void Start()
    {
        OnEnableCamera1();
        currIndex = 0;
        currentPos = transform.position;
    }

    private void Update()
    { 
      if (transform.position != currentPos)
      {
            transform.position = Vector3.Lerp(transform.position, StartPos[currIndex].transform.position, speed * Time.deltaTime);
      }
    }

    public void OnClickInFo()
    {
        InFoCanves.SetActive(true);
    }
    public void OnClickOK()
    {
        OnCloseMsg();
    }

    public void OnNextMoving()
    {
        if (currIndex < 9)
        {
            currIndex++;
        }
        currentPos = StartPos[currIndex].transform.position;
    }
    public void OnPreviousWagan()
    {
        if(currIndex>0)
        {
            currIndex--;
        }
        currentPos = StartPos[currIndex].transform.position;
    }
    public void OnDonePress()
    {
        CheckingFunction();
    }

    public void OnClickRestart()
    {
        Time.timeScale = 2f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void CheckingFunction()
    {
        for(int i =0;i<9;i++)
        {
            if (wagonNumber[i].transform.childCount == correctLog[i])
            {
                Debug.Log("Check ");
                if(i == 8)
                {
                    TrainHorn.Play();
                    Debug.Log("Play animation");
                    OnEnableCamera2();
                    animator.Play("train");

                }
            }
            else
            {
                CheckMsgEnable();
                return;
            }
        }
    }
    public void OnCloseMsg()
    {
        CheckMsg.SetActive(false);
    }
   public void CheckMsgEnable()
    {
       // Debug.Log("Message canves");
        CheckMsg.SetActive(true);
    }

    public void OnEnableCamera1()
    {
        cameraTwo.enabled = false;
        cameraOne.enabled = true;
        
    }
    public void OnEnableCamera2()
    {
        cameraOne.enabled = false;
        cameraTwo.enabled = true;
        
    }
}