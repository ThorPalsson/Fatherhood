using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float movementSpeed = 5; 
    [SerializeField] private float turnSpeed = 100; 

    private Rigidbody rb; 

    private bool canMove = true; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
        if (!canMove) return;

        float move = Input.GetAxis("Vertical"); 
        float turn = Input.GetAxis("Horizontal"); 

        if (move < 0) move = 0; 

        Vector3 movement = transform.forward * move * movementSpeed * Time.fixedDeltaTime; 
        rb.MovePosition(rb.position + movement); 

        float turnAmount = turn * turnSpeed * Time.fixedDeltaTime; 
        Quaternion turnRotation = Quaternion.Euler(0, turnAmount, 0);
        rb.MoveRotation(rb.rotation * turnRotation); 

        rb.linearVelocity = Vector3.zero; 
    }
}
