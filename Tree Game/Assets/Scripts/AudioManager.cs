using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource[] audioSources;
    public AudioSource drumAudioSource;

    private int tempo;
    private int beat;
    private float secondsPerBeat;
    private float timeElapsed;

    void Start() {
        this.tempo = 70;
        this.secondsPerBeat = 60f / this.tempo;
        this.timeElapsed = 0f;
        this.drumAudioSource.Play();
        foreach (AudioSource src in this.audioSources) {
            src.Play();
        }
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
                this.unmuteTrack(9);
                break;
            case "a#":
                this.unmuteTrack(10);
                break;
            case "b":
                this.unmuteTrack(11);
                break;
            case "c":
                this.unmuteTrack(0);
                break;
            case "c#":
                this.unmuteTrack(1);
                break;
            case "d":
                this.unmuteTrack(2);
                break;
            case "d#":
                this.unmuteTrack(3);
                break;
            case "e":
                this.unmuteTrack(4);
                break;
            case "f":
                this.unmuteTrack(5);
                break;
            case "f#":
                this.unmuteTrack(6);
                break;
            case "g":
                this.unmuteTrack(7);
                break;
            case "g#":
                this.unmuteTrack(8);
                break;
            default:
                break;
        }
        
    }

    private void unmuteTrack(int trackIndex) {
        for (int i = 0; i < this.audioSources.Length; i++) {
            if (i == trackIndex) {
                this.audioSources[trackIndex].mute = false;
            } else {
                this.audioSources[i].mute = true;
            }
        }
    }

}
