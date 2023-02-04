using System;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

    public int zeroFill;

    private TMP_Text textMesh;
    private string scorePrefix = "SCORE:\t";

    void Start() {
        this.textMesh = this.GetComponent<TMP_Text>();
        this.textMesh.text = scorePrefix + "0".PadLeft(zeroFill, '0'); 
    }

    void OnEnable() {
        EventManager.scoreEvent += ScorePoints;
	}

	void OnDisable() {
        EventManager.scoreEvent -= ScorePoints;
	}

    void ScorePoints(int score) {
        this.textMesh.text = scorePrefix + score.ToString().PadLeft(zeroFill, '0');
    }
}
