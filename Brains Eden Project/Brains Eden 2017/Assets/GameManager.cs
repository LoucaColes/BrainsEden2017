using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Transform[] PlayersStartingPoints;
    protected bool[] playersReady;

    public int maxPlayers;

<<<<<<< HEAD
	// Use this for initialization
	void Start () {
=======
    public float gameTime;
    private float gameTimer;

    public float gameOverTime;
    private float gameOverTimer;

    public GameObject gameCanvas;
    public GameObject gameOverCanvas;

    public GameObject[] bats;
    // Use this for initialization
    private void Start()
    {
>>>>>>> 95f0e9f3983fa6572bdac068374c91df3f8a6b1a
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
<<<<<<< HEAD

=======
        gameCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);

        bool continueSort=true;
        while (continueSort)
        {
            for (var i = 0; i < 4; i++)
            {
                for (var j = i + 1; j < 4; j++)
                {
                    if (bats[i].GetComponent<EnergyContainer>().energy > bats[j].GetComponent<EnergyContainer>().energy)
                    {
                        continueSort = true;
                        float leftMost = bats[i].GetComponent<EnergyContainer>().energy;
                        bats[i].GetComponent<EnergyContainer>().energy = bats[j].GetComponent<EnergyContainer>().energy;
                        bats[j].GetComponent<EnergyContainer>().energy = leftMost;
                    }
                    else continueSort = false;
                }
            }
        }

        foreach (Transform child in gameOverCanvas.transform)
        {
            switch (child.gameObject.name)
            {
                case "1":
                    child.gameObject.GetComponent<Text>().text = bats[0].GetComponent<EnergyContainer>().energy.ToString()+ 
                        bats[0].GetComponent<Renderer>().material.ToString();
                    break;
                case "2":
                    child.gameObject.GetComponent<Text>().text = bats[1].GetComponent<EnergyContainer>().energy.ToString() + 
                        bats[1].GetComponent<Renderer>().material.ToString();
                    break;
                case "3":
                    child.gameObject.GetComponent<Text>().text = bats[2].GetComponent<EnergyContainer>().energy.ToString() +
                        bats[2].GetComponent<Renderer>().material.ToString();
                    break;
                case "4":
                    child.gameObject.GetComponent<Text>().text = bats[3].GetComponent<EnergyContainer>().energy.ToString() + 
                        bats[3].GetComponent<Renderer>().material.ToString();
                    break;
                default:
                    break;
            }
        }
        gameOverTimer += Time.deltaTime;
        if (gameOverTimer >= gameOverTime)
        {
            //go to next state
            print("time finished");
            state = GameState.Return;
        }
>>>>>>> 95f0e9f3983fa6572bdac068374c91df3f8a6b1a
    }

    void UpdateGameOver()
    {

    }
}
