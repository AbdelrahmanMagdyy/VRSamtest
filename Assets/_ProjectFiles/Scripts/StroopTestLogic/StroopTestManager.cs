using System;
using System.Collections.Generic;
using System.Linq;
using _ProjectFiles.Scripts.SamTestLogic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;


namespace _ProjectFiles.Scripts.StroopTestLogic {
    public class StroopTestManager : MonoBehaviour {

        [SerializeField] private GameObject stroopTestPanel;
        [SerializeField] private GameObject stroopTestButtons;

        private Dictionary<string, Color> _stroopDictionary;
        private Dictionary<string, Color>.KeyCollection _stroopKeys;
        private Dictionary<string, Color>.ValueCollection _stroopValues;
        private int _stroopKeysLength, _stroopValuesLength;
        private int score = 0;
        public static int t = 0;

        private List<int> _randomSeedsList;
        private List<int> _keysRandomSeeds, _valuesRandomSeeds;
        private int _currentRandomSeed;


        public bool isCongruentTrial;
        public bool isNeutralTrial;
        private Color _stroopKeyValue;
        private bool _isCorrectStroop;
        private float _responseTime;
        public GameObject stroopTimer;


        // Start is called before the first frame update
        private void Start() 
        {
            SetupStroopTestBase();
            StroopButtonsTriggers();
            ActivateStroopTestPanel(true);
            stroopTimer.GetComponent<WaitingTimerManager>().timerStart = 3;
            stroopTimer.GetComponent<WaitingTimerManager>().timerSpeed = 2.5f;
            //kanet speed =1
            stroopTimer.GetComponent<WaitingTimerManager>().timerTolerance = 0;
            stroopTimer.GetComponent<WaitingTimerManager>().isAutomaticTimer = true;
        }

        // Update is called once per frame
        private void Update()
        {
            if (score == 10)
            {
              GameObject.Find("StroopTASK").SetActive(false);
            }
                AutoStroop();
                if (Input.GetKeyDown(KeyCode.X)) {
                
                    GenerateStroopTrial();
                }

                if (Input.GetKeyDown(KeyCode.C)) {
                    GenerateStroopTrial(isCongruentTrial);
                }
               
            
        }


        private static void ShuffleList(IList<int> list) 
        {
            var count = list.Count;
            var length = count - 1;

            for (int i = 0; i < length; ++i) {
                int random = Random.Range(i, count);
                int temp = list[i];
                list[i] = list[random];
                list[random] = temp;
            }
        }

        private string GetKeyByValue(Color color) 
        {
            return _stroopDictionary.FirstOrDefault(x => x.Value == color).Key;
        }

        private Color GetValueByKey(string str) 
        {
            return _stroopDictionary.FirstOrDefault(x => x.Key == str).Value;
        }

        private void SetupStroopTestBase() 
        {
            _stroopDictionary = new Dictionary<string, Color>() {
                {"Blue", Color.blue}, {"Green", Color.green}, {"Red", Color.red}, {"Yellow", Color.yellow},
                {"Pink", Color.magenta},
                {"Black", Color.black}, {"Orange", new Color(1f, 0.55f, 0.03f)},
                {"Purple", new Color(0.39f, 0.15f, 0.71f)},
                {"Brown", new Color(0.55f, 0.27f, 0.07f)}, {"Gray", Color.gray}
            };

            _stroopKeys = _stroopDictionary.Keys;
            _stroopValues = _stroopDictionary.Values;

            _stroopKeysLength = _stroopKeys.Count - 1;
            _stroopValuesLength = _stroopValues.Count - 1;

            _randomSeedsList = new List<int>();
            for (int i = 0; i < _stroopDictionary.Count; i++) {
                _randomSeedsList.Add(i);
            }

            ShuffleList(_randomSeedsList);
            ShuffleList(_randomSeedsList);

            _valuesRandomSeeds = new List<int>(_randomSeedsList);
            _randomSeedsList.Reverse();
            _keysRandomSeeds = new List<int>(_randomSeedsList);
        }


        private void GenerateStroopTrial(bool optionalIsCongruent = false, bool optionalIsNeutral = false) 
        {

            isCongruentTrial = optionalIsCongruent;
            isNeutralTrial = optionalIsNeutral;
            if (isNeutralTrial) {
                //TODO::Logic
            }
            else if (isNeutralTrial == false) {
            if (_currentRandomSeed + 1 >= _keysRandomSeeds.Count) {
                    _currentRandomSeed = 0;
                }
                else {
                    _currentRandomSeed += 1;
                }

                if (isCongruentTrial) {
                    stroopTestPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                        _stroopKeys.ElementAt(_valuesRandomSeeds[_currentRandomSeed]);
                    stroopTestPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color =
                        _stroopValues.ElementAt(_valuesRandomSeeds[_currentRandomSeed]);

                }
                else {
                    stroopTestPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                        _stroopKeys.ElementAt(_keysRandomSeeds[_currentRandomSeed]);
                    stroopTestPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color =
                        _stroopValues.ElementAt(_valuesRandomSeeds[_currentRandomSeed]);
                }

                _stroopKeyValue = _stroopValues.ElementAt(_valuesRandomSeeds[_currentRandomSeed]);
                
                SetupStroopButtons();
                

            }
        }
        private void SetupStroopButtons()
        {
        
            System.Random randomButton = new System.Random();
            int randomBtn = randomButton.Next(2);

            stroopTestButtons.transform.GetChild(randomBtn).GetComponent<Image>().color =
                _stroopValues.ElementAt(_valuesRandomSeeds[_currentRandomSeed]);
            stroopTestButtons.transform.GetChild(randomBtn).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                GetKeyByValue(_stroopValues.ElementAt(_valuesRandomSeeds[_currentRandomSeed]));

            randomBtn = randomBtn == 0 ? 1 : 0;

            stroopTestButtons.transform.GetChild(randomBtn).GetComponent<Image>().color =
                GetValueByKey(_stroopKeys.ElementAt(_keysRandomSeeds[_currentRandomSeed]));
            stroopTestButtons.transform.GetChild(randomBtn).transform.GetChild(0).GetComponent<TextMeshProUGUI>()
                .text = _stroopKeys.ElementAt(_keysRandomSeeds[_currentRandomSeed]);
            t++;
        }
        
        private void ValidateStroop() 
        {
            _isCorrectStroop = EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color
                .Equals(_stroopKeyValue);

            if (_isCorrectStroop == false) {
                //stroopTestPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Wrong!";
                 //stroopTestPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;
                //Debug.Log("Wrong");
            }
            else {
                //stroopTestPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Correct!" ;
                //stroopTestPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.green;
                //Debug.Log("Correct");
                score++;
            }
            stroopTimer.GetComponent<WaitingTimerManager>().ResetTime();
                 AutoStroop();
        }

        private void StroopButtonsTriggers() 
        {
            if (stroopTestButtons.transform.GetChild(0).GetComponent<Button>() == null ||
                stroopTestButtons.transform.GetChild(1).GetComponent<Button>() == null) return;
            
            stroopTestButtons.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(ValidateStroop);
            stroopTestButtons.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(ValidateStroop);
            stroopTestButtons.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(ResponseTime);
            stroopTestButtons.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(ResponseTime);
        }

        private void ResponseTime()
        {
             _responseTime = (stroopTimer.GetComponent<WaitingTimerManager>().timerStart) -
                            (stroopTimer.GetComponent<WaitingTimerManager>().currentTime);
             string r= _responseTime.ToString();
            // stroopTestPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = r;
        }

        private void ActivateStroopTestPanel(bool flag) 
        {
            if (stroopTestPanel != null) {
                stroopTestPanel.SetActive(flag);
            }
        }

        public void AutoStroop()
        {
       
            stroopTimer.GetComponent<WaitingTimerManager>().CountDownTime();
            
            if (Math.Abs(stroopTimer.GetComponent<WaitingTimerManager>().currentTime - stroopTimer.GetComponent<WaitingTimerManager>().timerTolerance) > 0) return;
            
            GenerateStroopTrial();
            stroopTimer.GetComponent<WaitingTimerManager>().ResetTime();



        }
    }
}
