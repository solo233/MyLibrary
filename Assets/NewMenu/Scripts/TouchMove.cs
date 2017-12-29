using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class TouchMove : MonoBehaviour ,IManipulationHandler{

    public GameObject objectToMove;
    private Vector3 oriPosition;
    public float MoveSensitivity = 1.0f;
    private TextMesh txt;
    private Renderer ren;

    public void OnManipulationCanceled(ManipulationEventData eventData)
    {
        print("OnManipulationCanceled");
        ren.material.color = Color.white;
    }

    public void OnManipulationCompleted(ManipulationEventData eventData)
    {
        print("OnManipulationCompleted");

        ren.material.color = Color.white;
    }

    public void OnManipulationStarted(ManipulationEventData eventData)
    {
        print("OnManipulationStarted");

        ren.material.color = Color.red;
        Debug.Log("start");
        oriPosition = objectToMove.transform.position;
    }

    public void OnManipulationUpdated(ManipulationEventData eventData)
    {
        print("OnManipulationUpdated");

        objectToMove.transform.position = oriPosition + eventData.CumulativeDelta* MoveSensitivity;
        txt.text = eventData.CumulativeDelta.ToString();
    }

    // Use this for initialization
    void Start () {
        ren = transform.GetComponent<Renderer>();
        txt = transform.GetComponentInChildren<TextMesh>();
    }

    // Update is called once per frame
    void Update () {
		
	}



}
