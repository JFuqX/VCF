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
    public GameObject instantiatedMenu;

    public bool menuOpen = false;
    public bool openOnce = false;

    public bool pastPress = false;
    public bool newPress = false;

    // Start is called before the first frame update
    void Start()
    {
        leftHandPresenceScript = leftHandPresence.GetComponent<HandPresence>();
      

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
            Debug.Log(primaryButtonValue);

            if (menuOpen == true && primaryButtonValue == true && openOnce == true)
            {

                //Close Menu
                Destroy(instantiatedMenu);
                openOnce = false;
                menuOpen = false;
            }

            if (menuOpen == false && primaryButtonValue == true && openOnce == true)
            {
           
                //Open Menu
                instantiatedMenu = Instantiate(menu, new Vector3(leftHandPositionMenu.position.x - 0.2f, leftHandPositionMenu.position.y + 0.4f, leftHandPositionMenu.position.z), new Quaternion(0, 0, 0, 0));
                instantiatedMenu.transform.Rotate(25, 90, 0);
                openOnce = false;
                menuOpen = true;
            }

            pastPress = newPress;
       
        }
    }
}
