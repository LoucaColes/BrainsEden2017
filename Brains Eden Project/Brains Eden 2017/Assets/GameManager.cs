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

    public int maxPlayers;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);


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
        for (int i = 0; i < maxPlayers; i++)
        {
            if (Input.GetButtonDown("joystick " + i + " button 0"))
            {

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
