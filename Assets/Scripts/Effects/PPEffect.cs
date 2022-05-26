using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PPEffect : MonoBehaviour
{
    private PostProcessVolume postProcessVolume;

    private ChromaticAberration chromaticAberration;
    void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out chromaticAberration);
        PostProcessOff();
    }

    public void PostProcessOn()
    {
        chromaticAberration.intensity.value = 1f;
    }
    public void PostProcessOff()
    {
        chromaticAberration.intensity.value = 0f;
    }
}
