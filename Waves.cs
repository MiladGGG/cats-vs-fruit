using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using TMPro;

public class Waves : MonoBehaviour
{
    public int wave;
    public TextMeshProUGUI text;
    public Button button;
    [Header("Fruit")]
    public GameObject Strawberry;
    public GameObject Apple;
    public GameObject Orange;
    public GameObject GreenApple;
    public GameObject Coconut;
    public GameObject Banana;
    public GameObject Pumpkin;
    public GameObject WaterMelon;

    public GameObject MetalStrawberry;
    public GameObject MetalApple;
    public GameObject MetalBanana;
    public GameObject MetalWaterMelon;

    public Vector3 startingPos;

    [Space]
    int amount = 1;
    float delay;
    float waitTime;

    [Space]
    [Header("WaveEnd")]
    public bool waveOngoing;
    public int enemyCount;
    bool waveReady;

    [Space]
    [Header("WaveEndUpgrades")]
    public GameObject Trap;
    public int trap1;
    public int trap2;
    public int trap3;
    public int trapCount;
    public int maxTraps;
    [Space]
    public int money1;
    public int money2;
    public int money3;
    [Space]
    [Header("WaveEnd")]
    public GameObject winMenu;

    [Space]
    [Header("LavaMap")]
    public bool lavaMap;
    public bool switchDown;
    public GameObject paths1;
    public GameObject paths2;

    [Space]
    [Header("Tutorial")]
    public bool tutorial;
    public Tutorial tut;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waveOngoing && waveReady)
        {
            if (enemyCount <= 0)
            {

                //Reset Wave
                waveOngoing = false;
                waveReady = false;
                enemyCount = 0;

                Money money = GameObject.Find("Money").GetComponent<Money>();

                if (wave <= 15) { money.money += 30; }
                if (wave > 15) { money.money += 150; }



                money.money += (money1 * 20);
                money.money += (money2 * 50);
                money.money += (money3 * 100);

                if (trap3 > 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (trapCount < maxTraps)
                        {
                            GameObject trap = Instantiate(Trap);


                            GameObject trapPos = GameObject.Find("TrapPoint");

                            trap.transform.position = trapPos.transform.position;

                            trap.GetComponent<Trap>().CreateTrap(3);
                        }
                    }



                }
                if (trap2 > 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (trapCount < maxTraps)
                        {
                            GameObject trap = Instantiate(Trap);


                            GameObject trapPos = GameObject.Find("TrapPoint");

                            trap.transform.position = trapPos.transform.position;

                            trap.GetComponent<Trap>().CreateTrap(2);
                        }
                    }
                }
                if (trap1 > 0)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (trapCount < maxTraps)
                        {
                            GameObject trap = Instantiate(Trap);


                            GameObject trapPos = GameObject.Find("TrapPoint");

                            trap.transform.position = trapPos.transform.position;

                            trap.GetComponent<Trap>().CreateTrap(1);
                        }
                    }
                }

                if (tutorial)
                {
                    tut.NewTip();

                    if (wave == 11)
                    {
                        winMenu.SetActive(true);
                    }
                }


                //Win
                if (wave == 30)
                {
                    winMenu.SetActive(true);
                    GameObject.Find("FruitSound").GetComponent<Sounds>().Victory();
                }
            }
        }
        if (waveOngoing == false)
        {
            button.interactable = true;
        }
    }

    public void SpawnWave()
    {
        wave++;
        waitTime = 0;

        waveOngoing = true;
        button.interactable = false;
        Invoke("WaveReady", 1.25f);

        text.text = ""+wave;

        if (lavaMap)
        {
            if (switchDown) { switchDown = false; }
            else { switchDown = true; }

            if (switchDown)
            {
                paths2.transform.SetSiblingIndex(0);
                startingPos = new Vector3(7f, 0, 8f);
            }
            if (switchDown == false)
            {
                paths1.transform.SetSiblingIndex(0);
                startingPos = new Vector3(7f, 0, -8.7f);
            }
        }
        if (tutorial)
        {
            tut.greendot1.SetActive(false);

            if(tut.phase == 2 || tut.phase == 3) { tut.CloseTip(); }
        }


        if(wave == 1)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 8;
                delay = 1f;
                Invoke("SpawnStrawberry", waitTime + delay * i);
            }
            waitTime = amount * delay;

        }
        if(wave == 2)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 10;
                delay = 0.7f;
                Invoke("SpawnStrawberry", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 1;
                delay = 1f;
                Invoke("SpawnApple", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        if (wave == 3)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 5;
                delay = 0.5f;
                Invoke("SpawnStrawberry", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 3;
                delay = 1.5f;
                Invoke("SpawnApple", waitTime + delay * i);
            }
            waitTime = amount * delay;


        }

        if (wave == 4)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 3;
                delay = 0.5f;
                Invoke("SpawnApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 6;
                delay = 0.1f;
                Invoke("SpawnStrawberry", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        if (wave == 5)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 9;
                delay = 0.3f;
                Invoke("SpawnStrawberry", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 1;
                delay = 1f;
                Invoke("SpawnOrange", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        if (wave == 6)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 2;
                delay = 1f;
                Invoke("SpawnOrange", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 10;
                delay = 0.5f;
                Invoke("SpawnStrawberry", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 10;
                delay = 1f;
                Invoke("SpawnApple", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        if (wave == 7)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 3;
                delay = 0.5f;
                Invoke("SpawnApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 3;
                delay = 0.5f;
                Invoke("SpawnOrange", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 3;
                delay = 0.5f;
                Invoke("SpawnApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

        }

 
        if (wave == 8)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 8;
                delay = 0.2f;
                Invoke("SpawnStrawberry", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 3;
                delay = 1.5f;
                Invoke("SpawnGreenApple", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        if (wave == 9)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 4;
                delay = 0.7f;
                Invoke("SpawnOrange", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 8;
                delay = 0.2f;
                Invoke("SpawnStrawberry", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        //Introduce Coconut
        if (wave == 10)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 1;
                delay = 1f;
                Invoke("SpawnCoconut", waitTime + delay * i);
            }
            waitTime = amount * delay;

        }

        if (wave == 11)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 5;
                delay = 0.4f;
                Invoke("SpawnApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 2;
                delay = 0.6f;
                Invoke("SpawnGreenApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 10;
                delay = 0.1f;
                Invoke("SpawnStrawberry", waitTime + delay * i);
            }
            waitTime = amount * delay;

        }


        if (wave == 12)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 8;
                delay = 0.4f;
                Invoke("SpawnApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 2;
                delay = 0.5f;
                Invoke("SpawnCoconut", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 4;
                delay = 0.3f;
                Invoke("SpawnOrange", waitTime + delay * i);
            }
            waitTime = amount * delay;

        }
        //Introduce Banana
        if (wave == 13)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 2;
                delay = 0.2f;
                Invoke("SpawnBanana", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 3;
                delay = 0.5f;
                Invoke("SpawnGreenApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 12;
                delay = 0.1f;
                Invoke("SpawnApple", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        if (wave == 14)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 6;
                delay = 0.2f;
                Invoke("SpawnGreenApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 3;
                delay = 0.1f;
                Invoke("SpawnBanana", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 4;
                delay = 0.1f;
                Invoke("SpawnOrange", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        //Introduce Pumpkin
        if (wave == 15)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 3;
                delay = 1.5f;
                Invoke("SpawnPumpkin", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        if (wave == 16)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 6;
                delay = 0.2f;
                Invoke("SpawnGreenApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 1;
                delay = 1f;
                Invoke("SpawnPumpkin", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 3;
                delay = 0.1f;
                Invoke("SpawnOrange", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 5;
                delay = 0.1f;
                Invoke("SpawnApple", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }


        if (wave == 17)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 2;
                delay = 1f;
                Invoke("SpawnPumpkin", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 5;
                delay = 0.7f;
                Invoke("SpawnOrange", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 7;
                delay = 0.3f;
                Invoke("SpawnGreenApple", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        if (wave == 18)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 8;
                delay = 0.5f;
                Invoke("SpawnBanana", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 10;
                delay = 1f;
                Invoke("SpawnGreenApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 5;
                delay = 0.5f;
                Invoke("SpawnBanana", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        if (wave == 19)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 10;
                delay = 0.2f;
                Invoke("SpawnGreenApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 2;
                delay = 1f;
                Invoke("SpawnPumpkin", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 5;
                delay = 0.2f;
                Invoke("SpawnOrange", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 10;
                delay = 0.1f;
                Invoke("SpawnApple", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        //Watermelon Round
        if (wave == 20)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 1;
                delay = 0.1f;
                Invoke("SpawnWaterMelon", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        //Metal
        if (wave == 21)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 5;
                delay = 0.3f;
                Invoke("SpawnMetalStrawberry", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 3;
                delay = 0.5f;
                Invoke("SpawnMetalApple", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        if (wave == 22)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 5;
                delay = 0.3f;
                Invoke("SpawnOrange", waitTime + delay * i);
            }
            waitTime = amount * delay;



            for (int i = 0; i < amount; i++)
            {
                amount = 6;
                delay = 0.3f;
                Invoke("SpawnMetalStrawberry", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 4;
                delay = 0.5f;
                Invoke("SpawnMetalApple", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        //MetalBanana
        if (wave == 23)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 6;
                delay = 0.3f;
                Invoke("SpawnGreenApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 4;
                delay = 0.5f;
                Invoke("SpawnMetalApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 2;
                delay = 0.2f;
                Invoke("SpawnMetalBanana", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        if (wave == 24)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 3;
                delay = 0.2f;
                Invoke("SpawnCoconut", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 5;
                delay = 0.2f;
                Invoke("SpawnGreenApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 7;
                delay = 0.4f;
                Invoke("SpawnApple", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        if (wave == 24)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 10;
                delay = 0.2f;
                Invoke("SpawnMetalStrawberry", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 4;
                delay = 0.2f;
                Invoke("SpawnOrange", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 7;
                delay = 0.2f;
                Invoke("SpawnApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 6;
                delay = 0.1f;
                Invoke("SpawnBanana", waitTime + delay * i);
            }
            waitTime = amount * delay;



            for (int i = 0; i < amount; i++)
            {
                amount = 6;
                delay = 0.3f;
                Invoke("SpawnGreenApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 4;
                delay = 0.5f;
                Invoke("SpawnMetalApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 2;
                delay = 0.2f;
                Invoke("SpawnMetalBanana", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        if (wave == 25)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 2;
                delay = 0.1f;
                Invoke("SpawnWaterMelon", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 12;
                delay = 0.3f;
                Invoke("SpawnMetalApple", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        if (wave == 26)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 6;
                delay = 0.1f;
                Invoke("SpawnBanana", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 5;
                delay = 0.2f;
                Invoke("SpawnMetalStrawberry", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 4;
                delay = 0.5f;
                Invoke("SpawnMetalApple", waitTime + delay * i);
            }
            waitTime = amount * delay;



            for (int i = 0; i < amount; i++)
            {
                amount = 6;
                delay = 0.4f;
                Invoke("SpawnOrange", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 3;
                delay = 0.5f;
                Invoke("SpawnPumpkin", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 7;
                delay = 0.3f;
                Invoke("SpawnGreenApple", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        if (wave == 27)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 6;
                delay = 0.4f;
                Invoke("SpawnOrange", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 3;
                delay = 0.5f;
                Invoke("SpawnPumpkin", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 7;
                delay = 0.3f;
                Invoke("SpawnGreenApple", waitTime + delay * i);
            }
            waitTime = amount * delay;



            for (int i = 0; i < amount; i++)
            {
                amount = 6;
                delay = 0.4f;
                Invoke("SpawnOrange", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 3;
                delay = 0.5f;
                Invoke("SpawnPumpkin", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 7;
                delay = 0.3f;
                Invoke("SpawnGreenApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 6;
                delay = 0.1f;
                Invoke("SpawnBanana", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        if (wave == 28)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 1;
                delay = 0.1f;
                Invoke("SpawnWaterMelon", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 4;
                delay = 0.2f;
                Invoke("SpawnBanana", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 3;
                delay = 1f;
                Invoke("SpawnGreenApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 4;
                delay = 0.4f;
                Invoke("SpawnBanana", waitTime + delay * i);
            }
            waitTime = amount * delay;



            for (int i = 0; i < amount; i++)
            {
                amount = 10;
                delay = 0.2f;
                Invoke("SpawnMetalStrawberry", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 4;
                delay = 0.2f;
                Invoke("SpawnOrange", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 7;
                delay = 0.2f;
                Invoke("SpawnApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 6;
                delay = 0.1f;
                Invoke("SpawnBanana", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        if (wave == 29)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 5;
                delay = 0.2f;
                Invoke("SpawnMetalStrawberry", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 3;
                delay = 0.5f;
                Invoke("SpawnMetalApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 6;
                delay = 0.2f;
                Invoke("SpawnGreenApple", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 3;
                delay = 0.1f;
                Invoke("SpawnBanana", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 4;
                delay = 0.1f;
                Invoke("SpawnOrange", waitTime + delay * i);
            }





            for (int i = 0; i < amount; i++)
            {
                amount = 6;
                delay = 0.2f;
                Invoke("SpawnOrange", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 4;
                delay = 0.2f;
                Invoke("SpawnPumpkin", waitTime + delay * i);
            }
            waitTime = amount * delay;

            for (int i = 0; i < amount; i++)
            {
                amount = 7;
                delay = 0.3f;
                Invoke("SpawnGreenApple", waitTime + delay * i);
            }
            waitTime = amount * delay;
        }

        if (wave == 30)
        {
            for (int i = 0; i < amount; i++)
            {
                amount = 1;
                delay = 0.1f;
                Invoke("SpawnMetalWaterMelon", waitTime + delay * i);
            }
        }

        if (wave == 69)
        {

        }

    }

    void SpawnStrawberry()
    {
       GameObject one = Instantiate(Strawberry);
       one.transform.position = startingPos;

        enemyCount++;
    }

    void SpawnApple()
    {
        GameObject one = Instantiate(Apple);
        one.transform.position = startingPos;

        enemyCount++;
    }

    void SpawnOrange()
    {
        GameObject one = Instantiate(Orange);
        one.transform.position = startingPos;

        enemyCount += 2;
    }

    void SpawnGreenApple()
    {
        GameObject one = Instantiate(GreenApple);
        one.transform.position = startingPos;

        enemyCount++;
    }

    void SpawnCoconut()
    {
        GameObject one = Instantiate(Coconut);
        one.transform.position = startingPos;

        enemyCount++;
    }

    void SpawnBanana()
    {
        GameObject one = Instantiate(Banana);
        one.transform.position = startingPos;

        enemyCount++;
    }

    void SpawnPumpkin()
    {
        GameObject one = Instantiate(Pumpkin);
        one.transform.position = startingPos;

        enemyCount += 2;
    }

    void SpawnWaterMelon()
    {
        GameObject one = Instantiate(WaterMelon);
        one.transform.position = startingPos;

        enemyCount += 3;
    }

    void SpawnMetalStrawberry()
    {
        GameObject one = Instantiate(MetalStrawberry);
        one.transform.position = startingPos;

        enemyCount += 2;
    }

    void SpawnMetalApple()
    {
        GameObject one = Instantiate(MetalApple);
        one.transform.position = startingPos;

        enemyCount += 2;
    }

    void SpawnMetalBanana()
    {
        GameObject one = Instantiate(MetalBanana);
        one.transform.position = startingPos;

        enemyCount += 2;
    }
    void SpawnMetalWaterMelon()
    {
        GameObject one = Instantiate(MetalWaterMelon);
        one.transform.position = startingPos;

        enemyCount += 4;
    }


    void WaveReady()
    {
        waveReady = true;
    }



}
