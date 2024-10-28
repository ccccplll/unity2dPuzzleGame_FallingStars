using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class nodeScript : MonoBehaviour
{
    public GameObject particle;
    public GameObject light2d;
    public guanqiaData guanqia;
    public int node_num;
    public string node_name;
    public AudioSource music;
    public bool node_status;//true 为已解锁
    public string node_introduction;
    public bool image_status;//
    public GameObject dialog;
    // Start is called before the first frame update
    void Start()
    {
        node_status = guanqia.guanqia_status[node_num];
        image_status = guanqia.image_status[node_num];
    }

    // Update is called once per frame

    public void showIntro()
    {
        Debug.Log(node_num);
        if (!image_status)
        {
            node_introduction = "? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ? ";
        }
        dialog.SetActive(true);
        dialogScript dia = dialog.GetComponent<dialogScript>();
        dia.guanqia_num = this.node_num;
        dia.guanqia_name = this.node_name;
        dia.story = this.node_introduction;
    }

    public void playMusic()
    {
        music.Play();
    }
    [System.Obsolete]
    void Update()
    {
        this.GetComponent<Button>().enabled = node_status;
        node_status = guanqia.guanqia_status[node_num];
        if (image_status)
        {
            this.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
            //这里加上关卡已经通过时粒子系统的颜色
            particle.GetComponent<ParticleSystem>().startColor = this.GetComponent<Image>().color;
            light2d.GetComponent<Light2D>().color = this.GetComponent<Image>().color;
        }
        else
        {
            if (!node_status)
            {
                this.GetComponent<Image>().color = new Color32(120, 120, 120, 255);
                //这里加上关卡未解锁时粒子系统的颜色
                particle.GetComponent<ParticleSystem>().startColor = this.GetComponent<Image>().color;
                light2d.GetComponent<Light2D>().color = this.GetComponent<Image>().color;
            }
        }

    }


}
