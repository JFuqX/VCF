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

    public GameObject spawnObjectTransform;
    

    // Start is called before the first frame update
    void Start()
    {
        leftHandPresenceScript = leftHandPresence.GetComponent<HandPresence>();
        scanner.SetActive(false);
        uvLamp.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(spawnObjectTransform.transform.position);
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
        
        Debug.Log(new Vector3(spawnObjectTransform.transform.position.x - 0.3f, spawnObjectTransform.transform.position.y, spawnObjectTransform.transform.position.z));
        scanner.GetComponent<Rigidbody>().velocity = Vector3.zero;
        scanner.GetComponent<Rigidbody>().rotation = new Quaternion(0, 0, 0, 0);
        scanner.SetActive(true);
        scanner.transform.position = new Vector3(spawnObjectTransform.transform.position.x - 0.3f, spawnObjectTransform.transform.position.y, spawnObjectTransform.transform.position.z);
        //scannerObject = Instantiate(scanner, spawnObjectTransform);
        
    }

    public void SpawnUVLamp()
    {
        Debug.Log(new Vector3(spawnObjectTransform.transform.position.x - 0.3f, spawnObjectTransform.transform.position.y, spawnObjectTransform.transform.position.x));
        uvLamp.GetComponent<Rigidbody>().velocity = Vector3.zero;
        uvLamp.GetComponent<Rigidbody>().rotation = new Quaternion(0, 0, 0, 0);
        uvLamp.SetActive(true);
        uvLamp.transform.position = new Vector3(spawnObjectTransform.transform.position.x - 0.3f, spawnObjectTransform.transform.position.y, spawnObjectTransform.transform.position.z);
        //uvLampObject = Instantiate(uvLamp, spawnObjectTransform);

    }

    public void SpawnKeyboard()
    {
        keyboard.SetActive(true);
        keyboard.transform.position = new Vector3(spawnObjectTransform.transform.position.x - 1f, spawnObjectTransform.transform.position.y - 1f, spawnObjectTransform.transform.position.z + 0.4f);
        keyboard.GetComponent<followPlayer>().isOnPlayer = true;
        //Destroy(uvLampObject);
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
        Debug.Log("Destroy canner");
    }

    public void DeleteUVLamp()
    {
        uvLamp.SetActive(false);
        //Destroy(uvLampObject);
    }


}
