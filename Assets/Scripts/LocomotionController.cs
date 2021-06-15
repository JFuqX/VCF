using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{

    public XRController rightTeleportRay;

    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.2f;

    public XRRayInteractor rightInteractorRay;

    public bool enableRightTeleport { get; set;  } = true;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3();
        Vector3 norm = new Vector3();

        int index = 0;
        bool validtarget = false;




        if (rightTeleportRay)
        {
            bool isRightInteractorRayHovering = rightInteractorRay.TryGetHitInfo(ref pos, ref norm, ref index, ref validtarget);
            rightTeleportRay.gameObject.SetActive(enableRightTeleport && CheckIfActivated(rightTeleportRay) && !isRightInteractorRayHovering);
        }
    }

    public bool CheckIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold);
        return isActivated;

    }

}
