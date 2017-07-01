using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    private Transform m_rayPoint;
    private Transform m_testPlayer;

    private Collider m_colliderRadius;
    public GameObject m_particle;
    private GameObject m_currParticle;

    public float m_rayDistance;
    public float m_speed;

    public int m_layerId;
    private int m_layerMask;

    private float m_bezierTime;

    // Use this for initialization
    private void Start()
    {
        m_rayPoint = transform.FindChild("RayPoint");
        m_colliderRadius = transform.FindChild("ColliderRadius").GetComponent<Collider>();
        transform.FindChild("ColliderRadius").gameObject.layer = m_layerId;
        m_layerMask = 1 << 12;
        m_layerMask = ~m_layerMask;
        m_bezierTime = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 t_dir = m_rayPoint.forward;
        if (Input.GetKey(KeyCode.Space))
        {
            ActivateBezier(false, 0.5f);
        }
        else if (Input.GetKey(KeyCode.KeypadEnter))
        {
            ActivateBezier(true, 0.1f);
        }
        else
        {
            Destroy(m_currParticle);
            m_currParticle = null;
        }

        Debug.DrawRay(m_rayPoint.position, t_dir * m_rayDistance, Color.green);
    }

    public void ActivateBezier(bool _reverse, float _strength)
    {
        Vector3 t_dir = m_rayPoint.forward;
        if (m_bezierTime == 0)
        {
            m_currParticle = (GameObject)Instantiate(m_particle, m_rayPoint.position, Quaternion.identity);
        }
        m_bezierTime += (_strength / 10f);
        if (m_bezierTime >= 1)
        {
            m_bezierTime = 0;
            Destroy(m_currParticle);
            m_currParticle = null;
        }

        if (GetTarget() != null)
        {
            m_testPlayer = GetTarget().transform;

            if (Vector3.Distance(m_rayPoint.position, m_testPlayer.position) > m_rayDistance)
            {
                m_testPlayer = null;
                Destroy(m_currParticle);
                m_currParticle = null;
            }
            else
            {
                Vector3 t_midPoint = m_rayPoint.position + (t_dir * m_rayDistance);
                if (_reverse)
                {
                    if (m_currParticle)
                    {
                        m_currParticle.transform.position = Bezier(m_testPlayer.position, t_midPoint, m_rayPoint.position, m_bezierTime);
                    }
                }
                else
                {
                    if (m_currParticle)
                    {
                        m_currParticle.transform.position = Bezier(m_rayPoint.position, t_midPoint, m_testPlayer.position, m_bezierTime);
                    }
                }
                Debug.DrawLine(t_midPoint, m_testPlayer.position, Color.red);
            }
        }
        else
        {
            Destroy(m_currParticle);
            m_currParticle = null;
        }
    }

    public GameObject GetTarget()
    {
        RaycastHit t_hit;
        Vector3 t_dir = m_rayPoint.forward;

        if (Physics.Raycast(m_rayPoint.position, t_dir, out t_hit, m_rayDistance, m_layerMask))
        {
            if (t_hit.collider.tag == "ColRadius")
            {
                m_testPlayer = t_hit.collider.transform;
                if (Vector3.Distance(m_rayPoint.position, m_testPlayer.position) < m_rayDistance)
                {
                    return m_testPlayer.gameObject;
                }
            }
        }
        return null;
    }

    private Vector3 Bezier(Vector3 _initPoint, Vector3 _midPoint, Vector3 _endPoint, float _time)
    {
        Vector3 t_bezierTime = new Vector3();
        t_bezierTime.x = Mathf.Pow(1 - _time, 2) * _initPoint.x + (1 - _time) * 2 * _time * _midPoint.x + _time * _time * _endPoint.x;
        t_bezierTime.y = _initPoint.y;
        t_bezierTime.z = Mathf.Pow(1 - _time, 2) * _initPoint.z + (1 - _time) * 2 * _time * _midPoint.z + _time * _time * _endPoint.z;
        return t_bezierTime;
    }
}