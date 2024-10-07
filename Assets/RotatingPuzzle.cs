using System.Collections;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class RotatingPuzzle : MonoBehaviour
{

    public float rotate = 100f;  
    public float winThreshold = 0.1f;

    public GameObject MainCamera; 
    private bool hasWon;
    public GameObject Video; 

    public AudioClip clip; 

    void Update()
    {
        if (hasWon) return; 
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotate * Time.deltaTime); 
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -rotate * Time.deltaTime); 
        }

        float zRotation = transform.eulerAngles.z;
        
        if (zRotation > 180)
        {
            zRotation -= 360;
        }

        if (Mathf.Abs(zRotation) <= winThreshold)
        {
            StartCoroutine(WinGame());
            hasWon = true; 
        }
    }

        private IEnumerator WinGame()
        {
            GameManager.Instance.StartConversation("You did it! The darkness claims you!", 420698880); 
            yield return new WaitForSeconds(6); 
            Video.SetActive(true);
            GameManager.Instance.ChangeSong(clip, 0.3f);
            yield return new WaitForSeconds(5.5f);
            LoadingManager.Instance.LoadScene("ThingScene", MainCamera); 
        }
}