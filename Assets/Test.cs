using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Test : MonoBehaviour
{
    Vector3 crtRotation;
    public Vector3 rotation;
    public Vector3 translation;
    // Use this for initialization
    void Start()
    {
        // copy mesh to edit the copy and not the original
        if (GetComponent<MeshFilter>())
        {
            GetComponent<MeshFilter>().sharedMesh = (Mesh)Instantiate(GetComponent<MeshFilter>().sharedMesh);
        }
        else if (GetComponentInChildren<MeshFilter>())
        {
            MeshFilter[] mfTab = GetComponentsInChildren<MeshFilter>();
            foreach (MeshFilter mf in mfTab)
            {
                mf.sharedMesh = (Mesh)Instantiate(mf.sharedMesh);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {   
        Rotation.rotateX(gameObject, rotation.x - crtRotation.x);
        //Rotation.rotateY(gameObject, rotation.y - crtRotation.y);
        //Rotation.rotateZ(gameObject, rotation.z - crtRotation.z);
        crtRotation = rotation;
    }
}
