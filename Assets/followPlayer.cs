using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    private Vector3 originalPosition;

    [SerializeField] private GameObject vrCamera;
    Vector3 direction;
    private Vector3 cameraAngle;
    private Quaternion lookAtCamera;

    public bool isOnPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
  
        lookAtCamera = Quaternion.LookRotation(vrCamera.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(isOnPlayer == true)
        {
            //find the vector pointing from our position to the target
            direction = (vrCamera.transform.position - transform.position).normalized;

            //create the rotation we need to be in to look at the target
            lookAtCamera = Quaternion.LookRotation(direction);

            //rotate us over time according to speed until we are in the required rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, lookAtCamera, Time.deltaTime * 0.1f);


            //cameraAngle = vrCamera.transform.eulerAngles;
            //transform.position = vrCamera.transform.position + new Vector3(-0.3f, -0.8f, 0.0f);
            //transform.rotation = Quaternion.LookRotation(vrCamera.transform.position);
            //transform.eulerAngles = new Vector3(cameraAngle.x, cameraAngle.y+90, cameraAngle.z);
        }
    }

}
