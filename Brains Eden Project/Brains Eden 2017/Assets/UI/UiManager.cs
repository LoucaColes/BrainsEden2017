using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    [SerializeField]
    public GameManager m_GM;
    public GameObject[] m_GmPlayer;
    public EnergyContainer[] m_Ec;

    public Image[] m_ImageBar;


    // Use this for initialization
    void Start()
    {
        if (m_GmPlayer != null)
            m_GmPlayer = m_GM.Players;
        else
            print("No Players");

        for(int i = 0;i<m_GmPlayer.Length;i++)
        {
            m_Ec[i] = m_GmPlayer[i].GetComponent<EnergyContainer>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < m_Ec.Length; i++)
        {
            m_ImageBar[i].GetComponent<UiBar>().SetHealthBar(m_Ec[i].energy, m_Ec[i].maxEnergy);
        }
    }
}
