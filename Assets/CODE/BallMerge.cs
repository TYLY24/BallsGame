using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMerge : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int BallNumber ;
     public BallControl ballControl;
     Rigidbody2D rigidbody2Ds;
     void Start()
     {
        rigidbody2Ds=GetComponent<Rigidbody2D>();
     }

     void OnCollisionEnter2D(Collision2D collision)
    {
        
        // This method will be called when a collision happens with another collider
        if(BallNumber!=11)
        {
            GameObject otherObject = collision.gameObject;
        if(rigidbody2Ds.bodyType !=RigidbodyType2D.Static)
        if(CompareTag(otherObject.tag))
        {
            Debug.Log("The tags of the two objects are the same!");
            Vector3 A=collision.gameObject.transform.position;
            
           
             ballControl.A=A;
            ballControl.Ballnum=BallNumber;
            ballControl.NewBall=true;
           
           
           
            ballControl.GetBallBack(this.gameObject,BallNumber);
             // Destroy(gameObject);
           
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
