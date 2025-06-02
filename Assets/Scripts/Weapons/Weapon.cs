using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



public class Weapon : MonoBehaviour
{
    //PlayerCam Ref 
    public Camera playerCam;
    [SerializeField]
    //RaycastRange 
    private float WeaponRange = 100f;
    //Damage that will be passed through to the enemy 
    [SerializeField]
    private float damage = 20f;
    //UI that keeps track of Ammo
    public Text ammo_text;
    //MuzzleFllash
    public ParticleSystem muzzleFlash;
    //AnimationRef for Recoil anim
    Animation anim;
    //AudioRef for SoundEffects
    AudioSource Audio;
    //SoundEffects
   public AudioClip PistolFire;
    public AudioClip DryFire;
    public AudioClip PistolReload;

    //MaxAmmo and CurrentAmmo
    public int MaxAmmo = 10;
    private int CurrentAmmo = 5;
    [SerializeField]
    private float fireRate = 1.5f; 
    private float nextFireTime = 0f;

    //PlayerInput, Shoot and reload action
    PlayerInput playerInput;
    InputAction ShootAction;
    InputAction ReloadAction;

    private void Start()
    {
        //Grabs Componets 
        playerInput = GetComponent<PlayerInput>();
        ShootAction = playerInput.actions.FindAction("Fire");
        ReloadAction = playerInput.actions.FindAction("Reload");
        anim = GetComponent<Animation>();
        
        Audio = GetComponent<AudioSource>();

    }

    private void Update()
    {
        //Whenever a Bullet is fired or gun is reloaded it will call UpdateAmmoText to update the UI
        UpdateAmmoText();
    }



    //InputAction CallBackContext is used so everytime I press left click on the mouse it will call Shoot

    public void Shoot(InputAction.CallbackContext context)
    {
        //If CurrentAmmo is less than or equal to 0 it will Disable the ShootAction and prevent further firing
        //Plays DryFire
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
        //Declare Raycast 
        RaycastHit hit;
        //Raycast is fired from PlayerCam it takes it's position and transform and fires forward and this takes WeaponsRange 
        //If this raycast hits any colliders its stored in 'hit' 
        //Using a raycast to hit the enemies collider 
        if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, WeaponRange))
        {
            Debug.Log(hit.collider.gameObject);
            muzzleFlash.Play();
            anim.Play();
            Audio.PlayOneShot(PistolFire);
            //If this raycast hits any of the enemies colliders it then will grab both of their HealthScripts
            miniGilHealth MiniGil = hit.collider.GetComponent<miniGilHealth>();
            enemyHealth enemyTarget = hit.collider.GetComponent<enemyHealth>();

            //If either of the enemies health scripts aren't null it will then call the takeDamageMethod in their scripts and then the damage variable is passed through 
            if (enemyTarget != null)
            {
                enemyTarget.TakeDamage(damage);

            }
            if (MiniGil != null)
            {
                MiniGil.TakeDamage(damage);
            }
        }

        //If Weapon has ammo and is not at 0 it will then start deducting ammo from CurrentAmmo everytime Shoot is called

        if(CurrentAmmo > 0)
        {
            CurrentAmmo-=1;
            
        }

        
    }

    

    public void Reload(InputAction.CallbackContext context)
    {
        //If Ammo is at and Current 0 and I press 'R'
        //Weapon will Reload, and ShootAction is renabled
        //Takes 5 ammo away from MaxAmmo and then gives CurrentAmmo 5 


        if(MaxAmmo >= 10 && CurrentAmmo == 0 && context.performed)
        {
            MaxAmmo -= 5;
            CurrentAmmo += 5;
            ShootAction.Enable();
            Debug.Log("Reloaded");
            Audio.PlayOneShot(PistolReload);
            
            
        }
        //More or less same here once it's been reloaded MaxAmmo will = 5 
        //WHen currentAmmo is at 0 and 'R' is pressed MaxAmmo will be 0 and then it adds 5 to currentAmmo 
        //Renables the weapon 
        if (MaxAmmo == 5 && CurrentAmmo == 0 && context.performed)
        {
            MaxAmmo -= 5;
            CurrentAmmo += 5;
            ShootAction.Enable();
            Debug.Log("Reloaded");
            Audio.PlayOneShot(PistolReload);


        }
    }

    //Method used by AmmoPickUps
    //AmmoPickUp will passthrough AmmoAmount should be 5 then assings it to MaxAmmo
    public void AddAmmo(int AmmoAmount)
    {
        MaxAmmo += AmmoAmount;

        


    }

    public void UpdateAmmoText()
    {
        ammo_text.text = $"{CurrentAmmo}/{MaxAmmo}";
    }


}
