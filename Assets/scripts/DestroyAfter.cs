using System.Collections;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    [SerializeField] int fTimer;
    void Start()
    {
        StartCoroutine(DeleteAfter(fTimer));
    }

    IEnumerator DeleteAfter(int time)
    {
        yield return new WaitForSeconds(time);  
        Destroy(gameObject);
    }
}
