using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;
using UnityEngine.UI;

public class DragText : MonoBehaviour, INavigationHandler
{
    private Text text;
    //rect data
    private RectTransform rect;
    private float startY;
    //mask in parent
    public RectTransform mask;
    private float maskHeight;
    //drag data
    private bool canDrag;
    private float maxDrag;
    //event data
    private Vector3 startposition;
    private Vector3 navigationposition;
    //config 
    public float extraSpace = 50.0f;
    public float sensitive = 8.0f;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
        text = GetComponent<Text>();
        maskHeight = mask.sizeDelta.y;
        startY = rect.localPosition.y;


        //test
        UpdateDragData();
    }

    public void UpdateDragData()
    {
        rect.localPosition = new Vector3(rect.localPosition.x, startY, rect.localPosition.z);
        maxDrag = text.preferredHeight - maskHeight;
        canDrag = maxDrag > 0;
    }

    public void OnNavigationStarted(NavigationEventData eventData)
    {
        navigationposition = eventData.CumulativeDelta;
        startposition = navigationposition;
    }

    public void OnNavigationUpdated(NavigationEventData eventData)
    {
        navigationposition = eventData.CumulativeDelta;
    }

    public void OnNavigationCompleted(NavigationEventData eventData)
    {
        navigationposition.Set(0, 0, 0);
    }

    public void OnNavigationCanceled(NavigationEventData eventData)
    {
        navigationposition.Set(0, 0, 0);
    }

    private void FixedUpdate()
    {
        if (!canDrag)
        {
            return;
        }
        if (navigationposition.x == 0 && navigationposition.y == 0)
        {
            return;
        }
        else if (Mathf.Abs(navigationposition.x) <= Mathf.Abs(navigationposition.y) && Mathf.Abs(navigationposition.y) >= Mathf.Abs(navigationposition.z))
        {
            float targetY = rect.localPosition.y + navigationposition.y * sensitive;
            //预留50
            if (targetY >= startY && targetY <= startY + maxDrag + extraSpace)
            {
                Vector3 target = new Vector3(rect.localPosition.x, targetY, rect.localPosition.z);
                text.transform.localPosition = target;
            }
        }
    }
}
