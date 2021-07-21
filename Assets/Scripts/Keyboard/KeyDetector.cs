using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyDetector : MonoBehaviour
{
    private TextMeshPro playerTextOutput;
    private SoundHandler soundHandler;

    [SerializeField] private GameObject[] pages;
    [SerializeField] private TextMeshPro pageCounter;


    // Start is called before the first frame update
    void Start()
    {
        playerTextOutput = pages[0].GetComponent<TextMeshPro>();
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
                else if (key.text == "<-'")
                {
                    playerTextOutput.text += "\n";
                    soundHandler.PlayKeyClickHeavy();
                }
                else if (key.text == "Page >")
                {
                    if(pages[0].activeSelf)
                    {
                        pages[0].SetActive(false);
                        pages[1].SetActive(true);
                        playerTextOutput = pages[1].GetComponent<TextMeshPro>();

                        pageCounter.text = "Page 2/5";
                    } 
                    else if (pages[1].activeSelf)
                    {
                        pages[1].SetActive(false);
                        pages[2].SetActive(true);
                        playerTextOutput = pages[2].GetComponent<TextMeshPro>();

                        pageCounter.text = "Page 3/5";
                    }
                    else if (pages[2].activeSelf)
                    {
                        pages[2].SetActive(false);
                        pages[3].SetActive(true);
                        playerTextOutput = pages[3].GetComponent<TextMeshPro>();

                        pageCounter.text = "Page 4/5";
                    }
                    else if (pages[3].activeSelf)
                    {
                        pages[3].SetActive(false);
                        pages[4].SetActive(true);
                        playerTextOutput = pages[4].GetComponent<TextMeshPro>();

                        pageCounter.text = "Page 5/5";
                    }
                    soundHandler.PlayKeyClickHeavy();
                }
                else if (key.text == "< Page")
                {
                    if (pages[1].activeSelf)
                    {
                        pages[1].SetActive(false);
                        pages[0].SetActive(true);
                        playerTextOutput = pages[0].GetComponent<TextMeshPro>();

                        pageCounter.text = "Page 1/5";
                    }
                    else if (pages[2].activeSelf)
                    {
                        pages[2].SetActive(false);
                        pages[1].SetActive(true);
                        playerTextOutput = pages[1].GetComponent<TextMeshPro>();

                        pageCounter.text = "Page 2/5";
                    }
                    else if (pages[3].activeSelf)
                    {
                        pages[3].SetActive(false);
                        pages[2].SetActive(true);
                        playerTextOutput = pages[2].GetComponent<TextMeshPro>();

                        pageCounter.text = "Page 3/5";
                    }
                    else if (pages[4].activeSelf)
                    {
                        pages[4].SetActive(false);
                        pages[3].SetActive(true);
                        playerTextOutput = pages[3].GetComponent<TextMeshPro>();

                        pageCounter.text = "Page 4/5";
                    }
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
