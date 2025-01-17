using System;
using UnityEngine;

public class StageChange : MonoBehaviour
{
    public GameObject background;
    public Material stage2Background;
    
    private void Update()
    {
        if (GameManager.Instance.isBossDie1)
        {
            background.GetComponent<Renderer>().material = stage2Background;
        }
    }
}
