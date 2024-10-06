using UnityEngine;

public class SHITFIXRAINMANSHIT : MonoBehaviour
{
    
    public GameObject[] Despawn; 
    public GameObject[] UnDespawn; 


    void Start()
    {
        var gm = GameManager.Instance; 

        if (gm.BarthalamewDone && gm.JessicaDone && gm.JohnDone)
        {
            foreach (var john in Despawn)
            {
                john.SetActive(false);
            }

            foreach (var john in UnDespawn)
            {
                john.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
