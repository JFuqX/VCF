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

    private float cooldown = 15;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(cooldown >= 0)
        {
            cooldown -= Time.deltaTime;
        }


        if (cooldown < 0)
        {
            if (player.transform.position.z < -20)
            {
                //Entscheidung Tutorial oder nicht, erklärung laufen
                if (source.isPlaying == false)
                {

                    source.clip = audio1;
                    source.Play();
                }

            }
            else if (player.transform.position.z > -20 && player.transform.position.z < -15.5)
            {
                //erklärung teleportieren
                if (source.isPlaying == false)
                {

                    source.clip = audio2;
                    source.Play();
                }
            }
            else if (player.transform.position.z > -15.5 && player.transform.position.z < -11)
            {
                //Runterlaufen oder teleportieren
                if (source.isPlaying == false)
                {

                    source.clip = audio3;
                    source.Play();
                }
            }
            else if (player.transform.position.z > -11 && player.transform.position.z < -6.5f)
            {
                //erklären grabben
                if (source.isPlaying == false)
                {

                    source.clip = audio4;
                    source.Play();
                }
            }
            else if (player.transform.position.z > -6.5f && player.transform.position.z < -2.3f)
            {
                //grabben cabin und grabben dann trigger
                if (source.isPlaying == false)
                {
                    source.clip = audio5;
                    source.Play();
                }

            }
            else if (player.transform.position.z > -2.3f && player.transform.position.z < 2)
            {
                //Grabben mit Raycast
                if (source.isPlaying == false)
                {
                    source.clip = audio6;
                    source.Play();
                }
            }
            else if (player.transform.position.z > 2 && player.transform.position.z < 5.8f)
            {
                //Erklären UI
                if (source.isPlaying == false)
                {
                    source.clip = audio7;
                    source.Play();
                }
            }
            else if (player.transform.position.z > 5.8f && player.transform.position.z < 9.9f)
            {
                //Öffnen menu
                if (source.isPlaying == false)
                {
                    source.clip = audio8;
                    source.Play();
                }
            }
            else if (player.transform.position.z > 9.9f && player.transform.position.z < 13.5f)
            {
                //Tag Nacht slider, Uv Lampe und Fußspuren
                if (source.isPlaying == false)
                {
                    source.clip = audio9;
                    source.Play();
                }
            }
            else if (player.transform.position.z > 13.5f && player.transform.position.z < 17.2f)
            {
                //Scannen Deadbody and slider
                if (source.isPlaying == false)
                {
                    source.clip = audio10;
                    source.Play();
                }
            }
            else if (player.transform.position.z > 17.2f && player.transform.position.z < 20.8f)
            {
                //Notizbuch
                if (source.isPlaying == false)
                {
                    source.clip = audio11;
                    source.Play();
                }
            }
            else if (player.transform.position.z > 20.8f)
            {
                //End Tutorial
                if (source.isPlaying == false)
                {
                    source.clip = audio12;
                    source.Play();
                }
            }

            cooldown = 20;
        }


        
    }
}