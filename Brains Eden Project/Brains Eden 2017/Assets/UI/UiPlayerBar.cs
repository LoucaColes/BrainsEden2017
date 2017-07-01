using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiPlayerBar : MonoBehaviour
{
    public Image m_bar;
    public float m_Max = 100f;
    public float m_current = 100f;
  
    // Use this for initialization
    void Start()
    {
        m_bar = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        m_current = gameObject.GetComponent<EnergyContainer>().energy;
        m_Max = gameObject.GetComponent<EnergyContainer>().maxEnergy;
        Decreacebar();

    }
    

    void Decreacebar()
    {
        float m_Val = m_current / m_Max;
        SetBar(m_Val);
    }

    void SetBar(float _amount)
    {
        if (_amount > 1 || _amount < 0)
            return;
        m_bar.fillAmount = _amount;
    }
}