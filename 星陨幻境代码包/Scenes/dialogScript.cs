using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dialogScript : MonoBehaviour
{
    internal int guanqia_num;

    public string guanqia_name { get; internal set; }
    public string story { get; internal set; }
    public GameObject t_name;
    public GameObject introduction;
    public GameObject playOn;
    // Start is called before the first frame update
    void Start()
    {
        if(guanqia_num == 3||guanqia_num==5||guanqia_num==7)
        {
            playOn.SetActive(false);
        }
        else
        {
            playOn.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        t_name.GetComponent<TextMeshProUGUI>().text = guanqia_name;
        introduction.GetComponent<TextMeshProUGUI>().text = story;
    }

    public void exit()
    {
        this.gameObject.SetActive(false);
    }
    public void changeScene()
    {
        SceneManager.LoadScene(guanqia_num+1);
    }
}
