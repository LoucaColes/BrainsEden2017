using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    [SerializeField]
    public GameManager m_GM;

<<<<<<< HEAD
    public Image[] m_ImageBar;
    public Image[] m_images;
=======
    public EnergyContainer[] containers;

    public UiBar[] m_ImageBar;
>>>>>>> ebf7deacaef9d45a87fa2c276543c392c699a27d


    // Use this for initialization
    void Start()
    {
<<<<<<< HEAD
        // m_ImageBar = new Image[4];
        for (int i = 0; i < m_images.Length; i++)
        {
           // m_images[i].gameObject.SetActive(false);
            
            
        }
       
=======
        containers = new EnergyContainer[4];
       // m_ImageBar = new Image[4];
>>>>>>> ebf7deacaef9d45a87fa2c276543c392c699a27d
    }

    // Update is called once per frame
    void Update()
    {
        if (m_GM != null)
        {
            for (int i = 0; i < m_GM.Players.Length; i++)
            {
<<<<<<< HEAD
                if (m_GM.Players[i] != null)
                {

                    m_ImageBar[i].GetComponent<UiBar>().SetHealthBar(m_GM.Players[i].GetComponent<EnergyContainer>().energy,
                                                                    m_GM.Players[i].GetComponent<EnergyContainer>().maxEnergy);
                    m_images[i].gameObject.SetActive(true);
                }
               // else
                  //  m_images[i].gameObject.SetActive(false);
=======
                if (containers[i] != null)
                {
                    m_ImageBar[i].SetHealthBar(containers[i].energy, containers[i].maxEnergy);
                }
>>>>>>> ebf7deacaef9d45a87fa2c276543c392c699a27d
            }
        }
    }
}
