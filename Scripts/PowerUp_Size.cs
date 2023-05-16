using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Size : MonoBehaviour
{
    public GameObject pickupEffect;
    public float multiplier = 1.5f;
    public float duration = 10f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }

        IEnumerator Pickup(Collider player)
        {
            Instantiate(pickupEffect, transform.position, transform.rotation);
            //spawn cool effect

            //apply useful effect to player
            player.transform.localScale *= multiplier;

            //wait x amount of seconds and remove power
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            yield return new WaitForSeconds(duration);
            player.transform.localScale /= multiplier;
            //remove power up object
            Destroy(gameObject);
        }
    }
}
