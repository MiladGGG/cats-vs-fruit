using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;

    [Space]
    public float sharpImpact = 100;
    public float bluntImpact = 100;

    [Space]
    public SpriteRenderer sprite;
    public float Frost;
    bool queued;

    float rememberSpeed;

    [Space]
    public int moneyPay = 5;


    [Header("Reborn")]
    [Space]
    public bool spawnFruit;
    public GameObject spawnedFruit;

    public bool pumpkinSpawn;
    public GameObject pumpkinSpawner;


    bool once = true;
    private void Awake()
    {

    }
    private void LateUpdate()
    {
        if (once)
        {
            once = false;
            if (gameObject.GetComponent<EnemyPath>().stage == 0)
            {
                gameObject.GetComponent<Collider>().enabled = false;
                Invoke("ColliderActive", 1.1f);
            }

        }

    }
    void Update()
    {
        if(health <= 0)
        {
            //Die
            if (spawnFruit)
            {
                GameObject newFruit = Instantiate(spawnedFruit);
                newFruit.transform.position = gameObject.transform.position;
                newFruit.GetComponent<EnemyPath>().stage = gameObject.GetComponent<EnemyPath>().stage;
                newFruit.GetComponent<EnemyPath>().lastDistance = gameObject.GetComponent<EnemyPath>().distance;
            }
            
            if (pumpkinSpawn)
            {
                GameObject pmp = Instantiate(pumpkinSpawner);
                pmp.GetComponent<PumpkinSpawn>().pos = gameObject.transform;
                pmp.GetComponent<PumpkinSpawn>().stage = gameObject.GetComponent<EnemyPath>().stage;
                pmp.GetComponent<PumpkinSpawn>().distance = gameObject.GetComponent<EnemyPath>().distance;

                pmp.GetComponent<PumpkinSpawn>().Spawn();
            }

            if(sharpImpact == 20) { GameObject.Find("FruitSound").GetComponent<Sounds>().MetalSound(); }
            if (sharpImpact != 20) { GameObject.Find("FruitSound").GetComponent<Sounds>().FruitSound(); }


                Money money = GameObject.Find("Money").GetComponent<Money>();
            money.money += moneyPay;

            Waves wave = GameObject.Find("WaveSpawner").GetComponent<Waves>();
            wave.enemyCount--;

            //gameObject.SetActive(false);
            Destroy(gameObject);
        }

        sprite.color = new Color(1 - (Frost * 1.25f), 1 - (Frost * 0.5f)  , 1);
    }



    public void Damage(float dmg, bool sharp, bool blunt, bool ignore, float freeze, float maxfreeze, float stun)
    {
        if (ignore) { health -= dmg; }

        else
        {
            if (sharp) { health -= dmg * sharpImpact/100; }

            if (blunt) { health -= dmg * bluntImpact/100; }

        }


        if(freeze != 0)
        {
            if(Frost < maxfreeze)
            {
                Frost += freeze;
            }

        }


        if(stun > 0)
        {
            GetStun(stun);
        }

    }

    void GetStun(float stuntime)
    {
        EnemyPath path = gameObject.GetComponent<EnemyPath>();


        if(path.stunIntensity != 0)
        {
            Invoke("RemoveStun", stuntime);
        }

        path.stunIntensity = 0;
    }
    void RemoveStun()
    {
        EnemyPath path = gameObject.GetComponent<EnemyPath>();
        path.stunIntensity = 1;
    }

    void ColliderActive()
    {
        gameObject.GetComponent<Collider>().enabled = true;
    }
}
