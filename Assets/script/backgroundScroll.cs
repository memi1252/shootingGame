using System;
using UnityEngine;

public class backgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 0.5f;

     public MeshRenderer MeshRenderer;

    private void Update()
    {
        MeshRenderer.material.mainTextureOffset = new Vector2(0, Time.time * scrollSpeed);
    }
}
