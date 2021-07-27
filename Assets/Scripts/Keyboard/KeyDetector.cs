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

    float timer = 0;
    float blinkDuration = 0.3f;
    bool cursorOn = false;
    bool removedCursor = false;

    int activePage = 0;


    // Start is called before the first frame update
    void Start()
    {
        playerTextOutput = pages[0].GetComponent<TextMeshPro>();
        soundHandler = GameObject.FindGameObjectWithTag("SoundHandler").GetComponent<SoundHandler>();

        pages[0].SetActive(true);
        pages[1].SetActive(true);
        pages[2].SetActive(false);
        pages[3].SetActive(false);
        pages[4].SetActive(false);
        pages[5].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer < blinkDuration && !cursorOn)
        {
            playerTextOutput.text += "|";
            cursorOn = true;
        }
        else if (timer > 2*blinkDuration)
        {
            timer = 0;
        }
        else if (timer > blinkDuration && cursorOn )
        {
            playerTextOutput.text = playerTextOutput.text.Substring(0, playerTextOutput.text.Length - 1);
            cursorOn = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var key = other.GetComponentInChildren<TextMeshPro>();

        if(key != null)
        {
            if(playerTextOutput.text.Length != 0)
            {
                if (playerTextOutput.text[playerTextOutput.text.Length - 1] == '|')
                {
                    playerTextOutput.text = playerTextOutput.text.Substring(0, playerTextOutput.text.Length - 1);
                    removedCursor = true;
                }
            }

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
                    switch (activePage)
                    {

                        case 0: 
                            playerTextOutput = pages[1].GetComponent<TextMeshPro>();

                            activePage = 1;
                            pageCounter.text = "Page 2/5";
                            break;
                        case 1: 
                            pages[0].SetActive(false);
                            pages[1].SetActive(false);


                            pages[2].SetActive(true);
                            pages[3].SetActive(true);

                            playerTextOutput = pages[2].GetComponent<TextMeshPro>();

                            activePage = 2;
                            pageCounter.text = "Page 3/5";
                            break;
                         case 2: 
                            playerTextOutput = pages[3].GetComponent<TextMeshPro>();

                            activePage = 3;
                            pageCounter.text = "Page 4/5";
                            break;
                        case 3:
                            pages[2].SetActive(false);
                            pages[3].SetActive(false);

                            pages[4].SetActive(true);
                            pages[5].SetActive(true);
                            playerTextOutput = pages[4].GetComponent<TextMeshPro>();

                            activePage = 4;
                            pageCounter.text = "Page 5/6";
                            break;
                        case 4:
                            playerTextOutput = pages[5].GetComponent<TextMeshPro>();

                            activePage = 5;
                            pageCounter.text = "Page 6/6";
                            break;
                    }

                    soundHandler.PlayKeyClickHeavy();
                }
                else if (key.text == "< Page")
                {
                    switch (activePage)
                    {

                        case 1:
                            playerTextOutput = pages[0].GetComponent<TextMeshPro>();

                            activePage = 0;
                            pageCounter.text = "Page 1/5";
                            break;
                        case 2:
                            pages[2].SetActive(false);
                            pages[3].SetActive(false);


                            pages[0].SetActive(true);
                            pages[1].SetActive(true);

                            playerTextOutput = pages[1].GetComponent<TextMeshPro>();

                            activePage = 1;
                            pageCounter.text = "Page 2/5";
                            break;
                        case 3:
                            playerTextOutput = pages[2].GetComponent<TextMeshPro>();

                            activePage = 2;
                            pageCounter.text = "Page 3/5";
                            break;
                        case 4:
                            pages[4].SetActive(false);
                            pages[5].SetActive(false);

                            pages[2].SetActive(true);
                            pages[3].SetActive(true);
                            playerTextOutput = pages[3].GetComponent<TextMeshPro>();

                            activePage = 3;
                            pageCounter.text = "Page 4/6";
                            break;
                        case 5:
                            playerTextOutput = pages[4].GetComponent<TextMeshPro>();

                            activePage = 4;
                            pageCounter.text = "Page 5/6";
                            break;
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

        if(removedCursor == true)
        {
            playerTextOutput.text += "|";
            removedCursor = false;
        }

    }
}
