using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Sex
{
    male, female, other, unknown
};
public enum HairColor
{
    blonde, brown, red, grey, bald, unknown
};

public class suspectClass : MonoBehaviour
{

    [SerializeField] public string fullName;
    [SerializeField] public int age;
    [SerializeField] public Sex sex;
    [SerializeField] public HairColor haircolor;
    [SerializeField] public int height;
                     
    [SerializeField] public TextMeshProUGUI nameLabel;
    [SerializeField] public TextMeshProUGUI ageLabel;

    public float curScale = 1;
    public Vector3 posDiffText = new Vector3(0,0,0);

    


    // Start is called before the first frame update
    void Start()
    {
        nameLabel.text = fullName;
        ageLabel.text = age.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }




}
