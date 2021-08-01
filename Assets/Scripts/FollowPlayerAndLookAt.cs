using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerAndLookAt : MonoBehaviour
{

    public Transform target;
    public GameObject camera;
    private Vector3 camRot;

    // Update is called once per frame
    void Update()
    {
        //camRot = camera.transform.rotation;
        camRot = camera.transform.forward;
        


        Vector3 tarPos = target.transform.position;
        tarPos += new Vector3(camRot.x, camRot.y + 1.0f, camRot.z);
        //tarPos += new Vector3(target.transform.position.x + camRot.x * 5, target.transform.position.y, target.transform.position.z + camRot.z * 2 + 5);

        this.transform.position = Vector3.MoveTowards(transform.position, tarPos, 0.3f);

        this.transform.LookAt(new Vector3(target.transform.position.x, target.transform.position.y+1.5f, target.transform.position.z));

    }


}

