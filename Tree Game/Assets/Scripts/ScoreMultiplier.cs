using UnityEngine;
using TMPro;

public class ScoreMultiplier : MonoBehaviour {

    private TMP_Text textMesh;

    void Start() {
        this.textMesh = this.GetComponent<TMP_Text>();
        this.textMesh.text = "";
    }

    void Update() {
        if (this.textMesh.text.Length > 1) {
            this.textMesh.text = this.textMesh.text.Remove(8, 6).Insert(8, ColorUtility.ToHtmlStringRGB(Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f)));
        }
    }

    void OnEnable() {
        EventManager.scoreMultiplierEvent += Multiplier;
	}

	void OnDisable() {
        EventManager.scoreMultiplierEvent -= Multiplier;
	}

    void Multiplier(int scoreMultiplier) {
        string newMultiplier = "";
        if (scoreMultiplier > 1) {
            newMultiplier = "<color=#" + ColorUtility.ToHtmlStringRGB(Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f)) + ">x" + scoreMultiplier.ToString() + "</color>";
        }
        this.textMesh.text = newMultiplier; 
    }
}
