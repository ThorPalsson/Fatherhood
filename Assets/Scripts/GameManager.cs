using System;
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
}

[Serializable]
public class CribEntry 
{
    public int Id; 
    public BabyEnum.Babies Baby; 
}
