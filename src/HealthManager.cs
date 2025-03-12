using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public int health = 200;
    public GameObject loseMenu;
    public TextMeshProUGUI healthCount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            health = 0;
            Time.timeScale = 1;
            loseMenu.SetActive(true);
        }
        healthCount.text = ""+health;
    }
}
