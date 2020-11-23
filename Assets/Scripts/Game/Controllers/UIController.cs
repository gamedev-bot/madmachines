using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject gasPanel;
    public GameObject coinPanel;

    public GameObject fade;
    public GameObject pauseWindow;

    private int gasCapacity = 150;
    private int gasValue = 100;
    private int gasProgressBar = 100;
    private int coinValue = 0;

    private int nextUpdate = 1;

    private RectTransform rectTransform;

    void Start()
    {
        GameObject gasProgress = gasPanel.transform.GetChild(0).gameObject;
        rectTransform = gasProgress.GetComponent<RectTransform>();
    }

    private void SetGasValue(int progress) {
        if (progress < 0)
        {
            progress = 0;
        }
        else if (progress > 100)
        {
            progress = 100;
        }
        gasProgressBar = progress;
    }

    public void IncrementCoinValue(int count)
    {
        GameObject coinsText = coinPanel.transform.GetChild(0).gameObject;

        TextMeshProUGUI textMesh = coinsText.GetComponent<TextMeshProUGUI>();

        coinValue += count;

        textMesh.text = "" + coinValue;
    }

    public void IncrementGasValue(int count)
    {
        gasValue += count;

        if(gasValue <= 0)
        {
            Debug.Log("Gas is left.");
            return;
        }

        SetGasValue((int) (((float)gasValue / (float)gasCapacity) * 100));
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextUpdate)
        {
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            IncrementGasValue(-1);
        }

        rectTransform.sizeDelta = new Vector2(15 + (3.35f * (float)gasProgressBar), rectTransform.sizeDelta.y);
    }

    public void onPressPause() {
        Time.timeScale = 0;
        fade.gameObject.active = true;
        pauseWindow.gameObject.active = true;
    }

    public void onPressResume() {
        Time.timeScale = 1;
        fade.gameObject.active = false;
        pauseWindow.gameObject.active = false;
    }
}
