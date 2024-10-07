using System;
using System.Collections;
using System.Collections.Generic;
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
    public GameObject JohnCribPrefab; 
    public GameObject BarhalamewPrefab; 

    public GameObject RoomParent;
    public CribEntry[] cribs; 
    public ScreenShake CurrentShake; 

    public GameObject DialogueParent; 
    public TMP_Text dialogueText;

    public List<int> NarrativeIds = new List<int>();  

    [SerializeField] private AudioSource source; 
    [SerializeField] private AudioSource speakSource;

    [SerializeField] private AudioClip[] defaultClip; 


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

    public void ChangeSong(AudioClip clip)
    {
        source.clip = clip; 
        source.Play();
    }

    public void DefaultSong()
    {
        source.clip = defaultClip[UnityEngine.Random.Range(0, defaultClip.Length)]; 
        source.Play();
    }

    public void StartConversation(string message, int id)
    {
        if (NarrativeIds.Contains(id))
        {
            return; 
        }

        PlayerController.Instance.canMove = false; 
        DialogueParent.SetActive(true); 

        StartCoroutine(Type(message)); 

        NarrativeIds.Add(id); 
    }

    public void EndConversation()
    {
        PlayerController.Instance.canMove = true; 
        DialogueParent.SetActive(false); 
        dialogueText.text = "";
    }


    private IEnumerator Type(string message)
    {
        speakSource.Play();
        for (int i = 0; i < message.Length; i++)
        {
            dialogueText.text += message[i]; 
            CurrentShake.StartShake(0.08f); 
            yield return new WaitForSeconds(0.1f);
        }

        //Typing is over


        speakSource.Stop();
        yield return new WaitForSeconds(1.5f); 
        EndConversation();
    }
}

[Serializable]
public class CribEntry 
{
    public int Id; 
    public BabyEnum.Babies Baby; 
}
