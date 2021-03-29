using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item{ public string name; } //Для примера
public class Player : MonoBehaviour //Класс для примера
{
    public static Player Singleton;
    [SerializeField] private float _myMoney;

    private void Awake()
    {
        Singleton = this;
        
    }

    public void AddMoney(float money)
    {
        _myMoney += money;
        Debug.Log("Вы получили - " + money );
    }

    public void AddItem(Item item)
    {
        //MyInventory.Add(item);
        Debug.Log("Вы получили - " +  item.name );
    }
}
