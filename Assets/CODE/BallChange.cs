using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallChange : MonoBehaviour
{
    public SaveInfo InfoToSave;
    [SerializeField]Texture2D[] image;
    [SerializeField] BallControl ballControl;
    [SerializeField] GameObject[] Ballls;
    [SerializeField] RawImage[] BallEx;
    [SerializeField]Texture2D imageGet;
    string pathGet;
    [SerializeField] GameObject Setting;
    [SerializeField]SavenLoad saveNLoad;
    [SerializeField] RawImage rawimage,BackGr;
    [SerializeField] TMP_Dropdown TMPdropdownBall;

    
    SpriteRenderer spriteRenderer;

    void Start()

    {
        //InfoToSave.Balls=new string[12];
        for (int i=0;i<Ballls.Length;i++)
            {
                spriteRenderer=Ballls[i].GetComponent<SpriteRenderer>();
                SetBallExample(i);
                if(InfoToSave.Balls[i]!="")
                    {
                     //   Debug.Log("Ball"+i+1+"Check InfoSave");
                        if(GetImage(InfoToSave.Balls[i]) is Texture2D texture2D)
                        spriteRenderer.sprite=TextureToSpriteMethod(texture2D);
                        spriteRenderer.size = new Vector2(1,1);
                    }
                    
                else 
                    {
                        Debug.Log("Ball"+i+1+"Null InfoSave Load Default");
                        
                        spriteRenderer.sprite= TextureToSpriteMethod(image[i]);
                        spriteRenderer.size = new Vector2(1,1);
                                
                    }
                
            }
       // ballControl.Test();
        
        SatIMAGE(InfoToSave.Balls,0);
        if(InfoToSave.Balls[11]!="")
                BackGr.texture=GetImage(InfoToSave.Balls[11]);
                else 
                BackGr.texture=image[11];
        BGFitIn();
    }

    void SetBallExample(int A)
    {
        if(InfoToSave.Balls[A]!="")
        {
            // Debug.Log("Ball:"+A+1+"Check");
            BallEx[A].texture=GetImage(InfoToSave.Balls[A]);
           
        }
                
                else 
                {
                    Debug.Log("Ball:"+A+1+"Null");
                    BallEx[A].texture=image[A];
                    
                }
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
        pathGet=TMPdropdownBall.value.ToString();
        Pickimage(1400);
        
        
        InfoToSave.Balls[TMPdropdownBall.value]=pathGet;
        
        LoadAndApplyImage(InfoToSave.Balls[TMPdropdownBall.value]);
        rawimage.texture=imageGet;
        if(TMPdropdownBall.value==11)
        BackGr.texture=imageGet;
        
       
    }
    
    public void BGFitIn()
    {
        
        float screenAspect = (float)Screen.width / Screen.height;
        float textureAspect = (float)BackGr.texture.width / BackGr.texture.height;

        if (screenAspect > textureAspect) // Screen is to hon
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    void Pickimage(int maxSize)
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery( ( path ) =>
        {
    ;
            
            if( path != null )
            {
             
                string destinationPath = Path.Combine(Application.persistentDataPath, pathGet);
                File.Copy(path, destinationPath, true);
                Debug.Log($"Image copied to: {destinationPath}");
            }
        });

    }
    void LoadAndApplyImage(string Paths)
    {
 
        string imagePath = Path.Combine(Application.persistentDataPath, Paths);

 
        if (File.Exists(imagePath))
        {

            byte[] imageData = File.ReadAllBytes(imagePath);

    
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageData);


            imageGet = texture;

        }
        else
        {
            Debug.LogError("Image file not found.");
        }
    }
    Texture GetImage(string path)
    {
        string imagePath = Path.Combine(Application.persistentDataPath, path);
         if (File.Exists(imagePath))
        {
            // Load the image as a byte array
            byte[] imageData = File.ReadAllBytes(imagePath);

            // Create a texture from the byte array
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageData);

            // Apply the texture to the target material (or UI Image)
            return texture;
      
        }else
        return null;
       
    }

    void SatIMAGE(string[] infoSave,int A)
    {
        if(infoSave[A]!="")
        {
             Debug.Log("Ball:"+A+1+"Check");
            rawimage.texture=GetImage(infoSave[A]);
           
        }
                
                else 
                {
                    Debug.Log("Ball:"+A+1+"Null");
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
