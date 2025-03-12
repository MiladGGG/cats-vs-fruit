using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject enemy;
    public GameObject particle;

    GameObject createdParticle;

    public bool blunt;
    public bool ignore;
    float damage = 0;
    float freeze = 0;
    float maxFreeze = 0;

    void Awake()
    {
        Invoke("Die", 0.1f);

    }


    public void GetValues(float dmg, float radius, float frze, float maxFrze)
    {
        damage = dmg;
        gameObject.transform.localScale += Vector3.one * radius;

        freeze = frze;
        maxFreeze = maxFrze;

        if(particle != null)
        {
            GameObject obj = Instantiate(particle);
            obj.gameObject.transform.position = gameObject.transform.position;
            createdParticle = obj;
        }
 
    }

    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Fruit")
        {
            enemy = col.gameObject;
            Explode();
        }

    }

    void Explode()
    {
        enemy.GetComponent<EnemyHealth>().Damage(damage, false, blunt, ignore, freeze, maxFreeze, 0);
    }


    void Die()
    {

        gameObject.GetComponent<Collider>().enabled = false;
        Invoke("Disappear", 1f);
    }
    void Disappear()
    {
        if (createdParticle != null) { Destroy(createdParticle); }
        Destroy(gameObject);
    }
}
