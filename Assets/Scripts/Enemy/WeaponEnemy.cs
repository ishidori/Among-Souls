using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class WeaponEnemy : MonoBehaviour
{

    [SerializeField] private float BulletSpreadLeft;
    [SerializeField] private float BulletSpreadRight;
    [SerializeField] private float RandomSpeedShotValue1;
    [SerializeField] private float RandomSpeedShotValue2;
    [SerializeField] private float Volume;

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform SpawnBullet;
    [SerializeField] private Transform Gun;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private AudioSource Sound_Shoot;
    [SerializeField] private AudioClip Clip;
   
    private HealthPlayer healthPlayer;
    private Transform target;
    private float _shootForse = 20f;
    private float distance;
    private float RateOfFire;


    private void Start()
    {
        target = TrackPlayer.instance.player.transform;
        StartCoroutine(routine: CoroutineShoot());
        healthPlayer = FindObjectOfType<HealthPlayer>();
    }

    private void Update()
    {
        if (healthPlayer.PlayerDied == false)
            distance = Vector3.Distance(target.position, transform.position);    
        else
            Destroy(gameObject);
    }

    private void Shoot()
    {
        SpawnBullet.localRotation = Quaternion.Euler(Gun.localRotation.x, Gun.localRotation.y +
            UnityEngine.Random.Range(BulletSpreadLeft, BulletSpreadRight), Gun.localRotation.z);

        GameObject Bullet = Instantiate(BulletPrefab, SpawnBullet.position, SpawnBullet.rotation);
        Bullet.GetComponent<Rigidbody>().AddForce(SpawnBullet.forward * _shootForse, ForceMode.Impulse);
        Destroy(Bullet, 2f);
    }


    private IEnumerator CoroutineShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(RateOfFire);
            if (distance <= agent.stoppingDistance)
            {
                Shoot();
                Sound_Shoot.pitch = UnityEngine.Random.Range(0.95f, 1.15f);
                Sound_Shoot.PlayOneShot(Clip, Volume);
                //Sound_Shoot.Play();
                RateOfFire = UnityEngine.Random.Range(RandomSpeedShotValue1, RandomSpeedShotValue2);
            }                       
        }
    }
}
