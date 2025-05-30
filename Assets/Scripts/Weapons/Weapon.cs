using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



public class Weapon : MonoBehaviour
{
    public Camera playerCam;
    [SerializeField]
    private float WeaponRange = 100f;
    private float damage = 20f;
    public Text ammo_text;
    public ParticleSystem muzzleFlash;
    Animation anim;
    AudioSource Audio;
   public AudioClip PistolFire;
    public AudioClip DryFire;
    public AudioClip PistolReload;

    public int MaxAmmo = 10;
    private int CurrentAmmo = 5;
    [SerializeField]
    private float fireRate = 1.5f; 
    private float nextFireTime = 0f;


    PlayerInput playerInput;
    InputAction ShootAction;
    InputAction ReloadAction;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        ShootAction = playerInput.actions.FindAction("Fire");
        ReloadAction = playerInput.actions.FindAction("Reload");
        anim = GetComponent<Animation>();
        Cursor.visible = false;
        Audio = GetComponent<AudioSource>();

    }

    private void Update()
    {
        UpdateAmmoText();
    }




    public void Shoot(InputAction.CallbackContext context)
    {
        if (CurrentAmmo <= 0)
        {
            Debug.Log("Out of Ammo");
            ShootAction.Disable();
            Audio.PlayOneShot(DryFire);
            return;
        }


        if (Time.time < nextFireTime)
            return;

       
        nextFireTime = Time.time + fireRate;

        RaycastHit hit;

        if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, WeaponRange))
        {
            Debug.Log(hit.collider.gameObject);
            muzzleFlash.Play();
            anim.Play();
            Audio.PlayOneShot(PistolFire);
            miniGilHealth MiniGil = hit.collider.GetComponent<miniGilHealth>();
            enemyHealth enemyTarget = hit.collider.GetComponent<enemyHealth>();

            if (enemyTarget != null)
            {
                enemyTarget.TakeDamage(damage);

            }
            if (MiniGil != null)
            {
                MiniGil.TakeDamage(damage);
            }
        }

        if(CurrentAmmo > 0)
        {
            CurrentAmmo-=1;
            
        }

        else if((CurrentAmmo == 0))
        {

            ShootAction.Disable();
            Debug.Log("Can't Shoot");
           
            return;
        }
    }

    

    public void Reload(InputAction.CallbackContext context)
    {
        if(MaxAmmo >= 10 && CurrentAmmo == 0 && context.performed)
        {
            MaxAmmo -= 5;
            CurrentAmmo += 5;
            ShootAction.Enable();
            Debug.Log("Reloaded");
            Audio.PlayOneShot(PistolReload);
            
            
        }

        if (MaxAmmo == 5 && CurrentAmmo == 0 && context.performed)
        {
            MaxAmmo -= 5;
            CurrentAmmo += 5;
            ShootAction.Enable();
            Debug.Log("Reloaded");
            Audio.PlayOneShot(PistolReload);


        }
    }

    public void AddAmmo(int AmmoAmount)
    {
        MaxAmmo += AmmoAmount;

        


    }

    public void UpdateAmmoText()
    {
        ammo_text.text = $"{CurrentAmmo}/{MaxAmmo}";
    }


}
