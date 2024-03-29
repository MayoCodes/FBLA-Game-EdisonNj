using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class ChangeIntro : MonoBehaviour
{
    [SerializeField] private EventReference startSelectSound;
    public SpriteRenderer squareRenderer; 
    public float fadeDuration = 2f;
    public GameObject mControl;
    public bool fadeOnce = false;

    void Start()
    {
 
        if (squareRenderer == null)
        {
            Debug.LogError("SpriteRenderer not assigned!");
            return;
        }
    }

    public void DetectAndHandleColor(Color targetColor)
    {
       
        Renderer renderer = mControl.GetComponent<Renderer>();

        if (renderer != null && renderer.material != null)
        {
   
            Color objectColor = renderer.material.color;

            if (objectColor == targetColor)
            {
                if (fadeOnce == false)
                {
                    fadeOnce = true;
                    squareRenderer.DOFade(0f, fadeDuration);
                }
            }
        }
    }

    void Update()
    {
        DetectAndHandleColor(Color.green);

    }
}