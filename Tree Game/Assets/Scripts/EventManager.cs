using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager {

    public delegate void EnemyDiedAction();
	public static event EnemyDiedAction enemyDiedEvent;

    public static void EnemyDied() {
        if (enemyDiedEvent != null) {
		    enemyDiedEvent();
        }
	}

}
