using System.Collections;
using UnityEngine;

public class ThingThangController : MonoBehaviour
{

    public GameObject Thing; 
    public GameObject Thang; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(waitandstart()); 
    }

    private IEnumerator waitandstart()
    {
        yield return new WaitForSeconds(12);
        Thang.SetActive(false);
        Thing.SetActive(true);
    }
}
