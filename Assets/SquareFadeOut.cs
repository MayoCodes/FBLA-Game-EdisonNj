using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class SquareFadeOut : MonoBehaviour
{
    public SpriteRenderer squareRenderer; // Reference to the SpriteRenderer of your square element
    public float fadeDuration = 1f; // Duration of the fade animation

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
            squareRenderer.DOFade(0f, fadeDuration);
        }
    }
}
