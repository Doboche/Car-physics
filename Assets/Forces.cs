using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Forces {

    public static Vector3 TractionForce(float maxTorque ,float wheelRadius)
    {
        Vector3 traction = new Vector3(0, 0, maxTorque/wheelRadius);
        return traction;
    }

    public static Vector3 AirResistanceForce(float cair, Vector3 velocity)
    {
        float speed = Mathf.Sqrt(velocity.x * velocity.x + velocity.y * velocity.y + velocity.z * velocity.z);
        Vector3 airResistance = -cair * velocity * speed;
        return airResistance;
    }

    public static Vector3 RollingResistanceForce(float cr, Vector3 velocity)
    {
        Vector3 rollingResistance = -cr * velocity;
        return rollingResistance;
    }

    public static Vector3 BrakingForce(float cbraking)
    {
        Vector3 braking = new Vector3(0, 0, -cbraking);
        return braking;
    }
}
