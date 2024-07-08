using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameplay_toppingStation : MonoBehaviour
{
    public int creamType=0;
    private int topping = 0;
    public Image progressBar;
    [SerializeField] Button arrowButton;

    //creams
    [SerializeField] Image cream;
    [SerializeField] Sprite onlyCream;
    [SerializeField] Sprite chocolateCream;
    [SerializeField] Sprite caramelCream;
    [SerializeField] Sprite strawberryCream;

    //toppings
    [SerializeField] Image cherriesImg;
    [SerializeField] Image berriesImg;
    [SerializeField] Image mikadoImg;
    [SerializeField] Image nutsImg;
    [SerializeField] Image cookiesImg;

    //buttons
    [SerializeField] Button creamBtn;
    [SerializeField] Button chocolateSyrupBtn;
    [SerializeField] Button caramelSyrupBtn;
    [SerializeField] Button strawberrySyrupBtn;
    [SerializeField] Button cherriesBtn;
    [SerializeField] Button berriesBtn;
    [SerializeField] Button mikadoBtn;
    [SerializeField] Button nutsBtn;
    [SerializeField] Button cookiesBtn;


    // Start is called before the first frame update
    void Start()
    {
        GameData.Instance.topping = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementProgressBar(int index)
    {
        progressBar.fillAmount += 0.1f;
        progressBar.fillAmount = Mathf.Clamp(progressBar.fillAmount, 0f, 1f);
        if (progressBar.fillAmount >= 1f)
        {   
            if (index == 0)
            {
                activeButtons();
                changeCream(index);
                
                progressBar.fillAmount = 0;
            } else if(index >=1 && index <= 3)
            {
                changeCream(index);
                progressBar.fillAmount = 0;
            } else if (index == 4)
            {
                cherriesImg.gameObject.SetActive(true);
                cherriesBtn.interactable = false;
            }
            else if (index == 5)
            {
                berriesImg.gameObject.SetActive(true);
                berriesBtn.interactable = false;
            }
            else if (index == 6)
            {
                mikadoImg.gameObject.SetActive(true);
                mikadoBtn.interactable = false;
            }
            else if (index == 7)
            {
                nutsImg.gameObject.SetActive(true);
                nutsBtn.interactable = false;
            }
            else if (index == 8)
            {
                cookiesImg.gameObject.SetActive(true);
                cookiesBtn.interactable = false;
            }
            //uninteractableButtons();
        }

    }

    public void uninteractableButtons()
    {
        chocolateSyrupBtn.interactable = false;
        caramelSyrupBtn.interactable = false;
        strawberrySyrupBtn.interactable = false;
        cherriesBtn.interactable = false;
        berriesBtn.interactable = false;
        mikadoBtn.interactable = false;
        nutsBtn.interactable = false;
        cookiesBtn.interactable = false;
    }

    void changeCream(int index)
    {
        creamType = index;
        Sprite[] creams = { onlyCream, chocolateCream, caramelCream, strawberryCream };
        cream.sprite = creams[index];
        cream.gameObject.SetActive(true);
        if (index == 0)
        {
            creamBtn.interactable = false;
        } else
        {
            chocolateSyrupBtn.interactable = false;
            caramelSyrupBtn.interactable = false;
            strawberrySyrupBtn.interactable = false;
        }
    }

    public void activeButtons()
    {
        chocolateSyrupBtn.interactable = true;
        caramelSyrupBtn.interactable = true;
        strawberrySyrupBtn.interactable = true;
        cherriesBtn.interactable = true;
        berriesBtn.interactable = true;
        mikadoBtn.interactable = true;
        nutsBtn.interactable = true;
        cookiesBtn.interactable = true;

        int avaiableToppings = PlayerPrefs.GetInt("avaiableToppings", 1);
        
        if (avaiableToppings == 1)
        {
            cherriesBtn.gameObject.SetActive(true);
        } else if (avaiableToppings == 2)
        {
            cherriesBtn.gameObject.SetActive(true);
            berriesBtn.gameObject.SetActive(true);
        } else if (avaiableToppings == 3)
        {
            cherriesBtn.gameObject.SetActive(true);
            berriesBtn.gameObject.SetActive(true);
            mikadoBtn.gameObject.SetActive(true);
        } else if (avaiableToppings == 4)
        {
            cherriesBtn.gameObject.SetActive(true);
            berriesBtn.gameObject.SetActive(true);
            mikadoBtn.gameObject.SetActive(true);
            nutsBtn.gameObject.SetActive(true);
        } else if (avaiableToppings == 5)
        {
            cherriesBtn.gameObject.SetActive(true);
            berriesBtn.gameObject.SetActive(true);
            mikadoBtn.gameObject.SetActive(true);
            nutsBtn.gameObject.SetActive(true);
            cookiesBtn.gameObject.SetActive(true);
        }

        arrowButton.gameObject.SetActive(true);
    }

    public void creamBottle()
    {
        incrementProgressBar(0);
        GameData.Instance.creamType = 0;
    }

    public void chocolateSyrup()
    {
        incrementProgressBar(1);
        GameData.Instance.creamType = 1;
    }

    public void caramelSyrup()
    {
        incrementProgressBar(2);
        GameData.Instance.creamType = 2;
    }

    public void strawberrySyrup()
    {
        incrementProgressBar(3);
        GameData.Instance.creamType = 3;
    }

    public void cherries()
    {
        incrementProgressBar(4);
        GameData.Instance.topping = 1;
    }

    public void berries()
    {
        incrementProgressBar(5);
        GameData.Instance.topping = 2;
    }

    public void mikado()
    {
        incrementProgressBar(6);
        GameData.Instance.topping = 3;
    }

    public void nuts()
    {
        incrementProgressBar(7);
        GameData.Instance.topping = 4;
    }

    public void cookies()
    {
        incrementProgressBar(8);
        GameData.Instance.topping = 5;
    }

    public void arrowRecollection()
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
                recollection.chargeCoffee();
            }
        }
        // Desuscribirse del evento para evitar múltiples suscripciones
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
