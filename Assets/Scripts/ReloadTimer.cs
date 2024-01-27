using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBar : MonoBehaviour
{
    public static ReloadBar instance;

    public Image barImage;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        barImage.fillAmount = 0f;
        gameObject.SetActive(false);
    }

    public IEnumerator ShowReload(float seconds)
    {
        gameObject.SetActive(true);
        if (barImage.fillAmount < 1.0f)
        {
            barImage.fillAmount += 0.01f;
            Debug.Log(barImage.fillAmount);
        }
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
