using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] private float die = 1; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(this.gameObject, die); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
