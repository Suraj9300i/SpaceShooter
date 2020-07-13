using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGroundScroller : MonoBehaviour
{
    [SerializeField] float backGroundSpeed = 0.2f;

    Material myMaterial;
    Vector2 offset;

    private void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(0, backGroundSpeed);
    }

    private void Update()
    {
        myMaterial.mainTextureOffset += offset*Time.deltaTime;

    }
}
