using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


#pragma warning disable 649
namespace _ProjectFiles.Scripts.SamTestLogic {
    public class SamTestGridManager : MonoBehaviour {

        [SerializeField] private GameObject samTestPanel;
        [SerializeField] private GameObject samTestButton;
        public static int v = 0;
        public static int a = 0;
        public static int d = 0;
        [HideInInspector] public List<Sprite> samTestSprites;
         
        // Start is called before the first frame update
        private void Start()
        {
            LoadSamTestSprites();
            SetupSamTestGrid();
            ActivateSamTestPanel(false);
        }

        // Update is called once per frame
        private void Update()
        {
            //TODO:CodeLogic
        }

             
        private void LoadSamTestSprites() 
        {
            var samTestSpritesObjects = Resources.LoadAll("SamTestSprites", typeof(Sprite));
            if (samTestSpritesObjects.Length == 0) return;
            foreach (var spriteObject in samTestSpritesObjects) {
                ((IList) samTestSprites).Add(spriteObject);
            }
        }
        
        private void SetupSamTestGrid() 
        {
            if (samTestPanel == null) return;
            if (samTestSprites.Count == 0) return;
            
            for (int i = 1; i <= samTestSprites.Count; i++) {
                var childObject = Instantiate(samTestButton, samTestPanel.transform, false);
                childObject.name = "Sam_" + i;
                
                
                var anchoredPosition3D = childObject.GetComponent<RectTransform>().anchoredPosition3D;
                anchoredPosition3D.z = -0.1f;
                childObject.GetComponent<RectTransform>().anchoredPosition3D = anchoredPosition3D;
                
                childObject.GetComponent<Image>().sprite = samTestSprites[i-1];
                childObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);
             //   childObject.transform.GetChild(0).GetComponent<Text>().text = "Button " + i;
            }
        }
        void TaskOnClick()
        {
            //Output this to console when Button1 or Button3 is clicked
            string name=EventSystem.current.currentSelectedGameObject.name;
            if (name == "Sam_1")
                v = 1;
            if (name == "Sam_2")
                v = 2;
            if (name == "Sam_3")
                v = 3;
            if (name == "Sam_4")
                v = 4;
            if (name == "Sam_5")
                v = 5;
            if (name == "Sam_6")
                v = 6;
            if (name == "Sam_7")
                v = 7;
            if (name == "Sam_8")
                v = 8;
            if (name == "Sam_9")
                v = 9;
            if (name == "Sam_10") 
                a = 1;
            if (name == "Sam_11")
                a = 2;
            if (name == "Sam_12")
                a = 3;
            if (name == "Sam_13")
                a = 4;
            if (name == "Sam_14")
                a = 5;
            if (name == "Sam_15")
                a = 6;
            if (name == "Sam_16")
                a = 7;
            if (name == "Sam_17")
                a = 8;
            if (name == "Sam_18")
                a = 9;
            if (name == "Sam_19") 
                d = 1;
            if (name == "Sam_20")
                d = 2;
            if (name == "Sam_21")
                d = 3;
            if (name == "Sam_22")
                d = 4;
            if (name == "Sam_23")
                d = 5;
            if (name == "Sam_24")
                d = 6;
            if (name == "Sam_25")
                d = 7;
            if (name == "Sam_26")
                d = 8;
            if (name == "Sam_27")
                d = 9;
            
        }
        
        

        private void ActivateSamTestPanel(bool flag) 
        {
            if (samTestPanel != null) {
                samTestPanel.SetActive(flag);
            }
        }
    }
}
