using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ClassHelper : MonoBehaviour
{
    public static void EnableGameObject(Transform tf, bool enable)
    {
        Renderer[] rendererComponents = tf.GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = tf.GetComponentsInChildren<Collider>(true);

        // Enable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = enable;
        }

        // Enable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = enable;
        }
    }

    public static void ChangeHoloShader(Transform tf)
    {
        Renderer[] rendererComponents = tf.GetComponentsInChildren<Renderer>(true);
        Shader holo = Shader.Find("HoloToolkit/Examples/UnlitTransparentTriplanar");
        foreach (Renderer component in rendererComponents)
        {
            component.materials[0].shader = holo;
            component.materials[0].SetFloat("_Ambient", 1.0f);
        }
    }

    public static void EnableSpatialHitting(bool enable)
    {
        int sr = LayerMask.GetMask("RoomStatic");
        int nonSR = Physics.DefaultRaycastLayers & ~sr;
        GazeManager.Instance.RaycastLayerMasks = enable ? new LayerMask[] { nonSR, sr } : new LayerMask[] { nonSR };
    }

    public static void ChangeTransValue(Transform obj,float alpha)
    {
        Renderer[] rendererComponents = obj.GetComponentsInChildren<Renderer>(true);
        foreach (Renderer component in rendererComponents)
        {
            Color pre = component.materials[0].color;
            component.materials[0].color = new Color(pre.r, pre.g, pre.b, alpha);
        }
    }

}
