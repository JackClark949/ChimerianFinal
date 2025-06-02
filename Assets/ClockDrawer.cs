using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockDrawer : MonoBehaviour
{
    Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    public void GrandFatherClockDrawer()
    {
        anim.Play();
    }

}
