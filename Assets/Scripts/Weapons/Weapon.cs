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
    [SerializeField] private AudioClip GunShootClip;
    [SerializeField] private AudioClip GunReloadClip;
    [SerializeField] private AudioClip GunDryFireClip;
    

    private PlayerInput playerInput;
    private InputAction shootAction;
    public InputActionAsset inputActionAsset;
    public ParticleSystem muzzleFlash;
    
    public int ammoCount = 5;
    private int increaseAmmo = 5;
    public int totalAmmo = 10;
    public Text ammo_text;
    private AudioSource audioSource; 
    
    Animation anim;
    
    

    void Start()
    {
        anim = GetComponent<Animation>();
        audioSource = GetComponent<AudioSource>();
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

    void Update()
    {
        UpdateAmmoText();
    }

    

    private void Shoot()
    {
            Raycast();
            decreaseAmmo();
            UpdateAmmoText();
        muzzleFlash.Play();
        anim.Play();
        audioSource.clip = GunShootClip;
        audioSource.Play();

        if(ammoCount == 0)
        {
            audioSource.clip = GunDryFireClip;
            audioSource.Play();
        }
        
    }

    public void Reload(InputAction.CallbackContext context)
    {
        if (totalAmmo == 10 && ammoCount == 0)
        {
            totalAmmo -= 5;
            ammoCount = 5;
            OnEnable();
            Debug.Log("Added ammo to ammoCount");
            audioSource.clip = GunReloadClip;
            audioSource.Play();
        }

        if (totalAmmo == 5 && ammoCount == 0)
        {
            totalAmmo -= 5;
            ammoCount = 5;
            OnEnable();
            Debug.Log("Added Ammo to ammoCount 2");
        }

    }
   



    private void Raycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, raycastRange))
        {
            Debug.Log(hit.collider.gameObject);
            miniGilHealth giltarget = hit.collider.GetComponent<miniGilHealth>();
            enemyHealth enemyTarget = hit.collider.GetComponent<enemyHealth>();

            if (enemyTarget != null)
            {
                enemyTarget.TakeDamage(damage);

            }
            if (giltarget != null)
            {
                giltarget.TakeDamage(damage);
            }
            

            
            
            

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
            if(ammoCount == 0)
            {
                OnDisable();
                Debug.Log("Can't shoot");
            }
            

        }
        UpdateAmmoText();

    }

    public void addAmmo(int amount)
    {
        ammoCount += amount;
        UpdateAmmoText();
        

    }
    private void UpdateAmmoText()
    {
        ammo_text.text = $"{ammoCount}/{totalAmmo}";
    }
}
