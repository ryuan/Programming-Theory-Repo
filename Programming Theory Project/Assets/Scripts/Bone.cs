using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : Pickups
{
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
