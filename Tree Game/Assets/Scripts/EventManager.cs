public class EventManager {

    public delegate void EnemyDiedAction();
	public static event EnemyDiedAction enemyDiedEvent;

    public delegate void ScoreAction(int score);
    public static event ScoreAction scoreEvent;
    public static event ScoreAction scoreMultiplierEvent;

    public delegate void EnemyShootAction(int row, int column);
    public static event EnemyShootAction enemyShootEvent;

    public delegate void BeatAction(int beatNumber);
    public static event BeatAction beatEvent;

    public delegate void KeyboardHitAction();
    public static event KeyboardHitAction keyboardHitEvent;

    public delegate void PitchAction(string root);
    public static event PitchAction pitchEvent;

    public static void EnemyDied() {
        if (enemyDiedEvent != null) {
		    enemyDiedEvent();
        }
	}

    public static void Score(int score) {
        if (scoreEvent != null) {
            scoreEvent(score);
        }
    }

    public static void ScoreMultiplier(int scoreMultiplier) {
        if (scoreMultiplierEvent != null) {
            scoreMultiplierEvent(scoreMultiplier);
        }
    }

    public static void EnemyShoot(int row, int column)
    {
        if (enemyShootEvent != null)
        {
            enemyShootEvent(row, column);
        }
    }

    public static void Beat(int beatNumber) {
        if (beatEvent != null) {
            beatEvent(beatNumber);
        }
    }

    public static void KeyboardHit() {
        if (keyboardHitEvent != null) {
            keyboardHitEvent();
        }
    }

    public static void Pitch(string root) {
        if (pitchEvent != null) {
            pitchEvent(root);
        }
    }
}
