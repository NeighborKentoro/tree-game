public class EventManager {

    public delegate void EnemyDiedAction();
	public static event EnemyDiedAction enemyDiedEvent;

    public delegate void ScoreAction(int score);
    public static event ScoreAction scoreEvent;

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

}
