using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Player Stats")]
    [SerializeField] private float _speed = 5f;
    public float _rotateSpeed = 10f; 
    private FollowPlayerLight _light;

    private void Start() => _light = FindObjectOfType<FollowPlayerLight>();

    public void MovePlayer (Vector3 moveDirection)
    {
        var offset = moveDirection * _speed * Time.deltaTime;
        transform.position += offset;
        _light.FollowPlayer();
    }


    public void RotatePlayer(Vector3 moveDirection)
    {    
        if (Vector3.Angle(transform.forward, moveDirection) > 0)
        {
            var newDirection = Vector3.RotateTowards(transform.forward, moveDirection, _rotateSpeed * Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
