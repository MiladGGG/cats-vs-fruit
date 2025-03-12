using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject enemy;

    

    public float damage;


    public GameObject explosion;
    public bool explode;
    float explodeDamage;
    float explodeRadius;
    void Awake()
    {
        float rand = Random.Range(-0.2f , 0.2f);
        gameObject.transform.localScale += Vector3.one * rand;
    }

    public void CreateTrap(int trapLevel)
    {
        GameObject.Find("WaveSpawner").GetComponent<Waves>().trapCount++;
        if (trapLevel == 1)
        {
            damage = 400;
        }
        if (trapLevel == 2)
        {
            gameObject.transform.localScale += Vector3.one *0.3f;

            damage = 1000;
            explode = true;

            explodeDamage = 350;
            explodeRadius = 10;
        }
        if (trapLevel == 3)
        {
            gameObject.transform.localScale += Vector3.one * 0.7f;


            explodeDamage = 1000;
            explodeRadius = 12;
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Fruit" && col.gameObject.GetComponent<EnemyHealth>().health > 0)
        {
            enemy = col.gameObject;

            enemy.GetComponent<EnemyHealth>().Damage(damage,false,true,false,0,0,0);

            if (explode)
            {
                GameObject obj = Instantiate(explosion);
                obj.transform.position = gameObject.transform.position;
                obj.GetComponent<Explosion>().GetValues(explodeDamage, explodeRadius, 0, 0);
            }
            if (explode == false)
            {
                GameObject obj = Instantiate(explosion);
                obj.transform.position = gameObject.transform.position;
                obj.GetComponent<Explosion>().GetValues(0, 0, 0, 0);
            }
            GameObject.Find("WaveSpawner").GetComponent<Waves>().trapCount--;
            Destroy(gameObject);
        }

    }
}
