using UnityEngine;

public class BoatController : MonoBehaviour
{
    public GameObject ChildPrefab; 
    public void Hit()
    {
        ChildPrefab.SetActive(true); 
        GameManager.Instance.DefaultSong();
        this.gameObject.SetActive(false); 
    }
}
