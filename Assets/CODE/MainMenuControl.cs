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
    [SerializeField] GameObject Setting;
    [SerializeField ] Slider musicSlider,SfxSlider;
    [SerializeField]    AudioMixer Mymixer;
    [SerializeField] Toggle toggleKeepShape;
    public bool KeepShape;
    [SerializeField] Mask rawImageMask;
    [SerializeField] SavenLoad savenLoad;
    [SerializeField] BallControl ballControl;
    
    void Awake()
    {
        
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
    

    public void QUIT()
    {
         Application.Quit();
    }
    public void option()
    {
        Setting.SetActive(true);
    }
    ///SETTTIINGGGGG
    public void Close()
    {
        Setting.SetActive(false);
    }
    public void KeepTheShape(bool A)
    {
        if(A)
        {
            rawImageMask.enabled=true;
            PlayerPrefs.SetInt("KeepShape",1);
        }
        
        else
        {
            rawImageMask.enabled=false;
           PlayerPrefs.SetInt("KeepShape",0);
        }
        KeepShape=A;
         ballControl.Test();
    }
    void loadToggler()
    {
        Debug.Log("KeepShape"+PlayerPrefs.GetInt("KeepShape"));
        bool A;
            if(PlayerPrefs.GetInt("KeepShape")==1)
            A=true;
            else
            A=false;
            toggleKeepShape.isOn = A;
            KeepTheShape(A);
    }
    public void CLear()
    {
        savenLoad.ClearData();
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("SampleScene*");
    }




     public void VolumeMusic()
    {
        float Vol=musicSlider.value;
        Mymixer.SetFloat("MusicVolume",Mathf.Log10(Vol)*20);
        PlayerPrefs.SetFloat("musicVol",Vol);
    }
     public void SfxVolume()
    {
        float Vol=SfxSlider.value;
        Mymixer.SetFloat("VfxVolume",Mathf.Log10(Vol)*20);
        PlayerPrefs.SetFloat("VfxcVol",Vol);
    }
    public void LoadVolume()
    {
        SfxSlider.value=PlayerPrefs.GetFloat("VfxcVol");
        musicSlider.value=PlayerPrefs.GetFloat("musicVol");
        VolumeMusic();
        SfxVolume();
    }

}
