using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetKill : XRSimpleInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        // if (!attachTransform) {
        //     gameObject attachPoint = new gameObject("Offset Kill");
        //     attachPoint.transform.SetParent(transform, false);
        //     attachTransform = attachPoint.transform;
        // }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args) {
        // attachTransform.position = args.interactorObject.transform.position;
        // attachTransform.rotation = args.interactorObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
}
