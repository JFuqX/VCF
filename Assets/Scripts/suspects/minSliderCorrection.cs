using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class minSliderCorrection : MonoBehaviour
{
    [SerializeField] private Slider minSlider;
    [SerializeField] private Slider maxSlider;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Floor(minSlider.value) > Mathf.Floor(maxSlider.value))
        {
            minSlider.value = maxSlider.value;
        }
    }
}
