using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip hitSound;

    [SerializeField] private AudioSource source;

    private void OnEnable()
    {
        PlayerEvents.onHit += PlayHitSound;
    }
    private void OnDisable()
    {
        PlayerEvents.onHit -= PlayHitSound;
    }
    private void PlayHitSound()
    {
        source.PlayOneShot(hitSound);
    }
}


