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

        //Save last scene loaded
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    // Update is called once per frame
    void Update()
    {
        NoBalls();
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        Debug.Log(BallsInGame());
    }

    private void StartGame()
    {
        gameover = false;

        p1 = Instantiate(playerPrefab);

        if (FindObjectOfType<Ball>() == null)
        {
            Instantiate(ballPrefab, new Vector2(p1.transform.position.x, p1.transform.position.y + 0.15f), Quaternion.identity);
        }

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

    private int BallsInGame()
    {
        int count = 0;
        for (int i = 0; i < FindObjectsOfType<Ball>().Length; i++)
        {
            count++;
        }
        return count;
    }

    private void NoBalls()
    {
        if (BallsInGame() == 0)
        {
            Invoke("ResetLevel", 1f);
        }
    }

    private void ResetLevel()
    {
        Time.timeScale = 1f;
        LoadLastScene();
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        PlayerPrefs.SetString("last_scene", scene.name);
    }

    private void LoadLastScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("last_scene"));
    }

}
