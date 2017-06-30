using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    private Transform m_rayPoint;

    public float m_rayDistance;

    // Use this for initialization
    private void Start()
    {
        m_rayPoint = transform.FindChild("RayPoint");
    }

    // Update is called once per frame
    private void Update()
    {
        float t_rx = Input.GetAxis("Horizontal");
        float t_ry = Input.GetAxis("Vertical");

        Vector3 t_dir = new Vector3(t_rx, 0, t_ry);

        RaycastHit t_hit;

        if (Physics.Raycast(m_rayPoint.position, t_dir, out t_hit))
        {
            if (t_hit.collider.tag == "Player")
            {
                print("Player Hit");
            }
        }

        Debug.DrawRay(m_rayPoint.position, t_dir * m_rayDistance, Color.green);
    }
}