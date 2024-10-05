using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class AnimationClipper : MonoBehaviour
{
    public AnimationClip clip;

    public void Start()
    {
        RemoveAlternateKeyframes(clip);
    }

    [ContextMenu("Clip")]
    void RemoveAlternateKeyframes(AnimationClip clip)
    {
        if (clip == null)
        {
            Debug.LogError("No animation clip assigned.");
            return;
        }

        var curveBindings = AnimationUtility.GetCurveBindings(clip);

        foreach (var binding in curveBindings)
        {
            var curve = AnimationUtility.GetEditorCurve(clip, binding);

            if (curve == null || curve.length <= 1) 
                continue;

            var newKeyframes = new Keyframe[(curve.length + 1) / 2]; 

            int index = 0;
            for (int i = 0; i < curve.length; i += 2)
            {
                newKeyframes[index] = curve[i];
                index++;
            }

            curve.keys = newKeyframes;

            AnimationUtility.SetEditorCurve(clip, binding, curve);
        }

        Debug.Log("Successfully removed every other keyframe.");
    }
}