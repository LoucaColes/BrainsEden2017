using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    [SerializeField]
    public GameManager m_GM;

    public Image[] m_ImageBar;


    // Use this for initialization
    void Start()
    {
       // m_ImageBar = new Image[4];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < m_GM.Players.Length; i++)
        {
            if (m_GM.Players[i] != null)
            {
                m_ImageBar[i].GetComponent<UiBar>().SetHealthBar(m_GM.Players[i].GetComponent<EnergyContainer>().energy,
                                                                m_GM.Players[i].GetComponent<EnergyContainer>().maxEnergy);
            }
        }
    }
}
