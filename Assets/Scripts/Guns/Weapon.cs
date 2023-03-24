using UnityEngine;
using System.Collections;
using System;
using TMPro;

public class Weapon : MonoBehaviour
{ 
    [Header ("Stats")]
    [SerializeField] private int CurrentMagBullets;
    [SerializeField] private int TotalBullets;
    [SerializeField] private int WasteOfAmmoPerShot;
    [SerializeField] private float BulletSpreadLeft;
    [SerializeField] private float BulletSpreadRight;
    [SerializeField] private float TimeForReload;
    [SerializeField] private float RateOfFire;
    [SerializeField] private float _shootForse = 20f;
    [SerializeField] private float VolumeForShoot;


    [Header("Objects")]
    [SerializeField] private TextMeshProUGUI CounterBulletInMagazin;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform SpawnBullet;
    [SerializeField] private Transform Gun;
    [SerializeField] private ShootingJoystick Shooting;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip ClipForShoot;

    private int MagCapacity;
    private float _reloadTimeLeft;
    private bool CantShoot = false;
    private bool CanReload = true;
    private bool OnReloading = false;
    
    public event Action <float> TimeReload;


    private void Start()
    {       
        MagCapacity = CurrentMagBullets;
    }



    private void Update()
    {
        CounterBulletInMagazin.text = CurrentMagBullets + "/" + TotalBullets;        
        TimeForReloading(Time.deltaTime);
        FunctionBoolAutoReload();

        if (Input.GetKeyDown(KeyCode.R))
            ButtonReload();
    }


    private void OnEnable()
    {
        StartCoroutine(routine: CoroutineShoot());
        OnReloading = false;
    }



    private void OnDisable()
    {
        StopAllCoroutines();       
        TimeReload?.Invoke(0f);
        _reloadTimeLeft = 0f;
        CantShoot = false;
        CanReload = true;
    }



    public void Shoot()
    {      
        SpawnBullet.localRotation = Quaternion.Euler(Gun.localRotation.x, Gun.localRotation.y + 
            UnityEngine.Random.Range(BulletSpreadLeft,BulletSpreadRight), Gun.localRotation.z);
       
        GameObject Bullet = Instantiate(BulletPrefab,SpawnBullet.position,SpawnBullet.rotation);
        Bullet.GetComponent<Rigidbody>().AddForce(SpawnBullet.forward * _shootForse,ForceMode.Impulse);
        Destroy(Bullet, 2f);
    }



    private IEnumerator CoroutineShoot()
    {
        while (true)
        {
            if (!CantShoot)
            {
                if ((Mathf.Abs(Shooting.joystick.Horizontal) >= 0.7f && CurrentMagBullets > 0)
                    || (Mathf.Abs(Shooting.joystick.Vertical)) >= 0.7f && CurrentMagBullets > 0)
                {
                    Shoot();
                    AudioSource.pitch = UnityEngine.Random.Range(0.95f,1.15f);
                    AudioSource.PlayOneShot(ClipForShoot,VolumeForShoot);
                    CurrentMagBullets -= WasteOfAmmoPerShot;
                }
            }           
            yield return new WaitForSeconds(RateOfFire);
        }
    }



    public void Reloading()
    {
        var amount = Mathf.Min(MagCapacity - CurrentMagBullets, TotalBullets);
        TotalBullets -= amount;
        CurrentMagBullets += amount;
    }



    public void ButtonReload()
    {
        if (CanReload && CurrentMagBullets < MagCapacity && TotalBullets > 0 && !OnReloading)
        {          
            _reloadTimeLeft = TimeForReload;
            AudioSource.Play();
        }  
    }



    public void AutoReload()
    {      
        if (CurrentMagBullets == 0 && TotalBullets > 0)
        {
            _reloadTimeLeft = TimeForReload;
            CanReload = false;
            AudioSource.Play();          
        }
    }



    private void FunctionBoolAutoReload()
    {
        if (CanReload)
        {
            AutoReload();
        }

        if (CurrentMagBullets > 0)
        {
            CanReload = true;
        }
    }



    private void TimeForReloading(float dt)
    {
        if (_reloadTimeLeft > 0f)
        {
            OnReloading = true;
            CantShoot = true;
            _reloadTimeLeft -= dt;
            
            float _CurrentTimeReloadAsPercantage = (TimeForReload - _reloadTimeLeft) / TimeForReload;
            TimeReload?.Invoke(_CurrentTimeReloadAsPercantage);             
        }
       
        if (_reloadTimeLeft < 0f)
        {
            Reloading();
            _reloadTimeLeft = 0f;
            CantShoot = false;
            OnReloading = false;
            TimeReload?.Invoke(0f);
            AudioSource.Stop();
        }               
    }
   
}

