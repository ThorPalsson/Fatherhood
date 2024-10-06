using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Crib : MonoBehaviour
{
    [SerializeField] private int cribId; 
    private bool start; 

    [SerializeField] private Transform childPos;


    private void Update()
    {
        if (!start)
        {
            var gm = GameManager.Instance; 

            if (gm == null) return; 

            var baby = gm.cribs.FirstOrDefault(X => X.Id == cribId).Baby;

            switch(baby)
            {
                case BabyEnum.Babies.None:
                    break;
                case BabyEnum.Babies.Jessica:
                    print ("spawning jessica in crib");
                    GameObject g = Instantiate(gm.JessicaPrefab, childPos.position, Quaternion.identity); 
                    g.transform.parent = childPos; 
                    g.GetComponent<PickUp>().enabled = false; 
                    break;
                case BabyEnum.Babies.LongJohn:
                    var g1 = Instantiate(gm.JohnCribPrefab, childPos.position, Quaternion.identity); 
                    g1.transform.parent = childPos; 
                    //g1.GetComponent<PickUp>().enabled = false; 
                    start = true; 
                    break;
                case BabyEnum.Babies.Barthalamew:
                    var g2 = Instantiate(gm.BarhalamewPrefab, childPos.position, Quaternion.identity); 
                    g2.transform.parent = childPos; 
                    g2.GetComponent<PickUp>().enabled = false; 
                    break;
            }

            start = true; 
        }
    }

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
                var entry = GameManager.Instance.cribs.First(x => x.Id == cribId); 
                entry.Baby = BabyEnum.Babies.Jessica;
                break; 
            case BabyEnum.Babies.LongJohn:
                GameManager.Instance.JohnDone = true; 
                var entry3 = GameManager.Instance.cribs.First(x => x.Id == cribId); 
                entry3.Baby = BabyEnum.Babies.LongJohn;
                break; 
            case BabyEnum.Babies.Barthalamew:
                GameManager.Instance.BarthalamewDone = true; 
                var entry5 = GameManager.Instance.cribs.First(x => x.Id == cribId); 
                entry5.Baby = BabyEnum.Babies.Barthalamew;
                break; 
        }


        baby.PlaceInCrib();
        baby.enabled = false; 
        this.enabled = false; 
    }
}
