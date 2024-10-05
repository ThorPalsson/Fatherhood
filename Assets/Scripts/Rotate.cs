using UnityEngine;

public class Rotate : MonoBehaviour
{

    public Vector3 Rotation;

    void Update()
    {
        this.transform.Rotate(Rotation);
    }
}
