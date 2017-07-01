using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnergyTransfer))]
[RequireComponent(typeof(EnergyContainerPlayer))]
[RequireComponent(typeof(Movment))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    int playerNumber = 0;
    // 0 = faulty, players = 1-4

    private float pushTrigger;
    private float pullTrigger;

	// Use this for initialization
	void Start () {
        GetComponent<Movment>().ControllerNum = playerNumber;
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetJoystickNames()[playerNumber].Contains("Xbox One"))
        {
            pushTrigger = (Input.GetAxis("RTrigger" + playerNumber)+1)/2;
        }
        else
        {
            pushTrigger = Input.GetAxis("RTrigger" + playerNumber);
        }

        if (Input.GetJoystickNames()[playerNumber].Contains("Xbox One"))
        {
            pullTrigger = (Input.GetAxis("LTrigger" + playerNumber) + 1) / 2;
        }
        else
        {
            pullTrigger = Input.GetAxis("LTrigger" + playerNumber);
        }

        if (pullTrigger > 0 || pushTrigger > 0)
        {
            GameObject other = null;

            if (other != null)
            {
                GetComponent<EnergyTransfer>().pushTo(other.GetComponent<EnergyContainer>(), pushTrigger);
                GetComponent<EnergyTransfer>().drainFrom(other.GetComponent<EnergyContainer>(), pullTrigger);
            }
        }
    }
}
