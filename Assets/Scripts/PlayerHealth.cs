using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Rendering.PostProcessing;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player ID")]
    public int playerIndex;

    [Header("Health")]
    public int maxHealth = 3;
    public int currentHealth;

    [Header("Keys")]
    public int keys = 0;
    public int requiredKeys = 3;

    [Header("UI")]
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    [Header("Visuals")]
    public Animator animator;

    private GameManager gm;
    private DepthOfField dof;
    public PostProcessVolume volume;
    private Vignette vignette;

    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();

        currentHealth = maxHealth;
        UpdateHearts();

        if (volume != null && volume.profile != null)
        {
            volume.profile.TryGetSettings(out dof);
            volume.profile.TryGetSettings(out vignette);

            if (vignette != null)
                vignette.intensity.value = 0f;
        }
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            UpdateHearts();
            UpdatePostProcessing();

            if (gm != null)
                gm.PlayerDied(this);

            return;

        }

        if (animator != null)
            animator.SetTrigger("hurt");

        UpdateHearts();
        UpdatePostProcessing();

        StartCoroutine(HitBlur());
        
    }

    IEnumerator HitBlur()
    {
        if (dof == null) yield break;

        dof.aperture.value = 1f;
        yield return new WaitForSeconds(0.15f);
        dof.aperture.value = 32f;
    }

    void UpdateHearts()
    {
        if (hearts == null) return;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (hearts[i] == null) continue;

            hearts[i].sprite = (i < currentHealth) ? fullHeart : emptyHeart;
        }
    }

    void UpdatePostProcessing()
    {
        if (vignette == null) return;

        if (currentHealth <= 1)
        {
            vignette.intensity.value = 0.8f;
            vignette.color.value = Color.red;
        }
        else
        {
            vignette.intensity.value = 0f;
        }
    }

    public void AddKey()
    {
        keys++;
    }
}