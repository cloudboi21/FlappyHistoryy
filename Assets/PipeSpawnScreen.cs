
using UnityEngine;

public class PipeSpawnScreen : MonoBehaviour
{

    public GameObject pipe1;
    public GameObject pipe2;
    public GameObject pipe3;

    public float pipeToBeSpawned = 1;
    public float spawnRate = 10;
    private float timer = 0;
    public float heightOffset = 5;
    public float spawnedPipes = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {

            spawnPipe();
            pipeToBeSpawned = Random.Range(1, 3);
            timer = 0;
            spawnedPipes++;
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        if (pipeToBeSpawned == 1)
        {
            Instantiate(pipe1, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint)), transform.rotation);

        }
        if (pipeToBeSpawned == 2)
        {
            Instantiate(pipe2, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint)), transform.rotation);
        }
        if (pipeToBeSpawned == 3)
        {
            Instantiate(pipe3, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint)), transform.rotation);
        }
    }

}
