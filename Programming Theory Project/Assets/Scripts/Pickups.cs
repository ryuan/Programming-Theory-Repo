using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Pickups : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.up, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.BonesCollected += 1;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody pickupRb = GetComponent<Rigidbody>();
        pickupRb.AddForce(Vector3.up * 15, ForceMode.Impulse);

        StartCoroutine(TransitionFromProjectile(pickupRb));
    }

    IEnumerator TransitionFromProjectile(Rigidbody pickupRb)
    {
        yield return new WaitForSeconds(0.2f);

        Destroy(pickupRb);

        Collider pickupCol = GetComponent<Collider>();
        pickupCol.isTrigger = true;
    }
}
