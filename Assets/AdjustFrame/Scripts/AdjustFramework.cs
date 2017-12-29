using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustFramework : MonoBehaviour
{
    public bool checkSize;
    public bool checkMesh;
    public Vector3 size;
    public Transform target;
    public List<GameObject> elements;
    public List<GameObject> lines;

    private float x;
    private float y;
    private float z;
    // Use this for initialization
    void Start()
    {
        if (checkSize)
        {
            x = size.x * 0.5f;
            y = size.y * 0.5f;
            z = size.z * 0.5f;
        }
        else if (!checkSize && checkMesh)
        {
            Vector3 temp = AccordingMeshCalculatePoints(target);
            //print(temp.x+" "+ temp.y + " "+temp.z);
            x = temp.x * 0.5f;
            y = temp.y * 0.5f;
            z = temp.z * 0.5f;
        }
        else
        {
            x = target.position.x * 0.5f;
            y = target.position.y * 0.5f;
            z = target.position.z * 0.5f;
        }




        elements[0].transform.localPosition = new Vector3(-x, 0, 0);
        elements[1].transform.localPosition = new Vector3(x, 0, 0);
        elements[2].transform.localPosition = new Vector3(0, 0, z);
        elements[3].transform.localPosition = new Vector3(0, 0, -z);
        elements[4].transform.localPosition = new Vector3(0, y, 0);
        elements[5].transform.localPosition = new Vector3(0, -y, 0);

        lines[0].transform.localPosition = new Vector3(x, y, 0);
        lines[1].transform.localPosition = new Vector3(-x, y, 0);
        lines[2].transform.localPosition = new Vector3(x, -y, 0);
        lines[3].transform.localPosition = new Vector3(-x, -y, 0);
        lines[4].transform.localPosition = new Vector3(0, -y, z);
        lines[5].transform.localPosition = new Vector3(0, y, -z);
        lines[6].transform.localPosition = new Vector3(0, -y, -z);
        lines[7].transform.localPosition = new Vector3(0, y, z);

        lines[8].transform.localPosition = new Vector3(x, 0, z);
        lines[9].transform.localPosition = new Vector3(x, 0, -z);
        lines[10].transform.localPosition = new Vector3(-x, 0, -z);
        lines[11].transform.localPosition = new Vector3(-x, 0, z);

        foreach (var item in lines)
        {
            if (item.transform.localPosition.z == 0)
            {
                item.transform.eulerAngles = new Vector3(90, 0, 0);
                item.transform.localScale = new Vector3(0.005f, z*2, 0.005f);

            }
            else if (item.transform.localPosition.x == 0)
            {
                item.transform.eulerAngles = new Vector3(90, 0, 90);
                item.transform.localScale = new Vector3(0.005f, x*2, 0.005f);

            }
            else
            {
                item.transform.localScale = new Vector3(0.005f, y*2, 0.005f);

            }
        }
    }

    public Vector3 AccordingMeshCalculatePoints(Transform transform)
    {
        float maxX = -100;
        float maxY = -100;
        float maxZ = -100;
        float minX = 100;
        float minY = 100;
        float minZ = 100;
        MeshFilter[] meshes = transform.GetComponentsInChildren<MeshFilter>();
        for (int i = 0; i < meshes.Length; i++)
        {
            BoxCollider box = meshes[i].gameObject.AddComponent<BoxCollider>();
            float tempMaxX = box.transform.TransformPoint(box.center + box.size * 0.5f).x;
            float tempMinX = box.transform.TransformPoint(box.center - box.size * 0.5f).x;
            maxX = tempMaxX > maxX ? tempMaxX : maxX;
            minX = tempMinX < minX ? tempMinX : minX;
            float tempMaxY = box.transform.TransformPoint(box.center + box.size * 0.5f).y;
            float tempMinY = box.transform.TransformPoint(box.center - box.size * 0.5f).y;
            maxY = tempMaxY > maxY ? tempMaxY : maxY;
            minY = tempMinY < minY ? tempMinY : minY;
            float tempMaxZ = box.transform.TransformPoint(box.center + box.size * 0.5f).z;
            float tempMinZ = box.transform.TransformPoint(box.center - box.size * 0.5f).z;
            maxZ = tempMaxZ > maxZ ? tempMaxZ : maxZ;
            minZ = tempMinZ < minZ ? tempMinZ : minZ;
            Destroy(box);

        }
        return new Vector3((maxX - minX) / 2, (maxY - minY) / 2, (maxZ - minZ) / 2);
    }
}

