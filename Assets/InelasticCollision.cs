using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InelasticCollision
{

    //Calculate velocity in case of inelastic collision

    public static Vector3 MomentumCalcul(float m1, float m2, Vector3 v1, Vector3 v2)
    {
        Vector3 p = (m1 * v1) + (m2 * v2);
        Vector3 velocity = p / (m1 + m2);
        return velocity;

    }
}
