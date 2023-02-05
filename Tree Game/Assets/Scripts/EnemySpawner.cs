using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject alienPrefab;
    public float xSpawnSpacing = 1f;
    public float ySpawnSpacing = 1f;
    public float xSpawnOffset = 0f;
    public float ySpawnOffset = 0f;
    public int enemiesPerRow = 1;
    public int enemiesPerColumn = 1;

    //void Start() {
    //    for (int iRow = 0; iRow < enemiesPerRow; iRow++) {
    //        Vector3 rowPosition = new Vector3((this.transform.position.x + (xSpawnSpacing * iRow)) + xSpawnOffset, this.transform.position.y, 0);
    //        for (int iColumn = 0; iColumn < enemiesPerColumn; iColumn++) {
    //            Vector3 columnPosition = new Vector3(rowPosition.x, (rowPosition.y + (ySpawnSpacing * iColumn)) + ySpawnOffset, 0);
    //            GameObject alien = GameObject.Instantiate(alienPrefab, columnPosition, this.transform.rotation);
    //            Alien alienComp = alien.GetComponent<Alien>();
    //            alienComp.SetGrid(iRow, iColumn);
    //        }
    //    }
    //}

    public void spawnAliens()
    {
        for (int iRow = 0; iRow < enemiesPerRow; iRow++)
        {
            Vector3 rowPosition = new Vector3((this.transform.position.x + (xSpawnSpacing * iRow)) + xSpawnOffset, this.transform.position.y, 0);
            for (int iColumn = 0; iColumn < enemiesPerColumn; iColumn++)
            {
                Vector3 columnPosition = new Vector3(rowPosition.x, (rowPosition.y + (ySpawnSpacing * iColumn)) + ySpawnOffset, 0);
                GameObject alien = GameObject.Instantiate(alienPrefab, columnPosition, this.transform.rotation);
                Alien alienComp = alien.GetComponent<Alien>();
                alienComp.SetGrid(iRow, iColumn);
            }
        }
    }

}
