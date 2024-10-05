using UnityEngine;

public class Crib : MonoBehaviour
{

    [SerializeField] private Transform childPos;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Hold.Instance.cribInRange = this; 
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Hold.Instance.cribInRange == this)
                Hold.Instance.cribInRange = null; 
        }
    }


    public void PlaceBaby(PickUp baby)
    {
        print ("placing baby");
        
        baby.transform.parent = null; 
        baby.transform.position = childPos.position; 



        baby.PlaceInCrib();
        baby.enabled = false; 
        this.enabled = false; 
    }
}
