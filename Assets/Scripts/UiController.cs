using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public static UiController Instance;
    
    //MENU DE PAUSA Y MENU DE INVENTARIO
    public GameObject menuPause;
    public GameObject inventory;

    //TEXTO DE CANTIDAD DE TINERO
    public TextMeshProUGUI cantidad;
    
    //GESTIONAR CORAZONES
    public Sprite secuencyOne;
    public Sprite secuencyTwo;
    public Sprite secuencyThree;
    public Sprite secuencyFour;
    public Sprite secuencyfive;
    public Sprite secuencySix;
    public Sprite secuencySeven;
    public Image lifeUi;
    
    private Dictionary<int, Sprite> _secuencys;


    public void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        menuPause.SetActive(false);
        _secuencys = new Dictionary<int, Sprite>();
        
        _secuencys.Add(0,secuencyOne);
        _secuencys.Add(1,secuencyTwo);
        _secuencys.Add(2,secuencyThree);
        _secuencys.Add(3,secuencyFour);
        _secuencys.Add(4,secuencyfive);
        _secuencys.Add(5,secuencySix);
        _secuencys.Add(6,secuencySeven);
        
    }

    
    

    public void UpdateHeal()
    {
        int health = HealthController.Instance.health;
        lifeUi.sprite= _secuencys[health];
    }

    private void Update()
    {
        //Controlar si se pulsa Espace, para abrir opciones
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuPause.SetActive(true);
            Time.timeScale = 0f;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            AbrirInventory();
        }else if (Input.GetKeyUp(KeyCode.I))
        {
            CerrarInventory();
        }
        
        //CONTROLAMOS LA CANTIDAD DE ORO QUE TENEMOS
        countGold();
    }

    //Reanudar el juego
    public void Reanudar()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1f;
    }

    //ABRIR INVENTARIO
    public void AbrirInventory()
    {
        Time.timeScale = 0f;
        inventory.SetActive(true);
    }

    //CERRAR INVENTARIO
    public void CerrarInventory()
    {
        inventory.SetActive(false);
        Time.timeScale = 1f;
    }
    
    //SUMAR DINERO
    public void countGold()
    {
        cantidad.SetText(LevelController.Instance.gemsCollected+"");
    }

    
}
