using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnergyTransfer))]
public class EnergyContainerPlayer : EnergyContainer {

    bool alive;

    Renderer playerRenderer;
    GameObject explosionParticle;

    protected override void Start()
    {
        base.Start();
        playerRenderer = GetComponent<Renderer>();
    }

    protected override void energyFull()
    {
        //Explode
    }

    protected override void energyEmpty()
    {
        //Stop Functioning
    }
}
