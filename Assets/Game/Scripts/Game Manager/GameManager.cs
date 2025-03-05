using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private RainGenerator rainGenerator;
    
    public int Score { get; private set; }
    public int PlayerHealth { get; private set; } = 100;
    
    public event Action<int> OnScoreChanged;
    public event Action<int> OnPlayerDamaged;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        rainGenerator = GameObject.FindGameObjectWithTag("RainController").GetComponent<RainGenerator>();
    }

    public void PauseGame()
    {
        if (rainGenerator != null)
        {
            rainGenerator.enabled = false;
        }
    }
    
    public void ResumeGame()
    {
        if (rainGenerator != null)
        {
            rainGenerator.enabled = true;
        }
    }

    public void AddScore(int point)
    {
        Score += point;
        OnScoreChanged?.Invoke(point);
    }

    public void DamagePlayer(int damage)
    {
        PlayerHealth -= damage;
        OnPlayerDamaged?.Invoke(PlayerHealth);

        if (PlayerHealth< 0)
        {
            Debug.Log("Game Over");
        }
    }
}
