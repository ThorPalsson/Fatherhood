using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool isActive; 
    public GameObject EnemyPrefab; 
    public Transform[] spawnLocations; 

    [SerializeField] private float timebetweenSpawns = .2f; 
    [SerializeField] private float spawningTimer = 120;

    private float timer;
    private float timetime; 

    private void Update()
    {
        if (!isActive) return; 

        timer += Time.deltaTime; 
        timetime += Time.deltaTime; 

        if (timer > timebetweenSpawns)
        {
            var tang = spawnLocations[Random.Range(0, spawnLocations.Length)]; 

            Instantiate(EnemyPrefab, tang.transform.position, Quaternion.identity); 
            timer = 0; 
        }

        if (timetime > spawningTimer)
        {
            isActive = false; 
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        	isActive = true;
            this.transform.GetComponent<Collider>().enabled = false; 
    }
}
