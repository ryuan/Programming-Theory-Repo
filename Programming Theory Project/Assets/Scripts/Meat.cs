using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : Pickups
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.MeatHunted += 1;
            Destroy(gameObject);
        }
    }


}
