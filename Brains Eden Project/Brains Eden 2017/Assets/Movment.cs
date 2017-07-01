using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour {
  
    private Rigidbody RB;
    public float speed;
    public int ControllerNum;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // RB.AddForce(new Vector3(Input.GetAxis("Horizontal"),0, Input.GetAxis("Vertical")) *Time.deltaTime*(speed*10));
        transform.position += new Vector3(Input.GetAxis("Horizontal" + ControllerNum), 0, Input.GetAxis("Vertical" + ControllerNum)) * Time.deltaTime * (speed/10);

        float t_rx = Input.GetAxis("RHorizontal"+ ControllerNum);
        float t_ry = Input.GetAxis("RVertical"+ ControllerNum);

        transform.LookAt(transform.position + new Vector3(t_rx, 0, -t_ry));

        //if (Input.GetJoystickNames()[ControllerNum].Contains("Xbox One"))
        //{
        //    Debug.Log((Input.GetAxis("RTrigger" + ControllerNum)+1)/2);
        //}
      
      
      
    }
    public void setSpeed(float m_speed)
    {
        speed = m_speed;
    }

}
