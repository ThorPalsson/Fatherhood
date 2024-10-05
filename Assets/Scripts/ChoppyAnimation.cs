using UnityEngine;

public class ChoppyAnimation : MonoBehaviour
{
    public Animator animator; 
    public float targetFrameRate = 10f; 
    private float timeBetweenFrames;
    private float timeAccumulator;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        timeBetweenFrames = 1f / targetFrameRate;
    }

    void Update()
    {
        timeAccumulator += Time.deltaTime; 

        if (timeAccumulator >= timeBetweenFrames)
        {
            animator.speed = 1f;
            timeAccumulator = 0f; 
        }
        else
        {
            animator.speed = 0f;
        }
    }
}