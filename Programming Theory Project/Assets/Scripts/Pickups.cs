using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Pickups : MonoBehaviour
{
    protected GameManager gameManager;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        gameObject.transform.Rotate(Vector3.up, 0.5f);
    }
}
