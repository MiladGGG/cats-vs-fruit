using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    public float speed;


    Vector3 pos;
    public GameObject[] paths;


    public int stage = 0;

    public GameObject Map;
    int pathcount;
    bool once = false;


    public float distance;
    public float lastDistance;
    public float time;

    public float stunIntensity = 1;
    [Space]
    public EnemyHealth enemyHealth;


    void Update()
    {
        if(once == false)
        {
            Map = GameObject.Find("MAP");
            pathcount = Map.transform.GetChild(0).transform.childCount;

            paths = new GameObject[pathcount];


            for (int i = 0; i < pathcount; i++){
                paths[i] = Map.transform.GetChild(0).transform.GetChild(i).gameObject;
            }
            once = true;
        }



        pos = transform.position;

        if (stage < pathcount)
        {


            transform.position = Vector3.MoveTowards(pos, paths[stage].transform.position, ((speed * (1f -enemyHealth.Frost)) * stunIntensity) * Time.deltaTime);

            if (pos == paths[stage].transform.position)
            {
                stage++;
            }
        }
        time = time += Time.deltaTime;
        distance = (speed * time) + lastDistance;


        if(stage == pathcount)
        {
            HealthManager health = GameObject.Find("Health").GetComponent<HealthManager>();
            health.health -= enemyHealth.moneyPay;

            Waves wave = GameObject.Find("WaveSpawner").GetComponent<Waves>();
            wave.enemyCount--;
            if(enemyHealth.spawnFruit) { wave.enemyCount--; }
            if(enemyHealth.pumpkinSpawn) { wave.enemyCount--; }
            if (gameObject.name == "Watermelon(Clone)") { wave.enemyCount--; }


            Destroy(gameObject);
        }
    }
}

