using UnityEngine;
using UnityEngine.Splines;

public class SplineFollow : MonoBehaviour
{
    public SplineContainer splineContainer; 
    [SerializeField] private float speed = 1; 
    [SerializeField] private float progress = 0; 


    private void Update()
    {
        progress += speed * Time.deltaTime; 

        if (progress > 1)
        {
            progress -= 1; 
        }

        Spline spline = splineContainer.Spline; 

        Vector3 position = spline.EvaluatePosition(progress); 
        Vector3 tangent = spline.EvaluateTangent(progress);


        transform.position = position + splineContainer.transform.position;

        if (tangent != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(tangent); 
        }

    }
}
