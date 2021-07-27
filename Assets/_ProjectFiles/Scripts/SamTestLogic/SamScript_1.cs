using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SamScript_1 : MonoBehaviour
{
   // public List<GameObject> allSamButtons;
    public List<GameObject> firstRow;
    public List<GameObject> secondRow;
    public List<GameObject> thirdRow;
    public List<GameObject> allButtons;
    public static int v;
    public static int a;
    public static int d;


    private void OnDisable()
    {
        ClearButton(allButtons);
    }

    void addEvent()
    {
        
        for(int i=0;i<firstRow.Count;i++)
        {
            firstRow[i].GetComponent<Button>().onClick.AddListener(FirstRow);
            secondRow[i].GetComponent<Button>().onClick.AddListener(SecondRow);
            thirdRow[i].GetComponent<Button>().onClick.AddListener(ThirdRow);
        }
        
    }

    void FirstRow()
    {
       ColorButton(firstRow);
        v = Vad();
        Debug.Log(v);

    }

    void SecondRow()
    {
        ColorButton(secondRow);
         a = Vad()-9;
        Debug.Log(a);
    }

    void ThirdRow()
    {
        ColorButton(thirdRow);
        d = Vad() - 18;
        Debug.Log(d);
    }

    void ColorButton(List<GameObject> m)
    {
        for(int i=0;i<m.Count;i++)
        {
            m[i].GetComponent<Image>().color=Color.white;
        }
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().color = Color.green;
    }

    public static void ClearButton(List<GameObject> n)
    {
        for (int i = 0; i < n.Count; i++)
        {
            n[i].GetComponent<Image>().color=Color.white;
            
        }
    }

    int Vad()
    {
        //string a = "Sam14";
        string name=EventSystem.current.currentSelectedGameObject.name;
        char[] charstoTrim = {'S', 'a', 'm'};
        string res = name.Trim(charstoTrim);
        int b = 0;
        b=int.Parse(res);
        return b;

    }
    

    // Start is called before the first frame update
    void Start()
    {
        addEvent();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
