public class EventManager {

    public delegate void EnemyDiedAction();
	public static event EnemyDiedAction enemyDiedEvent;

    public delegate void KillEnemyAction(int row, int column);
    public static event KillEnemyAction killEnemyEvent;

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

    public static void KillEnemy(int row, int column) {
        if (killEnemyEvent != null) {
            killEnemyEvent(row, column);
        }
    }

}
