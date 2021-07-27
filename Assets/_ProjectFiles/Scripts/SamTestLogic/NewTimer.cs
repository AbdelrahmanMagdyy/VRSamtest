using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewTimer : MonoBehaviour
{
    public float TimeToEnable;

    public UnityEvent onTimesUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        Invoke("TimesUp", TimeToEnable);
    }

    void TimesUp()
    {
        onTimesUp.Invoke();
        //gameObject.SetActive(false);
    }
}