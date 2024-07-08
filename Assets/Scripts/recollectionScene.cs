using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class recollectionScene : MonoBehaviour
{
    [SerializeField] GameObject coffeeObject;
    [SerializeField] GameObject donutObject;

    //character
    [SerializeField] Image character;
    [SerializeField] Sprite charles;
    [SerializeField] Sprite chole;
    [SerializeField] Sprite sophie;
    [SerializeField] Sprite john;

    //coffees
    [SerializeField] Image coffee;
    [SerializeField] Sprite latte;
    [SerializeField] Sprite mocca;
    [SerializeField] Sprite macchiato;
    [SerializeField] Sprite capuccino;

    //creams
    [SerializeField] Image cream;
    [SerializeField] Sprite onlyCream;
    [SerializeField] Sprite chocolateCream;
    [SerializeField] Sprite caramelCream;
    [SerializeField] Sprite strawberryCream;

    //toppings
    [SerializeField] Image topping;
    [SerializeField] Sprite cherries;
    [SerializeField] Sprite berries;
    [SerializeField] Sprite mikado;
    [SerializeField] Sprite nuts;
    [SerializeField] Sprite cookies;

    //glazed
    [SerializeField] Image chocolateGlazed;
    [SerializeField] Image blueberryGlazed;
    [SerializeField] Image strawberryGlazed;

    //donut Toppings
    [SerializeField] Image banana;
    [SerializeField] Image marshmallow;
    [SerializeField] Image oreo;
    [SerializeField] Image popcorn;
    [SerializeField] Image pretzels;

    //stars
    [SerializeField] Image star1;
    [SerializeField] Image star2;
    [SerializeField] Image star3;
    [SerializeField] Sprite yellowStar;
    [SerializeField] Sprite greystar;

    //coins 
    [SerializeField] TextMeshProUGUI coins;
    [SerializeField] GameObject coin1;
    [SerializeField] GameObject coin2;
    [SerializeField] GameObject coin3;
    [SerializeField] GameObject coin4;
    [SerializeField] GameObject coin5;
    [SerializeField] GameObject coin6;
    [SerializeField] GameObject coin7;
    [SerializeField] GameObject coin8;
    [SerializeField] GameObject coin9;
    [SerializeField] GameObject coin10;

    //arrow button
    [SerializeField] Button arrow;

    bool point1 = false, point2 = false, point3 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (point1 == true)
        {
            checkPosition(coin1);
            checkPosition(coin2);
            if(coin1.activeInHierarchy==false && coin2.activeInHierarchy == false)
            {
                point1 = false;
            }
        }

        if (point2 == true)
        {
            checkPosition(coin1);
            checkPosition(coin2);
            checkPosition(coin3);
            checkPosition(coin4);
            checkPosition(coin5);
            if (coin1.activeInHierarchy == false && coin2.activeInHierarchy == false && coin3.activeInHierarchy == false && coin4.activeInHierarchy == false && coin5.activeInHierarchy == false)
            {
                point2 = false;
            }
        }

        if (point3 == true)
        {
            checkPosition(coin1);
            checkPosition(coin2);
            checkPosition(coin3);
            checkPosition(coin4);
            checkPosition(coin5);
            checkPosition(coin6);
            checkPosition(coin7);
            checkPosition(coin8);
            checkPosition(coin9);
            checkPosition(coin10);
            if (coin1.activeInHierarchy == false && coin2.activeInHierarchy == false && coin3.activeInHierarchy == false && coin4.activeInHierarchy == false && coin5.activeInHierarchy == false &&
                coin6.activeInHierarchy == false && coin7.activeInHierarchy == false && coin8.activeInHierarchy == false && coin9.activeInHierarchy == false && coin10.activeInHierarchy == false)
            {
                point3 = false;
            }
        }
        
    }

    void checkPosition(GameObject coin)
    {
        coin.transform.position -= new Vector3(0, 0.5f, 0);
        if (coin.transform.position.y <= 15f)
        {
            //coin.transform.position = new Vector3(coin.transform.position.x, 15f, coin.transform.position.z);
            coin.SetActive(false);
        }
    }


    public void chargeCoffee()
    {
        coffeeObject.SetActive(true);
        donutObject.SetActive(false);

        chargeCharacter();

        if (GameData.Instance.coffeeType == 0)
        {
            coffee.sprite = latte;
        } else if (GameData.Instance.coffeeType == 1)
        {
            coffee.sprite = mocca;
        } else if (GameData.Instance.coffeeType == 2)
        {
            coffee.sprite = macchiato;
        } else if (GameData.Instance.coffeeType == 3)
        {
            coffee.sprite = capuccino;
        }

        if (GameData.Instance.creamType==0)
        {
            cream.sprite = onlyCream;
        } else if (GameData.Instance.creamType == 1)
        {
            cream.sprite = chocolateCream;
        } else if (GameData.Instance.creamType == 2)
        {
            cream.sprite = caramelCream;
        } else if (GameData.Instance.creamType == 3)
        {
            cream.sprite = strawberryCream;
        }

        if (GameData.Instance.topping == 0) {
            topping.gameObject.SetActive(false);
        } else
        {
            topping.gameObject.SetActive(true);
            if (GameData.Instance.topping == 1)
            {
                topping.sprite = cherries;
            }
            else if (GameData.Instance.topping == 2)
            {
                topping.sprite = berries;
            }
            else if (GameData.Instance.topping == 3)
            {
                topping.sprite = mikado;
            }
            else if (GameData.Instance.topping == 4)
            {
                topping.sprite = nuts;
            }
            else if (GameData.Instance.topping == 5)
            {
                topping.sprite = cookies;
            }
        }

        calculateReward();
    }

    public void chargeDonut()
    {
        coffeeObject.SetActive(false);
        donutObject.SetActive(true);
          
        chargeCharacter();

        if (GameData.Instance.glazed == 1)
        {
            chocolateGlazed.gameObject.SetActive(true);
        } else if (GameData.Instance.glazed == 2)
        {
            blueberryGlazed.gameObject.SetActive(true);
        } else if (GameData.Instance.glazed == 3)
        {
            strawberryGlazed.gameObject.SetActive(true);
        }

        if(GameData.Instance.toppingDonut == 1)
        {
            banana.gameObject.SetActive(true);
        } else if (GameData.Instance.toppingDonut == 2)
        {
            marshmallow.gameObject.SetActive(true);
        } else if (GameData.Instance.toppingDonut == 3)
        {
            oreo.gameObject.SetActive(true);
        } else if (GameData.Instance.toppingDonut == 4)
        {
            popcorn.gameObject.SetActive(true);
        } else if (GameData.Instance.toppingDonut == 5)
        {
            pretzels.gameObject.SetActive(true);
        }
        calculateRewardDonut();
    }

    void chargeCharacter()
    {
        Sprite[] characters = { charles, chole, sophie, john };
        character.sprite = characters[GameData.Instance.randomCharacter];
    }

    void calculateReward()
    {
        int points = 0;
        if (GameData.Instance.randomCoffeeType == GameData.Instance.coffeeType)
        {
            points++;
        }
        if (GameData.Instance.randomCreamType == GameData.Instance.creamType)
        {
            points++;
        }
        if(GameData.Instance.randomTopping == GameData.Instance.topping)
        {
            points++;
        }

        float improvement = PlayerPrefs.GetFloat("customerImprovement", 1);
        checkPoints(points, improvement);
        PlayerPrefs.SetInt("Coins", (PlayerPrefs.GetInt("Coins", 0) + GameData.Instance.coins));
        int totalCoins = PlayerPrefs.GetInt("Coins", 0);
        coins.text = totalCoins.ToString();
    }

    void calculateRewardDonut()
    {
        int points = 0;
        if (GameData.Instance.randomGlazed == GameData.Instance.glazed)
        {
            Debug.Log("same glazed");
            points++;
        }
        if (GameData.Instance.randomToppingDonut == GameData.Instance.toppingDonut)
        {
            points+=2;
            Debug.Log("same topping");
        }
        Debug.Log("points " + points);
        float improvement = PlayerPrefs.GetFloat("customerImprovementDonut", 1);
        checkPoints(points, improvement);
        PlayerPrefs.SetInt("Coins", (PlayerPrefs.GetInt("Coins", 0) + GameData.Instance.coins));
        int totalCoins = PlayerPrefs.GetInt("Coins", 0);
        coins.text = totalCoins.ToString();
    }

    void checkPoints(int points, float improvement)
    {
        if (points == 0)
        {
            star1.sprite = greystar;
            star2.sprite = greystar;
            star3.sprite = greystar;
            GameData.Instance.coins += (int)(0 * improvement);
            StartCoroutine(waitSeconds(0f));
        }
        else if (points == 1)
        {
            star1.sprite = yellowStar;
            star2.sprite = greystar;
            star3.sprite = greystar;
            GameData.Instance.coins += (int)(2 * improvement);

            point1 = true;
            StartCoroutine(waitSeconds(2f));
        }
        else if (points == 2)
        {
            star1.sprite = yellowStar;
            star2.sprite = yellowStar;
            star3.sprite = greystar;
            GameData.Instance.coins += (int)(4 * improvement);

            point2 = true;
            StartCoroutine(waitSeconds(3f));
        }
        else if (points == 3)
        {
            star1.sprite = yellowStar;
            star2.sprite = yellowStar;
            star3.sprite = yellowStar;
            GameData.Instance.coins += (int)(6 * improvement);

            point3 = true;
            StartCoroutine(waitSeconds(5f));
        }
    }

    IEnumerator waitSeconds(float sec)
    {
        yield return new WaitForSeconds(sec);
        arrow.gameObject.SetActive(true);
    }

    public void arrowPressed()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("inventoryScene");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string actualShop = PlayerPrefs.GetString("actualShop", "coffee");
        if (scene.name == "inventoryScene")
        {
            inventoryScene_Controller inventory = GameObject.Find("inventoryCamera").GetComponent<inventoryScene_Controller>();
            if (inventory != null)
            {
                inventory.updateInfo();
                if (actualShop.Equals("coffee"))
                {
                    inventory.updateCoffeeInfo();
                }
                else if (actualShop.Equals("donut"))
                {
                    inventory.updateDonutInfo();
                }
            }
        }
        // Desuscribirse del evento para evitar múltiples suscripciones
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
