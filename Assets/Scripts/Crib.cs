using UnityEngine;

public class Crib : MonoBehaviour
{

    [SerializeField] private Transform childPos;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Hold.Instance.cribInRange = this; 
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Hold.Instance.cribInRange == this)
                Hold.Instance.cribInRange = null; 
        }
    }


    public void PlaceBaby(PickUp baby)
    {
        print ("placing baby");
        
        baby.transform.parent = GameManager.Instance.RoomParent.transform; 
        baby.transform.position = childPos.position; 

        switch(baby.thisBaby)
        {
            case BabyEnum.Babies.Jessica:
                GameManager.Instance.JessicaDone = true; 
                break; 
            case BabyEnum.Babies.LongJohn:
                GameManager.Instance.JohnDone = true; 
                break; 
            case BabyEnum.Babies.Barthalamew:
                GameManager.Instance.BarthalamewDone = true; 
                break; 
        }


        baby.PlaceInCrib();
        baby.enabled = false; 
        this.enabled = false; 
    }
}
