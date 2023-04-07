using UnityEngine;

public class MovementJoystick : MonoBehaviour,IrotationPlayer
{
    [SerializeField] public Joystick joystickMovement;
    [SerializeField] private ShootingJoystick shootingJoystick;
    private PlayerMovement playermovement;
    [HideInInspector] public bool OnRotateInMovement = false;



    private void Start()
    {
        playermovement = FindObjectOfType<PlayerMovement>();
    }


    private void LateUpdate()
    {
        playermovement.MovePlayer(new Vector3(joystickMovement.Horizontal, 0, joystickMovement.Vertical));
        RotatingPlayer(shootingJoystick.OnRotateInShooting);
    }


    public void RotatingPlayer(bool OnRotate)
    {
        if (!OnRotate)
        {
            playermovement._rotateSpeed = 7f;
            playermovement.RotatePlayer(new Vector3(joystickMovement.Horizontal, 0, joystickMovement.Vertical));
        }
          
    }
}
