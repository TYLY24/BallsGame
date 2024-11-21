using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMerge : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int BallNumber ;
    [SerializeField] GameObject BallBig;
    public bool Lauch=false;
     [SerializeField] BallControl ballControl;
    void Start()
    {
        ballControl=FindObjectOfType<BallControl>();
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        
        // This method will be called when a collision happens with another collider
        if(BallNumber!=11)
        {
            GameObject otherObject = collision.gameObject;
        if(CompareTag(otherObject.tag))
        {
            Debug.Log("The tags of the two objects are the same!");
            Vector3 A=collision.gameObject.transform.position;
            
            //ballControl.Spawner(collision.gameObject.transform.position,BallNumber++);
             ballControl.A=A;
            ballControl.Ballnum=BallNumber+1;
            ballControl.NewBall=true;
            //StartCoroutine(ballControl.NewBallSpawn(A,BallNumber++));
           
           
              Destroy(collision.gameObject);
              Destroy(gameObject);
              // StopCoroutine("EndGame");
        }
    
        
        }
        
        // You can also access the collision details
        
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeadZone"))
        {
            StopCoroutine("EndGame");
        Debug.Log("Countdown stopped!");
        }
         
    }
    // Update is called once per frame
    
}
