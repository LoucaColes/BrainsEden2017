using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiBar : MonoBehaviour
{

    public Image m_bar;
    public float m_Max = 100f;
    public float m_current = 100f;




    // Use this for initialization
    void Start()
    {
        //m_current = s_Max;
    }


    void Update()
    {

        Decreacebar();

    }

    public void SetHealthBar(float _health, float _max)
    {
        m_current = _health;
        m_Max = _max;
        //Decreacebar();
    }


    void Decreacebar()
    {
        //m_current -= _dec;
        float m_Val = m_current / m_Max;
        SetBar(m_Val);
    }

    void SetBar(float _amount)
    {
        if (_amount > 1 || _amount < 0)
        {
            return;
        }
        m_bar.fillAmount = _amount;
    }
}
