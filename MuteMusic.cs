using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MuteMusic : MonoBehaviour
{
    bool ismuted;
    public AudioSource music;
    public TextMeshProUGUI txt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MusicToggle()
    {
        if (ismuted == false)
        {
            ismuted = true;
            music.volume = 0;
            txt.text = "UNMUTE<br>MUSIC";
        }
        else
        {
            ismuted = false;
            music.volume = 0.1f;
            txt.text = "MUTE<br>MUSIC";
        }
    }
}
