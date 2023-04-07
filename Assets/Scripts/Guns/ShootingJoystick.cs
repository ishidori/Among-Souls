using UnityEngine;

public class ShootingJoystick : MonoBehaviour,IrotationPlayer
{      
    [SerializeField] public Joystick joystickShooting;
    private PlayerMovement playermovement;
    [HideInInspector] public bool OnRotateInShooting = true;

   
    private void Start()
    {
        playermovement = FindObjectOfType<PlayerMovement>();
    }


    private void LateUpdate()
    {
        RotatingPlayer(OnRotateInShooting);
        BoolRotate();
    }


    public void RotatingPlayer(bool OnRotate)
    {              
        if (OnRotate)
        {
            playermovement._rotateSpeed = 50f;
            playermovement.RotatePlayer(new Vector3(joystickShooting.Horizontal, 0, joystickShooting.Vertical));            
        }             
    }
    

    private void BoolRotate()
    {
        if(Mathf.Abs(joystickShooting.Horizontal * Time.deltaTime) > 0f || Mathf.Abs(joystickShooting.Vertical * Time.deltaTime) > 0f)        
            OnRotateInShooting = true;
        else
            OnRotateInShooting = false;
    }
}
