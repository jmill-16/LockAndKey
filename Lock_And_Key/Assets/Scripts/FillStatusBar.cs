using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{

    public PlayerHealth playerhealth;
    public Image fillImage;
    private Slider slider;
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if(slider.value > slider.minValue && !(fillImage.enabled))
        {
            fillImage.enabled = true;
        }

        float fillValue = playerhealth.health / playerhealth.maxHealth;
        if(fillValue <= slider.maxValue / 3)
        {
            fillImage.color = Color.red;
        } else if(fillValue > slider.maxValue / 3)
        {
            Color color = new Color32(0x15, 0x65, 0x13, 0xFF); // FF for the alpha channel

            // Assign the color to the Image component's color property
            fillImage.color = color;
        }

        slider.value = fillValue;
    }
}
