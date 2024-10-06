using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private GameObject camMovePos; 
    [SerializeField] private GameObject theCamera; 

   private void OnTriggerEnter(Collider other)
   {
        if (other.CompareTag("Player"))
        {
            theCamera.transform.position = camMovePos.transform.position;
            theCamera.transform.rotation = camMovePos.transform.rotation;
        }
   }
}
