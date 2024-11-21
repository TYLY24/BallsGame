using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Droper : MonoBehaviour
{
    // Start is called before the first frame update
     Vector2 A,B;
     [SerializeField] GameObject CountDown;
     [SerializeField] RawImage Countdownimg;
     [SerializeField] Texture2D[] CountDownNum;
     [SerializeField] bool CroutineRun,Clicked=false,test;
     public GameObject Ball;
     [SerializeField] Vector2 Boxsize;
    [SerializeField] float castDis;
    [SerializeField] LayerMask BallLayer;
    [SerializeField] Button Drop;
    private Coroutine myCoroutine;

    private Vector2 previousFingerPosition;
    private bool isDragging = false;
    [SerializeField]BallControl ballControl;
    //  private void OnTriggerStay2D(Collider2D other)
    // {
    // //     if (other.CompareTag("1") || other.CompareTag("2")||other.CompareTag("3") || other.CompareTag("4"))
    // //     {
    // //         // Execute your logic here if the tag is "Ball" or "Bubble"
    // //         ballControl.HaveBall=true;
    // //         Ball=other.gameObject;
    // //         Debug.Log("Ball or Bubble is within the trigger!");
    // //     }
    //     if(other.gameObject!=Ball)
    //      if (other.CompareTag("1") || other.CompareTag("2")||other.CompareTag("3") || other.CompareTag("4")||other.CompareTag("5") 
    //     || other.CompareTag("6")||other.CompareTag("7") || other.CompareTag("8")||other.CompareTag("9") || other.CompareTag("10")||other.CompareTag("11"))
    //     {
    //       StartCoroutine(EndGame())  ;
    //     }
    //  }
    //   private void OnTriggerExit2D(Collider2D other)
    // {
    //     if(other.gameObject!=Ball)
    //      if (other.CompareTag("1") || other.CompareTag("2")||other.CompareTag("3") || other.CompareTag("4")||other.CompareTag("5") 
    //     || other.CompareTag("6")||other.CompareTag("7") || other.CompareTag("8")||other.CompareTag("9") || other.CompareTag("10")||other.CompareTag("11"))
    //     {
    //     StopCoroutine(EndGame());
    //     }
    // }
   
    public bool EndGameCheck()
    {
        RaycastHit2D hit=Physics2D.BoxCast(transform.position,Boxsize,0,-transform.up,castDis,BallLayer);
        if(hit&&hit.collider.gameObject!=Ball)
        return true;
        else
        return false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position-transform.up*castDis,Boxsize);
    }
    public IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1f);
        CountDown.SetActive(true);
        for(int i=3;i>0;i--)
        {
            Countdownimg.texture=CountDownNum[i-1];
            Debug.Log(i.ToString());
        yield return new WaitForSeconds(1f);
        }
        Time.timeScale = 0;
        ballControl.Gameover=true;
        
    }
    IEnumerator NewBall()
    {
        yield return new WaitForSeconds(1f);
        ballControl.HaveBall=false;
        Clicked=false;
    }
    // Update is called once per frame
    void Update()
    {
        test=EndGameCheck();
        
        if(EndGameCheck())
        {
            if(CroutineRun)
        {
          myCoroutine= StartCoroutine(EndGame());
          
            CroutineRun=false;
        }
        }
        
        
        else
        {
            if(myCoroutine!=null)
            {
                StopCoroutine(myCoroutine);
            
            CountDown.SetActive(false);
            }
            CroutineRun=true;
            
        }
        
        
        //     Vector2 mouseScreenPosition = Input.mousePosition;
        //  Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        //  A=transform.position;
         
        //  A.x=mouseWorldPosition.x;
        //  if(A.x>=4.3f)
        // {
        //   A.x=4.3f;

        // }
        //  else if(A.x<=-4.1f)
        //  {
            
        //     A.x=-4.3f;
        //  }
        //  else
        //  A.x=mouseWorldPosition.x;
        //  transform.position=A;
         
         
        // if(!Clicked)
        // if (Input.GetMouseButtonDown(0))
        // {
        //     Clicked=true;
        //     //Debug.Log("Left mouse button clicked!");

        //     // Additional code to handle the click
        //     BallFall();
        // }
        GetTouch();
        // if(!Clicked)
        // if (Input.touchCount > 0)
        // {
        //     Touch touch = Input.GetTouch(0);
        //     if((!Clicked && touch.phase == TouchPhase.Ended) || (touch.phase == TouchPhase.Canceled && !Clicked))
        //     {
                
        //             Clicked=true;
        //             BallFall();
                
        //     }
        // }
        if(Ball!=null)
         {
            B=Ball.transform.position;
            B.x=A.x;
            Ball.transform.position=B;
         }
    }
    public void BallDroped()
    {
        if(!Clicked)
        {
            Clicked=true;
            BallFall();
        }
    }
    void GetTouch()
    {
        
         if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
               
                previousFingerPosition = touch.position;
                isDragging = true;
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
              
                Vector2 delta = touch.position - previousFingerPosition;
                float newXPosition = transform.position.x + delta.x * Time.deltaTime;

                 newXPosition = Mathf.Clamp(newXPosition, -4.1f,4.3f);
              //  transform.Translate(delta.x * Time.deltaTime, 0, 0);
                A=  transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
                

                
                previousFingerPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended||touch.phase == TouchPhase.Canceled )
            {
                isDragging = false;
                
                
            }
            
        }
    }
    void BallFall()
    {
        if(Ball!=null)
        Ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Ball=null;
     
        StartCoroutine(NewBall());
        
    }
}
