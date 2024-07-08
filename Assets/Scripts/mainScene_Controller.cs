using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainScene_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void coffeeShop()
    {
        // Suscribirse al evento de carga de la escena
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("gameplayScene");

        //reset playerprefs
        /*PlayerPrefs.SetInt("Coins", 0);
        PlayerPrefs.SetString("actualShop", "coffee");
        PlayerPrefs.SetInt("avaiableToppings", 1);
        PlayerPrefs.SetFloat("coffeeClicks", 0.033f);
        PlayerPrefs.SetFloat("customerImprovement", 1f);
        PlayerPrefs.SetInt("coffeeCounter", 0);
        PlayerPrefs.SetInt("customerCounter", 0);
        PlayerPrefs.SetInt("toppingCounter", 0);
        PlayerPrefs.SetInt("PriceCoffee", 20);
        PlayerPrefs.SetInt("PriceCustomers", 20);
        PlayerPrefs.SetInt("PriceToppings", 20);
        PlayerPrefs.SetInt("fullCoffee", 0);
        PlayerPrefs.SetInt("fullCustomer", 0);
        PlayerPrefs.SetInt("fullTopping", 0);
        */
    }

    public void donutShop()
    {
        //reset playerprefs
        /*PlayerPrefs.SetInt("avaiableToppingsDonut", 1);
        PlayerPrefs.SetFloat("donutClicks", 0.033f);
        PlayerPrefs.SetFloat("customerImprovementDonut", 1f);
        PlayerPrefs.SetInt("donutCounter", 0);
        PlayerPrefs.SetInt("customerCounterDonut", 0);
        PlayerPrefs.SetInt("toppingCounterDonut", 0);
        PlayerPrefs.SetInt("PriceDonut", 20);
        PlayerPrefs.SetInt("PriceCustomersDonut", 20);
        PlayerPrefs.SetInt("PriceToppingsDonut", 20);
        PlayerPrefs.SetString("actualShop", "donut");
        */

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
                } 
                else if (actualShop.Equals("donut"))
                {
                    gameplay.manageTicketDonut();
                }
                
            }
        }
        // Desuscribirse del evento para evitar múltiples suscripciones
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void chargeShops()
    {

    }
}
