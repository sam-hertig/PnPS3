using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Material[] BlanketMaterials;
    public int NumberOfBlankets = 5;
    public GameObject BlanketPrefab;
    public Text GameStartText;
    public Text GameWonText;
    public Text GameLostText;
    public Image TextBackground;

    private float _blanketMinPosition = 5;
    private float _blanketMaxPosition = 20;

    private void Start()
    {
        for (int i = 0; i < NumberOfBlankets; i++)
        {
            int sign1 = 1 - 2 * (Mathf.RoundToInt(Random.Range(0f, 1f)));
            int sign2 = 1 - 2 * (Mathf.RoundToInt(Random.Range(0f, 1f)));
            float rand1 = Random.Range(sign1 * _blanketMinPosition, sign1 * _blanketMaxPosition);
            float rand2 = Random.Range(sign2 * _blanketMinPosition, sign2 * _blanketMaxPosition);
            Vector3 randomPosition = new Vector3(rand1, 0.15f, rand2);
            GameObject blanket = Instantiate(BlanketPrefab, randomPosition, new Quaternion());
            SkinnedMeshRenderer blanketRenderer = blanket.GetComponent<SkinnedMeshRenderer>();
            blanketRenderer.material = BlanketMaterials[i % BlanketMaterials.Length];
        }
        ShowStartText();
    }

    public void GameOver()
	{
        GameLostText.gameObject.SetActive(true);
        TextBackground.gameObject.SetActive(true);
        AwaitRestartGame();
    }

    public void GameWon()
	{
        GameWonText.gameObject.SetActive(true);
        TextBackground.gameObject.SetActive(true);
        AwaitRestartGame();
    }

    private void AwaitRestartGame()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    private void ShowStartText()
    {
        GameStartText.gameObject.SetActive(true);
        TextBackground.gameObject.SetActive(true);
        StartCoroutine(HideStartText());
    }

    private IEnumerator HideStartText()
    {
        yield return new WaitForSeconds(6);
        GameStartText.gameObject.SetActive(false);
        TextBackground.gameObject.SetActive(false);
    }
}