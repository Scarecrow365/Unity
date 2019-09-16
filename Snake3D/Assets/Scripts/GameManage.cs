using UnityEngine;

public class GameManage : MonoBehaviour
{

    [SerializeField] private GameObject Snake;
    [SerializeField] private GameObject Apple;
    [SerializeField] private GameObject PosSpawnSnake;
    [Range(1,5)]
    [SerializeField] private int HowMuchAppleCreate;
    [SerializeField] private float _borderApplesSpawn = 6.7f;

    private GameObject _firstSnake;
    private GameObject _secondSnake;

	void Start ()
	{
        SnakeCreate(1);
        SnakeCreate(2);
		AppleCreate(HowMuchAppleCreate);
	}

    /// <summary>
    /// What is number snake you want create 1 or 2
    /// </summary>
    /// <param name="numberOfSnake"></param>
    private void SnakeCreate(int numberOfSnake)
    {
        switch (numberOfSnake)
        {
            case 1:
                Instantiate(Snake, Vector3Int.RoundToInt(PosSpawnSnake.transform.position),Quaternion.identity);
                break;
            case 2:
                Instantiate(Snake, Vector3Int.RoundToInt(-PosSpawnSnake.transform.position),Quaternion.Euler(0,180,0));
                break;
        }
    }

    private void AppleCreate(int countAppleCreate)
    {
        for (int i = 0; i < countAppleCreate; i++)
        {
            var spawnPosition = new Vector3(Random.Range(-_borderApplesSpawn, _borderApplesSpawn), 0,
                Random.Range(-_borderApplesSpawn, _borderApplesSpawn));
            Instantiate(Apple, Vector3Int.RoundToInt(spawnPosition), Quaternion.identity);
        }
    }

    public void DestroyFood(GameObject food)
    {
        Destroy(food);
        AppleCreate(1);
    }
}
