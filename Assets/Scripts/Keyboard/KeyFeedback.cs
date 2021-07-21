using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFeedback : MonoBehaviour
{

    public bool keyHit = false;
    public bool keyCanBeHitAgain = false;


    public float originalYPosition;

    // Start is called before the first frame update
    void Start()
    {

        originalYPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        if(keyHit)
        {


            keyCanBeHitAgain = false;
            keyHit = false;
            transform.position += new Vector3(0, -0.03f, 0);
        }

        if(transform.position.y < originalYPosition)
        {
            transform.position += new Vector3(0, 0.005f, 0);
        }
        else
        {
            keyCanBeHitAgain = true;
        }
    }

    public void updatePosition()
    {
        originalYPosition = transform.position.y;
    }
}
