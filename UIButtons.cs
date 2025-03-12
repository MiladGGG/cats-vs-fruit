using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public Texture oneSpeed;
    public Texture twoSpeed;
    public RawImage speedUpButton;
    public bool spedUp;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseGame()
    {
        Application.Quit();
    }
    public void SpeedUp()
    {

        if(spedUp == false)
        {
            spedUp = true;

            Time.timeScale = 2.5f;

            speedUpButton.texture = twoSpeed;

        }
        else
        {
            spedUp = false;


            Time.timeScale = 1f;

            speedUpButton.texture = oneSpeed;

        }
    }
}
