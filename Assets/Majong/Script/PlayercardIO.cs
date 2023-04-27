﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class PlayercardIO : MonoBehaviour
{
    private List<string[]> rowData = new List<string[]>();
    private int Count = 0;
    private string filename ;
    // Use this for initialization

    public void Save( Player player)
    {
        filename =  player.name.ToString();
        string[] rowDataTemp = new string[9];
        if (Count == 0)
        {
            
            rowDataTemp[0] = "player";
            rowDataTemp[1] = "Type";
            rowDataTemp[2] = "Number";
            rowData.Add(rowDataTemp);
            Count++;
        }
        // You can add up the values in as many cells as you want.

        rowDataTemp = new string[9];
         rowDataTemp[0] =player.name; // name
       rowDataTemp[1] =player.handcard[player.handcard_index].Type; // ID
        rowDataTemp[2] = player.handcard[player.handcard_index ].Number.ToString();
        rowData.Add(rowDataTemp);


        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));


        string filePath = getPath();

        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
       outStream.Close();
    }

    // Following method is used to retrive the relative path as device platform
    private string getPath()
    {
#if UNITY_EDITOR
        return Application.dataPath + "/CSV/" +filename+".csv";
#elif UNITY_ANDROID
        return Application.persistentDataPath+"Saved_data.csv";
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"Saved_data.csv";
#else
        return Application.dataPath +"/"+"Saved_data.csv";
#endif
    }
}
