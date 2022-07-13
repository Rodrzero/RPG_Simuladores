using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Player : MonoBehaviour
{
    [SerializeField] private float totalWood;
    [SerializeField] private float currentWater;
    [SerializeField] private float waterLimit = 30;
    [SerializeField] private float woodLimit = 30;


    #region Encapsulamento
    public float TotalWood 
    { get => totalWood; set => totalWood = value; }

 public float TotalWater
    { get => currentWater; set => currentWater = value; }



 
    #endregion



    public void WaterLimit(float water)
    {
        if (currentWater <= waterLimit)
            currentWater += water;
    }

    public void WoodLimit(float wood)
    {
        if (totalWood <= woodLimit)
            totalWood += wood;
    }

 
}
