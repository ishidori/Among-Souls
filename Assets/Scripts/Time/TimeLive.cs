using UnityEngine;
using TMPro;
using System.Collections;

public class TimeLive : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI Time_Text;
    [SerializeField] private int delta = 0;
    [SerializeField] private float speedTime = 1f;
    
    private int sec = 0;
    public int _sec { get => sec; }
    
    private int min = 0;
    public int _min { get => min; }
    

    private void Start()
    {
        StartCoroutine(StopWatch());
    }



    public IEnumerator StopWatch()
    {
        while (true)
        {
            if(sec == 59)
            {
                min++;
                sec = -1;
            }
            sec += delta;
            Time_Text.text = min.ToString("D2") + " : " + sec.ToString("D2");
            yield return new WaitForSeconds(speedTime);
        }
    }
    
}
