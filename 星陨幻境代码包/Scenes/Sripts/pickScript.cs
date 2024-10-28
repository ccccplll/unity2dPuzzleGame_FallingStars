using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickScript : MonoBehaviour
{
    public GameObject idCard;
    public StoryData data;
    public int guanqia_num;
    public AudioSource pick_s;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.pick();
        };
    }

    void pick()
    {
        idCard.SetActive(false);
        pick_s.Play();
        data.setBool(this.guanqia_num,true);
    }
}
