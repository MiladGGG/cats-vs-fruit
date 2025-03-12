using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTarget : MonoBehaviour
{
    public GameObject target;

    public float lastDistance;
    public float currentDistance;


    [Header("Ice Cat Parameters")]
    public bool IceCat = false;
    public bool isShooting;
    public TowerShoot towerShoot;


    private void OnTriggerStay(Collider col)
    {
        //Normal Cat targetting
        if (IceCat == false)
        {
            if (col.gameObject.tag == "Fruit")
            {

                currentDistance = col.gameObject.GetComponent<EnemyPath>().distance;
                if (col.gameObject.GetComponent<EnemyPath>().distance > lastDistance)
                {
                    target = col.gameObject;

                    lastDistance = col.gameObject.GetComponent<EnemyPath>().distance;
                }
            }
        }




        //Ice Cat targetting
        if (IceCat)
        {
            if (col.gameObject.tag == "Fruit" && col.gameObject.GetComponent<EnemyHealth>().Frost < towerShoot.maxFreeze)
            {

                currentDistance = col.gameObject.GetComponent<EnemyPath>().distance;
                if (col.gameObject.GetComponent<EnemyPath>().distance > lastDistance)
                {
                    target = col.gameObject;

                    lastDistance = col.gameObject.GetComponent<EnemyPath>().distance;
                }
            }
        }

    }

    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject == target)
        {
            target = null;
            lastDistance = 0;


            isShooting = false;
        }
    }


    void Update()
    {
        //Reset Target if dead
        if (target != null && target.gameObject.GetComponent<EnemyHealth>().health <= 0)
        {
            target = null;

            isShooting = false;
        }

        if(target == null)
        {
            lastDistance = 0;
        }



        //Reset Target if Frozen for ICE CAT
        if (IceCat) 
        {
            if (target != null && target.gameObject.GetComponent<EnemyHealth>().Frost >= towerShoot.maxFreeze)
            {
                target = null;

                isShooting = false;
            }
        }

    }
}
