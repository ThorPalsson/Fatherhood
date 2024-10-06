using UnityEngine;

public class Kill : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            other.GetComponent<Enemy>().Die();
    }
}
