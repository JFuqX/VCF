using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProductionEffects : MonoBehaviour
{
    public GameObject effect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.Equals("Ground"))
        {
            effect.SetActive(true);
        }
    }
}
