using System.Collections;
using HoloToolkit.Examples.Prototyping;
using UnityEngine;
namespace HoloToolkit.Examples.InteractiveElements
{
    public class ButtonThemeWidgetEffect : InteractiveWidget {

        private EffectInteractiveTheme effectTheme;
        public Animator aniController;

        public override void SetState(Interactive.ButtonStateEnum state)
        {
            base.SetState(state);
            if (effectTheme != null)
            {
                string aniName=effectTheme.GetThemeValue(state);
             //   Debug.Log(state.ToString()+"   set state:  " + aniName);
                if (aniName != null && aniName != "")
                {
                    aniController.Play(aniName);
                }
                else
                {
                    aniController.Play("idle");
                }
            }
        }

        // Use this for initialization
        void Start () {
            aniController = GetComponent<Animator>();
            effectTheme = InteractiveHost.GetComponentInChildren<EffectInteractiveTheme>();
	    }
	
    }
}

