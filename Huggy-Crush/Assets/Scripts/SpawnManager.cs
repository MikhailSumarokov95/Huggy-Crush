using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public Action OnDidHuggy;
    [SerializeField] private GameObject huggyPref;
    [SerializeField] private Transform[] pointsSpawn;
    private HuggyLife[] _huggys;

    private void Start()
    {
        _huggys = new HuggyLife[pointsSpawn.Length];

        for (var i = 0; i < pointsSpawn.Length; i++)
        {
            var huggy = Instantiate(huggyPref, pointsSpawn[i].position, pointsSpawn[i].rotation);
            _huggys[i] = huggy.GetComponent<HuggyLife>();
        }
    }

    private void LateUpdate()
    {
        for (var i = 0; i < _huggys.Length; i++)
        {
            if (_huggys[i].IsDid)
            {
                OnDidHuggy?.Invoke();
                _huggys[i] = SpawnHuggy();
            }
        }
    }

    private HuggyLife SpawnHuggy()
    {
        var pointSpawn = pointsSpawn[Random.Range(0, pointsSpawn.Length)];
        return Instantiate(huggyPref, pointSpawn.position, pointSpawn.rotation).GetComponent<HuggyLife>();
    }
}
