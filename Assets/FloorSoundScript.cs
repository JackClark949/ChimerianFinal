using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSoundScript : MonoBehaviour
{
    AudioSource Audio;
    [SerializeField] private AudioClip PlayerMovementHouseClip;
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        Audio.clip = PlayerMovementHouseClip;

    }

    private void onCollisionEnter()
    {
        if (gameObject.CompareTag("PlayerFeet"))
        {
            Debug.Log("Now playing" + PlayerMovementHouseClip);
            Audio.Play();
        }
    }
}
