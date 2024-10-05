using UnityEngine;

public class ChoppyAnimation : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public float targetFrameRate = 10f; // Frames per second you want to simulate

    private float timeBetweenFrames;
    private float lastFrameTime;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // Calculate the time between frames based on the target frame rate
        timeBetweenFrames = 1f / targetFrameRate;
    }

    void Update()
    {
        if (Time.time - lastFrameTime >= timeBetweenFrames)
        {
            // Allow the animation to advance one frame
            animator.speed = 1f;

            // Record the time for the next frame
            lastFrameTime = Time.time;
        }
        else
        {
            // Pause the animation between frames
            animator.speed = 0f;
        }
    }
}