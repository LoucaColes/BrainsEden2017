﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyContainer : MonoBehaviour {

    [SerializeField]
    public float maxEnergy;
    [SerializeField]
    public float energy;


    // Use this for initialization
    protected virtual void Start()
    {

    }

    void changeEnergy(float change)
    {
        energy += change;
        if (energy <= 0.0f)
        {
            energy = 0.0f;
            energyEmpty();
        }
        if (energy >= maxEnergy)
        {
            energy = maxEnergy;
            energyFull();
        }

    }

    protected virtual void energyFull()
    {
        
    }

    protected virtual void energyEmpty()
    {

    }
}
