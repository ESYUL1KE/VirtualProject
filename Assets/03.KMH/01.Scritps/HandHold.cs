using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandHold : XRBaseInteractable
{
    protected Weapon weapon = null;

    public void Setup(Weapon weapon)
    {
        this.weapon = weapon;
    }

    protected override void Awake()
    {
        base.Awake();
        onSelectEntered.AddListener(Grab);
/*        onSelectExit.*/
    }

    private void OnDestroy()
    {

    }

    protected virtual void BeginAction(XRBaseInteractor interactor)
    {
        // Empty
    }

    protected virtual void EndAction(XRBaseInteractor interactor)
    {
        // Empty
    }

    protected virtual void Grab(XRBaseInteractor interactor)
    {

    }

    protected virtual void Drop(XRBaseInteractor interactor)
    {

    }

    private void TryToHideHand(XRBaseInteractor interactor, bool hide)
    {

    }

    public void BreakHold(XRBaseInteractor interactor)
    {

    }
}
