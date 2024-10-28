using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "guanqiaData", menuName = "ScriptableObject/�ؿ�����", order = 1)]
public class guanqiaData : ScriptableObject
{
    public bool[] image_status;//�Ƿ�ͨ��
    public bool[] guanqia_status;//�Ƿ����

    public void setGuanqiaBool(int guanqia_num, bool value)
    {
        guanqia_status[guanqia_num] = value;
    }

    public void setStatus(int guanqia_num, bool value)
    {
        image_status[guanqia_num] = value;
    }


}
