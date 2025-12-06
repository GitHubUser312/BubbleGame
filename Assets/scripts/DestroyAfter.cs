using System.Collections;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    [SerializeField] int fTimer;
    void Start()
    {
        Destroy(gameObject, fTimer);
    }
}
