using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Invoke("Die", 3);
    }


    void Die()
    {
        Destroy(gameObject);
    }
}
