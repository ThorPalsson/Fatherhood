using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance; 
    [SerializeField] private float movementSpeed = 5; 
    [SerializeField] private float turnSpeed = 100; 

    private Rigidbody rb; 

    public GameObject Sword;

    public bool canMove = true; 
    [SerializeField] private Animator anim; 

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(this);
        } else 
        {
            Instance = this; 
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!canMove) return;

        float move = Input.GetAxis("Vertical"); 
        float turn = Input.GetAxis("Horizontal"); 

        if (move == 0 && turn == 0)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero; 
            anim.SetBool("Walking", false); 
        } else anim.SetBool("Walking", true); 

        if (move < 0) move = 0; 

        Vector3 movement = transform.forward * move * movementSpeed * Time.fixedDeltaTime; 
        rb.MovePosition(rb.position + movement); 

        float turnAmount = turn * turnSpeed * Time.fixedDeltaTime; 
        Quaternion turnRotation = Quaternion.Euler(0, turnAmount, 0);
        rb.MoveRotation(rb.rotation * turnRotation); 

        rb.linearVelocity = Vector3.zero; 
    }
}
