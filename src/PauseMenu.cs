using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
   
    public UIButtons uI;
    public GameObject guide;

    public int guidePage;

    public GameObject catGuide;
    public GameObject fruitGuide;

    public Animator blackCircle;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);

        GameObject.Find("Select").GetComponent<AudioSource>().Play();
    }

    public void Resume()
    {
        if (uI.spedUp) { Time.timeScale = 2.5f; }
        if (uI.spedUp == false) { Time.timeScale = 1; }
        pauseMenu.SetActive(false);

        GameObject.Find("Select").GetComponent<AudioSource>().Play();
    }

    public void Quit()
    {
        SceneManager.LoadScene("StartMenu");
        blackCircle.Play("CircleIn");
        Invoke("LoadQuit",0.5f);
    }
    public void LoadQuit()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Restart()
    {
        blackCircle.Play("CircleIn");
        Invoke("LoadScene", 0.5f);
    }
    public void LoadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        string name = scene.name;
        SceneManager.LoadScene(name);
    }

    public void Guide()
    {
        GameObject.Find("Select").GetComponent<AudioSource>().Play();

        guide.SetActive(true);

        catGuide.SetActive(false);
        fruitGuide.SetActive(false);
        if (guidePage == 0)
        {
            catGuide.SetActive(true);
            fruitGuide.SetActive(false);
        }
        if (guidePage == 1)
        {
            catGuide.SetActive(false);
            fruitGuide.SetActive(true);
        }
    }

    public void GuideSwitch()
    {

        if (guidePage == 0)
        {
            guidePage = 1;
            catGuide.SetActive(false);
            fruitGuide.SetActive(true);
        }
        else
        {
            guidePage = 0;
            catGuide.SetActive(true);
            fruitGuide.SetActive(false);
        }
    }

    public void CloseGuide()
    {
        GameObject.Find("Select").GetComponent<AudioSource>().Play();


        guide.SetActive(false);
    }
}
