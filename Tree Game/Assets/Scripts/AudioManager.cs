using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource songAudioSource;
    public AudioSource drumAudioSource;
    public AudioClip[] drumLoops;

    private int drumLoopIndex;
    private int tempo;
    private int beat;
    private float secondsPerBeat;
    private float timeElapsed;

    void Start() {
        this.drumLoopIndex = 0;
        // this.drumAudioSource.clip = this.drumLoops[this.drumLoopIndex];
        // this.songAudioSource.pitch = 1f;
        // this.songAudioSource.Play();
        // this.drumAudioSource.Play();
        this.tempo = 70;
        this.secondsPerBeat = 60f / this.tempo;
        this.timeElapsed = 0f;
    }

    void Update() {
        this.timeElapsed += Time.deltaTime;
        if (this.timeElapsed >= this.secondsPerBeat) {
            this.timeElapsed = 0f;
            if (this.beat == 4) {
                this.beat = 1;
            } else {
                this.beat++;
            }
            EventManager.Beat(this.beat);
        }
    }

    void OnEnable() {
        EventManager.enemyDiedEvent += IncreaseTempo;
        EventManager.pitchEvent += Pitch;
	}

	void OnDisable() {
        EventManager.enemyDiedEvent -= IncreaseTempo;
        EventManager.pitchEvent -= Pitch;
	}

    void IncreaseTempo() {
        this.secondsPerBeat = 60f / this.tempo;
    }

    void Pitch(string root) {
        switch (root)
        {
            case "a":
                
                break;
            case "a#":
                break;
            case "b":
                break;
            case "c":
                break;
            case "c#":
                break;
            case "d":
                break;
            case "d#":
                break;
            case "e":
                break;
            case "f":
                break;
            case "f#":
                break;
            case "g":
                break;
            case "g#":
                break;
            default:
                break;
        }
        Debug.Log("Son of a Pitch");
    }

}
