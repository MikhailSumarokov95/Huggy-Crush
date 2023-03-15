using UnityEngine;
using UnityEngine.AI;

public class HuggyMove : MonoBehaviour
{
    public enum asdv
    {
        asd,
        qwe,
        tyu
    }
    [SerializeField] private float distanceSearchPointRandomMove = 50f;
    [SerializeField] private float scaleSpeedPerKill = 0.02f;
    private NavMeshAgent _huggyNMA;
    private HuggyLife _huggyLife;

    [SerializeField] private asdv asdva;

    private void Start()
    {
        _huggyNMA = GetComponent<NavMeshAgent>();
        _huggyLife = GetComponent<HuggyLife>();
        ScaleSpeed(FindObjectOfType<KillCounter>().KilledCount * scaleSpeedPerKill);
    }

    private void Update()
    {
        if (_huggyLife.IsDid) return;

        RandomMove();
    }

    private void RandomMove()
    {
        if (_huggyNMA.remainingDistance > 3) return;

        var targetX = transform.position.x + Random.Range(-distanceSearchPointRandomMove, distanceSearchPointRandomMove);
        var targetZ = transform.position.z + Random.Range(-distanceSearchPointRandomMove, distanceSearchPointRandomMove);

        NavMeshHit hit;
        NavMesh.SamplePosition(new Vector3(targetX, 0, targetZ), out hit, 3, NavMesh.AllAreas);
        _huggyNMA.destination = hit.position;
    }

    private void ScaleSpeed(float value)
    {
        _huggyNMA.acceleration *= 1 + value;
        _huggyNMA.speed *= 1 + value;
        _huggyNMA.angularSpeed *= 1 + value;
    }
}
