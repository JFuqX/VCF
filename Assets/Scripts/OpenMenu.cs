using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class OpenMenu : MonoBehaviour
{

    private HandPresence leftHandPresenceScript;
    public GameObject leftHandPresence;
    public Transform leftHandPositionMenu;
    public GameObject menu;
    //public GameObject instantiatedMenu;

    public bool menuOpen = false;
    public bool openOnce = false;

    public bool pastPress = false;
    public bool newPress = false;

    public GameObject scanner;
    public GameObject uvLamp;
    private GameObject scannerObject;
    private GameObject uvLampObject;

    public GameObject keyboard;
    public GameObject cameraObj;
    public GameObject board;
    public GameObject stick;
    public GameObject keys;


    public GameObject tagNachtSlider;

    public GameObject spawnObjectTransform;
    private bool sliderSpawned = false;


    // Start is called before the first frame update
    void Start()
    {
        leftHandPresenceScript = leftHandPresence.GetComponent<HandPresence>();
        scanner.SetActive(false);
        uvLamp.SetActive(false);
        tagNachtSlider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (leftHandPresenceScript.targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue))
        {
            newPress = primaryButtonValue;
            if(pastPress == newPress)
            {
                openOnce = false;
            }
            if(pastPress != newPress)
            {
                openOnce = true;
            }
           
            if (menuOpen == true && primaryButtonValue == true && openOnce == true)
            {

                //Close Menu
                //Destroy(instantiatedMenu);
                menu.SetActive(false);
                openOnce = false;
                menuOpen = false;
            }

            if (menuOpen == false && primaryButtonValue == true && openOnce == true)
            {

                //Open Menu
                //instantiatedMenu = Instantiate(menu, new Vector3(leftHandPositionMenu.position.x - 0.2f, leftHandPositionMenu.position.y + 0.4f, leftHandPositionMenu.position.z), new Quaternion(0, 0, 0, 0));
                //instantiatedMenu.transform.Rotate(25, 90, 0);
                menu.SetActive(true);
                menu.transform.Rotate(25, 90, 0);
                openOnce = false;
                menuOpen = true;
            }

            pastPress = newPress;
       
        }
    }


    public void SpawnScanner()
    {
        
        
        scanner.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //scanner.GetComponent<Rigidbody>().rotation = new Quaternion(0, 0, 0, 0);
        scanner.SetActive(true);
        scanner.transform.position = new Vector3(spawnObjectTransform.transform.position.x - 0.3f, spawnObjectTransform.transform.position.y, spawnObjectTransform.transform.position.z);
        //scannerObject = Instantiate(scanner, spawnObjectTransform);
        
    }

    public void SpawnUVLamp()
    {
     
        uvLamp.GetComponent<Rigidbody>().velocity = Vector3.zero;
        //uvLamp.GetComponent<Rigidbody>().rotation = new Quaternion(0, 0, 0, 0);
        uvLamp.SetActive(true);
        uvLamp.transform.position = new Vector3(spawnObjectTransform.transform.position.x - 0.3f, spawnObjectTransform.transform.position.y, spawnObjectTransform.transform.position.z);
        //uvLampObject = Instantiate(uvLamp, spawnObjectTransform);

    }

    public void SpawnKeyboard()
    {
        keyboard.SetActive(true);
        Vector3 camRot = cameraObj.transform.forward;
        Vector3 tarPos = cameraObj.transform.position;

        tarPos += new Vector3(camRot.x, -0.7f, camRot.z);

        keyboard.transform.position = tarPos;

        keyboard.transform.LookAt(new Vector3(cameraObj.transform.position.x, keyboard.transform.position.y, cameraObj.transform.position.z));


        foreach ( KeyFeedback child in keys.GetComponentsInChildren<KeyFeedback>())
        {
            child.updatePosition();
        }
    }

    public void SpawnOrDeleteSlider()
    {
        if (sliderSpawned == false)
        {
            tagNachtSlider.SetActive(true);
            sliderSpawned = true;
            Debug.Log("Slider is Active");
        }
        else
        {
            tagNachtSlider.SetActive(false);
            sliderSpawned = false;
            Debug.Log("Slider is Inactive");
        }


    }



    public void DeleteKeyboard()
    {
        keyboard.SetActive(false);
        keyboard.GetComponent<followPlayer>().isOnPlayer = false;

        //Destroy(uvLampObject);
    }


    public void DeleteScanner()
    {
        scanner.SetActive(false);
        //Destroy(scannerObject);
     
    }

    public void DeleteUVLamp()
    {
        uvLamp.SetActive(false);
        //Destroy(uvLampObject);
    }


}
