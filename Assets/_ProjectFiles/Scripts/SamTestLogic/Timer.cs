using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float TimeToDisable;

    public UnityEvent OnTimesUp;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("TimesUp", TimeToDisable);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TimesUp()
    {
        OnTimesUp.Invoke();
        //gameObject.SetActive(false);
    }
}
