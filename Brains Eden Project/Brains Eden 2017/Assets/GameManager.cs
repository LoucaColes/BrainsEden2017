using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Selection,
    Game,
    GameOver
}

public class GameManager : MonoBehaviour {

    [SerializeField]
    GameObject PlayerPrefab;

    public GameState state = GameState.Selection;

    public GameObject[] Players;
    protected bool[] playersReady;

    public int maxPlayers;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        Players = new GameObject[maxPlayers];
        playersReady = new bool[maxPlayers];

        for (int i = 0; i < playersReady.Length; i++)
        {
            playersReady[i] = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
        switch (state)
        {
            case GameState.Selection:
                UpdateSelection();
                break;
            case GameState.Game:
                UpdateGame();
                break;
            case GameState.GameOver:
                UpdateGameOver();
                break;
        }
	}

    void UpdateSelection()
    {
        for (int i = 0; i < Mathf.Min(maxPlayers, Input.GetJoystickNames().Length); i++)
        {
            if (Input.GetButtonDown("joystick " + i + " button 0") )
            {
                if (Players[i] == null)
                {
                    Players[i] = Instantiate(PlayerPrefab);
                }
                else
                {
                    //Set ready
                    playersReady[i] = !playersReady[i];
                }
            }
        }
    }

    void UpdateGame()
    {

    }

    void UpdateGameOver()
    {

    }
}
