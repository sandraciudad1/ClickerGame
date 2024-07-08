using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class inventoryScene_Controller : MonoBehaviour
{
    [SerializeField] GameObject coffeeImprovementImg;
    [SerializeField] GameObject donutImprovementImg;

    //buttons
    [SerializeField] Button improve1;
    [SerializeField] Button improve2;
    [SerializeField] Button improve3;
    [SerializeField] Button improve1Donut;
    [SerializeField] Button improve2Donut;
    [SerializeField] Button improve3Donut;

    //coins 
    [SerializeField] TextMeshProUGUI coins;
    [SerializeField] TextMeshProUGUI moneyText1;
    [SerializeField] TextMeshProUGUI moneyText2;
    [SerializeField] TextMeshProUGUI moneyText3;
    [SerializeField] Image coin1;
    [SerializeField] Image coin2;
    [SerializeField] Image coin3;

    //message
    [SerializeField] GameObject errorMsg;
    [SerializeField] GameObject warningMsg;
    [SerializeField] Image exclamation;

    //coffee machine and donut oven improvements
    [SerializeField] Image coffeeImprovement;
    [SerializeField] Image donutImprovement;
    [SerializeField] Sprite speed1;
    [SerializeField] Sprite speed2;
    [SerializeField] Sprite speed3;
    [SerializeField] Sprite speed4;
    [SerializeField] Sprite speed5;
    [SerializeField] Sprite speed6;

    //customer improvements
    [SerializeField] Image coinImprovement;
    [SerializeField] Image billImprovement;
    [SerializeField] Sprite money1;
    [SerializeField] Sprite money2;
    [SerializeField] Sprite money3;
    [SerializeField] Sprite money4;
    [SerializeField] Sprite money5;

    //toppings improvements
    [SerializeField] Image toppingImprovement;
    [SerializeField] Image impr1;
    [SerializeField] Image impr2;
    [SerializeField] Image impr3;
    [SerializeField] Image impr4;
    [SerializeField] Image impr5;

    bool open = false, openDonut=false;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        string actualShop = PlayerPrefs.GetString("actualShop", "coffee");
        if (actualShop.Equals("coffee"))
        {
            coffeeImprovementImg.gameObject.SetActive(true);
            donutImprovementImg.gameObject.SetActive(false);
            //check if coffee, customers and toppings can be improved or not
            int coffeeCounter = PlayerPrefs.GetInt("coffeeCounter", 0);
            if (coffeeCounter == 5)
            {
                PlayerPrefs.SetInt("fullCoffee", 1);
                improve1.interactable = false;
                moneyText1.gameObject.SetActive(false);
                coin1.gameObject.SetActive(false);
            }

            int customerCounter = PlayerPrefs.GetInt("customerCounter", 0);
            if (customerCounter == 4)
            {
                PlayerPrefs.SetInt("fullCustomer", 1);
                improve2.interactable = false;
                moneyText2.gameObject.SetActive(false);
                coin2.gameObject.SetActive(false);
            }

            int toppingCounter = PlayerPrefs.GetInt("toppingCounter", 0);
            if (toppingCounter == 4)
            {
                PlayerPrefs.SetInt("fullTopping", 1);
                improve3.interactable = false;
                moneyText3.gameObject.SetActive(false);
                coin3.gameObject.SetActive(false);
            }

            int fullCoffee = PlayerPrefs.GetInt("fullCoffee", 0);
            int fullCustomer = PlayerPrefs.GetInt("fullCustomer", 0);
            int fullTopping = PlayerPrefs.GetInt("fullTopping", 0);
            if (fullCoffee == 1 && fullCustomer == 1 && fullTopping == 1 && open == false)
            {
                //warningMsg.SetActive(true);
                PlayerPrefs.SetString("nextShop", "donut");
                StartCoroutine(waitExclamation());
                open = true;
            }
        } else if (actualShop.Equals("donut"))
        {
            coffeeImprovementImg.gameObject.SetActive(false);
            donutImprovementImg.gameObject.SetActive(true);
            //check if donut, customers and toppings can be improved or not
            int donutCounter = PlayerPrefs.GetInt("donutCounter", 0);
            if (donutCounter == 5)
            {
                PlayerPrefs.SetInt("fullDonut", 1);
                improve1Donut.interactable = false;
                moneyText1.gameObject.SetActive(false);
                coin1.gameObject.SetActive(true);
            }

            int customerCounterDonut = PlayerPrefs.GetInt("customerCounterDonut", 0);
            if (customerCounterDonut == 4)
            {
                PlayerPrefs.SetInt("fullCustomerDonut", 1);
                improve2Donut.interactable = false;
                moneyText2.gameObject.SetActive(false);
                coin2.gameObject.SetActive(true);
            }

            int toppingCounterDonut = PlayerPrefs.GetInt("toppingCounterDonut", 0);
            if (toppingCounterDonut == 4)
            {
                PlayerPrefs.SetInt("fullToppingDonut", 1);
                improve3Donut.interactable = false;
                moneyText3.gameObject.SetActive(false);
                coin3.gameObject.SetActive(true);
            }

            int fullDonut = PlayerPrefs.GetInt("fullDonut", 0);
            int fullCustomerDonut = PlayerPrefs.GetInt("fullCustomerDonut", 0);
            int fullToppingDonut = PlayerPrefs.GetInt("fullToppingDonut", 0);
            if (fullDonut == 1 && fullCustomerDonut == 1 && fullToppingDonut == 1 && openDonut == false)
            {
                //warningMsg.SetActive(true);
                StartCoroutine(waitExclamation());
                openDonut = true;
            }
        }
        
    }

    IEnumerator waitExclamation()
    {
        exclamation.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        exclamation.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        exclamation.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        exclamation.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        exclamation.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        exclamation.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        exclamation.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        exclamation.gameObject.SetActive(false);
    }

   
    public void updateInfo()
    {
        int numCoins = PlayerPrefs.GetInt("Coins", 0);
        coins.text = numCoins.ToString();
    }

    public void updateCoffeeInfo()
    {
        //update prices
        int priceCoffee = PlayerPrefs.GetInt("PriceCoffee", 20);
        moneyText1.text = priceCoffee.ToString();
        int priceCustomers = PlayerPrefs.GetInt("PriceCustomers", 20);
        moneyText2.text = priceCustomers.ToString();
        int priceToppings = PlayerPrefs.GetInt("PriceToppings", 20);
        moneyText3.text = priceToppings.ToString();

        //update images
        int coffeeCounter = PlayerPrefs.GetInt("coffeeCounter", 0);
        Sprite[] coffeeImprovements = { speed1, speed2, speed3, speed4, speed5, speed6 };
        coffeeImprovement.sprite = coffeeImprovements[coffeeCounter];

        int customerCounter = PlayerPrefs.GetInt("customerCounter", 0);
        selectImageCustomers(customerCounter);

        int toppingCounter = PlayerPrefs.GetInt("toppingCounter", 0);
        selectImageToppings(toppingCounter);
    }

    public void updateDonutInfo()
    {
        //update prices
        int priceCoffee = PlayerPrefs.GetInt("PriceDonut", 20);
        moneyText1.text = priceCoffee.ToString();
        int priceCustomers = PlayerPrefs.GetInt("PriceCustomersDonut", 20);
        moneyText2.text = priceCustomers.ToString();
        int priceToppings = PlayerPrefs.GetInt("PriceToppingsDonut", 20);
        moneyText3.text = priceToppings.ToString();

        //update images
        int donutCounter = PlayerPrefs.GetInt("donutCounter", 0);
        Sprite[] donutImprovements = { speed1, speed2, speed3, speed4, speed5, speed6 };
        donutImprovement.sprite = donutImprovements[donutCounter];

        int customerCounter = PlayerPrefs.GetInt("customerCounterDonut", 0);
        selectImageCustomers(customerCounter);

        int toppingCounter = PlayerPrefs.GetInt("toppingCounterDonut", 0);
        selectImageToppings(toppingCounter);
    }

    void selectImageCustomers(int customerCounter)
    {
        Sprite[] customerImprovements = { money1, money2, money3, money4, money5 };
        if (customerCounter < 3)
        {
            coinImprovement.gameObject.SetActive(true);
            billImprovement.gameObject.SetActive(false);
            coinImprovement.sprite = customerImprovements[customerCounter];
        }
        else
        {
            billImprovement.gameObject.SetActive(true);
            coinImprovement.gameObject.SetActive(false);
            billImprovement.sprite = customerImprovements[customerCounter];
        }
    }

    void selectImageToppings(int toppingCounter)
    {
        if (toppingCounter == 0)
        {
            impr1.gameObject.SetActive(true);
            impr2.gameObject.SetActive(false);
            impr3.gameObject.SetActive(false);
            impr4.gameObject.SetActive(false);
            impr5.gameObject.SetActive(false);
        }
        else if (toppingCounter == 1)
        {
            impr1.gameObject.SetActive(false);
            impr2.gameObject.SetActive(true);
            impr3.gameObject.SetActive(false);
            impr4.gameObject.SetActive(false);
            impr5.gameObject.SetActive(false);
        }
        else if (toppingCounter == 2)
        {
            impr1.gameObject.SetActive(false);
            impr2.gameObject.SetActive(false);
            impr3.gameObject.SetActive(true);
            impr4.gameObject.SetActive(false);
            impr5.gameObject.SetActive(false);
        }
        else if (toppingCounter == 3)
        {
            impr1.gameObject.SetActive(false);
            impr2.gameObject.SetActive(false);
            impr3.gameObject.SetActive(false);
            impr4.gameObject.SetActive(true);
            impr5.gameObject.SetActive(false);
        }
        else if (toppingCounter == 4)
        {
            impr1.gameObject.SetActive(false);
            impr2.gameObject.SetActive(false);
            impr3.gameObject.SetActive(false);
            impr4.gameObject.SetActive(false);
            impr5.gameObject.SetActive(true);
        }
    }

    public void improveCoffee()
    {
        int price = PlayerPrefs.GetInt("PriceCoffee", 20);
        int coffeeCounter = PlayerPrefs.GetInt("coffeeCounter", 0);
        //check if user has enough money
        bool coffee = checkMoney(price);
        if (coffee == true)
        {
            int newPrice = incrementPrice(price);
            PlayerPrefs.SetInt("PriceCoffee", newPrice);
            moneyText1.text = newPrice.ToString();
            //cambiar imagen progreso
            Sprite[] coffeeImprovements = { speed1, speed2, speed3, speed4, speed5, speed6 };
            coffeeCounter++;
            coffeeImprovement.sprite = coffeeImprovements[coffeeCounter];
            PlayerPrefs.SetInt("coffeeCounter", coffeeCounter);
            //make coffee machines faster (less clicks)
            if (coffeeCounter == 1)
            {
                PlayerPrefs.SetFloat("coffeeClicks", 0.04f);
            } else if (coffeeCounter == 2)
            {
                PlayerPrefs.SetFloat("coffeeClicks", 0.05f);
            } else if (coffeeCounter == 3)
            {
                PlayerPrefs.SetFloat("coffeeClicks", 0.067f);
            } else if (coffeeCounter == 4)
            {
                PlayerPrefs.SetFloat("coffeeClicks", 0.1f);
            } else if (coffeeCounter == 5)
            {
                PlayerPrefs.SetFloat("coffeeClicks", 0.2f);
            }   
        }
    }

    public void improveDonut()
    {
        int price = PlayerPrefs.GetInt("PriceDonut", 20);
        int donutCounter = PlayerPrefs.GetInt("donutCounter", 0);
        //check if user has enough money
        bool donut = checkMoney(price);
        if (donut == true)
        {
            int newPrice = incrementPrice(price);
            PlayerPrefs.SetInt("PriceDonut", newPrice);
            moneyText1.text = newPrice.ToString();
            //cambiar imagen progreso
            Sprite[] donutImprovements = { speed1, speed2, speed3, speed4, speed5, speed6 };
            donutCounter++;
            donutImprovement.sprite = donutImprovements[donutCounter];
            PlayerPrefs.SetInt("donutCounter", donutCounter);
            //make coffee machines faster (less clicks)
            if (donutCounter == 1)
            {
                PlayerPrefs.SetFloat("donutClicks", 0.04f);
            }
            else if (donutCounter == 2)
            {
                PlayerPrefs.SetFloat("donutClicks", 0.05f);
            }
            else if (donutCounter == 3)
            {
                PlayerPrefs.SetFloat("donutClicks", 0.067f);
            }
            else if (donutCounter == 4)
            {
                PlayerPrefs.SetFloat("donutClicks", 0.1f);
            }
            else if (donutCounter == 5)
            {
                PlayerPrefs.SetFloat("donutClicks", 0.2f);
            }
        }
    }

    public void improveCustomers()
    {
        int price = PlayerPrefs.GetInt("PriceCustomers", 20);
        int customerCounter = PlayerPrefs.GetInt("customerCounter", 0);
        //check if user has enough money
        bool customers = checkMoney(price);
        if (customers == true)
        {
            int newPrice = incrementPrice(price);
            PlayerPrefs.SetInt("PriceCustomers", newPrice);
            moneyText2.text = newPrice.ToString();
            //cambiar imagen progreso
            Sprite[] customerImprovements = { money1, money2, money3, money4, money5 };
            customerCounter++;
            if (customerCounter < 3)
            {
                coinImprovement.gameObject.SetActive(true);
                billImprovement.gameObject.SetActive(false);
                coinImprovement.sprite = customerImprovements[customerCounter];
            }
            else
            {
                billImprovement.gameObject.SetActive(true);
                coinImprovement.gameObject.SetActive(false);
                billImprovement.sprite = customerImprovements[customerCounter];
            }

            PlayerPrefs.SetInt("customerCounter", customerCounter);
            //improve customer rattings (more money)
            if (customerCounter == 1)
            {
                PlayerPrefs.SetFloat("customerImprovement", 1.5f);
            } else if (customerCounter == 2)
            {
                PlayerPrefs.SetFloat("customerImprovement", 2f);
            } else if (customerCounter == 3)
            {
                PlayerPrefs.SetFloat("customerImprovement", 3.5f);
            } else if (customerCounter == 4)
            {
                PlayerPrefs.SetFloat("customerImprovement", 5f);
            }
        }
    }

    public void improveCustomersDonut()
    {
        int price = PlayerPrefs.GetInt("PriceCustomersDonut", 20);
        int customerCounter = PlayerPrefs.GetInt("customerCounterDonut", 0);
        //check if user has enough money
        bool customers = checkMoney(price);
        if (customers == true)
        {
            int newPrice = incrementPrice(price);
            PlayerPrefs.SetInt("PriceCustomersDonut", newPrice);
            moneyText2.text = newPrice.ToString();
            //cambiar imagen progreso
            Sprite[] customerImprovements = { money1, money2, money3, money4, money5 };
            customerCounter++;
            if (customerCounter < 3)
            {
                coinImprovement.gameObject.SetActive(true);
                billImprovement.gameObject.SetActive(false);
                coinImprovement.sprite = customerImprovements[customerCounter];
            }
            else
            {
                billImprovement.gameObject.SetActive(true);
                coinImprovement.gameObject.SetActive(false);
                billImprovement.sprite = customerImprovements[customerCounter];
            }

            PlayerPrefs.SetInt("customerCounterDonut", customerCounter);
            //improve customer rattings (more money)
            if (customerCounter == 1)
            {
                PlayerPrefs.SetFloat("customerImprovementDonut", 1.5f);
            }
            else if (customerCounter == 2)
            {
                PlayerPrefs.SetFloat("customerImprovementDonut", 2f);
            }
            else if (customerCounter == 3)
            {
                PlayerPrefs.SetFloat("customerImprovementDonut", 3.5f);
            }
            else if (customerCounter == 4)
            {
                PlayerPrefs.SetFloat("customerImprovementDonut", 5f);
            }
        }
    }

    public void improveToppings()
    {
        int price = PlayerPrefs.GetInt("PriceToppings", 20);
        int toppingCounter = PlayerPrefs.GetInt("toppingCounter", 0);
        //check if user has enough money
        bool toppings = checkMoney(price);
        if (toppings == true)
        {
            int newPrice = incrementPrice(price);
            PlayerPrefs.SetInt("PriceToppings", newPrice);
            moneyText3.text = newPrice.ToString();
            //cambiar imagen progreso
            toppingCounter++;
            PlayerPrefs.SetInt("toppingCounter", toppingCounter);
            selectImageToppings(toppingCounter);
            //improve toppings (more variety)
            PlayerPrefs.SetInt("avaiableToppings", (toppingCounter+1));
        }
    }

    public void improveToppingsDonut()
    {
        int price = PlayerPrefs.GetInt("PriceToppingsDonut", 20);
        int toppingCounter = PlayerPrefs.GetInt("toppingCounterDonut", 0);
        //check if user has enough money
        bool toppings = checkMoney(price);
        if (toppings == true)
        {
            int newPrice = incrementPrice(price);
            PlayerPrefs.SetInt("PriceToppingsDonut", newPrice);
            moneyText3.text = newPrice.ToString();
            //cambiar imagen progreso
            toppingCounter++;
            PlayerPrefs.SetInt("toppingCounterDonut", toppingCounter);
            selectImageToppings(toppingCounter);
            //improve toppings (more variety)
            PlayerPrefs.SetInt("avaiableToppingsDonut", (toppingCounter + 1));
        }
    }

    bool checkMoney(int price)
    {
        int money = PlayerPrefs.GetInt("Coins", 0);
        if (money < price)
        {
            errorMsg.SetActive(true);
            return false;
        } else
        {
            money -= price;
            PlayerPrefs.SetInt("Coins", money);
            int numCoins = PlayerPrefs.GetInt("Coins", 0);
            coins.text = numCoins.ToString();
            return true;
        }
    }

    /*public void warningMsgOk()
    {
        homeIcon_controller homeIcon = GameObject.Find("mapIcon").GetComponent<homeIcon_controller>();
        if (homeIcon != null)
        {
            homeIcon.homePressed();
            string actualShop = PlayerPrefs.GetString("actualShop", "coffee");
            if (actualShop.Equals("coffee"))
            {
                PlayerPrefs.SetString("nextShop", "donut");
            }
            else if (actualShop.Equals("donut"))
            {
                PlayerPrefs.SetString("nextShop", "iceCream");
            }
            else if (actualShop.Equals("iceCream"))
            {
                PlayerPrefs.SetString("nextShop", "bakery");
            }
        }
    }*/

    public void okErrorMsg()
    {
        errorMsg.SetActive(false);
    }

    int incrementPrice(int actualPrice)
    {
        int newPrice = (int)(actualPrice * 1.5f);
        return newPrice;
    }

    public void arrowPressed()
    {
        // Suscribirse al evento de carga de la escena
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("gameplayScene");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        string actualShop = PlayerPrefs.GetString("actualShop", "coffee");
        
        if (scene.name == "gameplayScene")
        {
            // Buscar el objeto con el script 'gameplayScene_Controller'
            gameplayScene_Controller gameplay = GameObject.Find("gameplayCamera").GetComponent<gameplayScene_Controller>();
            if (gameplay != null)
            {
                gameplay.startMovingCharacter = true;
                gameplay.manageCharacter();
                if (actualShop.Equals("coffee"))
                {
                    gameplay.manageTicket();
                } else if (actualShop.Equals("donut"))
                {
                    gameplay.manageTicketDonut();
                }
                    
            }
        }
        // Desuscribirse del evento para evitar múltiples suscripciones
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
