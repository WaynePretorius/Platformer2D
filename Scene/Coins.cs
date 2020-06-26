using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    AudioSource audioSource;
    private void Awake()
    {
        GetCashedComponents();
    }

    private void GetCashedComponents()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void CoinCollected()
    {
        audioSource.PlayOneShot(audioSource.clip);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.IsTouchingLayers(LayerMask.GetMask(Tags.LAYER_PLAYER)))
        {
            CoinCollected();
        }
    }

}
