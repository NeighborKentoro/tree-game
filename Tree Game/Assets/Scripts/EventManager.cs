public class EventManager {

    public delegate void EnemyDiedAction();
	public static event EnemyDiedAction enemyDiedEvent;

    public delegate void ScoreAction(int score);
    public static event ScoreAction scoreEvent;

    public delegate void EnemyShootAction(int row, int column);
    public static event EnemyShootAction enemyShootEvent;

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

    public static void EnemyShoot(int row, int column)
    {
        if (enemyShootEvent != null)
        {
            enemyShootEvent(row, column);
        }
    }

}
