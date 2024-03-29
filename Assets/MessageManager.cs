using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    public GameObject mControl;
    public GameObject bossSpeak;

    // The desired transparency value (0 for fully transparent, 1 for fully opaque)
    public float transparency = 1f;
    // Start is called before the first frame up

    void Start()
    {
        bossSpeak.SetActive(false);
    }

   

// Update is called once per frame
void Update()
    {
        // Call function e()
        if (bossSpeak != null)
        {
            Renderer rendere = mControl.GetComponent<Renderer>();
            if (rendere != null)
            {
                Material material = rendere.material;
                if (material.color == Color.red)
                {
                    bossSpeak.SetActive(true);
                }
            }
        }
    }
}
