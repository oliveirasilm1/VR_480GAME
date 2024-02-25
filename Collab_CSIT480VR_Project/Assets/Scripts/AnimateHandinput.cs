using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandinput : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public Animator handAnimator;

    void Start()
    {
        // using the prest righht/left hand activaction refrence
       




    }

    // Update is called once per frame
    void Update()
    {

       float triggerValue = pinchAnimationAction.action.ReadValue<float>();             //bool to show if the button is pressed or not.
        handAnimator.SetFloat("Trigger", triggerValue);

        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);




    }
}
