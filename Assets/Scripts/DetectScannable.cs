using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectScannable : MonoBehaviour
{

    public GameObject slider;
    public Light light;

    public bool scanned = false;

    // Start is called before the first frame update
    void Start()
    {
        slider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {

 
        if (other.tag == "DeadBody")
        {
           
            if (scanned == false)
            {
                
                light.color = new Color(0, 0, 255);
                
                Invoke("ActivateSlider", 3);
                scanned = true;
            }
        }

    }


    void ActivateSlider()
    {
        light.color = new Color(0, 255, 0);
        slider.SetActive(true);
    }

}
