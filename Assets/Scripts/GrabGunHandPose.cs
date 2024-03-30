using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabGunHandPose : MonoBehaviour
{
    //public HandData rightHandPose;
    //private Vector3 startingHandPosition;
    //private Quaternion startingHandRotation;
    //private Vector3 finalHandPosition;
    //private Quaternion finalHandRotation;

    //private Quaternion[] startingFingerRotations;
    //private Quaternion[] finalFingerRotations;


    public HandData initialHandPose;
    public HandData gunHandPose;

    private Vector3 initialHandPosition;
    private Quaternion initialHandRotation;
    private Vector3 gunHandPosition;
    private Quaternion gunHandRotation;

    private Quaternion[] initialFingerRotations;
    private Quaternion[] gunFingerRotations;

    // Start is called before the first frame update
    void Start()
    {
        //XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        //grabInteractable.selectEntered.AddListener(SetupPose);
        //grabInteractable.selectExited.AddListener(UnSetPose);
        //rightHandPose.gameObject.SetActive(false);

    }

    //public void SetupPose(BaseInteractionEventArgs args)
    //{
    //    if (args.interactorObject is XRDirectInteractor)
    //    {
    //        HandData handData = args.interactorObject.transform.GetComponentInChildren<HandData>();
    //        handData.animator.enabled = false; // freeze animation when grabbing gun

    //        SetHandDataValues(handData, rightHandPose);
    //        SetHandData(handData, finalHandPosition, finalHandRotation, finalFingerRotations);
    //    }
    //}



    //public void UnSetPose(BaseInteractionEventArgs args)
    //{
    //    if (args.interactorObject is XRDirectInteractor)
    //    {
    //        HandData handData = args.interactorObject.transform.GetComponentInChildren<HandData>();
    //        handData.animator.enabled = true; // freeze animation when grabbing gun

    //        SetHandData(handData, startingHandPosition, startingHandRotation, startingFingerRotations);
    //    }
    //}

    public void SetupGunPose()
    {
        initialHandPose.animator.enabled = false;
        InitializeHandDataValues(initialHandPose, gunHandPose);
        SetHandData(initialHandPose, gunHandPosition, gunHandRotation, gunFingerRotations);
    }

    public void RevertGunPose()
    {
        initialHandPose.animator.enabled = true;
        SetHandData(initialHandPose, initialHandPosition, initialHandRotation, initialFingerRotations);
    }

    //public void SetHandDataValues(HandData h1, HandData h2)
    //{
    //    startingHandPosition = new Vector3(h1.root.localPosition.x / h1.root.localScale.x,
    //        h1.root.localPosition.y / h1.root.localScale.y,
    //        h1.root.localPosition.z / h1.root.localScale.z);
    //    finalHandPosition = new Vector3(h2.root.localPosition.x / h2.root.localScale.x,
    //        h2.root.localPosition.y / h2.root.localScale.y,
    //        h2.root.localPosition.z / h2.root.localScale.z);

    //    startingHandRotation = h1.root.localRotation;
    //    finalHandRotation = h2.root.localRotation;

    //    startingFingerRotations = new Quaternion[h1.fingerBones.Length];
    //    finalFingerRotations = new Quaternion[h2.fingerBones.Length];

    //    for (int i = 0; i < h1.fingerBones.Length; i++)
    //    {
    //        startingFingerRotations[i] = h1.fingerBones[i].localRotation;
    //        finalFingerRotations[i] = h2.fingerBones[i].localRotation;
    //    }

    //}

    private void InitializeHandDataValues(HandData h1, HandData h2)
    {
        initialHandPosition = new Vector3(h1.root.localPosition.x / h1.root.localScale.x,
            h1.root.localPosition.y / h1.root.localScale.y,
            h1.root.localPosition.z / h1.root.localScale.z);
        gunHandPosition = new Vector3(h2.root.localPosition.x / h2.root.localScale.x,
            h2.root.localPosition.y / h2.root.localScale.y,
            h2.root.localPosition.z / h2.root.localScale.z);

        initialHandRotation = h1.root.localRotation;
        gunHandRotation = h2.root.localRotation;

        initialFingerRotations = new Quaternion[h1.fingerBones.Length];
        gunFingerRotations = new Quaternion[h2.fingerBones.Length];

        for (int i = 0; i < h1.fingerBones.Length; i++)
        {
            initialFingerRotations[i] = h1.fingerBones[i].localRotation;
            gunFingerRotations[i] = h2.fingerBones[i].localRotation;
        }
    }

    private void SetHandData(HandData h, Vector3 newPosition, Quaternion newRotation, Quaternion[] newBonesRotation)
    {
        h.root.localPosition = newPosition;
        h.root.localRotation = newRotation;

        for (int i = 0; i < newBonesRotation.Length; i++)
        {
            h.fingerBones[i].localRotation = newBonesRotation[i];
        }
    }
}
