using UnityEngine;

public class HuggyLife : MonoBehaviour
{
    [SerializeField] private float minDistanceToBlackHole = 3f;
    private Transform _blackHoleTr;

    private bool _isDid;
    public bool IsDid { get { return _isDid; } private set { _isDid = value; } }

    private void Start()
    {
        _blackHoleTr = GameObject.FindGameObjectWithTag("BlackHole").transform;
    }

    private void Update()
    {
        var distanceToBlackhole = Vector3.Distance(_blackHoleTr.position, transform.position);
        if (distanceToBlackhole < minDistanceToBlackHole)
        {
            IsDid = true;
            Destroy(gameObject);
            return;
        }
    }
}
