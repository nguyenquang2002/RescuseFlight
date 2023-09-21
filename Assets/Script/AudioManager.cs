using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Button musicToggle;
    public Sprite musicOn, musicOff;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("MusicSlider") )
        {
            PlayerPrefs.SetFloat("MusicSlider", 0.8f);
            Load();
        }
        else
            Load();
        if (!PlayerPrefs.HasKey("MusicToggle"))
            AudioListener.pause = false;
        else
        {
            if (PlayerPrefs.GetInt("MusicToggle") == 0)
                AudioListener.pause = false;
            else AudioListener.pause = true;
        }
        if (AudioListener.pause)
            musicToggle.image.sprite = musicOff;
        else
            musicToggle.image.sprite = musicOn;
        AudioListener.pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeVolume()
    {
        AudioListener.volume = musicSlider.value;
        Save();
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("MusicSlider", musicSlider.value);
    }
    private void Load()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicSlider");
        
    }
    public void Toggle()
    {
        AudioListener.pause = !AudioListener.pause;
        if (AudioListener.pause)
        {
            musicToggle.image.sprite = musicOff;
            PlayerPrefs.SetInt("MusicToggle", 1);
        }
        else
        {
            musicToggle.image.sprite = musicOn;
            PlayerPrefs.SetInt("MusicToggle", 0);
        }
    }
}
