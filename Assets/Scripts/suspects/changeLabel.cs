using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class changeLabel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpMinAge;
    [SerializeField] private Slider sliderMinAge;

    [SerializeField] private TextMeshProUGUI tmpMaxAge;
    [SerializeField] private Slider sliderMaxAge;


    [SerializeField] private TextMeshProUGUI tmpMinHeight;
    [SerializeField] private Slider sliderMinHeight;

    [SerializeField] private TextMeshProUGUI tmpMaxHeight;
    [SerializeField] private Slider sliderMaxHeight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Floor(sliderMinAge.value) == 0 && Mathf.Floor(sliderMaxAge.value) == 0)
        {
            tmpMinAge.text = "unknown";
            tmpMaxAge.text = "unknown";
        }
        else
        {
            tmpMinAge.text = Mathf.Floor(sliderMinAge.value).ToString();
            tmpMaxAge.text = Mathf.Floor(sliderMaxAge.value).ToString();
        }


        if (Mathf.Floor(sliderMinHeight.value) == 100 && Mathf.Floor(sliderMaxHeight.value) == 100)
        {
            tmpMinHeight.text = "unknown";
            tmpMaxHeight.text = "unknown";
        }
        else
        {
            tmpMinHeight.text = Mathf.Floor(sliderMinHeight.value).ToString();
            tmpMaxHeight.text = Mathf.Floor(sliderMaxHeight.value).ToString();
        }
    }
}
