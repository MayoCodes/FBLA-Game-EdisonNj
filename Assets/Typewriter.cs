using UnityEngine;
using TMPro;
using DG.Tweening;

public class Typewriter : MonoBehaviour
{
    public float typingSpeed = 0.05f;
    private TMP_Text textComponent;
    private string fullText;
    private bool isTyping = false;
    public TMP_Text textMeshProText;
    public Color transparentColor = new Color(0f, 0f, 0f, 0f);
    public Color blackColor = Color.black;
    private bool isTextTransparent = true;
    public bool typeOnce = false;
    public GameObject mControl;

    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        fullText = textComponent.text;
        textComponent.text = ""; // Clear the text initially

        // Set the initial color of textMeshProText to transparent
        textMeshProText.color = transparentColor;
    }

    public void StartTypewriterEffect()
    {
        if (!isTyping)
        {
            isTyping = true;
            textComponent.text = ""; // Clear the text initially
            int totalVisibleCharacters = fullText.Length;
            int visibleCount = 0;
            DOTween.To(() => visibleCount, x => visibleCount = x, totalVisibleCharacters, typingSpeed * totalVisibleCharacters)
                .OnUpdate(() =>
                {
                    textComponent.text = fullText.Substring(0, visibleCount);
                })
                .OnComplete(() => isTyping = false);
        }
    }

    public void DetectAndHandleColor(Color targetColor)
    {
        // Get the renderer component of the object
        Renderer renderer = mControl.GetComponent<Renderer>();

        // Ensure renderer is not null and it has a material
        if (renderer != null && renderer.material != null)
        {
            // Get the color of the material
            Color objectColor = renderer.material.color;

            // Check if the color matches the target color
            if (objectColor == targetColor)
            {
                if (typeOnce == false)
                {
                    typeOnce = true;
                    StartTypewriterEffect();

                    // Toggle text color between transparent and black
                    if (isTextTransparent)
                    {
                        textMeshProText.color = blackColor;
                    }
                    else
                    {
                        textMeshProText.color = transparentColor;
                    }

                    //isTextTransparent = !isTextTransparent; // Toggle the flag
                }
            }
        }
    }

    void Update()
    {
        DetectAndHandleColor(Color.green);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTypewriterEffect();

            // Toggle text color between transparent and black
            if (isTextTransparent)
            {
                textMeshProText.color = blackColor;
            }
            else
            {
                textMeshProText.color = transparentColor;
            }

            isTextTransparent = !isTextTransparent; // Toggle the flag
        }
    }
}
