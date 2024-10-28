using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idCardScript : MonoBehaviour
{
    public GameObject idCardDialog;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            idCardDialog.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            idCardDialog.SetActive(false);
        }
    }
}
