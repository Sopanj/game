using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;

public class chatsystem : MonoBehaviour
{
    public GameObject dialogusPanel;
    public Text dialogusText;
    public string[] dialogue;
    private int index;
    public GameObject contButtne;
    public float wordSpeed;
    public bool playerIsClose;
    public static bool IsTalking;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && playerIsClose)
        {
            IsTalking = true;
            if (dialogusPanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialogusPanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
    }

    public void zeroText()
    {
        dialogusText.text = "";
        IsTalking = false;
        index = 0;
        dialogusPanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogusText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        if (dialogue[index] == dialogusText.text)
        {
            contButtne.SetActive(true);
        }
    }

    public void nextline()
    {
        contButtne.SetActive(false);
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogusText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
}
