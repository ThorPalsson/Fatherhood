using System.Security.Cryptography;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject visualIndicator; 
    public bool IsHeld = false; 
    public bool IsBaby; 

    private Rigidbody rb; 
    private Collider col; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; 
        col = GetComponent<Collider>();
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
            visualIndicator.SetActive(false); 
        }
    }

    public void PickThisUp(Transform thing)
    {
        rb.isKinematic = true; 
        col.enabled = false; 
        this.transform.position = thing.position; 
        this.transform.parent = thing; 
        visualIndicator.SetActive(false);
        IsHeld = true; 
    }


    public void Throw(float power)
    {
        rb.isKinematic = false; 
        col.enabled = true; 
        this.transform.parent = null; 
        IsHeld = false; 
        rb.AddForce(transform.forward * power);
    }
}
