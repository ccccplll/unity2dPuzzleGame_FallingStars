using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class successScript : MonoBehaviour
{
    public StoryData data;
    public guanqiaData guanqia;
    public int guanqia_num;
    public int next_guanqia1;
    public int next_guanqia2;
    public int next_guanqia3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool pickable = !data.idcards_status[guanqia_num];
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (pickable)
            {

            }
            else
            {
                this.success();
            }
        }
    }

    public void success()
    {
        guanqia.setStatus(guanqia_num, true);
        guanqia.setGuanqiaBool(next_guanqia1, true);
        guanqia.setGuanqiaBool(next_guanqia2, true);
        guanqia.setGuanqiaBool(next_guanqia3, true);
        SceneManager.LoadScene(0);
    }
}
