using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image[] m_BaseImage;
   
    public Camera m_Cam;

    public float worldScreenHeight;
    public float worldScreenWidth;
    public float newLocalScale;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < m_BaseImage.Length; i++)
        {
            //m_BaseImage[i].color = new Color(m_BaseImage[i].color.r, m_BaseImage[i].color.g, m_BaseImage[i].color.b, 100.00f);
           /* if (m_BaseImage[i])
            {
                worldScreenHeight = (float)(m_Cam.orthographicSize * 4.0);
                worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
                newLocalScale = (worldScreenWidth / m_BaseImage[i].sprite.bounds.size.x);
                m_BaseImage[i].transform.localScale = new Vector3(newLocalScale, newLocalScale, 1);
            }*/


        }



    }

    // Update is called once per frame
    void Update()
    {

    }







}
