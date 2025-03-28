using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class Weapon : MonoBehaviour
{
    [SerializeField] Camera playerCam;
    [SerializeField] float raycastRange = 100f;
    [SerializeField] float damage = 10f;
    

    private InputAction shootAction;
    public InputActionAsset inputActionAsset;
    public int ammoCount = 5;
    private int increaseAmmo = 5;
    public int totalAmmo = 10;
    public Text ammo_text;
    //public float ClipLength = 1f;
    //public GameObject AudioClip;

    //private void Start()
    //{
        //AudioClip.SetActive(false);
    //}
    void Update()
    {
        UpdateAmmoText();
    }

    public void OnEnable()
    {
        shootAction = inputActionAsset.FindActionMap("Shoot").FindAction("Fire");
        shootAction.performed += ctx => Shoot();
        shootAction.Enable();
    }

    private void OnDisable()
    {
        shootAction.Disable();
    }

    private void Shoot()
    {
        Raycast();
        decreaseAmmo();
        UpdateAmmoText();
    }

    public void Reload(InputAction.CallbackContext context)
    {
        if (totalAmmo == 10 && ammoCount == 0)
        {
            totalAmmo -= 5;
            ammoCount = 5;
            OnEnable();
            Debug.Log("Added ammo to ammoCount");
        }

        if (totalAmmo == 5 && ammoCount == 0)
        {
            totalAmmo -= 5;
            ammoCount = 5;
            OnEnable();
            Debug.Log("Added Ammo to ammoCount 2");
        }
        UpdateAmmoText();
    }



    private void Raycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, raycastRange))
        {
            Debug.Log(hit.collider.gameObject);
            //enemyHealth enemyTarget = hit.collider.GetComponent<enemyHealth>();
            //enemyTarget.TakeDamage(damage);

        }


    }


    private void decreaseAmmo()
    {
        if (ammoCount > 0)
        {
            ammoCount -= 1;
        }

        else
        {
            OnDisable();
            Debug.Log("Can't shoot");

        }
        UpdateAmmoText();

    }

    public void addAmmo()
    {
        totalAmmo += increaseAmmo;
        if (totalAmmo > 0 && totalAmmo < 5)
        {
            OnEnable();

        }
        UpdateAmmoText();

    }
    private void UpdateAmmoText()
    {
        ammo_text.text = $"{ammoCount}/{totalAmmo}";
    }
}
