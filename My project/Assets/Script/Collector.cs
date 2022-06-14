using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    int coinsCount = 0;
    [SerializeField] Text pouch;
    [SerializeField] AudioSource collectSound;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            coinsCount++;
            pouch.text = "Coins: " + coinsCount;
            Destroy(other.gameObject);
            collectSound.Play();
        }
    }
}
