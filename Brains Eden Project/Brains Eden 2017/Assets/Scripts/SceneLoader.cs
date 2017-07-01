using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader m_sceneLoader;
    public string[] m_sceneNames;

    // Use this for initialization
    private void Awake()
    {
        if (m_sceneLoader)
        {
            Destroy(m_sceneLoader);
            m_sceneLoader = this;
        }
        else
        {
            m_sceneLoader = this;
        }
    }

    public void LoadMainMenu()
    {
    }

    public void LoadPlayerSelect()
    {
    }

    public void LoadArena1()
    {
    }

    public void LoadArena2()
    {
    }

    public void LoadArena3()
    {
    }
}