using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Rotation {
    public static void rotateX(GameObject go, double theta)
    {
        Vector3 centerOfMass = CenterOfMass.getCenterOfMass(go.GetComponentsInChildren<Mass>());
        double sin_t = Math.Sin(theta);
        double cos_t = Math.Cos(theta);

        MeshFilter[] mfTab = GetMesh(go);
        foreach (MeshFilter mf in mfTab)
        {
            Mesh m = mf.sharedMesh;
            Vector3[] newVal = new Vector3[m.vertexCount];
            for (int i = 0; i < m.vertexCount; i++)
            {
                Vector3 node = centerOfMass;
                newVal[i] = new Vector3(node.x, (float)(node.y * cos_t - node.z * sin_t), (float)(node.z * cos_t + node.y * sin_t));
            }
            m.vertices = newVal;
        }
    }
    public static void rotateY(GameObject go, double theta)
    {
        Vector3 centerOfMass = CenterOfMass.getCenterOfMass(go.GetComponentsInChildren<Mass>());
        double sin_t = Math.Sin(theta);
        double cos_t = Math.Cos(theta);

        MeshFilter[] mfTab = GetMesh(go);
        foreach (MeshFilter mf in mfTab)
        {
            Mesh m = mf.sharedMesh;
            Vector3[] newVal = new Vector3[m.vertexCount];
            for (int i = 0; i < m.vertexCount; i++)
            {
                Vector3 node = centerOfMass;
                newVal[i] = new Vector3((float)(node.x * cos_t - node.z * sin_t), node.y, (float)(node.z * cos_t + node.x * sin_t));
            }
            m.vertices = newVal;
        }
    }
    public static void rotateZ(GameObject go, double theta)
    {
        Vector3 centerOfMass = CenterOfMass.getCenterOfMass(go.GetComponentsInChildren<Mass>());
        double sin_t = Math.Sin(theta);
        double cos_t = Math.Cos(theta);

        MeshFilter[] mfTab = GetMesh(go);
        foreach (MeshFilter mf in mfTab)
        {
            Mesh m = mf.sharedMesh;
            Vector3[] newVal = new Vector3[m.vertexCount];
            for (int i = 0; i < m.vertexCount; i++)
            {
                Vector3 node = centerOfMass;
                newVal[i] = new Vector3((float)(node.x * cos_t - node.y * sin_t), (float)(node.y * cos_t + node.x * sin_t), node.z);
            }
            m.vertices = newVal;
        }
    }
    public static MeshFilter[] GetMesh(GameObject go)
    {
        if (go.GetComponent<MeshFilter>())
        {
            MeshFilter mf = go.GetComponent<MeshFilter>();
            MeshFilter[] mfTab = new MeshFilter[1];
            mfTab.SetValue(mf, 0);
            return mfTab;
        }
        else if (go.GetComponentInChildren<MeshFilter>())
        {
            MeshFilter[] mf = go.GetComponentsInChildren<MeshFilter>();
            return mf;
        }
        return new MeshFilter[0];
    }
}

