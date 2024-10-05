using UnityEngine;

public class Crib : MonoBehaviour
{



    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }


    public void PlaceBaby()
    {
        
    }
}
