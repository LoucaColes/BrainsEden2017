using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    [SerializeField]
    public GameManager m_GM;

    public Image[] m_ImageBar;
    public Image[] m_images;


    // Use this for initialization
    void Start()
    {
        // m_ImageBar = new Image[4];
        for (int i = 0; i < m_images.Length; i++)
        {
           // m_images[i].gameObject.SetActive(false);
            
            
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (m_GM != null)
        {
            for (int i = 0; i < m_GM.Players.Length; i++)
            {
                if (m_GM.Players[i] != null)
                {

                    m_ImageBar[i].GetComponent<UiBar>().SetHealthBar(m_GM.Players[i].GetComponent<EnergyContainer>().energy,
                                                                    m_GM.Players[i].GetComponent<EnergyContainer>().maxEnergy);
                    m_images[i].gameObject.SetActive(true);
                }
               // else
                  //  m_images[i].gameObject.SetActive(false);
            }
        }
    }
}
