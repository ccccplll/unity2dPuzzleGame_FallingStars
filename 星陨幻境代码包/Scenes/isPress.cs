using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class isPress : MonoBehaviour
{
    public GameObject particle;
    private bool isPressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.mousePosition);
        Vector2 vector2 = Camera.main.WorldToScreenPoint(particle.transform.position)- Input.mousePosition;
        if (vector2.magnitude<=20)
        {
            particle.SetActive(true);
        }
        else
        {
            particle.SetActive(false);
        }



    }
    
    
        
    
}
