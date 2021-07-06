using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallFade : MonoBehaviour
{
    int layerMask = 1 << 6;
    public GameObject Wall;
    public Material WallMatOffice;
    public Material WallMatTatort;
    private GameObject vrRig;
    private float distanceToPlayer = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        vrRig = GameObject.Find("VR Rig");

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Material wallMat = Wall.GetComponent<Material>();
        RaycastHit hit;



        if (Physics.Raycast(vrRig.transform.position, new Vector3(0, 0, 10), out hit, Mathf.Infinity, layerMask))
        {
            
            //if(hit.distance < 2.0f)
            //{
            //    Color color = WallMat.color;
            //    color.a = 0.0f;
            //    WallMat.color = color;
            //}
            //else
            //{
            //    Color color = WallMat.color;
            //    color.a = 1.0f;
            //    WallMat.color = color;
            //}


            if (hit.distance < distanceToPlayer)
            {

                Color colorOffice = WallMatOffice.color;
                colorOffice.a = hit.distance * 0.32f;
                WallMatOffice.color = colorOffice;

                Color colorTatort = WallMatTatort.color;
                colorTatort.a = 0;
                WallMatTatort.color = colorTatort;

            }

        }
        else if (Physics.Raycast(vrRig.transform.position, new Vector3(0, 0, -10), out hit, Mathf.Infinity, layerMask))
        {
        
            //if(hit.distance < 2.0f)
            //{
            //    Color color = WallMat.color;
            //    color.a = 0.0f;
            //    WallMat.color = color;
            //}
            //else
            //{
            //    Color color = WallMat.color;
            //    color.a = 1.0f;
            //    WallMat.color = color;
            //}


            if (hit.distance < distanceToPlayer)
            {

                Color colorOffice = WallMatOffice.color;
                colorOffice.a = 0;
                WallMatOffice.color = colorOffice;

                Color colorTatort = WallMatTatort.color;
                colorTatort.a = hit.distance * 0.32f;
                WallMatTatort.color = colorTatort;

            }



        }
    }

    private void OnDestroy()
    {
        Color colorOffice = WallMatOffice.color;
        colorOffice.a = 1;
        WallMatOffice.color = colorOffice;

        Color colorTatort = WallMatTatort.color;
        colorTatort.a = 1;
        WallMatTatort.color = colorTatort;
    }
}
