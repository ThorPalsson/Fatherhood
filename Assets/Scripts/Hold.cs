using UnityEngine;

public class Hold : MonoBehaviour
{
    public static Hold Instance; 
    public PickUp pickUpInRange;
    public Crib cribInRange;

    [SerializeField] PickUp HeldObject; 

    [SerializeField] private bool isHolding; 
    [SerializeField] private Transform holdPosition; 
    [SerializeField] private Animator anim; 

    public BabyEnum.Babies HeldBaby; 


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
               if (cribInRange != null && HeldObject.IsBaby) 
                {
                    HeldObject.transform.parent = null;
                    cribInRange.PlaceBaby(HeldObject);
                    isHolding = false; 
                    anim.SetBool("Carry", false);
                }

                
            if (Input.GetKeyDown(KeyCode.E))
            {
             

                if (cribInRange == null || HeldObject.IsBaby == false)
                {
                    HeldObject?.Throw(500, transform.forward);
                    isHolding = false;
                    pickUpInRange = null; 
                    anim.SetTrigger("Throw"); 
                    anim.SetBool("Carry", false);
                }

                HeldObject = null;
                HeldBaby = BabyEnum.Babies.None; 
                isHolding = false;  
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
           anim.SetTrigger("PickUp"); 
            anim.SetBool("Carry", true);


           if (HeldObject.IsBaby)
           {
                print ("Setting hold baby to "+ HeldObject.thisBaby.ToString()); 
                HeldBaby = HeldObject.thisBaby; 
           }
        }
    }
}
