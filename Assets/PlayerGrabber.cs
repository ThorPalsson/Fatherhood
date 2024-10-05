using UnityEngine;

public class PlayerGrabber : MonoBehaviour
{

    public Transform GrabPos;

    public string RoomFrom; 

    private bool hasFoundPlayer;


    // Update is called once per frame
    void Update()
    {
        if (!hasFoundPlayer)
        {
            var player = PlayerController.Instance; 

            if (player == null) return; 

            if (RoomFrom == player.transform.GetComponent<RoomHolder>().SceneName)
            {
                player.transform.position = GrabPos.position; 
            }

            hasFoundPlayer = true; 
        }
    }
}
