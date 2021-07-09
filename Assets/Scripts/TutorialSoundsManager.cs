using UnityEngine.Audio;
using UnityEngine;


public class TutorialSoundsManager : MonoBehaviour
{

    public GameObject player;

    public AudioSource source;
    public AudioClip audio1;
    public AudioClip audio2;
    public AudioClip audio3;
    public AudioClip audio4;
    public AudioClip audio5;
    public AudioClip audio6;
    public AudioClip audio7;
    public AudioClip audio8;
    public AudioClip audio9;
    public AudioClip audio10;
    public AudioClip audio11;
    public AudioClip audio12;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (player.transform.position.z < 10)
        {
            //Entscheidung Tutorial oder nicht, erklärung laufen
            if (source.isPlaying == false)
            {
                source.clip = audio1;
                source.Play();
            }

        }
        else if (player.transform.position.z > 10 && player.transform.position.z < 24)
        {
            //erklärung teleportieren
            if (source.isPlaying == false)
            {
                source.clip = audio2;
                source.Play();
            }
        }
        else if (player.transform.position.z > 24 && player.transform.position.z < 40)
        {
            //Runterlaufen oder teleportieren
            if (source.isPlaying == false)
            {
                source.clip = audio3;
                source.Play();
            }
        }
        else if (player.transform.position.z > 40 && player.transform.position.z < 55)
        {
            //erklären grabben
            if (source.isPlaying == false)
            {
                source.clip = audio4;
                source.Play();
            }
        }
        else if (player.transform.position.z > 55 && player.transform.position.z < 70)
        {
            //grabben cabin und grabben dann trigger
            if (source.isPlaying == false)
            {
                source.clip = audio5;
                source.Play();
            }

        }
        else if (player.transform.position.z > 70 && player.transform.position.z < 84)
        {
            //Grabben mit Raycast
            if (source.isPlaying == false)
            {
                source.clip = audio6;
                source.Play();
            }
        }
        else if (player.transform.position.z > 84 && player.transform.position.z < 97)
        {
            //Erklären UI
            if (source.isPlaying == false)
            {
                source.clip = audio7;
                source.Play();
            }
        }
        else if (player.transform.position.z > 97 && player.transform.position.z < 111)
        {
            //Öffnen menu
            if (source.isPlaying == false)
            {
                source.clip = audio8;
                source.Play();
            }
        }
        else if (player.transform.position.z > 111 && player.transform.position.z < 123)
        {
            //Tag Nacht slider, Uv Lampe und Fußspuren
            if (source.isPlaying == false)
            {
                source.clip = audio9;
                source.Play();
            }
        }
        else if (player.transform.position.z > 123 && player.transform.position.z < 136)
        {
            //Scannen Deadbody and slider
            if (source.isPlaying == false)
            {
                source.clip = audio10;
                source.Play();
            }
        }
        else if (player.transform.position.z > 136 && player.transform.position.z < 148)
        {
            //Notizbuch
            if (source.isPlaying == false)
            {
                source.clip = audio11;
                source.Play();
            }
        }
        else if (player.transform.position.z > 148)
        {
            //End Tutorial
            if (source.isPlaying == false)
            {
                source.clip = audio12;
                source.Play();
            }
        }




        
    }
}