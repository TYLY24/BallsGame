using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Setting,Play1,Play2,LeaderBoards;
    [SerializeField ] Slider musicSlider,SfxSlider,musicSlider2,SfxSlider2;
    [SerializeField]    AudioMixer Mymixer;
    [SerializeField] Toggle toggleKeepShape;
    public bool KeepShape;
    [SerializeField] Mask rawImageMask;
    [SerializeField] SavenLoad savenLoad;
    [SerializeField] BallControl ballControl;
    
    void Awake()
    {
        Application.targetFrameRate=60;
        
        if(PlayerPrefs.HasKey("VfxcVol"))
        {
            LoadVolume();
            loadToggler();

        }
        else
        {
            VolumeMusic();
            SfxVolume();
        }
    }

    // Update is called once per frame
    public void Play()
    {
        Play2.SetActive(true);
        
        Play1.SetActive(true);
        gameObject.SetActive(false);
    }

    public void QUIT()
    {
         Application.Quit();
    }
    public void option()
    {
        Setting.SetActive(true);
    }
    ///SETTTIINGGGGG
    
    
    // public void KeepTheShape(bool A)
    // {
    //     if(A)
    //     {
    //         rawImageMask.enabled=true;
    //         PlayerPrefs.SetInt("KeepShape",1);
    //     }
        
    //     else
    //     {
    //         rawImageMask.enabled=false;
    //        PlayerPrefs.SetInt("KeepShape",0);
    //     }
    //     KeepShape=A;
    //      ballControl.Test();
    // }
    void loadToggler()
    {
        Debug.Log("KeepShape"+PlayerPrefs.GetInt("KeepShape"));
        bool A;
            if(PlayerPrefs.GetInt("KeepShape")==1)
            A=true;
            else
            A=false;
            toggleKeepShape.isOn = A;
            //KeepTheShape(A);
    }
    public void CLear()
    {
        savenLoad.ClearData();
        savenLoad.ClearDataPath();
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }




     public void VolumeMusic()
    {
        float Vol=musicSlider.value;
        Mymixer.SetFloat("MusicVolume",Mathf.Log10(Vol)*20);
        PlayerPrefs.SetFloat("musicVol",Vol);
        musicSlider2.value=Vol;
      //  LoadVolume();
    }
    public void VolumeMusic2()
    {
        float Vol=musicSlider2.value;
        Mymixer.SetFloat("MusicVolume",Mathf.Log10(Vol)*20);
        PlayerPrefs.SetFloat("musicVol",Vol);
      //  LoadVolume();
      musicSlider.value=Vol;
    }
    public void SfxVolume2()
    {
        float Vol=SfxSlider2.value;
        Mymixer.SetFloat("VfxVolume",Mathf.Log10(Vol)*20);
        PlayerPrefs.SetFloat("VfxcVol",Vol);
        SfxSlider.value=Vol;
      //  LoadVolume();
    }
     public void SfxVolume()
    {
        float Vol=SfxSlider.value;
        Mymixer.SetFloat("VfxVolume",Mathf.Log10(Vol)*20);
        PlayerPrefs.SetFloat("VfxcVol",Vol);
        SfxSlider2.value=Vol;
      //  LoadVolume();
    }
    public void LoadVolume()
    {
        SfxSlider2.value=SfxSlider.value=PlayerPrefs.GetFloat("VfxcVol");
        musicSlider2.value=musicSlider.value=PlayerPrefs.GetFloat("musicVol");
        VolumeMusic();
        SfxVolume();
        
    }
    public void Leader()
    {
        LeaderBoards.SetActive(true);
    }
    public void CloseLeader()
    {
        LeaderBoards.SetActive(false);
    }
}
