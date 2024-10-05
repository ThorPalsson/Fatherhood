using UnityEngine;

public class ChoppyAnimation : MonoBehaviour
{
    public Animator animator; 
    public float targetFrameRate = 10f; 
    private float timeBetweenFrames;
    private float lastFrameTime;

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
        if (Time.time - lastFrameTime >= timeBetweenFrames)
        {
            animator.speed = 1f;
            lastFrameTime = Time.time;
        }
        else
        {
            animator.speed = 0f;
        }
    }
}