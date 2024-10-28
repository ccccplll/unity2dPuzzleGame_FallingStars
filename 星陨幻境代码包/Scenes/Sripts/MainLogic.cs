using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MainLogic : MonoBehaviour
{

    public int guanqia_num = 0;
    public int object_num = 1;//剩余可放置物块数目
    public int object_num_inside = 1;

    public StoryData data;

    public GameObject id_card;
    // Start is called before the first frame update
    public bool world_status = true; //世界状态，true为现实世界，false为里世界
    public GameObject out_world;
    public GameObject inside_world;//同一关卡两种世界的地图
    public GameObject visual_object;
    public GameObject real_object;
    public GameObject real_object_outside;

    public AudioSource inside_s;
    public AudioSource outside_s;

    public GameObject outside_number; //ui文字
    public GameObject outside_put_object;
    public GameObject inside_put_object;
    public GameObject inside_number;
    public GameObject player;
    private Vector3 createPosition;
    void Start()
    {
        Application.targetFrameRate = 60;
        bool pickable = data.idcards_status[guanqia_num];
        id_card.SetActive(!pickable);
        this.world_status = true;//c初始世界状态 
    }

    // Update is called once per frame
    void Update()
    {
        out_world.SetActive(world_status);
        inside_world.SetActive(!world_status);
        outside_put_object.SetActive(world_status);
        inside_put_object.SetActive(!world_status);
        outside_number.GetComponent<TextMeshProUGUI>().text = object_num.ToString();
        inside_number.GetComponent<TextMeshProUGUI>().text = object_num_inside.ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            this.restart();
        }
        if (Input.GetKeyDown(KeyCode.F) && this.world_status && this.object_num > 0)
        {
            this.putObject(visual_object,real_object);
            object_num--;
            outside_s.Play();
        }
        else if(Input.GetKeyDown(KeyCode.F) && (!this.world_status) && this.object_num_inside > 0)
        {
            this.putObject(real_object_outside, visual_object);
            object_num_inside--;
            inside_s.Play();
        }
    }

    public void restart()
    {

        //场景重置
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void putObject(GameObject A,GameObject B)
    {
        createPosition = player.transform.position;
        GameObject visual_object = Instantiate(A, createPosition, Quaternion.identity,out_world.transform);
        GameObject real_object = Instantiate(B , createPosition, Quaternion.identity, inside_world.transform);
    }
}
