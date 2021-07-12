using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProductionEffects : MonoBehaviour
{
    public GameObject effect;

    public float borderZPosition = 3.3f;


    private void Update()
    {
        if (this.transform.position.z >= borderZPosition)
        {
            effect.SetActive(true);
        }
        else
        {
            effect.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {


        //if (collision.Equals("Ground"))
        //{
        //    effect.SetActive(true);
        //}
    }
}
