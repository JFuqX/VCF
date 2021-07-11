using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChestWithKey : MonoBehaviour
{
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Chest").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("goes into trigger");
        if (other.tag == "Key")
        {
            Debug.Log("OpensChest");
            anim.SetBool("Open", true);
        }

        //Debug.Log(other.tag);
    }


}
