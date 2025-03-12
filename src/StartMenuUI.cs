using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuUI : MonoBehaviour
{
    public Animator playMenu;


    [Space]
    public GameObject[] maps;
    public int mapInt;
    public Animator circle;



    [Space]
    [Header("Guide")]
    public GameObject guide;
    public int guidePage;
    public GameObject catGuide;
    public GameObject fruitGuide;

    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        GameObject.Find("Select").GetComponent<AudioSource>().Play();


        playMenu.gameObject.SetActive(true);
        playMenu.Play("Open");


        foreach(GameObject obj in maps)
        {
            obj.SetActive(false);
        }

        maps[mapInt].SetActive(true);
    }



    public void ClosePlay()
    {
        GameObject.Find("Select").GetComponent<AudioSource>().Play();


        playMenu.Play("Close");
    }

    public void SelectNext()
    {
        GameObject.Find("Select").GetComponent<AudioSource>().Play();


        if (mapInt < 4) { mapInt++; }
        else { mapInt = 0; }

        foreach (GameObject obj in maps)
        {
            obj.SetActive(false);
        }

        maps[mapInt].SetActive(true);
    }

    public void SelectPlay()
    {
        GameObject.Find("Select").GetComponent<AudioSource>().Play();

        circle.gameObject.SetActive(true);
        circle.Play("CircleIn");
        Invoke("SceneLoad", 0.5f);
    }

    public void SceneLoad()
    {
        if(mapInt == 0) { SceneManager.LoadScene("GrassMap"); }
        if (mapInt == 1) { SceneManager.LoadScene("SandMap"); }
        if (mapInt == 2) { SceneManager.LoadScene("SnowMap"); }
        if (mapInt == 3) { SceneManager.LoadScene("IslandMap"); }
        if (mapInt == 4) { SceneManager.LoadScene("LavaMap"); }

    }


    public void QuitGame()
    {
        Application.Quit();
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
