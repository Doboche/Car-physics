using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[ExecuteInEditMode]
public class MyTransform : MonoBehaviour
{
    Vector3 crtRotation;
    Vector3 crtTranslation;
    public Vector3 rotation;
    public Vector3 translation;
    public static Vector3 position;
    // Use this for initialization
    void Start()
    {
        position = translation;
        translation = transform.position;
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
        Translation.translateX(gameObject, translation.x - crtTranslation.x);
        Translation.translateY(gameObject, translation.y - crtTranslation.y);
        Translation.translateZ(gameObject, translation.z - crtTranslation.z);
        Rotation.rotateX(gameObject, convertToRadian(rotation.x - crtRotation.x));
        Rotation.rotateY(gameObject, convertToRadian(rotation.y - crtRotation.y));
        Rotation.rotateZ(gameObject, convertToRadian(rotation.z - crtRotation.z));
        crtRotation = rotation;
        crtTranslation = translation;
        transform.position = translation;
    }

    private double convertToRadian(double degree)
    {
        return Math.PI * degree / 180;
    }
}
