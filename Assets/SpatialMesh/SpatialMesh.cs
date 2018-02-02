using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.SpatialMapping;
using HoloToolkit.Unity;

public class SpatialMesh : MonoBehaviour {

    public TextMesh debugtxt;
    [SerializeField]
    private Material gridMaterial;
    private Material[] gridMaterials = new Material[1];
    private RaycastHit environmentHit;
    private List<MeshFilter> meshes;
    // Use this for initialization
    void Start () {
        gridMaterials[0] = gridMaterial;
        SpatialUnderstanding.Instance.UnderstandingCustomMesh.DrawProcessedMesh = false;
    }

    // Update is called once per frame
    void Update () {
        if (SpatialMappingManager.Instance.DrawVisualMeshes)
        {
            meshes = SpatialMappingManager.Instance.GetMeshFilters();
            for (int i = 0; i < meshes.Count; i++)
            {
                meshes[i].GetComponent<MeshRenderer>().sharedMaterials = gridMaterials;
            }
            float pulseSize = Mathf.Repeat(Time.time * 3, 6f);
            Vector3 shaderFocusPoint = CameraCache.Main.transform.position;
            if (Physics.Raycast(CameraCache.Main.transform.position,
                CameraCache.Main.transform.forward,
                out environmentHit,
                float.MaxValue,
                8, QueryTriggerInteraction.Ignore))
            {
                shaderFocusPoint = environmentHit.point;
            }
            //debugtxt.text = shaderFocusPoint.x.ToString() + "=" + shaderFocusPoint.y.ToString() + "=" + shaderFocusPoint.z.ToString();
            gridMaterial.SetVector("_PulseCenter", shaderFocusPoint);
            gridMaterial.SetFloat("_PulseSize", pulseSize);
            gridMaterial.SetColor("_Color", Color.white);
        }
        
    }
}
