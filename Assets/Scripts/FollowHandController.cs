using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHandController : MonoBehaviour
{

    public GameObject gameobjectController;

    // Start is called before the first frame update
    void Start()
    {
        gameobjectController = GameObject.Find("Left Hand");
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position = new Vector3(gameobjectController.transform.position.x, gameobjectController.transform.position.y+0.2f , gameobjectController.transform.position.z);
        this.transform.rotation = gameobjectController.transform.rotation;


    }
}
