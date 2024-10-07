using UnityEngine;

public class MusicChange : MonoBehaviour
{

    public AudioClip clip;
    bool start; 

    void Start()
    {
        
    }

    void Update()
    {
        if (!start)
        {
            var gm = GameManager.Instance; 

            if (gm == null) return; 

            gm.ChangeSong(clip); 
            start = true; 
        }
    }
}
