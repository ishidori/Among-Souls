using UnityEngine;
using System.Collections;
public class Message : MonoBehaviour
{

    [SerializeField] private Canvas message;
    
    private void Start()
    {
        message.enabled = true;
        StartCoroutine(routine: Time());
    }

    private IEnumerator Time()
    {
        while (true) 
        {           
            yield return new WaitForSeconds(3);
            message.enabled = false;
        }
    }

}
