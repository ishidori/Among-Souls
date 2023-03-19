using UnityEngine;

public class PlayerJumpHandler : MonoBehaviour
{
    [SerializeField] private int JumpForce = 5;
    [SerializeField] private Transform Check_Ground;
    [SerializeField] private LayerMask Ground;
    private Rigidbody _rb;
    private bool OnGround;
    private float checkRadius = 0.1f;
    


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        ChekingGround();
    }

    private void ChekingGround()
    {
        OnGround = Physics.CheckSphere(Check_Ground.position, checkRadius, Ground);
    }



    public void Jump()
    {
        if (OnGround)
            _rb.AddForce(Vector3.up * JumpForce,ForceMode.Impulse);
    }
}
