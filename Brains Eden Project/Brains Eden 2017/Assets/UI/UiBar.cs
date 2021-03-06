﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiBar : MonoBehaviour
{

    public Image m_bar;
    public float m_Max = 100f;
    public float m_current = 100f;
    public float m_ScrollSpeed = 0.5f;



    // Use this for initialization
    void Start()
    {
        m_bar = gameObject.GetComponent<Image>();
    }


    void Update()
    {
        Decreacebar();
       // float m_offSet = Time.time * m_ScrollSpeed;
        //m_bar.material.SetTextureOffset("_MainTex", new Vector2(m_offSet, 0));
    }

    public void SetHealthBar(float _health, float _max)
    {
        m_current = _health;
        m_Max = _max;
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
