using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LowHealthVignette : MonoBehaviour
{
    public PostProcessVolume volume;
    private Vignette vignette;

    void Start()
    {
        volume.profile.TryGetSettings(out vignette);
    }

    public void UpdateVignette(int hp)
    {
        if (vignette == null) return;

        if (hp <= 1)
        {
            vignette.intensity.value = 0.8f;
            vignette.color.value = Color.red;
        }
        else
        {
            vignette.intensity.value = 0f;
        }
    }
}