using UnityEngine;

public class Hold : MonoBehaviour
{
    public static Hold Instance; 
    public PickUp pickUpInRange;

    [SerializeField] private bool isHolding; 
    [SerializeField] private Transform holdPosition; 


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } else 
        {
            Instance = this; 
        }
    }


    private void Update()
    {
        if (pickUpInRange == null) return;


        if (Input.GetKeyDown(KeyCode.E))
        {
            pickUpInRange.transform.parent = holdPosition; 
            pickUpInRange.transform.position = holdPosition.position; 
        }
    }
}
