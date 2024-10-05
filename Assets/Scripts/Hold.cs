using UnityEngine;

public class Hold : MonoBehaviour
{
    public static Hold Instance; 
    public PickUp pickUpInRange;
    public Crib cribInRange;

    [SerializeField] PickUp HeldObject; 

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
                if (cribInRange == null || HeldObject.IsBaby == false)
                {
                    HeldObject.Throw(500, transform.forward);
                    isHolding = false;
                    pickUpInRange = null; 
                } else if (cribInRange != null && HeldObject.IsBaby) 
                {
                    HeldObject.transform.parent = null;
                    cribInRange.PlaceBaby(HeldObject);
                    isHolding = false; 
                }

                HeldObject = null; 
            }
        }


        if (pickUpInRange == null) return;
        if (isHolding) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            print ("pickup");
           pickUpInRange.PickThisUp(holdPosition);
           HeldObject = pickUpInRange; 
           pickUpInRange = null; 
           isHolding = true; 
        }
    }
}
