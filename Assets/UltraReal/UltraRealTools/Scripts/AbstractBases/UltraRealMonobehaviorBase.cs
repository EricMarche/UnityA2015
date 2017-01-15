using UnityEngine;
using System.Collections;

namespace UltraReal.Utilities
{
    public abstract class Singleton : MonoBehaviour
    {
        private Transform _cachedTransform = null;
        private Renderer _cachedRenderer = null;
        private Rigidbody _cachedRigidbody = null;
        private Animator _cachedAnimator = null;
        private AudioSource _cachedAudioSource = null;

        public virtual Transform CachedTransform
        {
            get
            {
                if (_cachedTransform == null)
                    _cachedTransform = GetComponent<Transform>();
                return _cachedTransform;
            }
            set { _cachedTransform = value; }
        }

        public virtual Renderer CachedRenderer
        {
            get
            {
                if (_cachedRenderer == null)
                    _cachedRenderer = GetComponent<Renderer>();
                return _cachedRenderer;
            }
            set { _cachedRenderer = value; }
        }

        public virtual Rigidbody CachedRigidbody
        {
            get
            {
                if (_cachedRigidbody == null)
                    _cachedRigidbody = GetComponent<Rigidbody>();
                return _cachedRigidbody;
            }
            set { _cachedRigidbody = value; }
        }

        public virtual Animator CachedAnimator
        {
            get
            {
                if (_cachedAnimator == null)
                    _cachedAnimator = GetComponent<Animator>();
                return _cachedAnimator;
            }
            set { _cachedAnimator = value; }
        }

        public virtual AudioSource CachedAudioSource
        {
            get
            {
                if (_cachedAudioSource == null)
                    _cachedAudioSource = GetComponent<AudioSource>();
                return _cachedAudioSource;
            }
            set { _cachedAudioSource = value; }
        }
    }
}
