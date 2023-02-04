using UnityEngine;

public class AudioManager : MonoBehaviour {

    public int tempo;
    public AudioSource songAudioSource;
    public AudioSource drumAudioSource;
    public AudioClip[] drumLoops;

    private int drumLoopIndex;
    private float secondsPerBeat;
    private float timeElapsed;

    void Start() {
        this.drumLoopIndex = 0;
        // this.drumAudioSource.clip = this.drumLoops[this.drumLoopIndex];
        // this.songAudioSource.pitch = 1f;
        // this.songAudioSource.Play();
        // this.drumAudioSource.Play();
        this.tempo = 80;
        this.secondsPerBeat = 60f / this.tempo;
        this.timeElapsed = 0f;
    }

    void Update() {
        this.timeElapsed += Time.deltaTime;
        if (this.timeElapsed >= this.secondsPerBeat) {
            this.timeElapsed = 0f;
        }
    }

    void OnEnable() {
        EventManager.enemyDiedEvent += IncreaseTempo;
	}

	void OnDisable() {
        EventManager.enemyDiedEvent -= IncreaseTempo;
	}

    void IncreaseTempo() {
        this.tempo += 10;
        this.secondsPerBeat = 60f / this.tempo;
    }
}
