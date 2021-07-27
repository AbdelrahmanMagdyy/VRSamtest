using System;
using System.Globalization;
using TMPro;
using UnityEngine;

namespace _ProjectFiles.Scripts.SamTestLogic {
    public class WaitingTimerManager : MonoBehaviour {

        [SerializeField] public GameObject waitingTimerPanel;
        
        public bool isAutomaticTimer;
        public bool isGUIEnable;
        public float timerSpeed = 1;
        public float timerTolerance;
        public float timerStart ;
        public float currentTime;
        
        private TextMeshProUGUI _timerTextBox;
        
        
        // Start is called before the first frame update
        private void Start() 
        {
            
            if (waitingTimerPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>() != null & isGUIEnable==true) 
            {
                _timerTextBox = waitingTimerPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            }
            
            SetUpTimer(timerStart);
            //ActivateWaitingTimerPanel(false);
        }

        // Update is called once per frame
        private void Update() 
        {
            CountDownTime(timerSpeed, timerTolerance, isAutomaticTimer);
        }


        private void SetUpTimer(float optionalTimerStart = 60)
        {
            currentTime = optionalTimerStart;
            timerStart = optionalTimerStart;
            if (isGUIEnable==true)
            {
                _timerTextBox.color = Color.green;
                _timerTextBox.text = "Waiting task"+ "\n"+ "Please wait for"+ " "+optionalTimerStart.ToString(CultureInfo.InvariantCulture)+" "+ "seconds";
            }
        }

        public void CountDownTime(float optionalTimerSpeed = 1, float optionalTimerTolerance = 0, bool optionalIsAutomaticTimer = true) 
        {
            if (!(currentTime >= optionalTimerTolerance)) return;
            if (!(optionalIsAutomaticTimer || Input.GetKey(KeyCode.Space))) return;
            
            
            currentTime-= (Time.deltaTime * optionalTimerSpeed);
            currentTime = Mathf.Clamp(currentTime, optionalTimerTolerance, currentTime);
            if (isGUIEnable == true)
            {
                _timerTextBox.color = Color.red;
                _timerTextBox.text = "Waiting task"+ "\n"+ "Please wait for"+ " "+ Mathf.RoundToInt(currentTime).ToString(CultureInfo.InvariantCulture)+" "+ "seconds" +" "+" and fill the sam after";
            }
        }

        private void ActivateWaitingTimerPanel(bool flag) 
        {
            if (waitingTimerPanel != null) {
                waitingTimerPanel.SetActive(flag);
            }
        }

        public void ResetTime()
        {
            currentTime = timerStart;
        }

        private void OnEnable()
        {
            isAutomaticTimer = true;
        }

        
    }
}