using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public float interactionDistance;
    public GameObject InteractionText;
    public LayerMask InteractionLayers;

    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, InteractionLayers))
        {
            if (hit.collider.gameObject.GetComponent<Note>())
            {
                InteractionText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<Note>().OpenCloseNote();
                }
            }
            else
            {
                InteractionText.SetActive(false);
            }
        }
        else
        {
            InteractionText.SetActive(false);
        }
    }
}
