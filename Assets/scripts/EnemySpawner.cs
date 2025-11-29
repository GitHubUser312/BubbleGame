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
    int fTimer = 2;

    void OnDrawGizmosSelected() 
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
    private void Start()
    {
        StartCoroutine(Spawn(fTimer));
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
