using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BallChange : MonoBehaviour
{
    public SaveInfo InfoToSave;
    [SerializeField]Texture[] image;
    [SerializeField] BallControl ballControl;
    [SerializeField] GameObject[] Ballls;
    [SerializeField]Texture2D imageGet;
    string pathGet;
    [SerializeField]SavenLoad saveNLoad;
    [SerializeField] RawImage rawimage,BackGr;
    [SerializeField] TMP_Dropdown TMPdropdownBall;
    [SerializeField] int BgWidth ;
    [SerializeField] int BgHeight;
    
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    // void Awake()
    // {
    //     #if !UNITY_EDITOR && UNITY_ANDROID
    //         using( AndroidJavaClass ajc = new AndroidJavaClass( "com.yasirkula.unity.NativeGalleryMediaPickerFragment" ) )
    //         ajc.SetStatic<bool>( "GrantPersistableUriPermission", true );
    //     #endif
    // }
    void Start()

    {
        //InfoToSave.Balls=new string[12];
        for (int i=0;i<Ballls.Length;i++)
            {
                spriteRenderer=Ballls[i].GetComponent<SpriteRenderer>();
                
                if(InfoToSave.Balls[i]!=null)
                    {
                        
                        if(GetImage(InfoToSave.Balls[i]) is Texture2D texture2D)
                        spriteRenderer.sprite=TextureToSpriteMethod(texture2D);
                       // spriteRenderer.size = new Vector2(1,1);
                    }
                    
                else 
                    {
                        if(image[i] is Texture2D texture2D)
                        spriteRenderer.sprite=TextureToSpriteMethod(texture2D);
                      //  spriteRenderer.size = new Vector2(1,1);
                                
                    }
                
            }
       // ballControl.Test();
        
        SatIMAGE(InfoToSave.Balls,0);
        if(InfoToSave.Balls[11]!=null)
                BackGr.texture=GetImage(InfoToSave.Balls[11]);
                else 
                BackGr.texture=image[11];
        BGFitIn();
    }
    Sprite TextureToSpriteMethod(Texture2D texture)
    {
        // Create a sprite from the texture
        Rect spriteRect = new Rect(0, 0, texture.width, texture.height);
        Sprite newSprite = Sprite.Create(texture, spriteRect, new Vector2(0.5f, 0.5f));

        return newSprite;
    }
    // Update is called once per frame
    public void clear()
    {
       saveNLoad.ClearData();
    }

    public void pickimage()
    {
        if( NativeGallery.IsMediaPickerBusy() )
				return;
        Pickimage(50);
        
        
        InfoToSave.Balls[TMPdropdownBall.value]=pathGet;
        rawimage.texture=imageGet;
        if(TMPdropdownBall.value==11)
        BackGr.texture=imageGet;
        
       
    }
    
    public void BGFitIn()
    {
        
        float screenAspect = (float)Screen.width / Screen.height;
        float textureAspect = (float)BackGr.texture.width / BackGr.texture.height;

        // Calculate UV Rect to preserve aspect ratio without stretching
        if (screenAspect > textureAspect) // Screen is wider
        {
            float heightScale = textureAspect / screenAspect;
            BackGr.uvRect = new Rect(0, (1 - heightScale) / 2, 1, heightScale);
        }
        else // Screen is taller
        {
            float widthScale = screenAspect / textureAspect;
            BackGr.uvRect = new Rect((1 - widthScale) / 2, 0, widthScale, 1);
        }
    }

    public void CloseSave()
    {
       
       saveNLoad.Save();

    }


    void Pickimage(int maxSize)
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery( ( path ) =>
        {
          //  Debug.Log( "Image path: " + path );
            
            if( path != null )
            {
             //   pathGet=path;
             pathGet= path;
               // Debug.Log("Path saved: " + pathGet);
                // Create Texture from selected image
                imageGet = NativeGallery.LoadImageAtPath( path, maxSize );
                
                if( imageGet == null )
                {
                    Debug.Log( "Couldn't load texture from " + path );
                    return;
                }
            }
        });
        Debug.Log( "Permission result: " + permission );
    }
    Texture GetImage(string path)
    {
       return NativeGallery.LoadImageAtPath( path, 300 );
    }

    void SatIMAGE(string[] infoSave,int A)
    {
        if(infoSave[A]!=null)
        {
             Debug.Log("Ball:"+A+"Check");
            rawimage.texture=GetImage(infoSave[A]);
           
        }
                
                else 
                {
                    Debug.Log("Ball:"+A+"Null");
                    rawimage.texture=image[A];
                    
                }
                
    }
    
    public void BallsImage(int A)
    {
        SatIMAGE(InfoToSave.Balls, A);
        
               if(A==11)
               {
                if(InfoToSave.Balls[11]!=null)
                BackGr.texture=GetImage(InfoToSave.Balls[11]);
                else 
                BackGr.texture=image[A];
               
               }
                
         
        
        
    }
}
