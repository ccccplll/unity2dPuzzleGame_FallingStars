using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingScript : MonoBehaviour
{
    public int next_guanqia1;
    public int next_guanqia2;
    public int next_guanqia3;
    public guanqiaData guanqia;
    // Start is called before the first frame update
    void Start()
    {
        guanqia.setStatus(next_guanqia1, true);
        guanqia.setStatus(next_guanqia2, true);
        guanqia.setStatus(next_guanqia3, true);
    }

}
