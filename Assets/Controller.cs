using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Controller{

  
    public static Vector3 WheelController()
    {
        // Use this for initialization
        Vector3 force = new Vector3(0, 0, 0);
        int torque = 100;
        float rayon = 0.4639f;
        Vector3 normal = new Vector3(0, 0, 0);
        float grav = 9.81f;
        int masse = 6;
        float muk = 0.8f;
        // Force de friction cinétique force frainant l'objet en mouvement Fk = muk * n
        // muk = 20 à 30 pneu sur bitume
        // Force de friction statique force de résistance lorsque l'objet est immobile Fs = mus *n
        normal = new Vector3(0, masse * grav, 0);
        Vector3 vecTorque = new Vector3(0, 0, torque);
        force =vecTorque / rayon;
        return force;
        
    }
}
