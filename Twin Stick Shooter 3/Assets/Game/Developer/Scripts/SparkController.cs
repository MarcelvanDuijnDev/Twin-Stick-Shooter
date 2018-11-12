using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkController : MonoBehaviour {

    private ParticleSystem _particle;
    private float _timer = 0;
    private float _minTimer = 1;
    private float _maxTimer = 6;

    private void Start() {
        _particle = GetComponent<ParticleSystem>();
        SetTimer();
    }

    private void SetTimer() {
        _timer = Random.Range(_minTimer, _maxTimer);
    }

    private void Update() {
        // if timer reaches 0, play the particle effect and reset timer to random amount
        _timer -= Time.deltaTime;

        if (_timer <= 0) {
            _particle.Play();
            SetTimer();
        }
    }
}
