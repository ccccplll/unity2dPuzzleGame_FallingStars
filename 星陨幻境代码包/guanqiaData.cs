using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "guanqiaData", menuName = "ScriptableObject/关卡数据", order = 1)]
public class guanqiaData : ScriptableObject
{
    public bool[] image_status;//是否通关
    public bool[] guanqia_status;//是否解锁

    public void setGuanqiaBool(int guanqia_num, bool value)
    {
        guanqia_status[guanqia_num] = value;
    }

    public void setStatus(int guanqia_num, bool value)
    {
        image_status[guanqia_num] = value;
    }


}
