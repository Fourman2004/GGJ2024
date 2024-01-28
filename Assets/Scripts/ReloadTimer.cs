using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadBar : MonoBehaviour
{
    public static ReloadBar instance;

    public Image barImage;

    public bool completedReload;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        barImage.fillAmount = 0.0f;
        gameObject.SetActive(false);
        completedReload = true;
    }

    private void Update()
    {
        if (barImage.fillAmount >= 1.0f && completedReload == true)
        {
            //StopAllCoroutines();
            barImage.fillAmount = 0.0f;
            gameObject.SetActive(false);
        }
    }
    public IEnumerator ShowReload(float seconds)
    {
        completedReload = false;
        while (completedReload == false && barImage.fillAmount < 1.0f)
        {
            Debug.Log("help");
            gameObject.SetActive(true);
            barImage.fillAmount += 0.01f;
            yield return new WaitForSeconds(seconds / 100f);
        }
        completedReload = true;
    }
}
