using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using _ProjectFiles.Scripts.SamTestLogic;

public class PreSamLog : MonoBehaviour
{
    void LogEnd() {
        //Path of the file
        string path = Application.dataPath + "/UserLog.csv";
        //Create File if it doesn't exist
        if (!File.Exists(path)) {
            File.WriteAllText(path, "UserID,PreV,PreA,PreD,Emotion,PostV,PostA,PostD,Task,Start,End,Ntrials,V1,A1,D1,V2,A2,D2,V3,A3,D3");
        }
        //Content of the file
        string v = SamScript_1.v.ToString();
        string a = SamScript_1.a.ToString();
        string d = SamScript_1.d.ToString();
        string content = v+","+a+","+d+",";
        //Add some to text to it
        File.AppendAllText(path, content);
    }
    void LogStart() {
        //Path of the file
        string path = Application.dataPath + "/UserLog.csv";
        //Create File if it doesn't exist
        if (!File.Exists(path)) {
            File.WriteAllText(path, "UserID,PreV,PreA,PreD,Emotion,PostV,PostA,PostD,Task,Start,End,Ntrials,V1,A1,D1,V2,A2,D2,V3,A3,D3");
        }
        //Content of the file
        string content = "\n"+" 24," ;
        //Add some to text to it
        File.AppendAllText(path, content);
    }

    public void OnDisable()
    {
        LogEnd();
    }
    
    public void OnEnable()
    {
        LogStart();
    }
}
