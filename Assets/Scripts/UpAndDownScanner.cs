using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDownScanner : MonoBehaviour
{

    private float position = 0;
    private float positionAdd = 0.05f;
    private bool up = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (up == true)
        {
            if (position >= 0.08f)
            {
                up = false;
            }
            position += 0.05f * Time.deltaTime;
            this.transform.Translate(0, positionAdd * Time.deltaTime, 0);
        }
        else
        {

            if(position <= 0.0f)
            {
                up = true;
            }
            position -= 0.05f * Time.deltaTime;
            this.transform.Translate(0, -(positionAdd * Time.deltaTime), 0);
        }


       


    }
}
