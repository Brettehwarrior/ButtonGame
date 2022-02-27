using System;
using UnityEngine;

namespace UnityTemplateProjects
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundOnCollision : MonoBehaviour
    {
        [SerializeField] private AudioClip sound;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.relativeVelocity.magnitude > 1.2f)
                _audioSource.PlayOneShot(sound);
        }
    }
}