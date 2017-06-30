using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    private Transform m_rayPoint;
    private Transform m_testPlayer;

    public float m_rayDistance;

    // Use this for initialization
    private void Start()
    {
        m_rayPoint = transform.FindChild("RayPoint");
    }

    // Update is called once per frame
    private void Update()
    {
        RaycastHit t_hit;

        Vector3 t_dir = m_rayPoint.forward;

        if (Physics.Raycast(m_rayPoint.position, t_dir, out t_hit))
        {
            if (t_hit.collider.tag == "Player")
            {
                print("Player Hit");
                m_testPlayer = t_hit.collider.transform;
            }
        }

        if (m_testPlayer)
        {
            Debug.DrawLine(m_rayPoint.position, m_testPlayer.position, Color.red);
        }

        Debug.DrawRay(m_rayPoint.position, t_dir * m_rayDistance, Color.green);
    }
}