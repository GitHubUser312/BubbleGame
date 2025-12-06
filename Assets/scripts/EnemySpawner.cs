using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [Header("Gizmo"), SerializeField] 
    float detectionRadius = 1f;
    [SerializeField] Color gizmoColor = Color.yellow;

    [Header("Spawn"), SerializeField]
    GameObject enemies;

    [SerializeField]
    float fTimer = 2;
    [SerializeField]
    float fCountDown = 0;
    // Delta time tracking
    private float localDelta = 0.0f;
    // Can be used to log only once per second
    private bool localDeltaWait = false;
    // local int for delta time tracking
    private int localInt = 0;
    void OnDrawGizmosSelected() 
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
    private void Start()
    {
        //StartCoroutine(Spawn(fTimer));
    }

    private void Update()
    {
        fTimer -= Time.deltaTime / 10;
        fTimer = Mathf.Clamp(fTimer, 0.1f, 10);

        localDelta += Time.deltaTime;
        // Updates every second
        if ((int)localDelta > localInt)
        {
            ++localInt;
            localDeltaWait = true;
        }

        if (fCountDown <= 0)
        {
            Vector2 rand = Random.insideUnitCircle * detectionRadius;
            Instantiate(enemies, rand, Quaternion.identity);
            fCountDown = fTimer;
        }
        else
        {
            fCountDown -= Time.deltaTime;
        }

            // debug
            if (localDeltaWait)
        {
            Debug.Log("Spawner Timer: " + fTimer);
        }

        // Must be at the end of this Update
        if (localDeltaWait) { localDeltaWait = false; }
    }
    IEnumerator Spawn(float time)
    {
        while (true)
        {
            Vector2 rand = Random.insideUnitCircle * detectionRadius;
            Instantiate(enemies, rand, Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }
}
