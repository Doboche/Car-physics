using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ElasticCollision {

    public static Vector3 ElasticCol(float e , Vector3 normal, float m1,float m2, Vector3 vrel, Vector3 velocity)
    {
        float K = ((e + 1) * Vector3.Scale(vrel,normal).x + Vector3.Scale(vrel, normal).y 
            + Vector3.Scale(vrel, normal).z)
            / (((1 / m1) + (1 / m2)) * Vector3.Scale(normal,normal).x + Vector3.Scale(normal, normal).y + 
            Vector3.Scale(normal, normal).z);
        //Debug.Log(K);
        Vector3 newVelocity = velocity + K * normal / m2;
        return newVelocity;
    }
}
