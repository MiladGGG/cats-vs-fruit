using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource win;
    public GameObject fruitSound;
    public GameObject metalSound;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FruitSound()
    {
        if (GameObject.Find("Health").GetComponent<HealthManager>().health > 0)
        {
            GameObject obj = Instantiate(fruitSound);
        }
    }

    public void MetalSound()
    {
        if (GameObject.Find("Health").GetComponent<HealthManager>().health > 0)
        {
            GameObject obj = Instantiate(metalSound);
        }
    }
    public void Victory()
    {
        win.Play();
    }
}
