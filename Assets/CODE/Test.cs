using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Test : MonoBehaviour
{
    PolygonCollider2D polygonCollider;
    
    Sprite sprite;
    Color color;
    // Start is called before the first frame update
    // void Start()
    // {
    //     polygonCollider = GetComponent<PolygonCollider2D>();
    //     sprite = GetComponent<SpriteRenderer>().sprite;
    //     //color=GetComponent<SpriteRenderer>().color;
        
    // }
    
    // Update is called once per frame
    // public void SAVE()
    // {
    //     // color.a=0.01f;
    //     // GetComponent<SpriteRenderer>().color = color;
    //     for (int i = 0; i < polygonCollider.pathCount; i++) //polygonCollider.SetPath(i, null);
    //     polygonCollider.pathCount = sprite.GetPhysicsShapeCount();

    //     List<Vector2> path = new List<Vector2>();
    //     for (int i = 0; i < polygonCollider.pathCount; i++) {
    //     path.Clear();
    //     sprite.GetPhysicsShape(i, path);
    //     polygonCollider.SetPath(i, path.ToArray());
        
    //     }
    // }
}
