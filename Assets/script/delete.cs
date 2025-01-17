using System;
using System.Collections;
using UnityEngine;

public class delete : MonoBehaviour
{
    [SerializeField] private float deleteTime = 1.0f;

    private void Awake()
    {
        StartCoroutine(Delete());
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(deleteTime);
        Destroy(gameObject);
    }
}
