using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameplayScene_Controller : MonoBehaviour
{
    public bool startMovingCharacter = false;

    //character data
    [SerializeField] GameObject character;
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] Image characterImg;
    [SerializeField] Sprite charles;
    [SerializeField] Sprite chole;
    [SerializeField] Sprite sophie;
    [SerializeField] Sprite john;

    public string[] charactersNames = { "charles", "chloe", "sophie", "john" };
    public string characterName;

    //ticket and toppings data
    [SerializeField] GameObject ticket;
    [SerializeField] GameObject coffeeOrder;
    [SerializeField] GameObject donutOrder;
    //coffee
    [SerializeField] Image coffeeImg;
    [SerializeField] Sprite latte;
    [SerializeField] Sprite mocca;
    [SerializeField] Sprite macchiato;
    [SerializeField] Sprite capuccino;
    //syrup
    [SerializeField] Image syrupImg;
    [SerializeField] Sprite chocolateSyrup;
    [SerializeField] Sprite caramelSyrup;
    [SerializeField] Sprite strawberrySyrup;
    //toppings
    [SerializeField] Image toppingImg;
    [SerializeField] Sprite cherries;
    [SerializeField] Sprite berries;
    [SerializeField] Sprite mikado;
    [SerializeField] Sprite nuts;
    [SerializeField] Sprite cookies;

    //donut
    //glazed
    [SerializeField] Image glazedImg;
    [SerializeField] Sprite chocolateGlazed;
    [SerializeField] Sprite blueberryGlazed;
    [SerializeField] Sprite strawberryGlazed;
    //toppings
    [SerializeField] Image donutToppingImg;
    [SerializeField] Sprite banana;
    [SerializeField] Sprite marshmallow;
    [SerializeField] Sprite oreo;
    [SerializeField] Sprite popcorn;
    [SerializeField] Sprite pretzel;

    public int toppingsLevel = 1;

    [SerializeField] GameObject startBtnCoffee;
    [SerializeField] GameObject startBtnDonut;

    void Start()
    {
        
    }

    void Update()
    {
        if (startMovingCharacter == true)
        {
            character.transform.position += new Vector3(0.5f, 0, 0);
            if(character.transform.position.x >= 208.5f)
            {
                ticket.SetActive(true);
                name.text = characterName;
                startMovingCharacter = false;
            }
        }
    }

    int generateRandom(int li, int ls)
    {
        int randomNumber = Random.Range(li, ls);
        return randomNumber;
    }

    //Generates a random character
    public void manageCharacter()
    {
        Sprite[] characters = { charles, chole, sophie, john};
        int num = generateRandom(0, 4);
        GameData.Instance.randomCharacter = num;
        characterName = charactersNames[num];
        characterImg.sprite = characters[num];
    }

    //Generates a random ticket (with random coffee and toppings)
    public void manageTicket()
    {
        coffeeOrder.SetActive(true);
        donutOrder.SetActive(false);

        Sprite[] coffees = { latte, mocca, macchiato, capuccino };
        Sprite[] syrups = { chocolateSyrup, caramelSyrup, strawberrySyrup };
        Sprite[] toppings = { cherries, berries, mikado, nuts, cookies };

        //decide type of coffee
        int coffee = generateRandom(0, 4);
        GameData.Instance.randomCoffeeType = coffee;
        coffeeImg.sprite = coffees[coffee];

        int syrup = generateRandom(0, 4);
        if (syrup == 0)
        {
            GameData.Instance.randomCreamType = 0;
        } else
        {
            syrupImg.gameObject.SetActive(true);
            GameData.Instance.randomCreamType = syrup;
            syrupImg.sprite = syrups[syrup-1];
        }

        //decide if has toppings and what type
        int avaiableToppings = PlayerPrefs.GetInt("avaiableToppings", 1);
        int topping = generateRandom(0, (avaiableToppings+1));
        if (topping == 0)
        {
            GameData.Instance.randomTopping = 0;
        } else
        {
            toppingImg.gameObject.SetActive(true);
            GameData.Instance.randomTopping = topping;
            toppingImg.sprite = toppings[topping-1];
        }
        StartCoroutine(waitSecondsCoffee());
    }

    public void manageTicketDonut()
    {
        coffeeOrder.SetActive(false);
        donutOrder.SetActive(true);

        Sprite[] glazeds = { chocolateGlazed, blueberryGlazed, strawberryGlazed };
        Sprite[] donutToppings = { banana, marshmallow, oreo, popcorn, pretzel };

        int glazed = generateRandom(0, 4);
        GameData.Instance.randomGlazed = glazed;
        if (glazed != 0)
        {
            glazedImg.gameObject.SetActive(true);
            glazedImg.sprite = glazeds[glazed - 1];
        }

        //decide if has toppings and what type
        int avaiableToppings = PlayerPrefs.GetInt("avaiableToppingsDonut", 1);
        int topping = generateRandom(0, (avaiableToppings + 1));
        GameData.Instance.randomToppingDonut = topping;
        if (topping != 0)
        {
            donutToppingImg.gameObject.SetActive(true);
            donutToppingImg.sprite = donutToppings[topping - 1];
        }
        StartCoroutine(waitSecondsDonut());
    }

    IEnumerator waitSecondsCoffee()
    {
        yield return new WaitForSeconds(3f);
        startBtnCoffee.SetActive(true);
    }

    IEnumerator waitSecondsDonut()
    {
        yield return new WaitForSeconds(3f);
        startBtnDonut.SetActive(true);
    }
}
