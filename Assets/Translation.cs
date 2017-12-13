using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Translation {

    public static void translateX(GameObject go, double x)
    {
        x = x * Time.deltaTime;
        MeshFilter[] mfTab = GetMesh(go);
        foreach (MeshFilter mf in mfTab)
        {
            Mesh m = mf.sharedMesh;
            Vector3[] newVal = new Vector3[m.vertexCount];
            for (int i = 0; i < m.vertexCount; i++)
            {
                Vector3 node = m.vertices[i];
                newVal[i] = new Vector3((float)(node.x + x), node.y, node.z);
            }
            m.vertices = newVal;
        }
    }
    public static void translateY(GameObject go, double y)
    {
        y = y * Time.deltaTime;
        MeshFilter[] mfTab = GetMesh(go);
        foreach (MeshFilter mf in mfTab)
        {
            Mesh m = mf.sharedMesh;
            Vector3[] newVal = new Vector3[m.vertexCount];
            for (int i = 0; i < m.vertexCount; i++)
            {
                Vector3 node = m.vertices[i];
                newVal[i] = new Vector3(node.x, (float)(node.y + y), node.z);
            }
            m.vertices = newVal;
        }
    }
    public static void translateZ(GameObject go, double z)
    {
        z = z * Time.deltaTime;
        MeshFilter[] mfTab = GetMesh(go);
        foreach (MeshFilter mf in mfTab)
        {
            Mesh m = mf.sharedMesh;
            Vector3[] newVal = new Vector3[m.vertexCount];
            for (int i = 0; i < m.vertexCount; i++)
            {
                Vector3 node = m.vertices[i];
                newVal[i] = new Vector3(node.x, node.y, (float)(node.z + z));
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
