using UnityEngine;
using DG.Tweening;
using FMODUnity;

public class StartBtn : MonoBehaviour
{
    private Vector3 originalScale;
    [SerializeField] private EventReference startSelectSound;
    public GameObject mControl;
    public SpriteRenderer squareRenderer; 
    public float fadeDuration = 2f;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void OnMouseEnter()
    {
        transform.DOScale(originalScale * 1.2f, 0.3f);
    }

    void OnMouseExit()
    {
        transform.DOScale(originalScale, 0.3f);
    }

    public void ChangeMColor(Color newColor)
    {
 
        Renderer renderer = mControl.GetComponent<Renderer>();


        if (renderer != null && renderer.material != null)
        {

            renderer.material.color = newColor;
            squareRenderer.DOFade(0f, fadeDuration);
        }
    }


    void OnMouseDown()
    {
        AudioManager.instance.PlayOneShot(startSelectSound, this.transform.position);
        ChangeMColor(Color.green);

    }
}

