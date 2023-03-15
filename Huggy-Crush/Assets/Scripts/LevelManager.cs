using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int maxKillPerLevel = 10;
    [SerializeField] private Image winPanel; 
    private KillCounter _killCounter;

    private void Start()
    {
        _killCounter = FindObjectOfType<KillCounter>();        
    }

    private void Update()
    {
        if (_killCounter.KilledPerLevel >= maxKillPerLevel) WinLevel();
    }

    public void SetPause(bool value)
    {
        Time.timeScale = value ? 0f : 1f;
    }

    private void WinLevel()
    {
        _killCounter.ResetCountKillPerLevel();
        winPanel.gameObject.SetActive(true);
        SetPause(true);
    }
}
