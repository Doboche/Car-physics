using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {
    public GameObject obj;
    public double radius;
    public bool activate;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        double distance = Vector3.Distance(transform.position, obj.transform.position);
        Debug.Log(" " + distance);
        if (distance != 0 && distance < radius + 1)
        {
            
        }
    }
}
