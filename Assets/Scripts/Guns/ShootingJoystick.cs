using System;
using UnityEngine;

public class ShootingJoystick : MonoBehaviour, IrotationPlayer
{
    public static ShootingJoystick Instance;
      
    [SerializeField] public Joystick joystick;
    [SerializeField] private MovementJoystick movementJoystick;
    private PlayerMovement playermovement;
    [HideInInspector] public bool OnRotateInShooting = true;

   
    private void Start()
    {
        playermovement = FindObjectOfType<PlayerMovement>();
        Instance = this;
    }



    private void Update()
    {    
        RotatingPlayer(OnRotateInShooting);
    }

  

    public void RotatingPlayer(bool OnRotate)
    {
        BoolRotate();
        
        if (OnRotate)
        {
            playermovement._rotateSpeed = 50f;
            playermovement.RotatePlayer(new Vector3(joystick.Horizontal, 0, joystick.Vertical) * Time.deltaTime);            
        }             
    }
    


    private void BoolRotate()
    {
        if(Mathf.Abs(joystick.Horizontal) > 0f || Mathf.Abs(joystick.Horizontal ) > 0f)            
        {
            OnRotateInShooting = true;
        }
        else
        {
            OnRotateInShooting = false;
        }
        //Debug.Log(OnRotateInShooting);
    }
}
