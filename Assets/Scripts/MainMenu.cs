using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
   public Button button; 
   public GameObject MainCamera; 


   private void Start()
   {
        //SceneManager.LoadSceneAsync("DoorScene"); 
        button.onClick.AddListener(() => LoadGame()); 
   }


   private void LoadGame()
   {
        SceneManager.LoadScene("DoorScene"); 
   }
}
