using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public static class Controller{

  
    public static Vector3 WheelController()
    {
        // Use this for initialization
        Vector3 force = new Vector3(0, 0, 0);
        int torque = 100;
=======
public static class Controller {

    // Use this for initialization
    public static Vector3 getWheelForce () {
        int torque = 100;
        Vector3 force = new Vector3(0, 0, 0);
>>>>>>> e9da15b145102d4f9dcd40dcf0a670af03979848
        float rayon = 0.4639f;
        Vector3 normal = new Vector3(0, 0, 0);
        float grav = 9.81f;
        int masse = 6;
        float muk = 0.8f;
<<<<<<< HEAD
        // Force de friction cinétique force frainant l'objet en mouvement Fk = muk * n
        // muk = 20 à 30 pneu sur bitume
        // Force de friction statique force de résistance lorsque l'objet est immobile Fs = mus *n
        normal = new Vector3(0, masse * grav, 0);
        Vector3 vecTorque = new Vector3(0, 0, torque);
        force =vecTorque / rayon;
        return force;
        
    }
=======
    // Force de friction cinétique force frainant l'objet en mouvement Fk = muk * n
    // muk = 20 à 30 pneu sur bitume
    // Force de friction statique force de résistance lorsque l'objet est immobile Fs = mus *n
    normal = new Vector3(0, masse * grav, 0);
        Vector3 vecTorque = new Vector3(0, 0, torque);
        force = vecTorque / rayon;
        return force;
    }
	
>>>>>>> e9da15b145102d4f9dcd40dcf0a670af03979848
}
