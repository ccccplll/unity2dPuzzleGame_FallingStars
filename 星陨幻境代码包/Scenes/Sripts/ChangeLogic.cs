using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLogic : MonoBehaviour
{
    public GameObject maincode;
    public AudioSource change;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            this.changeWorld();
        };
        
    }

    void changeWorld()
    {
        //����״̬�û�
        MainLogic M =  maincode.GetComponent<MainLogic>();
        M.world_status = !M.world_status;
        //�л�������Ч/////
        change.Play();
  
    }
}
