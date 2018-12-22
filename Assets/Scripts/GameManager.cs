using UnityEngine;

public class GameManager : MonoBehaviour {

    public Material[] BlanketMaterials;
    public int NumberOfBlankets = 5;
    public GameObject BlanketPrefab;

    private float _blanketMinPosition = 5;
    private float _blanketMaxPosition = 20;

    private void Start()
    {
        for (int i = 0; i < NumberOfBlankets; i++)
        {
            int sign = 1 - 2*(i % 2);
            float rand1 = Random.Range(sign * _blanketMinPosition, sign * _blanketMaxPosition);
            float rand2 = Random.Range(sign * _blanketMinPosition, sign * _blanketMaxPosition);

            Vector3 randomPosition = new Vector3(rand1, 0.15f, rand2);
            GameObject blanket = Instantiate(BlanketPrefab, randomPosition, new Quaternion());
            SkinnedMeshRenderer blanketRenderer = blanket.GetComponent<SkinnedMeshRenderer>();
            blanketRenderer.material = BlanketMaterials[i % BlanketMaterials.Length];
        }
    }

    public void GameOver()
	{
		print("Game over!");
	}


	public void GameWon()
	{
		print("You win!");
	}

}