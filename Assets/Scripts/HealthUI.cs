using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image healthImage;

    // Start is called before the first frame update
    void Start()
    {
        //healthImage.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        healthImage.fillAmount = (float)PlayerController.instance.currentHealth / PlayerController.instance.maxHealth;
        healthImage.fillAmount = Mathf.Clamp(healthImage.fillAmount, 0f, 1f);
    }
}
