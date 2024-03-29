using UnityEngine;
using TMPro;
using DG.Tweening;

public class DiaScript : MonoBehaviour
{
    public float typingSpeed = 0.05f;
    private TMP_Text textComponent;
    private string fullText;
    private bool isTyping = false;
    public TMP_Text textMeshProText;
    public Color transparentColor = new Color(0f, 0f, 0f, 0f);
    public Color blackColor = Color.black;
    public GameObject mControl;
    public GameObject squareElement;

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

    void Update()
    {
        if (mControl != null)
        {
            // Get the renderer component of the object
            Renderer renderer = mControl.GetComponent<Renderer>();

            // Ensure renderer is not null and it has a material
            if (renderer != null && renderer.material != null)
            {
                // Get the color of the material
                Color objectColor = renderer.material.color;

                // Check if the color is red
                if (objectColor == Color.red)
                {
                    // Call function e()
                    if (squareElement != null)
                    {
                        Renderer rendere = squareElement.GetComponent<Renderer>();
                        if (rendere != null)
                        {
                            Color color = rendere.material.color;
                            color.a = 0f; // Set alpha channel to 0 for full transparency
                            rendere.material.color = color;
                        }
                    }

                    StartTypewriterEffect();
                }
            }

        }
    }
}
