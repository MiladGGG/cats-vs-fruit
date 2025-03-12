using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinSpawn : MonoBehaviour
{
    public Transform pos;
    public int stage;
    public float distance;

    public GameObject GreenApple;
    public GameObject Coconut;
    public GameObject Banana;




    public void Spawn()
    {
        int count = Random.Range(1, 4);
        for (int i = 0; i < count; i++)
        {
            int fruit = Random.Range(1, 4);

            if (fruit == 1)
            {
                GameObject obj = Instantiate(GreenApple);
                obj.transform.position = pos.position;
                obj.GetComponent<EnemyPath>().stage = stage;
                obj.GetComponent<EnemyPath>().lastDistance = distance;
            }

            if (fruit == 2)
            {
                GameObject obj = Instantiate(Coconut);
                obj.transform.position = pos.position;
                obj.GetComponent<EnemyPath>().stage = stage;
                obj.GetComponent<EnemyPath>().lastDistance = distance;
            }

            if (fruit == 3)
            {
                GameObject obj = Instantiate(Banana);
                obj.transform.position = pos.position;
                obj.GetComponent<EnemyPath>().stage = stage;
                obj.GetComponent<EnemyPath>().lastDistance = distance;
            }
        }


        Destroy(gameObject);
    }
}
