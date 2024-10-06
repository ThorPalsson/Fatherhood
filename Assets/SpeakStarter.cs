using UnityEngine;

public class SpeakStarter : MonoBehaviour
{
   public string message;

   private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.StartConversation(message); 
            Destroy(this.gameObject); 
        }
   }
}
