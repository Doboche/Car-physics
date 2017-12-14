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


    // All the code above is for implementing the rotation of the car, but this is not fonctionning

    public static float AngularSpeed(float rpm)
    {
        float angularSpeed = (rpm * Mathf.PI * 2) / 60;
        return angularSpeed;
    }

    public static float FrontSlipAngle(Vector3 vlong, Vector3 vlat, float rpm,float steeringAngle)
    {
        float speedlong = Mathf.Sqrt(vlong.x * vlong.x + vlong.y * vlong.y + vlong.z * vlong.z);
        float slipAngle;
        if (vlong.x > 0)
        {
           slipAngle = Mathf.Atan((vlat.x + AngularSpeed(rpm) * 0.8f) / speedlong) - steeringAngle;
        }
        else
        {
           slipAngle = Mathf.Atan((vlat.x + AngularSpeed(rpm) * 0.8f) / speedlong) + steeringAngle;
        }
        return slipAngle;
    }

    public static float rearSlipAngle(Vector3 vlong, Vector3 vlat, float rpm, float steeringAngle)
    {
        float speedlong = Mathf.Sqrt(vlong.x * vlong.x + vlong.y * vlong.y + vlong.z * vlong.z);
        float slipAngle;
        slipAngle = Mathf.Atan((vlat.x - AngularSpeed(rpm) * 0.8f) / speedlong);
        return slipAngle;
    }
}
