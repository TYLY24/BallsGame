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
        
        GetTouch();
      
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
