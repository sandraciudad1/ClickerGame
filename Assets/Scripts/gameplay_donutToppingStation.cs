using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameplay_donutToppingStation : MonoBehaviour
{
    public Image progressBar;
    [SerializeField] Button arrowButton;

    //glazed
    [SerializeField] Image chocolateGlazed;
    [SerializeField] Image blueberryGlazed;
    [SerializeField] Image strawberryGlazed;

    //toppings
    [SerializeField] Button bananaBtn;
    [SerializeField] Button marshmallowBtn;
    [SerializeField] Button oreoBtn;
    [SerializeField] Button popcornBtn;
    [SerializeField] Button pretelBtn;
    [SerializeField] Image bananaImg;
    [SerializeField] Image marshmallowImg;
    [SerializeField] Image oreoImg;
    [SerializeField] Image popcornImg;
    [SerializeField] Image pretzelImg;

    // Start is called before the first frame update
    void Start()
    {
        GameData.Instance.toppingDonut = 0;
        activeButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeGlazed()
    {
        if(GameData.Instance.glazed == 1)
        {
            chocolateGlazed.gameObject.SetActive(true);
        } else if (GameData.Instance.glazed == 2)
        {
            blueberryGlazed.gameObject.SetActive(true);
        } else if (GameData.Instance.glazed == 3)
        {
            strawberryGlazed.gameObject.SetActive(true);
        }
    }

    public void activeButtons()
    {
        int avaiableToppings = PlayerPrefs.GetInt("avaiableToppingsDonut", 1);

        if (avaiableToppings == 1)
        {
            bananaBtn.gameObject.SetActive(true);
        }
        else if (avaiableToppings == 2)
        {
            bananaBtn.gameObject.SetActive(true);
            marshmallowBtn.gameObject.SetActive(true);
        }
        else if (avaiableToppings == 3)
        {
            bananaBtn.gameObject.SetActive(true);
            marshmallowBtn.gameObject.SetActive(true);
            oreoBtn.gameObject.SetActive(true);
        }
        else if (avaiableToppings == 4)
        {
            bananaBtn.gameObject.SetActive(true);
            marshmallowBtn.gameObject.SetActive(true);
            oreoBtn.gameObject.SetActive(true);
            popcornBtn.gameObject.SetActive(true);
        }
        else if (avaiableToppings == 5)
        {
            bananaBtn.gameObject.SetActive(true);
            marshmallowBtn.gameObject.SetActive(true);
            oreoBtn.gameObject.SetActive(true);
            popcornBtn.gameObject.SetActive(true);
            pretelBtn.gameObject.SetActive(true);
        }
    }

    public void incrementProgressBar(int index)
    {
        progressBar.fillAmount += 0.1f;
        progressBar.fillAmount = Mathf.Clamp(progressBar.fillAmount, 0f, 1f);
        if (progressBar.fillAmount >= 1f)
        {
            if (index == 1)
            {
                bananaImg.gameObject.SetActive(true);
            }
            else if (index == 2)
            {
                marshmallowImg.gameObject.SetActive(true);
            }
            else if (index == 3)
            {
                oreoImg.gameObject.SetActive(true);
            }
            else if (index == 4)
            {
                popcornImg.gameObject.SetActive(true);
            }
            else if (index == 5)
            {
                pretzelImg.gameObject.SetActive(true);
            }
            uninteractableButtons();
        }

    }

    public void uninteractableButtons()
    {
        bananaBtn.interactable = false;
        marshmallowBtn.interactable = false;
        oreoBtn.interactable = false;
        popcornBtn.interactable = false;
        pretelBtn.interactable = false;
    }

    public void banana()
    {
        Debug.Log("pressed banana");
        incrementProgressBar(1);
        GameData.Instance.toppingDonut = 1;
    }

    public void marshmallow()
    {
        incrementProgressBar(2);
        GameData.Instance.toppingDonut = 2;
    }

    public void oreo()
    {
        incrementProgressBar(3);
        GameData.Instance.toppingDonut = 3;
    }

    public void popcorn()
    {
        incrementProgressBar(4);
        GameData.Instance.toppingDonut = 4;
    }

    public void pretzel()
    {
        incrementProgressBar(5);
        GameData.Instance.toppingDonut = 5;
    }

    public void arrowPressed()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("recollectionScene");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "recollectionScene")
        {
            // Buscar el objeto con el script 'gameplayScene_Controller'
            recollectionScene recollection = GameObject.Find("recollectionCamera").GetComponent<recollectionScene>();
            if (recollection != null)
            {
                recollection.chargeDonut();
            }
        }
        // Desuscribirse del evento para evitar múltiples suscripciones
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
