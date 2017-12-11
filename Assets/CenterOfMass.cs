using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CenterOfMass {

    public static Vector3 getCenterOfMass(Mass[] components)
    {
        int totalMass = 0;
        Vector3 totalPosition = new Vector3(0, 0, 0);
        // addition de tout les vecteurs position diviser par le nombre d'objet
        foreach (Mass c in components)
        {
            if (c.mass != 0)
            {
                totalMass += c.mass;
                totalPosition += c.mass * c.transform.position;
            }
            else Debug.LogError("The component doesn't have mass: " + c);
        }
        return totalPosition / totalMass;
    }
}
