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
