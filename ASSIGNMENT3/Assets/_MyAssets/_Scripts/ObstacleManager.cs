using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Sprite[] sprites;

    private int obsCtr;
    // Start is called before the first frame update
    void Start()
    {
        obsCtr = 0;
        obstacles = new List<GameObject>();
        for (int i = 0; i <9 ; i++)
        {
            SpawnObstacle(i * 4f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveObstacles();
    }
    private void MoveObstacles()
    {
        // Move each obstacle gameobject 
        foreach (var obstacle in obstacles)
        {
            obstacle.transform.Translate(moveSpeed * Time.deltaTime, 0f , 0f);
        }
        // if the first obtacle is fully off-screen
        if (obstacles[0].transform.position.x <= -4f)
        {
            // Destroy and remove the first obstacle from the list 
            Destroy(obstacles[0]);
            obstacles.RemoveAt(0);
            // Create and push a new obstacle to the list 
            SpawnObstacle(32f, (obsCtr++ %3 == 0));
        }
    }
    private void SpawnObstacle(float xPos, bool hasSprite = false )
    {
        GameObject obsInst = Instantiate( obstaclePrefab, new Vector3(xPos, -16f, 0f ), Quaternion.identity );
        obsInst.transform.parent = this.transform;
        obstacles.Add( obsInst );
        if ( hasSprite )
        {
            obsInst.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length) ];
            obsInst.AddComponent<BoxCollider2D>(); // unity will "wrap" the sprite geometry in the box no mater where the pivot 
        }
    } 
}
