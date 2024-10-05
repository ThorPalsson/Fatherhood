using UnityEngine;

public class SceneMover : MonoBehaviour
{
    public bool IsTrigger = false; 

    public string SceneName; 

    public GameObject MainCamera; 


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MoveScene();
        }
    }


    public void MoveScene()
    {
        LoadingManager.Instance.LoadScene(SceneName, MainCamera) ; 
    }
}
