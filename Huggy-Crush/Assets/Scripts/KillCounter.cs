using UnityEngine;
using TMPro;

public class KillCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text killedCountText;
    private SpawnManager _spawnManager;

    private int _killedPerLevel;
    public int KilledPerLevel 
    { 
        get 
        { 
            return _killedPerLevel;
        } 

        private set 
        { 
            _killedPerLevel = value;
        }
    } 
    
    private int _killedCount;
    public int KilledCount
    { 
        get 
        {
            return _killedCount;
        } 

        private set 
        {
            _killedCount = value;
            killedCountText.text = _killedCount.ToString();
            PlayerPrefs.SetInt(nameof(KilledCount), _killedCount);
        }
    }

    private void OnEnable()
    {
        _spawnManager = FindObjectOfType<SpawnManager>();
        _spawnManager.OnDidHuggy += AddCounterKill;
    }

    private void OnDisable()
    {
        _spawnManager.OnDidHuggy -= AddCounterKill;
    }

    private void Start()
    {
        _killedCount = PlayerPrefs.GetInt(nameof(KilledCount), _killedCount);
        killedCountText.text = KilledCount.ToString();
    }

    public void ResetCountKillPerLevel() => KilledPerLevel = 0;

    private void AddCounterKill()
    {
        KilledPerLevel++;
        KilledCount++;
    }
}
