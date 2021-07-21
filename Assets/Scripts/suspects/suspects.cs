using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class suspects : MonoBehaviour
{

    class Suspect
    {
        [SerializeField] private GameObject portrait;
        [SerializeField] private string name;
        [SerializeField] private int age;
        [SerializeField] private Sex sex;
        [SerializeField] private HairColor haircolor;
        [SerializeField] private int height;

        public Suspect(string name, int age, Sex sex, HairColor haircolor, int height, GameObject portrait = null)
        {
            this.portrait = portrait ? portrait : null;
            this.name = name;
            this.age = age;
            this.sex = sex;
            this.haircolor = haircolor;
            this.height = height;
        }

    }

    enum Sex
    {
        male, female, other
    };
    enum HairColor
    {
        blonde, brown, red, white, bald
    };



    [SerializeField] private Transform originalPortrait;

    [SerializeField] static private float horizontalDistance = 0.1f;

    [SerializeField] static private float verticalDistance = 0.1f;


    private static Vector3 horizontalDistanceVec = Vector3.right * horizontalDistance;
    private static Vector3 verticalDistanceVec = Vector3.down * verticalDistance;


    // Declare array of Suspects
    [SerializeField] private Suspect[] suspectPortraits =
{
            new Suspect("Joe B", 42, Sex.male, HairColor.bald, 180),
            new Suspect("Joe B", 42, Sex.male, HairColor.bald, 180),
            new Suspect("Joe B", 42, Sex.male, HairColor.bald, 180),
            new Suspect("Joe B", 42, Sex.male, HairColor.bald, 180),
            new Suspect("Joe B", 42, Sex.male, HairColor.bald, 180),
            new Suspect("Joe B", 42, Sex.male, HairColor.bald, 180),
            new Suspect("Joe B", 42, Sex.male, HairColor.bald, 180),
            new Suspect("Joe B", 42, Sex.male, HairColor.bald, 180),
            new Suspect("Joe B", 42, Sex.male, HairColor.bald, 180),
    };


    // Start is called before the first frame update
    void Start()
    {

        Vector3 origPicPos = originalPortrait.position;


        //array of positions for the portraits
        Vector3[] portaitPos =
        {
            origPicPos, origPicPos + horizontalDistanceVec, origPicPos + 2*horizontalDistanceVec,
            origPicPos + verticalDistanceVec, origPicPos + horizontalDistanceVec + verticalDistanceVec, origPicPos + 2*horizontalDistanceVec + verticalDistanceVec,
            origPicPos + 2*verticalDistanceVec, origPicPos + horizontalDistanceVec + 2*verticalDistanceVec, origPicPos + 2*horizontalDistanceVec + 2*verticalDistanceVec,

        };

        if(suspectPortraits.Length == portaitPos.Length)
        {
            for(int i=0; i<suspectPortraits.Length; i++)
            {

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
