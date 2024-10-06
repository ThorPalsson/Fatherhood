using System.Collections;
using UnityEngine;

public class awit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(waitandquit());
    }

    private IEnumerator waitandquit()
    {
        yield return new WaitForSeconds(20);
        Application.Quit();
    }
}
