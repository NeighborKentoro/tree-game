using UnityEngine;

public class TreeCamera : MonoBehaviour {

    public float seizureTime;
    private float elaspsedSeizureTime;
    private Camera treeCamera;

    void OnEnable() {
        // EventManager.keyboardHitEvent += KeyboardHit;
	}

	void OnDisable() {
        // EventManager.keyboardHitEvent -= KeyboardHit;
	}

    void Start() {
        this.treeCamera = this.GetComponent<Camera>();
    }

    void Update() {
        if (this.elaspsedSeizureTime > 0) {
            this.treeCamera.backgroundColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            this.elaspsedSeizureTime -= Time.deltaTime;
        } else {
            this.treeCamera.backgroundColor = new Color(0, 0, 0, 1);
        }
    }

    void KeyboardHit() {
        this.elaspsedSeizureTime = this.seizureTime;
    }
}
