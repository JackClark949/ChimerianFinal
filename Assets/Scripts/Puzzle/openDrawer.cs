using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDrawer : MonoBehaviour
{
    private Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }
    public void playAnim()
    {
        anim.Play();
        Debug.Log("Playing Anim");




    }
}
