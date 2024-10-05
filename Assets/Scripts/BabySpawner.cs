using UnityEngine;

public class BabySpawner : MonoBehaviour
{
   public BabyEnum.Babies ThisBaby; 

   private bool start; 


   private void Update()
   {
        if(!start)
        {
            var gameManager = GameManager.Instance; 
            var pc = PlayerController.Instance; 

            if (gameManager == null || pc == null) return; 


            var hold = pc.transform.GetComponent<Hold>();


            print (hold.HeldBaby); 

            switch(ThisBaby)
            {
                case BabyEnum.Babies.Jessica:
                    if (gameManager.JessicaDone || hold.HeldBaby == BabyEnum.Babies.Jessica) break;  

                    print ("Spawning baby"); 
                    Instantiate(gameManager.JessicaPrefab); 
                    break;
                case BabyEnum.Babies.LongJohn:
                    if (gameManager.JohnDone || hold.HeldBaby == BabyEnum.Babies.LongJohn) break; 
                
                    Instantiate(gameManager.JohnPrefab); 
                    break;
                case BabyEnum.Babies.Barthalamew:
                    if (gameManager.BarthalamewDone || hold.HeldBaby == BabyEnum.Babies.Barthalamew) break; 

                    Instantiate(gameManager.BarhalamewPrefab); 
                    break;
            }


            start = true; 
        }
   }
}
