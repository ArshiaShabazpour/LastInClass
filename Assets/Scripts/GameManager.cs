using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float currentSpeed = 0f;
    public float maxSpeed = 10f;
    public float acceleration = 2f;
    public float fuel = 100f;
    public float score = 0f;

    public float spawnInterval = 0.5f; 
    private float _spawnTimer;

    public Renderer roadRenderer;
    public TextMeshProUGUI fuelText;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public GameObject enemyPrefab;

    public bool IsGameOver { get; private set; } = false;

    private float _roadOffset;

    void Awake() => Instance = this;

    void Update()
    {
        if (IsGameOver) return;

        if (currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }

        if (roadRenderer != null)
        {
            _roadOffset += currentSpeed * 0.1f * Time.deltaTime;
            roadRenderer.material.mainTextureOffset = new Vector2(0, _roadOffset);
        }

        fuel -= 2f * Time.deltaTime;
        score += currentSpeed * Time.deltaTime * 10f;

        if (fuelText) fuelText.text = $"FUEL: {(int)fuel}";
        if (scoreText) scoreText.text = $"SCORE: {(int)score}";

        if (fuel <= 0)
        {
            EndGame();
        }

        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer <= 0f)
        {
            SpawnEnemy();
            _spawnTimer = spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null) return;

        float xPos = Random.Range(-3.5f, 3.5f);

        Vector3 spawnPos = new Vector3(xPos, 8f, 0);

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    public void HandleCrash()
    {
        currentSpeed = 1f; 
        fuel -= 10f; 
    }

    void EndGame()
    {
        IsGameOver = true;
        if (gameOverPanel) gameOverPanel.SetActive(true);
        currentSpeed = 0;
    }
}