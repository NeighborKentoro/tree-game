using UnityEngine;

public class TreeCamera : MonoBehaviour {

    public float seizureTime;
    private float elaspsedSeizureTime;

    void OnEnable() {
        EventManager.keyboardHitEvent += KeyboardHit;
	}

	void OnDisable() {
        EventManager.keyboardHitEvent -= KeyboardHit;
	}

    void Update() {
        if (this.elaspsedSeizureTime > 0) {
            this.GetComponent<Camera>().backgroundColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            this.elaspsedSeizureTime -= Time.deltaTime;
        }
    }

    void KeyboardHit() {
        this.elaspsedSeizureTime = this.seizureTime;
    }
}
