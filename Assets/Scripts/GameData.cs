using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    //initial values of random generation
    public int randomCharacter;
    public int randomCoffeeType;
    public int randomCreamType;
    public int randomTopping;
    public int randomGlazed;
    public int randomToppingDonut;

    //user values
    public int coffeeType;
    public int creamType;
    public int topping;
    public int glazed;
    public int toppingDonut;

    //total coins
    public int coins;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
