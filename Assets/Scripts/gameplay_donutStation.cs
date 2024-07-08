using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameplay_donutStation : MonoBehaviour
{
    public Image progressBar;
    [SerializeField] Button arrowButton;

    //stations
    [SerializeField] GameObject orderStation;
    [SerializeField] GameObject donutStation;
    [SerializeField] GameObject donutToppingStation;

    //glazed
    [SerializeField] Button ovenBtn;
    [SerializeField] Button chocolatePB;
    [SerializeField] Button blueberryPB;
    [SerializeField] Button strawberryPB;
    [SerializeField] GameObject dish;
    [SerializeField] Image chocolateGlazed;
    [SerializeField] Image blueberryGlazed;
    [SerializeField] Image strawberryGlazed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startOrderBtn()
    {
        donutStation.SetActive(true);
        orderStation.SetActive(false);
    }

    public void incrementProgressBar()
    {
        float clicks = PlayerPrefs.GetFloat("donutClicks", 0.033f);
        progressBar.fillAmount += clicks;
        progressBar.fillAmount = Mathf.Clamp(progressBar.fillAmount, 0f, 1f);
        if (progressBar.fillAmount >= 1f)
        {
            dish.SetActive(true);

            chocolatePB.interactable = true;
            blueberryPB.interactable = true;
            strawberryPB.interactable = true;
            progressBar.fillAmount = 0f;
            ovenBtn.interactable = false;
            arrowButton.gameObject.SetActive(true);
        }
    }

    public void incrementProgressBar_PB(int index)
    {
        progressBar.fillAmount += 0.1f;
        progressBar.fillAmount = Mathf.Clamp(progressBar.fillAmount, 0f, 1f);
        if (progressBar.fillAmount >= 1f)
        {
            if (index == 1)
            {
                chocolateGlazed.gameObject.SetActive(true);
            }
            else if (index == 2)
            {
                blueberryGlazed.gameObject.SetActive(true);
            }
            else if (index == 3)
            {
                strawberryGlazed.gameObject.SetActive(true);
            }
            nonInteractableButtons();
        }
    }

    void nonInteractableButtons()
    {
        ovenBtn.interactable = false;
        chocolatePB.interactable = false;
        blueberryPB.interactable = false;
        strawberryPB.interactable = false;
    }

    public void oven()
    {
        incrementProgressBar();
        GameData.Instance.glazed = 0;
    }

    public void chocolatePB_pressed()
    {
        blueberryPB.interactable = false;
        strawberryPB.interactable = false;
        incrementProgressBar_PB(1);
        GameData.Instance.glazed = 1;
    }

    public void blueberryPB_pressed()
    {
        chocolatePB.interactable = false;
        strawberryPB.interactable = false;
        incrementProgressBar_PB(2);
        GameData.Instance.glazed = 2;
    }

    public void strawberryPB_pressed()
    {
        chocolatePB.interactable = false;
        blueberryPB.interactable = false;
        incrementProgressBar_PB(3);
        GameData.Instance.glazed = 3;
    }

    public void changeToppingStation()
    {
        gameplay_donutToppingStation topping = GameObject.Find("gameplayCamera").GetComponent<gameplay_donutToppingStation>();
        if (topping != null)
        {
            topping.changeGlazed();
        }
        donutToppingStation.SetActive(true);
        donutStation.SetActive(false);
    }
}
