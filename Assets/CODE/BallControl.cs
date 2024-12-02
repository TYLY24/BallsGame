using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] GameObject[] Balls;
    [SerializeField] GameObject Droper,GameOverUi;
   [SerializeField] Droper droper;
   [SerializeField] AudioControl audioControl;
    [SerializeField] TMP_Text textPoint;
    public int Points;
    public Vector3 A; 
    public int Ballnum;
    public bool NewBall=false,HaveBall,Gameover;
    int wincon=0;
    
    int newOrderInLayer=1;

    private Dictionary<string, Stack<GameObject>> BallsStack;
    
    void Start()
    {
      BallsStack = new Dictionary<string, Stack<GameObject>>();
      for(int i=0;i<Balls.Length;i++)
        BallsStack[i.ToString()] = new Stack<GameObject>();
    }
    

    void Update()
    {
      if(Gameover)
        {
         GameOverUi.SetActive(true);
         textPoint.text=Points.ToString();
         Gameover=false;

        }
        else
        {

        
       if(NewBall)
       {
         audioControl.Playsfx(audioControl.bubblePop);
        Spawner(A,Ballnum,false);
        
        NewBall=false;
        PointsPlus(Ballnum);
       }
        if (!HaveBall)
        {
             Vector3 SpawnPoint=Droper.transform.position;
            SpawnPoint.y=2.7f;
            int Rand=Random.Range(1,10);
            int i=0;
            if(Rand==1)
            i=2;
            else if(Rand<5)
            i=1;
            else 
            i=0;
            Spawner(SpawnPoint,i,true);
            HaveBall=true;
         
        }
      //   if(wincon==2)
      //   {
      //    Gameover=true;
      //    wincon++;
      //   }
        
        }
    }
    
    
    void PointsPlus(int Poitn)
   {
      int P=2;
      for (int i=1;i<=Poitn-1;i++)
      {
         P*=2;
      }
      Points+=P;
      
   }
    public void Spawner(Vector3 spawnPosition,int BallNum,bool Droper)
    {
      if(BallNum==11)
        {
          wincon++;
        }
       GameObject Ball=Balls[0];
        GameObject A;

        if(BallsStack[BallNum.ToString()].Count>0)
        {
          A = BallsStack[BallNum.ToString()].Pop();
          A.transform.position=spawnPosition;
          A.SetActive(true);
        }
        else
        {
          Ball=Balls[BallNum];
           A= Instantiate(Ball, spawnPosition, Quaternion.identity);
               A.GetComponent<SpriteRenderer>().sortingOrder=newOrderInLayer;
               A.GetComponent<BallMerge>().ballControl=this;
               SpriteMask spriteMask;
               spriteMask=A.GetComponent<SpriteMask>();
               spriteMask.backSortingOrder=newOrderInLayer-1;
               spriteMask.frontSortingOrder=newOrderInLayer+1;
               newOrderInLayer+=2;
        }

         if(Droper)
         {
           A.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            droper.Ball=A;
         }     
               
    }

    public void GetBallBack(GameObject B,int BallNumber)
    {
      BallsStack[(BallNumber-1).ToString()].Push(B);
      B.SetActive(false);
    }




}
