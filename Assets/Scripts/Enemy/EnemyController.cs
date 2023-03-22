using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Transform target;
    private NavMeshAgent agent;
    private HealthPlayer healthPlayer;
    private float distance;
    [SerializeField] private float Damage;
    [SerializeField] private bool CanDamageWithTheHelpOfHands;

    private void Start()
    {
        target = TrackPlayer.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();   
        healthPlayer = FindObjectOfType<HealthPlayer>();       
    }



    private void LateUpdate()
    {
        stalkingPlayer();
        agent.SetDestination(target.position);
    }


    private void stalkingPlayer()
    {
        distance = Vector3.Distance(target.position, transform.position);    
              

        if (distance <= agent.stoppingDistance)
        {
            FaceTarget();
            healthPlayer.Die();

            if (CanDamageWithTheHelpOfHands && Time.timeScale == 1f)
            healthPlayer.Hp -= Damage;
        }       
    }



    private void FaceTarget()
    {
        Vector3 direction  = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime * 5f);
    }

}
