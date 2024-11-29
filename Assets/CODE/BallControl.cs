using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] GameObject[] Balls;
    [SerializeField] GameObject Droper,GameOverUi;
    PolygonCollider2D polygonCollider;
   [SerializeField] Droper droper;
   [SerializeField] AudioControl audioControl;
    [SerializeField] MainMenuControl mainMenuControl;
    [SerializeField] TMP_Text textPoint;
    [SerializeField]Sprite sprite;
    [SerializeField]SpriteRenderer spriteRenderer;
    public int Points;
    public Vector3 A; 
    public int Ballnum;
    public bool NewBall=false,HaveBall,Gameover;
    int wincon=0;
    
    int newOrderInLayer=1;
    
    // Start is called before the first frame update
   
   //  public void Test()
   //  {
   //      for(int i=0;i<Balls.Length;i++)
   //      {
            
   //            BallShapeOrNot(Balls[i]);
   //          // ChangeCollider(Balls[i]);
   //      }
   //  }

    
    // Update is called once per frame
   //  public void BallShapeOrNot(GameObject Ball)
   //  {
   //      if(mainMenuControl.KeepShape)
   //      {
            
            
   //              spriteRenderer=Ball.GetComponent<SpriteRenderer>();
   //              spriteRenderer.maskInteraction=SpriteMaskInteraction.VisibleInsideMask;
   //             // spriteRenderer.size=new Vector2(1,1);
   //      }
   //      else
   //      {
             
   //              spriteRenderer=Ball.GetComponent<SpriteRenderer>();
   //              spriteRenderer.maskInteraction=SpriteMaskInteraction.None;
   //            //  spriteRenderer.size=new Vector2(1,1);
   //      }
   //  }
   //   void ChangeCollider(GameObject Balls)
   //  {
   //      polygonCollider = Balls.GetComponent<PolygonCollider2D>();
   //          sprite = Balls.GetComponent<SpriteRenderer>().sprite;
   //      for (int i = 0; i < polygonCollider.pathCount; i++) 
   //      polygonCollider.pathCount = sprite.GetPhysicsShapeCount();

   //      List<Vector2> path = new List<Vector2>();
   //      for (int i = 0; i < polygonCollider.pathCount; i++) {
   //      path.Clear();
   //      sprite.GetPhysicsShape(i, path);
   //      polygonCollider.SetPath(i, path.ToArray());
        
   //      }
   //      //spriteRenderer=Balls.GetComponent<SpriteRenderer>();
   //    //  spriteRenderer.size=new Vector2(1,1);
   //  }

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
            // Get the mouse position on the screen
            // Vector3 mouseScreenPosition = Input.mousePosition;

            // // Convert the screen position to world position
            // Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
            
            // // Set the z-coordinate to match the object's z-level (optional, if needed)
            // mouseWorldPosition.z = 0; // Or another value depending on your game
             Vector3 SpawnPoint=Droper.transform.position;
            SpawnPoint.y=2.7f;
            int Rand=Random.Range(1,10);
            int i=0;
            if(Rand==1)
            i=3;
            else if(Rand<5)
            i=2;
            else 
            i=1;
            Spawner(SpawnPoint,i,true);
            HaveBall=true;
            // Output the world position to the console
           // Debug.Log("Mouse clicked at world position: " + mouseWorldPosition);
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
        GameObject Ball=Balls[0];
        switch (BallNum)
        {
            case 1:
               Ball=Balls[0];
            break;
            case 2:
               Ball=Balls[1];
            break;
            case 3:
               Ball=Balls[2];
            break;
            case 4:
               Ball=Balls[3];
            break;
            case 5:
               Ball=Balls[4];
            break;
            case 6:
               Ball=Balls[5];
            break;
            case 7:
               Ball=Balls[6];
            break;
            case 8:
               Ball=Balls[7];
            break;
            case 9:
               Ball=Balls[8];
            break;
            case 10:
               Ball=Balls[9];
            break;
            case 11:
               Ball=Balls[10];
               wincon++;
            break;
        }
             
        GameObject A= Instantiate(Ball, spawnPosition, Quaternion.identity);
               A.GetComponent<SpriteRenderer>().sortingOrder=newOrderInLayer;
               
               SpriteMask spriteMask;
               spriteMask=A.GetComponent<SpriteMask>();
               spriteMask.backSortingOrder=newOrderInLayer-1;
               spriteMask.frontSortingOrder=newOrderInLayer+1;
               newOrderInLayer+=2;
         if(Droper)
         {
           // A.GetComponent<Rigidbody2D>().constraints= RigidbodyConstraints2D.FreezePositionY;
           A.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            droper.Ball=A;
         }     
               
    }


}
