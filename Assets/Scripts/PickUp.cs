using System.Security.Cryptography;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject visualIndicator; 
    public bool IsHeld = false; 
    public bool IsBaby; 

    public BabyEnum.Babies thisBaby; 

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

    public void OnCollisionEnter(Collision collision)
    {
        if (rb.linearVelocity.magnitude > 2)
        {
            var col = collision.collider; 
            print ($"i crashed into {col.name}");
            if (col.CompareTag("Enemy"))
            {
                col.GetComponent<Enemy>().Stun(); 
            }
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


    public void Throw(float power, Vector3 dir)
    {
        rb.isKinematic = false; 
        col.enabled = true; 
        trigger.enabled = true;
        this.transform.parent = GameManager.Instance.RoomParent.transform; 
        IsHeld = false; 
        rb.AddForce(dir * power);
    }

    public void PlaceInCrib()
    {
        col.enabled = false; 
        trigger.enabled = false; 
        visualIndicator.SetActive(false); 
        rb.isKinematic = true; 
    }
}
