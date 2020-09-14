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
    public static int ballsInGame;

    // Game State
    private bool gameover;

    /*
    // Brick Range
    [Range(1,29)]
    [SerializeField] int brickNumbersH;
    [Range(1, 20)]
    [SerializeField] int brickNumbersV;
    */


    public static GameManager instance = null;
    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        NoBalls();
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(0);
    }

    private void StartGame()
    {
        gameover = false;

        p1 = Instantiate(playerPrefab);

        Instantiate(ballPrefab, new Vector2(p1.transform.position.x, p1.transform.position.y + 0.15f), Quaternion.identity);
        ballsInGame++;

        BrickCreation();
    }

    private void BrickCreation()
    {
        // Creates a group for bricks
        GameObject brickGroup = new GameObject("Brick Group");

        // Creates every single brick
        for (int i = 1; i <= SliderBricksH.bricksH; i++)
        {
            for (int j = 1; j <= SliderBricksV.bricksV; j++)
            {
                GameObject thisBrick = Instantiate(brickPrefab, new Vector3(i * 0.60f, j * 0.20f , 0), Quaternion.identity);
                thisBrick.transform.SetParent(brickGroup.transform);
            }
        }

        // Centers the group
        brickGroup.transform.position = new Vector3(0 - 0.30f - ((SliderBricksH.bricksH * 0.60f) / 2), 0.75f, 0f);
    }

    private void NoBalls()
    {
        if (ballsInGame == 0)
        {
            Invoke("ResetGame", 1f);
        }
    }

    private void ResetGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

}
