using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class suspects : MonoBehaviour
{
    static int totalSuspectCounter = 9;

    [SerializeField] private GameObject[] SuspectArr;
    Vector3[] portraitPos = new Vector3[totalSuspectCounter];

    [SerializeField] static private float horizontalDistance = 0.275f;
    [SerializeField] static private float verticalDistance = 0.34f;

    private static Vector3 horizontalDistanceVec = Vector3.forward * horizontalDistance;
    private static Vector3 verticalDistanceVec = Vector3.down * verticalDistance;

    [SerializeField] private Slider minAge;
    [SerializeField] private Slider maxAge;
    [SerializeField] private Slider minHeight;
    [SerializeField] private Slider maxHeight;
    [SerializeField] private TMPro.TMP_Dropdown hairColor;
    [SerializeField] private TMPro.TMP_Dropdown sexDropdown;



    [SerializeField] private bool testPositionSuspects = false;
    [SerializeField] private bool testReset = false;
    [SerializeField] private bool testFilter = false;
    [SerializeField] private List<int> testList;



    // Start is called before the first frame update
    void Start()
    {

        Vector3 origPicPos = SuspectArr[0].transform.position;

        for(int i=0; i<totalSuspectCounter; i++)
        {
            portraitPos[i] = origPicPos + Mathf.Floor(i / 3) * verticalDistanceVec + i % 3 * horizontalDistanceVec;
        }



        for(int i=0; i<SuspectArr.Length; i++)
        {
            SuspectArr[i].transform.position = portraitPos[i];
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (testPositionSuspects)
        {
            positionSuspects(testList);
            testPositionSuspects = false;
        }

        if(testReset)
        {
            resetPositions();
            testReset = false;
        }

        if(testFilter)
        {
           readAndFilter();
            testFilter = false;
        }
    }


    public List<int> filterSuspects()
    {
        

        List<int> indexs = new List<int>();

        Sex suspectSex = new Sex();
        HairColor suspectHaircolor = new HairColor();

        switch (sexDropdown.value)
        {
            case 0:
                suspectSex = Sex.unknown;
                break;
            case 1:
                suspectSex = Sex.male;
                break;
            case 2:
                suspectSex = Sex.female;
                break;
            case 3:
                suspectSex = Sex.other;
                break;

        }

        switch (hairColor.value)
        {
            case 0:
                suspectHaircolor = HairColor.unknown;
                break;
            case 1:
                suspectHaircolor = HairColor.blonde;
                break;
            case 2:
                suspectHaircolor = HairColor.brown;
                break;
            case 3:
                suspectHaircolor = HairColor.red;
                break;
            case 4:
                suspectHaircolor = HairColor.grey;
                break;
            case 5:
                suspectHaircolor = HairColor.bald;
                break;

        }

        for (int i=0; i<SuspectArr.Length; i++)
        {
            suspectClass suspectScript = SuspectArr[i].GetComponent<suspectClass>();

            bool ageFits = (minAge.value<=suspectScript.age && suspectScript.age <= maxAge.value) || (minAge.value == 0 && maxAge.value == 0);
            bool heightFits = (minHeight.value <= suspectScript.height && suspectScript.height <= maxHeight.value) || (minHeight.value == 100 && maxHeight.value == 100);
            bool sexFits = suspectSex == Sex.unknown ? true : suspectSex == suspectScript.sex ? true : false; 
            bool haircolorFits = suspectHaircolor == HairColor.unknown ? true : suspectHaircolor == suspectScript.haircolor ? true : false; 


            if(ageFits && heightFits && sexFits && haircolorFits)
            {
                indexs.Add(i);
            }

        }

        


        return indexs;
    }

    void positionSuspects(List<int> remainingSuspects)
    {


        List<suspectClass> suspectScripts = new List<suspectClass>();
        foreach (int i in remainingSuspects)
        {
            suspectScripts.Add(SuspectArr[i].GetComponent<suspectClass>());
        }

        hideAll();

        if (remainingSuspects.Count == 1)
        {

            GameObject suspect = SuspectArr[remainingSuspects[0]];
            float scaleFactor = 1.5f;
            Vector3 textReposition = new Vector3(0, -0.065f, 0);

            //suspect.transform.localScale += new Vector3(scaleFactor, scaleFactor, scaleFactor);
            suspect.transform.position = portraitPos[4];
            foreach (Transform child in suspect.transform)
            {

                child.localScale *= scaleFactor;

                if (child.tag == "suspectText")
                {
                    child.position += textReposition;
                }

            }

            suspectScripts[0].curScale = scaleFactor;

            hideAll();
            suspect.SetActive(true);

        }
        else if (remainingSuspects.Count == 2)
        {

            float posDiff = 0.05f;
            Vector3[] posDiffArr = { new Vector3(0, posDiff, 0), new Vector3(0, -posDiff, 0) };

            float scaleFactor = 1.3f;
            Vector3 textReposition = new Vector3(0, -0.040f, 0);



            SuspectArr[remainingSuspects[0]].transform.position = ((portraitPos[1] + portraitPos[4]) / 2) + posDiffArr[0];
            SuspectArr[remainingSuspects[1]].transform.position = ((portraitPos[4] + portraitPos[7]) / 2) + posDiffArr[1];

            for (int i = 0; i < remainingSuspects.Count; i++)
            {

                foreach (Transform child in SuspectArr[remainingSuspects[i]].transform)
                {

                    child.localScale *= scaleFactor;

                    if (child.tag == "suspectText")
                    {
                        child.position += textReposition;
                    }

                }

                suspectScripts[i].curScale = scaleFactor;
                suspectScripts[i].posDiffText += textReposition;
            }


            hideAll();
            SuspectArr[remainingSuspects[0]].SetActive(true);
            SuspectArr[remainingSuspects[1]].SetActive(true);

        }
        else if (remainingSuspects.Count == 3)
        {
            float posDiff = 0.05f;
            Vector3[] posDiffArr = { new Vector3(0, posDiff, 0), new Vector3(0, -posDiff, 0), 
                                     new Vector3(0, 0, -posDiff), new Vector3(0, 0, posDiff) };

            float scaleFactor = 1.3f;
            Vector3 textReposition = new Vector3(0, -0.040f, 0);



            SuspectArr[remainingSuspects[0]].transform.position = ((portraitPos[0] + portraitPos[4]) / 2) + posDiffArr[0] + posDiffArr[2];
            SuspectArr[remainingSuspects[1]].transform.position = ((portraitPos[2] + portraitPos[4]) / 2) + posDiffArr[0] + posDiffArr[3];
            SuspectArr[remainingSuspects[2]].transform.position = ((portraitPos[4] + portraitPos[7]) / 2) + posDiffArr[1];

            for (int i = 0; i < remainingSuspects.Count; i++)
            {

                foreach (Transform child in SuspectArr[remainingSuspects[i]].transform)
                {

                    child.localScale *= scaleFactor;

                    if (child.tag == "suspectText")
                    {
                        child.position += textReposition;
                    }

                }

                suspectScripts[i].curScale = scaleFactor;
                suspectScripts[i].posDiffText += textReposition;
            }


            hideAll();
            SuspectArr[remainingSuspects[0]].SetActive(true);
            SuspectArr[remainingSuspects[1]].SetActive(true);
            SuspectArr[remainingSuspects[2]].SetActive(true);

        }
        else if (remainingSuspects.Count > 3)
        {

            int posIndex = 0;

            hideAll();

            foreach (int suspectIndex in remainingSuspects)
            {
                SuspectArr[suspectIndex].transform.position = portraitPos[posIndex];
                SuspectArr[suspectIndex].SetActive(true);
                posIndex++;
            }

        }
    }

    public void readAndFilter()
    {
        List<int> suspects = filterSuspects();
        positionSuspects(suspects);
    }

    public void resetPositions()
    {
        for(int i=0; i<SuspectArr.Length; i++)
        {
            suspectClass suspectScript = SuspectArr[i].GetComponent<suspectClass>();


            SuspectArr[i].transform.localScale *= 1.0f / suspectScript.curScale;
            suspectScript.curScale = 1.0f;
            suspectScript.posDiffText = Vector3.zero;

            SuspectArr[i].transform.position = portraitPos[i];

            unhideAll();
        }
    }

    void hideAll()
    {
        for (int i = 0; i < SuspectArr.Length; i++)
        {
            SuspectArr[i].SetActive(false);
        }
    }

    void unhideAll()
    {
        for (int i = 0; i < SuspectArr.Length; i++)
        {
            SuspectArr[i].SetActive(true);
        }
    }
}
