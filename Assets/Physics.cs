using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour
{

    // Use this for initialization
    public int masse;
    public float grav;
    public GameObject obj;
    private Vector3 force = new Vector3(0, 0, 0);
    private Vector3 velocity = new Vector3(0, 0, 0);
    private Vector3 antvelocity = new Vector3(0, 0, 0);
    private Vector3 acceleration = new Vector3(0, 0, 0);
    private Vector3 position = new Vector3(0, 0, 0);
    private Vector3 antposition = new Vector3(0, 0, 0);
    private Vector3 gravity = new Vector3(0, 0, 0);
    private Vector3 normal = new Vector3(0, 0, 0);
    private float m2;
    private Vector3 v2;
    private float speedmax = 300;

    void Start()
    {
        // float pound = masse * grav;
        // force.y = -pound;
        position.x = transform.position.x;
        position.y = transform.position.y;
        position.z = transform.position.z;
        gravity = new Vector3(0, -masse * grav, 0);
        normal = new Vector3(0, masse * grav, 0);

    }

    // Update is called once per frame
    void Update()
    {
        force = new Vector3(0, 0, 0);
        force = AddForce(force, gravity);
        if (Collision(obj) == true)
        {
            force = AddForce(force, normal);
        }
        antposition = position;
        acceleration = force / masse;
        Debug.Log("acceleration" + acceleration);
        velocity = velocity + acceleration * Time.deltaTime;
        position = position + velocity * Time.deltaTime;
        float step = speedmax * Time.deltaTime;
        transform.position = Vector3.MoveTowards(antposition, position, step);
        if (Collision(obj) == true)
        {
            //transform.Translate(-force * Time.deltaTime);
            if (obj.GetComponent("masse") == null)
            {
                m2 = 10000000000;
                v2 = new Vector3(0, 0, 0);
            }
            velocity = InelasticCollision.MomentumCalcul(masse, m2, velocity, v2);
        }
        antvelocity = velocity;
        Debug.Log("position" + position);
    }

    bool Collision(GameObject obj)
    {
        
        if (transform.position.y - 0.8023 <= obj.transform.position.y)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    Vector3 CalculateVelocity(Vector3 acceleration, Vector3 antvelocity)
    {
        Vector3 velocity = antvelocity + acceleration * Time.deltaTime;
        return velocity;
    }

    Vector3 AddForce(Vector3 force, Vector3 newForce)
    {
        Vector3 calcul = new Vector3(0, 0, 0);
        calcul = force + newForce;
        return calcul;
    }
}
