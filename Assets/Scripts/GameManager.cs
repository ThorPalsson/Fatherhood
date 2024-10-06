using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    public bool JessicaDone; 
    public bool JohnDone; 
    public bool BarthalamewDone; 

    public GameObject JessicaPrefab; 
    public GameObject JohnPrefab; 
    public GameObject BarhalamewPrefab; 

    public GameObject RoomParent;
    public CribEntry[] cribs; 
    public ScreenShake CurrentShake; 

    public GameObject DialogueParent; 
    public TMP_Text dialogueText;


    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(this);
        } else 
        {
            Instance = this; 
        }
    }


    public void StartConversation(string message)
    {
        PlayerController.Instance.canMove = false; 
        DialogueParent.SetActive(true); 

        StartCoroutine(Type(message)); 
    }


    private IEnumerator Type(string message)
    {
        for (int i = 0; i < message.Length; i++)
        {
            dialogueText.text += message[i]; 
            CurrentShake.StartShake(0.08f); 
            yield return new WaitForSeconds(0.1f);
        }

        //Typing is over
    }
}

[Serializable]
public class CribEntry 
{
    public int Id; 
    public BabyEnum.Babies Baby; 
}
