using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        cam = GameObject.Find("Camera");
        gameObject.transform.LookAt(cam.transform);
        gameObject.transform.eulerAngles = new Vector3(180+gameObject.transform.eulerAngles.x,0,180);
    }
}
