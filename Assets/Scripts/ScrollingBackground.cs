using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{

    public Renderer backgroud;
    public float backgroundSpeed;

    void Start()
    {

    }

    void Update()
    {
        backgroud.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);


    }
}
