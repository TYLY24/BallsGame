using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] GameObject[] Balls;
    PolygonCollider2D polygonCollider;
    [SerializeField] MainMenuControl mainMenuControl;
    [SerializeField]Sprite sprite;
    [SerializeField]SpriteRenderer spriteRenderer;
    Color color;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    public void Test()
    {
        for(int i=0;i<Balls.Length;i++)
        {
            
              BallShapeOrNot(Balls[i]);
            // ChangeCollider(Balls[i]);
        }
    }

    
    // Update is called once per frame
    void BallShapeOrNot(GameObject Ball)
    {
        if(mainMenuControl.KeepShape)
        {
            
            
                spriteRenderer=Ball.GetComponent<SpriteRenderer>();
                spriteRenderer.maskInteraction=SpriteMaskInteraction.VisibleInsideMask;
               // spriteRenderer.size=new Vector2(1,1);
        }
        else
        {
             
                spriteRenderer=Ball.GetComponent<SpriteRenderer>();
                spriteRenderer.maskInteraction=SpriteMaskInteraction.None;
              //  spriteRenderer.size=new Vector2(1,1);
        }
    }
    //  void ChangeCollider(GameObject Balls)
    // {
    //     polygonCollider = Balls.GetComponent<PolygonCollider2D>();
    //         sprite = Balls.GetComponent<SpriteRenderer>().sprite;
    //     for (int i = 0; i < polygonCollider.pathCount; i++) 
    //     polygonCollider.pathCount = sprite.GetPhysicsShapeCount();

    //     List<Vector2> path = new List<Vector2>();
    //     for (int i = 0; i < polygonCollider.pathCount; i++) {
    //     path.Clear();
    //     sprite.GetPhysicsShape(i, path);
    //     polygonCollider.SetPath(i, path.ToArray());
        
    //     }
    //     //spriteRenderer=Balls.GetComponent<SpriteRenderer>();
    //   //  spriteRenderer.size=new Vector2(1,1);
    // }
}
