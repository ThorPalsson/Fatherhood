using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool isActive; 
    public GameObject EnemyPrefab; 
    public Transform[] spawnLocations; 

    [SerializeField] private float timebetweenSpawns = .2f; 
    [SerializeField] private float spawningTimer = 120;

    private float timer;

    private void Update()
    {
        if (!isActive) return; 

        timer += Time.deltaTime; 

        if (timer > timebetweenSpawns)
        {
            var tang = spawnLocations[Random.Range(0, spawnLocations.Length)]; 

            Instantiate(EnemyPrefab, tang.transform.position, Quaternion.identity); 
            timer = 0; 
        }
    }
}
