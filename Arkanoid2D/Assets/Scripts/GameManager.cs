using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject brickPrefab;
    [SerializeField] private GameObject ballPrefab;

    // Player & Ball
    private GameObject p1;
    private GameObject ball;

    // Game State
    private bool gameover;

    // Brick Range
    [Range(1,29)]
    [SerializeField] int brickNumbersH;
    [Range(1, 20)]
    [SerializeField] int brickNumbersV;


    public static GameManager instance = null;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        OutOfPlay();
        if (Input.GetKeyDown(KeyCode.R)) ResetGame();
    }

    private void StartGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        gameover = false;

        p1 = Instantiate(playerPrefab) as GameObject;
        ball = Instantiate(ballPrefab) as GameObject;

        BrickCreation();
    }

    private void BrickCreation()
    {
        // Creates a group for bricks
        GameObject brickGroup = new GameObject("Brick Group");

        // Creates every single brick
        for (int i = 1; i <= brickNumbersH; i++)
        {
            for (int j = 1; j <= brickNumbersV; j++)
            {
                GameObject thisBrick = Instantiate(brickPrefab, new Vector3(i * 0.60f, j * 0.20f , 0), Quaternion.identity);
                thisBrick.transform.SetParent(brickGroup.transform);
            }
        }

        // Centers the group
        brickGroup.transform.position = new Vector3(0 - 0.30f - ((brickNumbersH * 0.60f) / 2), 0.75f, 0f);
    }

    private void OutOfPlay()
    {
        if (ball.transform.position.y < -5f)
        {
            Invoke("ResetGame", 1f);
        }
    }

    private void ResetGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
