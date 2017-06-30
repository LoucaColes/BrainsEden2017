using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour {
  
    private Rigidbody RB;
    public float speed;
    public int Cont;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
         RB.AddForce(new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical")) *Time.deltaTime*(speed*100));
        float t_rx = Input.GetAxis("RHorizontal"+Cont);
        float t_ry = Input.GetAxis("RVertical"+Cont);

        transform.LookAt(transform.position + new Vector3(t_rx, 0,-t_ry));
      
    }

}
