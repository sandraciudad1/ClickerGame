using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopsController : MonoBehaviour
{
    [SerializeField] Button donutShop;
    [SerializeField] Button iceCreamShop;
    [SerializeField] Button bakeryShop;

    // Start is called before the first frame update
    void Start()
    {
        donutShop.interactable = false;
        iceCreamShop.interactable = false;
        bakeryShop.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        string shop = PlayerPrefs.GetString("nextShop", "coffee");
        if (shop.Equals("donut"))
        {
            donutShop.interactable = true;
        } else if (shop.Equals("iceCream"))
        {
            iceCreamShop.interactable = true;
        } else if (shop.Equals("bakery"))
        {
            bakeryShop.interactable = true;
        }
    }
}
