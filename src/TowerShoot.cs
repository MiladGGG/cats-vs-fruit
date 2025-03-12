using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public GameObject ParentTower;
    public Animator ani;
    public GameObject Tower;
    public GameObject projectile;
    public TowerTarget towerTarget;
    public GameObject Collider;
    public GameObject weapon;

    [Space]
    [Header("Stats")]
    public float speed = 10;
    public float fireRate = 1f;
    public float damage = 20;

    [Space]
    public float stunTime = 0f;

    [Header("Attributes")]
    public bool sharp;
    public bool blunt;
    public bool ignore;

    [Space]
    [Header("Explode")]
    public float radius;
    public float explodeDamage;
    public float explodeFreeze;
    public float explodeMaxFreeze;

    [Space]
    [Header("Trap")]
    public int trapLevel;
    public GameObject Trap;
    public GameObject activeTrap;


    [Space]
    bool ready = true;
    public bool weaponVisible = true;

    [Space]
    [Header("Ice Cat")]
    public bool iceCat;
    public float freezeIntensity;
    public float maxFreeze;
    bool isIdling;
    bool unlockIdle = false;

    public bool threeShot;
    public GameObject Empty;
    GameObject Point1;
    GameObject Point2;
    GameObject Point3;

    void Awake()
    {
        weaponVisible = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (iceCat == false)
        {
            if (towerTarget.target != null && ready)
            {
                Shoot();
            }

            if (weaponVisible)
            {
                weapon.GetComponent<Renderer>().enabled = true;
            }
            if (weaponVisible == false)
            {
                weapon.GetComponent<Renderer>().enabled = false;
            }
        }



        if (iceCat)
        {
            if (towerTarget.target != null && ready)
            {
                Shoot();
                unlockIdle = true;
            }

            if (towerTarget.isShooting == false && isIdling == false && unlockIdle == true)
            {
                ani.Play("UnShoot");
                isIdling = true;
            }

        }
    }

    public void Shoot()
    {
        if(iceCat == false){
            //Create Projectile
            GameObject proj = Instantiate(projectile);

            proj.GetComponent<Projectile>().Tower = gameObject;
            proj.transform.position = Tower.transform.position;

            //Move and animate
            ParentTower.gameObject.transform.LookAt(towerTarget.GetComponent<TowerTarget>().target.transform);
            ani.Play("Shoot");

            weaponVisible = false;

            ready = false;
            Invoke("Reload", fireRate);
        }


        if (iceCat)
        {
            //Create Projectile(s)
            if(threeShot == false)
            {
                GameObject proj = Instantiate(projectile);

                proj.GetComponent<Projectile>().Tower = gameObject;
                proj.transform.position = Tower.transform.position;
            }

            if (threeShot == true)
            {
                //AOE Hitting
                Point2 = Instantiate(Empty);
                Point2.transform.position = towerTarget.GetComponent<TowerTarget>().target.transform.position;
                Point2.transform.rotation = ParentTower.transform.rotation;

                Point1 = Instantiate(Empty);
                Point1.transform.position = Point2.transform.TransformPoint(Vector3.left * 1f);

                Point3 = Instantiate(Empty);
                Point3.transform.position = Point2.transform.TransformPoint(-Vector3.left * 1f);



                GameObject proj2 = Instantiate(projectile);

                proj2.GetComponent<Projectile>().Tower = gameObject;
                proj2.transform.position = Tower.transform.position;

                proj2.GetComponent<Projectile>().iceCat = true;
                proj2.GetComponent<Projectile>().target = Point2;


                GameObject proj1 = Instantiate(projectile);

                proj1.GetComponent<Projectile>().Tower = gameObject;
                proj1.transform.position = Tower.transform.position;

                proj1.GetComponent<Projectile>().iceCat = true;
                proj1.GetComponent<Projectile>().target = Point1;

                GameObject proj3 = Instantiate(projectile);

                proj3.GetComponent<Projectile>().Tower = gameObject;
                proj3.transform.position = Tower.transform.position;

                proj3.GetComponent<Projectile>().iceCat = true;
                proj3.GetComponent<Projectile>().target = Point3;
            }

            //Move
            ParentTower.gameObject.transform.LookAt(towerTarget.GetComponent<TowerTarget>().target.transform);

            //Is shooting?
            if (towerTarget.isShooting == false)
            {
                ani.Play("Shoot");
                towerTarget.isShooting = true;

                isIdling = false;
            }



            
            ready = false;
            Invoke("Reload", fireRate);

        }
    }

    public void Reload()
    {
        ready = true;
        weaponVisible = true;
    }


    public void PlaceTrap()
    {
        GameObject trap = Instantiate(Trap);
        activeTrap = trap;

        GameObject trapPos = GameObject.Find("TrapPoint");

        activeTrap.transform.position = trapPos.transform.position;

        activeTrap.GetComponent<Trap>().CreateTrap(trapLevel);
    }

}
