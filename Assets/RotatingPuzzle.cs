using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class RotatingPuzzle : MonoBehaviour
{

    public float rotate = 100f;  
    public float winThreshold = 0.1f;

    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotate * Time.deltaTime); 
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
            WinGame();
        }
        }

        void WinGame()
        {
            Debug.Log("Win");
        }
    }
}