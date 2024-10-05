using System.Security.Cryptography;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject visualIndicator; 
    public bool IsHeld = false; 
    public bool IsBaby; 

    private Rigidbody rb; 
    [SerializeField] private Collider col; 
    [SerializeField] private Collider trigger; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; 
    }    

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
            if (Hold.Instance.pickUpInRange == this)
                Hold.Instance.pickUpInRange = null; 
            
            visualIndicator.SetActive(false); 
        }
    }

    public void PickThisUp(Transform thing)
    {
        rb.isKinematic = true; 
        col.enabled = false; 
        trigger.enabled = false;
        this.transform.position = thing.position; 
        this.transform.parent = thing; 
        visualIndicator.SetActive(false);
        IsHeld = true; 
    }


    public void Throw(float power)
    {
        rb.isKinematic = false; 
        col.enabled = true; 
        trigger.enabled = true;
        this.transform.parent = null; 
        IsHeld = false; 
        rb.AddForce(transform.forward * power);
    }

    public void PlaceInCrib()
    {
        col.enabled = false; 
        trigger.enabled = false; 
        visualIndicator.SetActive(false); 
        rb.isKinematic = true; 
    }
}
