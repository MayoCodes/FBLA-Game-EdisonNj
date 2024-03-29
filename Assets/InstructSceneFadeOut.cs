using UnityEngine;
using TMPro;
using DG.Tweening;

public class InstructSceneFadeOut : MonoBehaviour
{
    public SpriteRenderer squareRenderer;
    public TextMeshProUGUI tmpElement;
    public bool instructFaded = false;
    public GameObject mControl;

    public void DetectAndHandleColor(Color targetColor)
    {
     
        Renderer renderer = mControl.GetComponent<Renderer>();

        
        if (renderer != null && renderer.material != null)
        {
           
            Color objectColor = renderer.material.color;

         
            if (objectColor == targetColor)
            {
                Invoke("FadeOut", 15f);
            }
        }
    }


    void Update()
    {
        DetectAndHandleColor(Color.green);
    }

    private void FadeOut()
    {

        squareRenderer.DOFade(0f, 1f).OnComplete(() => Destroy(squareRenderer.gameObject));


        tmpElement.DOFade(0f, 1f).OnComplete(() => Destroy(tmpElement.gameObject));
        if (mControl != null)
        {
      
            Renderer renderer = mControl.GetComponent<Renderer>();

      
            if (renderer != null && renderer.material != null)
            {
  
                renderer.material.color = Color.red;
            }
        }
    }


}

