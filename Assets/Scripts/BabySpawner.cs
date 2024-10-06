using Unity.Mathematics;
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
                    var g = Instantiate(gameManager.JessicaPrefab, this.transform.position, Quaternion.identity); 
                    g.transform.parent = gameManager.RoomParent.transform; 
                    break;
                case BabyEnum.Babies.LongJohn:
                    if (gameManager.JohnDone || hold.HeldBaby == BabyEnum.Babies.LongJohn) break; 
                
                    var g2 = Instantiate(gameManager.JohnPrefab, this.transform.position, Quaternion.identity);
                    g2.transform.parent = gameManager.RoomParent.transform; 
                    break;
                case BabyEnum.Babies.Barthalamew:
                    if (gameManager.BarthalamewDone || hold.HeldBaby == BabyEnum.Babies.Barthalamew) break; 

                    var g3 = Instantiate(gameManager.BarhalamewPrefab, this.transform.position, Quaternion.identity); 
                    g3.transform.parent = gameManager.RoomParent.transform; 
                    break;
            }


            start = true; 
        }
   }
}
