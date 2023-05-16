using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Camera : MonoBehaviour
{
    public GameObject pickupEffect;
    public GameObject Camera_1;
    public GameObject Camera_2;
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
            Camera_1.SetActive(false);
            Camera_2.SetActive(true);
            //wait x amount of seconds and remove power
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            yield return new WaitForSeconds(duration);
            Camera_1.SetActive(true);
            Camera_2.SetActive(false);
            //remove power up object
            Destroy(gameObject);
        }
    }
}
