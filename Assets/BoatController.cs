using UnityEngine;

public class BoatController : MonoBehaviour
{
    public GameObject ChildPrefab; 
    public void Hit()
    {
        ChildPrefab.SetActive(true); 
        this.gameObject.SetActive(false); 
    }
}
