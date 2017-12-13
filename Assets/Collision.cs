using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

    public GameObject ground;
    public double radius;
    private Collision[] objCollision;
	// Use this for initialization
	void Start () {
        objCollision = GetComponents<Collision>();
    }
	
	// Update is called once per frame
	void Update () {
        foreach (Collision c in objCollision)
        {
            if(this != c && Vector3.Distance(c.transform.position, transform.position)  < c.radius + radius)
            {
                //Debug.Log(" " + c);
                //Debug.Log("COLLISIONNN !!!!!");
            }
        }
	}
}
