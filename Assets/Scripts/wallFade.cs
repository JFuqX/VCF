using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallFade : MonoBehaviour
{
    int layerMask = 1 << 6;
    public GameObject Wall;
    public Material WallMatOffice;
    public Material WallMatTatort;


    // Start is called before the first frame update
    void Start()
    {


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Material wallMat = Wall.GetComponent<Material>();
        RaycastHit hit;
        Debug.DrawRay(transform.position, new Vector3(0,10,0), Color.green);


        if (Physics.Raycast(transform.position, new Vector3(0, 0, 10), out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log(hit.distance);
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


            if (hit.distance < 3)
            {

                Color colorOffice = WallMatOffice.color;
                colorOffice.a = hit.distance * 0.32f;
                WallMatOffice.color = colorOffice;

                Color colorTatort = WallMatTatort.color;
                colorTatort.a = 0;
                WallMatTatort.color = colorTatort;

            }

        }
        else if (Physics.Raycast(transform.position, new Vector3(0, 0, -10), out hit, Mathf.Infinity, layerMask))
        {
            Debug.Log(hit.distance);
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


            if (hit.distance < 3)
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
