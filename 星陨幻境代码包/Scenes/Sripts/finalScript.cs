using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalScript : MonoBehaviour
{
    public GameObject finalDialog;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            finalDialog.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            finalDialog.SetActive(false);
        }
    }
}
