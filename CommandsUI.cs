using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandsUI : MonoBehaviour
{
    public GameObject enemy;

    public Vector3 startingPos;
    void Start()
    {

    }

    void Update()
    {

    }

    public void AddEnemy()
    {
        GameObject obj = Instantiate(enemy);

        obj.transform.position = startingPos;
    }
}

