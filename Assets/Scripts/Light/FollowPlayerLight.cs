using UnityEngine;

public class FollowPlayerLight : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    public void FollowPlayer()
    {
        Vector3 relativePos = Player.transform.position - transform.position;
        Quaternion FollowPlayer = Quaternion.LookRotation(relativePos);
        transform.rotation = Quaternion.Slerp(transform.rotation,FollowPlayer,Time.deltaTime * 3);
    }     
}
