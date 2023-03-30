using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            Destroy(other.gameObject);
        }

        if (other.CompareTag("bulletEnemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
