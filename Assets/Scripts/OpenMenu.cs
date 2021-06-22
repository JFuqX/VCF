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
    public bool openOnce = true;

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



            if (menuOpen == true && primaryButtonValue == true && openOnce == true)
            {
                Debug.Log("Menu Close");
                //Close Menu
                Destroy(instantiatedMenu);
                openOnce = false;
            }

            if (menuOpen == false && primaryButtonValue == true)
            {
                Debug.Log("Menu Open");
                //Open Menu
                instantiatedMenu = Instantiate(menu, new Vector3(leftHandPositionMenu.position.x - 0.2f, leftHandPositionMenu.position.y + 0.4f, leftHandPositionMenu.position.z), new Quaternion(0, 0, 0, 0));
                instantiatedMenu.transform.Rotate(25, 90, 0);
                openOnce = false;
            }


            openOnce = true;
        }
    }
}
