using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    private SpriteRenderer sr;
    private Vector2 scroll;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        scroll = new Vector2(0f, 0f);
    }

    void Update()
    {
        ScrollBackground(Time.deltaTime);
    }

    private void FixedUpdate()
    {
        // ScrollBackground(Time.fixedDeltaTime);
    }

    private void ScrollBackground(float timeStep)
    {
        // Scroll the offset.
        scroll.x += scrollSpeed * timeStep;
        // Apply the offset.
        sr.material.mainTextureOffset = scroll;
    }
}
