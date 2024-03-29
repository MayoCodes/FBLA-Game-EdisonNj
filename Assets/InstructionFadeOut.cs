using UnityEngine;
using DG.Tweening;
using System.Collections;

public class FadeOutController : MonoBehaviour
{
    public SpriteRenderer squareRenderer; // Reference to the SpriteRenderer of your square element
    public float fadeDuration = 1f; // Duration of the fade animation
    public bool fadeOutInstruct = false;

    void Start()
    {
        // Ensure that the squareRenderer is not null
        if (squareRenderer == null)
        {
            Debug.LogError("SpriteRenderer not assigned!");
            return;
        }
    }

    void Update()
    {
        // Check for space key press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Fade out the sprite
            StartCoroutine(FadeOutAfterDelay());
        }
    }

    IEnumerator FadeOutAfterDelay()
    {
        // Wait for 30 seconds
        yield return new WaitForSeconds(1f);
        fadeOutInstruct = true;
        // Fade out the UI element using DoTween
        squareRenderer.DOFade(40f, fadeDuration);
    }
}
