using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics : MonoBehaviour
{
    public int masse;
    public float grav;      // gravity
    public float cair;   // constant for the air resistance
    public float cr;   // constant for rolling resistance
    public float cbraking;   // constant for braking
    public float maxTorque; // maximum torque of the car
    private float wheelRadius = 0.4639f;   // Wheel radius
    public GameObject obj; // the ground
    public GameObject cube;
    public double radius;
    private Vector3 force = new Vector3(0, 0, 0);
    private Vector3 velocity = new Vector3(0, 0, 0);
    //private Vector3 antvelocity = new Vector3(0, 0, 0);
    private Vector3 acceleration = new Vector3(0, 0, 0);
    private Vector3 position = new Vector3(0, 0, 0);
    private Vector3 antposition = new Vector3(0, 0, 0); // Vector position before moving
    private Vector3 gravity = new Vector3(0, 0, 0);  // gravity vector
    private Vector3 normal = new Vector3(0, 0, 0); // normal vector
    private Vector3 normalImpact = new Vector3(0, 0, 5); // normal vector when collision (test)
    private float massInfinity = 10000000; // infinity mass
    private Vector3 zeroVelocity = new Vector3(0,0,0) ; //Using to represent velocity of non-moving object
    private float speedmax = 300; //max speed of the car
    private int i = 0; // Count the number of frame

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
        force = new Vector3(0, 0, 0); // reset the force to 0,0,0 at each frame
        force = AddForce(force, gravity); // add the gravity force
        if (Collision(obj) == true)
        {
            force = AddForce(force, normal); // if the car collide the ground, add normal force
        }
        antposition = position;
        if (i > 500)
        {
            if (velocity.x <= 0 && velocity.y <= 0 && velocity.z <= 0)
            {
            }
            else
            {
                force = AddForce(force, Forces.BrakingForce(cbraking)); // When 500 frame are executed, brake the car
            }
        }
        else
        {
            force = AddForce(force, Forces.TractionForce(maxTorque,wheelRadius)); // addforce to move the car
        }
        force = AddForce(force, Forces.AirResistanceForce(cair, velocity)); // add air resistance force
        force = AddForce(force, Forces.RollingResistanceForce(cr, velocity)); // add rolling resistance force
        if (Collision(obj) == true)
        {
            if (obj.GetComponent("masse") == null && velocity.y !=0)
            {
                velocity = InelasticCollision.MomentumCalcul(masse, massInfinity, velocity, zeroVelocity); // Calculate inelasticCollision when the car touch the ground
            }
        }
        if (CubeCollision() == true)
        {
            velocity = ElasticCollision.ElasticCol(0.8f, normalImpact, 100, masse, -velocity, velocity); // Calculate elasticCollision when the car touch the cube
        }
        else
        {
            acceleration = force / masse; // compute the acceleration
            velocity = velocity + acceleration * Time.deltaTime; // compute the velocity each frame
            position = position + velocity * Time.deltaTime; // compute the position each frame
            float step = speedmax * Time.deltaTime; // calculta the maximum step the car coul do each frame
            transform.position = Vector3.MoveTowards(antposition, position, step); // transform the position of the car to the new position
            i++; // count each frame
        }
    }

    bool Collision(GameObject obj) // detect the collision with the ground
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

    Vector3 AddForce(Vector3 force, Vector3 newForce) // add a force
    {
        Vector3 calcul = new Vector3(0, 0, 0);
        calcul = force + newForce;
        return calcul;
    }


    bool CubeCollision() // detect collision with a cube
    {
        double distance = Vector3.Distance(transform.position, cube.transform.position);
        if (distance != 0 && distance < radius + 2)
        {

            return true;
        }
        else
        {
            return false;
        }
    }
}
