using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject snakeHead;
    public GameObject food;
    public GameObject tailPrefab;

    public int gridSize = 20;

    private List<GameObject> tailObjects = new List<GameObject>();

    private Vector2 foodPosition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SpawnFood();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void SpawnFood()
    {
        foodPosition = new Vector2(Random.Range(-gridSize / 2, gridSize / 2), Random.Range(-gridSize / 2, gridSize / 2));
        Instantiate(food, foodPosition, Quaternion.identity);
    }

    public void AddTail()
    {
        GameObject tailObject = Instantiate(tailPrefab, tailObjects[tailObjects.Count - 1].transform.position, Quaternion.identity);
        tailObjects.Add(tailObject);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}