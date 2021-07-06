using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeFootprint : MonoBehaviour
{

    private float cooldown = 2;


    public Material material1;
    public Material material2;
    float duration = 0f;
    Renderer rend;

    bool changeOne = false;
    bool changeTwo = false;

    public Light light;
    private bool isBrightEnough = false;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (light.intensity <= 0.8f)
        {
            isBrightEnough = true;
        }
        else
        {
            isBrightEnough = false;
        }

        if (cooldown >= 0)
        {
            cooldown -= Time.deltaTime;
        }
        if (isBrightEnough == true)
        {
            if (changeOne == true)
            {
                //float startTime = Time.time;
                //float t = (Time.time - startTime);
                //rend.material.Lerp(material1, material2, t);

                //if(t >= 2)
                //{
                //    Debug.Log("Ja");
                //}
                //float lerp = Mathf.PingPong(Time.time, duration) / duration;
                //rend.material.Lerp(material1, material2, duration);
                //if(duration >= 2f)
                //{
                //    duration = 0;
                //    changeOne = false;
                //}
                rend.material = material2;
                changeOne = false;
            }

            if (changeTwo == true)
            {
                //float lerp = Mathf.PingPong(Time.time, duration) / duration;
                //rend.material.Lerp(material2, material1, duration);
                //if (duration >= 2f)
                //{
                //    duration = 0;
                //    changeTwo = false;
                //}
                rend.material = material1;
                changeTwo = false;
            }
        }
    }


    public void StartFadeFootprint()
    {

        if (isBrightEnough == true && cooldown <= 0)
        {

            changeOne = true;
            Invoke("StartFadeoutFootprint", 10);
            cooldown = 2;
        }
        
    }

    void StartFadeoutFootprint()
    {
        if (cooldown <= 0)
        {
            changeTwo = true;
            cooldown = 2;
        }
}
}
