using UnityEngine;

public class ParentGrabber : MonoBehaviour
{
   private bool start; 


   private void Update()
   {
      if (!start)
      {
            var gm = GameManager.Instance; 

            if (gm == null) return;

            gm.RoomParent = this.gameObject;

            start = false;  
      }
   }
}
