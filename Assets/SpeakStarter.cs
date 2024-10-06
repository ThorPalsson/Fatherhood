using UnityEditor;
using UnityEngine;

public class SpeakStarter : MonoBehaviour
{
   public string message;
   public int id = 0; 

   public bool doesthing; 
   private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            if(doesthing)
            {
                PlayerController.Instance.Sword.SetActive(true); 
            }

            GameManager.Instance.StartConversation(message, id ); 
            Destroy(this.gameObject); 
        }
   }
}
