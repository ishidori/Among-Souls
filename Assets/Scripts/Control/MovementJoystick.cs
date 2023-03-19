using UnityEngine;

public class MovementJoystick : MonoBehaviour, IrotationPlayer
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private ShootingJoystick shootingJoystick;
    private PlayerMovement playermovement;
    [HideInInspector] public bool OnRotateInMovement = false;



    private void Start()
    {
        playermovement = FindObjectOfType<PlayerMovement>();
    }



    private void LateUpdate()
    {
        playermovement.MovePlayer(new Vector3(joystick.Horizontal, 0, joystick.Vertical));
        RotatingPlayer(shootingJoystick.OnRotateInShooting);
    }



    public void RotatingPlayer(bool OnRotate)
    {
        if (!OnRotate)
        {
            playermovement._rotateSpeed = 7f;
            playermovement.RotatePlayer(new Vector3(joystick.Horizontal, 0, joystick.Vertical));
        }
    }
}
