using UnityEngine;

public class Hold : MonoBehaviour
{
    public static Hold Instance; 
    public PickUp pickUpInRange;
    public Crib cribInRange;

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
        if (isHolding) 
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (cribInRange == null || pickUpInRange.IsBaby == false)
                {
                    pickUpInRange.Throw(500);
                    isHolding = false;
                    pickUpInRange = null; 
                } else 
                {

                }
            }
        }


        if (pickUpInRange == null) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
           pickUpInRange.PickThisUp(holdPosition);
           isHolding = true; 
        }
    }
}
