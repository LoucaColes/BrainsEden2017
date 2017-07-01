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
    [SerializeField]
    UiManager UI;

    public GameState state = GameState.Selection;

    public GameObject[] Players;
    public Transform[] PlayersStartingPoints;
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
        for (int i = 1; i <= Mathf.Min(maxPlayers, Input.GetJoystickNames().Length); i++)
        {
            if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), "Joystick"+i+"Button0")))
            {
                if (Players[i-1] == null)
                {
                    Players[i-1] = Instantiate(PlayerPrefab);
                    Players[i - 1].transform.position = PlayersStartingPoints[i - 1].position;
                    Players[i - 1].transform.rotation = PlayersStartingPoints[i - 1].rotation;
                    Players[i - 1].GetComponent<PlayerController>().playerNumber = i;
                    UI.containers[i-1] = Players[i-1].GetComponent<EnergyContainerPlayer>();
                }
                else
                {
                    //Set ready
                    playersReady[i-1] = !playersReady[i-1];
                }
            }
        }

        int readyNum = 0;
        int currPlayers = 0;
        for (int i = 1; i <= Mathf.Min(maxPlayers, Input.GetJoystickNames().Length); i++)
        {
            if (Players[i] != null)
            {
                currPlayers++;
                if (playersReady[i])
                {
                    readyNum++;
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
