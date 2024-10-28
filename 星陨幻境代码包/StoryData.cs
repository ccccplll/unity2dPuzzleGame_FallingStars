using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

[CreateAssetMenu(fileName = "StoryData", menuName = "ScriptableObject/ͼ������", order = 0)] 
public class StoryData : ScriptableObject
{

    public string[] stories;
    public int[] idcards;
    public bool[] idcards_status;

    public void setBool(int guanqia_num,bool value)
    {
        idcards_status[guanqia_num] = value;
    }

}


