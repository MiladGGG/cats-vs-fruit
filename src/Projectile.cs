using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject thisProjectile;
    public GameObject Tower;

    public bool spin;
    [Space]
    public bool explode;
    public GameObject explosion;
    float radius;
    float explodeDamage;
    float explodeFreeze;
    float explodeMaxFreeze;



    bool once;

    public GameObject target;


    float speed;

    float damage;
    bool sharp;
    bool blunt;
    bool ignore;

    float stun;

    [Space]
    [Header("Ice Cat")]
    public bool iceCat;
    float freezeIntensity;
    float maxFreeze;



    void Update()
    {
        if(once == false)
        {
            thisProjectile = gameObject;

            if (target == null) { target = Tower.GetComponent<TowerShoot>().Collider.GetComponent<TowerTarget>().target; }
            speed = Tower.GetComponent<TowerShoot>().speed;

            if(target == null)
            {
                Destroy(gameObject);
            }

            once = true;
        }



        if (target != null)
        {

            if(iceCat == false)
            {
                if (target.GetComponent<EnemyHealth>().health <= 0)
                {
                    Destroy(gameObject);
                }
            }


            //Move
            thisProjectile.transform.position = Vector3.MoveTowards(thisProjectile.transform.position, target.transform.position, speed * Time.deltaTime);

            if (spin == false)
            {
                thisProjectile.transform.LookAt(target.transform);
            }

            if (iceCat)
            {

            }

        }


    }

    private void OnTriggerEnter(Collider col)
    {
        if (iceCat == false)
        {
            if (col.gameObject == target)
            {
                //Send damage components
                damage = Tower.GetComponent<TowerShoot>().damage;
                sharp = Tower.GetComponent<TowerShoot>().sharp;
                blunt = Tower.GetComponent<TowerShoot>().blunt;
                ignore = Tower.GetComponent<TowerShoot>().ignore;

                freezeIntensity = Tower.GetComponent<TowerShoot>().freezeIntensity;
                maxFreeze = Tower.GetComponent<TowerShoot>().maxFreeze;

                stun = Tower.GetComponent<TowerShoot>().stunTime;

                target.GetComponent<EnemyHealth>().Damage(damage, sharp, blunt, ignore, freezeIntensity, maxFreeze, stun);

                if (explode) {
                    explodeDamage = Tower.GetComponent<TowerShoot>().explodeDamage;
                    radius = Tower.GetComponent<TowerShoot>().radius;
                    explodeFreeze = Tower.GetComponent<TowerShoot>().explodeFreeze;
                    explodeMaxFreeze = Tower.GetComponent<TowerShoot>().explodeMaxFreeze;

                    GameObject obj = Instantiate(explosion); 
                    obj.transform.position = gameObject.transform.position;
                    obj.GetComponent<Explosion>().GetValues(explodeDamage, radius , explodeFreeze, explodeMaxFreeze); 
                }

                
                Destroy(gameObject);


            }
        }



        if (iceCat)
        {
            if (col.gameObject.tag == "Fruit")
            {
                //Send damage components
                damage = Tower.GetComponent<TowerShoot>().damage;
                sharp = Tower.GetComponent<TowerShoot>().sharp;
                blunt = Tower.GetComponent<TowerShoot>().blunt;
                ignore = Tower.GetComponent<TowerShoot>().ignore;

                freezeIntensity = Tower.GetComponent<TowerShoot>().freezeIntensity;
                maxFreeze = Tower.GetComponent<TowerShoot>().maxFreeze;

                stun = Tower.GetComponent<TowerShoot>().stunTime;

                col.gameObject.GetComponent<EnemyHealth>().Damage(damage, sharp, blunt, ignore, freezeIntensity, maxFreeze, stun);

                Destroy(gameObject);
            }
            if (col.gameObject == target)
            {
                Destroy(gameObject);

            }
        }

    }

}
