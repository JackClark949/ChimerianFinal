using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour
{
    Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }

    public void OpenGate()
    {
        anim.Play();
    }
}
