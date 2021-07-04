using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyDetector : MonoBehaviour
{
    private TextMeshPro playerTextOutput;
    private SoundHandler soundHandler;

    // Start is called before the first frame update
    void Start()
    {
        playerTextOutput = GameObject.FindGameObjectWithTag("PlayerTextOutput").GetComponentInChildren<TextMeshPro>();
        soundHandler = GameObject.FindGameObjectWithTag("SoundHandler").GetComponent<SoundHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var key = other.GetComponentInChildren<TextMeshPro>();

        if(key != null)
        {
            KeyFeedback keyFeedback = other.gameObject.GetComponent<KeyFeedback>();
            if (keyFeedback.keyCanBeHitAgain)
            {
                keyFeedback.keyHit = true;
                if(key.text == "SPACE")
                {
                    playerTextOutput.text += " ";
                    soundHandler.PlayKeyClickHeavy();
                }
                else if(key.text == "<-")
                {
                    playerTextOutput.text = playerTextOutput.text.Substring(0, playerTextOutput.text.Length - 1);
                    soundHandler.PlayKeyClickHeavy();
                }
                else
                {
                    playerTextOutput.text += key.text;
                    soundHandler.PlayKeyClickLight();
                }
            }
        }
    }
}
