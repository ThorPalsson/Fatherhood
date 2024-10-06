using UnityEditor;
using UnityEngine;

public class SpeakStarter : MonoBehaviour
{
   public string message;
   public int id = 0; 

   public AudioClip audioClip; 
   public EnemySpawner spawner;

   public bool doesthing; 
   private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            if(doesthing)
            {
                PlayerController.Instance.Sword.SetActive(true); 
                spawner.isActive = true; 
            }

            if (audioClip != null)
            {
                GameManager.Instance.ChangeSong(audioClip); 
            }


            GameManager.Instance.StartConversation(message, id ); 
            Destroy(this.gameObject); 
        }
   }
}
