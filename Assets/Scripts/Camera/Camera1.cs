using UnityEngine;


class Camera1 : MonoBehaviour
{
    [Header("FollowPlayer")]
    [SerializeField] private GameObject _MainPlayer;

    [Header("Settings")]
    [SerializeField] private float _returnSpeed;
    [SerializeField] private float _height;
    [SerializeField] private float _rearDistance;

    private Vector3 currentVector;

    
    
    private void Start()
    {
        transform.position = new Vector3(_MainPlayer.transform.position.x, _MainPlayer.transform.position.y +
            _height, _MainPlayer.transform.position.z - _rearDistance);
       
        transform.rotation = Quaternion.LookRotation(_MainPlayer.transform.position - transform.position);
    }



    private void LateUpdate()
    {
        CameraMove();
    }



    private void CameraMove()
    {
        currentVector = new Vector3(_MainPlayer.transform.position.x, _MainPlayer.transform.position.y + 
            _height, _MainPlayer.transform.position.z - _rearDistance);
        
        transform.position = Vector3.Lerp(transform.position, currentVector, _returnSpeed * Time.deltaTime);
    }

}

