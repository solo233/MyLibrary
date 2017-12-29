using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    private InterfaceAnimManager iaManager;

    private void Awake()
    {
        iaManager = transform.GetComponent<InterfaceAnimManager>();
    }

    public void Resetanm()
    {
        if (iaManager != null)
        {
            iaManager.startDisappear(true);
        }
    }

    public void Appear()
    {
        if (iaManager == null)
        {
            return;
        }
        iaManager.startAppear();
    }
    public void Disappear()
    {
        if (iaManager == null||iaManager.currentState!=CSFHIAnimableState.appeared)
        {
            return;
        }
        iaManager.startDisappear();
    }

	
}
