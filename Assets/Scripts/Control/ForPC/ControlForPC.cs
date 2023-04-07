using UnityEngine;

public class ControlForPC : MonoBehaviour
{
    private PlayerMovement playermovement;
    [SerializeField] private MovementJoystick Movementjoystick;
    [SerializeField] private ShootingJoystick shootingJoystick;

    private float X;
    private float Y;


    private void Start()
    {
        playermovement = FindObjectOfType<PlayerMovement>();
       
    }


    private void LateUpdate()
    {
        Movement();
    }


    private void Movement()
    {
        if (Mathf.Abs(Movementjoystick.joystickMovement.Horizontal) == 0f || Mathf.Abs(Movementjoystick.joystickMovement.Horizontal) == 0f)
        {
            X = Input.GetAxisRaw("Horizontal");
            Y = Input.GetAxisRaw("Vertical");
            playermovement.MovePlayer(new Vector3(X, 0, Y).normalized);
            RotatingPlayer(shootingJoystick.OnRotateInShooting);
        }
    }


    public void RotatingPlayer(bool OnRotate)
    {
        if (!OnRotate)
        {
            X = Input.GetAxisRaw("Horizontal");
            Y = Input.GetAxisRaw("Vertical");

            playermovement._rotateSpeed = 7f;
            playermovement.RotatePlayer(new Vector3(X, 0, Y));
        }
       
    }
}
