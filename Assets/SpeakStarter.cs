using UnityEditor;
using UnityEngine;

public class SpeakStarter : MonoBehaviour
{
   public string message;
   public int id = 0; 
   private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.StartConversation(message, id ); 
            Destroy(this.gameObject); 
        }
   }
}
