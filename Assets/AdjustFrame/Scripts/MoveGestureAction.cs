using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGestureAction : MonoBehaviour {
    private Transform model;
    //public Direction dir;
    public bool isMove = false;
    private Vector3 targetPos;
    private float factor = 0.001f;
    public bool test = false;
    private AdjustFramework adjustFramework;

    //public enum Direction
    //{
    //    Up,Down,Left,Right,Forward,Back
    //}
	// Use this for initialization
	void Start () {
        adjustFramework = this.GetComponentInParent<AdjustFramework>();
        if (adjustFramework)
        {
            model = adjustFramework.target;
        }
        else
        {
            model = this.transform.parent;
        }
    }
	public void OnSelect()
    {
        isMove = true;
        targetPos = model.position + transform.forward * factor;
    }

	// Update is called once per frame
	void Update () {
        if (test)
        {
            OnSelect();
            test = false;
        }
        if (isMove)
        {
            model.position = Vector3.Lerp(model.position, targetPos, 0.1f);
            //HologramScale.Instance.isMove = isMove;
            //TapToPlace.Instance.PlaceAdjustFramework();
        }
        if (Vector3.Distance(model.position,targetPos)<0.001f)
        {
            isMove = false;
            //HologramScale.Instance.isMove = isMove;

        }
    }
}
