using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrabInteractable : XRGrabInteractable
{
    private Vector3 initialAttachLoaclPos;
    private Quaternion initialAttachLocalRot;

    void Start()
    {
        if (!attachTransform)
        {
            GameObject grab = new GameObject("Pivot"); //change to "Pivot" if needed
            grab.transform.SetParent(transform, false);
            attachTransform = grab.transform;
        }

        initialAttachLoaclPos = attachTransform.localPosition;
        initialAttachLocalRot = attachTransform.localRotation;
    }

    [Obsolete("This method is obsolete, use OnSelectEntering(XRBaseInteractor, XRBaseInteractable) instead.")]
    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        if (interactor is XRDirectInteractor)
        {
            attachTransform.position = interactor.transform.position;
            attachTransform.rotation = interactor.transform.rotation;
        }
        else
        {
            attachTransform.localPosition = initialAttachLoaclPos;
            attachTransform.localRotation = initialAttachLocalRot;
        }

        base.OnSelectEntering(interactor);
    }
}
