using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiBar : MonoBehaviour
{

    public Image m_bar;
    public float m_Max = 100f;
    
    public float m_current = 0f;


    // Use this for initialization
    void Start()
    {
        m_current = m_Max;

    }



  


    void Decreacebar(float _dec)
    {
        m_current -= _dec;
        SetBar(m_current / m_Max);
    }

    void SetBar(float _amount)
    {
        if(_amount > 1 || _amount < 0)
        {
            return;
        }
        m_bar.fillAmount = m_current;
    }
}
