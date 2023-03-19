using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    #region Singleton 
    
    public static TrackPlayer instance;
   
    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
}
