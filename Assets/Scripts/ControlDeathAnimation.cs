using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlDeathAnimation : MonoBehaviour
{

    private Animator anim;
    public Slider slider;

    Animator m_Animator;
    string m_ClipName;
    AnimatorClipInfo[] m_CurrentClipInfo;
    float m_CurrentClipLength;
    float timer;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //Get them_Animator, which you attach to the GameObject you intend to animate.
        m_Animator = gameObject.GetComponent<Animator>();
        //Fetch the current Animation clip information for the base layer
        m_CurrentClipInfo = this.m_Animator.GetCurrentAnimatorClipInfo(0);
        //Access the current length of the clip
        m_CurrentClipLength = m_CurrentClipInfo[0].clip.length;
        //Access the Animation clip name
        m_ClipName = m_CurrentClipInfo[0].clip.name;
        print(m_CurrentClipLength);
        timer = (1 / m_CurrentClipLength) / 60;
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play("Death", 0, slider.normalizedValue);
        slider.normalizedValue += timer;
    }
}
