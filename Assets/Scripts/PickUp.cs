using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject visualIndicator; 
    public bool IsHeld = false; 

    public void OnTriggerEnter(Collider other)
    {
        if (IsHeld) return; 
        if (other.CompareTag("Player"))
        {
            Hold.Instance.pickUpInRange = this; 
            visualIndicator.SetActive(true);  
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            visualIndicator.SetActive(false); 
        }
    }
}
