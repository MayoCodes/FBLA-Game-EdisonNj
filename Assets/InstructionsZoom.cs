using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InstructionsZoom : MonoBehaviour
{
    public Transform squareTransform; // Reference to the Transform of your square element
    public float moveDuration = 1f; // Duration of the movement animation
    public float moveDistance = 1f; // Distance to move up
    public string area = "INSTRUCTIONMUSIC";

    void Start()
    {
        // Ensure that the squareTransform is not null
        if (squareTransform == null)
        {
            Debug.LogError("Transform not assigned!");
            return;
        }
    }

    void Update()
    {
        // Check for space key press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Move the square up
           // AudioManager.instance.SetBGMusic(area);
            squareTransform.DOMoveY(squareTransform.position.y + moveDistance, moveDuration);
        }
    }
}
