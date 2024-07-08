using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class homeIcon_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void homePressed()
    {
        // Suscribirse al evento de carga de la escena
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("mainScene");
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "gameplayScene")
        {
            // Buscar el objeto con el script 'gameplayScene_Controller'
            mainScene_Controller main = GameObject.Find("mainCamera").GetComponent<mainScene_Controller>();
            if (main != null)
            {
                main.chargeShops();
            }
        }
        // Desuscribirse del evento para evitar múltiples suscripciones
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
