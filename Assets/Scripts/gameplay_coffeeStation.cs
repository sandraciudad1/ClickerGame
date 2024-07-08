using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameplay_coffeeStation : MonoBehaviour
{
    [SerializeField] GameObject startBtn;
    public Image progressBar;
    [SerializeField] Button arrowButton;

    //stations
    [SerializeField] GameObject orderStation;
    [SerializeField] GameObject coffeeStation;
    [SerializeField] GameObject toppingStation;

    //coffee machines
    [SerializeField] Button latteCoffeeMachine;
    [SerializeField] Button moccaCoffeeMachine;
    [SerializeField] Button macchiatoCoffeeMachine;
    [SerializeField] Button capuccinoCoffeeMachine;

    //coffees
    [SerializeField] Image coffeeImg;
    [SerializeField] Image coffeeImgToppings;
    [SerializeField] Sprite latte;
    [SerializeField] Sprite mocca;
    [SerializeField] Sprite macchiato;
    [SerializeField] Sprite capuccino;
    public int coffeeType;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void startOrderBtn()
    {
        coffeeStation.SetActive(true);
        orderStation.SetActive(false);
    }

    public void incrementProgressBar(int index)
    {
        float clicks = PlayerPrefs.GetFloat("coffeeClicks", 0.033f);
        progressBar.fillAmount += clicks;
        progressBar.fillAmount = Mathf.Clamp(progressBar.fillAmount, 0f, 1f);
        if (progressBar.fillAmount >= 1f)
        {
            Sprite[] coffees = { latte, mocca, macchiato, capuccino };
            coffeeImg.sprite = coffees[index];
            coffeeImgToppings.sprite = coffees[index];
            coffeeImg.gameObject.SetActive(true);
            latteCoffeeMachine.interactable = false;
            moccaCoffeeMachine.interactable = false;
            macchiatoCoffeeMachine.interactable = false;
            capuccinoCoffeeMachine.interactable = false;
            arrowButton.gameObject.SetActive(true);
        }

    }

    public void latteMachine()
    {
        moccaCoffeeMachine.interactable = false;
        macchiatoCoffeeMachine.interactable = false;
        capuccinoCoffeeMachine.interactable = false;
        incrementProgressBar(0);
        GameData.Instance.coffeeType = 0;
    }

    public void moccaMachine()
    {
        latteCoffeeMachine.interactable = false;
        macchiatoCoffeeMachine.interactable = false;
        capuccinoCoffeeMachine.interactable = false;
        incrementProgressBar(1);
        GameData.Instance.coffeeType = 1;
    }

    public void macchiatoMachine()
    {
        latteCoffeeMachine.interactable = false;
        moccaCoffeeMachine.interactable = false;
        capuccinoCoffeeMachine.interactable = false;
        incrementProgressBar(2);
        GameData.Instance.coffeeType = 2;
    }

    public void capuccinoMachine()
    {
        latteCoffeeMachine.interactable = false;
        moccaCoffeeMachine.interactable = false;
        macchiatoCoffeeMachine.interactable = false;
        incrementProgressBar(3);
        GameData.Instance.coffeeType = 3;
    }

    public void changeToppingStation()
    {
        toppingStation.SetActive(true);
        coffeeStation.SetActive(false);
    }

}
