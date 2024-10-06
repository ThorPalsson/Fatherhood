using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerController pc; 
    private Rigidbody rb; 

    [SerializeField] private float moveSpeed = 4; 
    [SerializeField] private float turnSpeed = 5; 
    [SerializeField] private float attackRange = .75f; 

    private bool isStunned = false; 
    [SerializeField] private GameObject stunVisual; 
    [SerializeField] private GameObject explosionOfBlood; 

    private void Start()
    {
        pc = PlayerController.Instance;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isStunned) return; 

        if (pc == null)
        {
            pc = PlayerController.Instance; 
            return; 
        }

        Vector3 direction = (pc.transform.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, pc.transform.position); 

        if (distance < attackRange)
        {
            print ("damage player"); 
        }

        Vector3 movement = direction * moveSpeed * Time.fixedDeltaTime; 
        rb.MovePosition(rb.position + movement); 

        Quaternion targetRotation  = Quaternion.LookRotation(direction); 
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime)); 
    }


    public void Stun()
    {
        isStunned = true; 
        stunVisual.SetActive(true); 
    }

    public void Die()
    {
        Instantiate(explosionOfBlood, transform.position, Quaternion.identity); 
        Destroy(this.gameObject); 
    }
}
