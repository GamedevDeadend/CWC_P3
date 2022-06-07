using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
// using System.Numerics;
using UnityEngine;

public class RepeatBackgrounds : MonoBehaviour
{
    private Vector3 StartPos;
    private float BackgroundWidth;



    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        BackgroundWidth = GetComponent<BoxCollider>().size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < (StartPos.x - BackgroundWidth))
        {
            transform.position = StartPos;
        }
    }
}
