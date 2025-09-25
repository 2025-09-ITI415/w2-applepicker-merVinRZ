using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class ApplePicker : MonoBehaviour
{
    [Header("Score / Lives")]
    public int lives = 3;
    public int score = 0;
    public TMP_Text scoreText;

    [Header("Baskets")]
    public GameObject basketPrefab;
    public Transform basketsParent;
    public float basketY = -3.5f;
    public float basketSpacing = 0.6f;

    List<GameObject> baskets = new();

    void Start()
    {
        for (int i = 0; i < lives; i++)
        {
            Vector3 pos = new Vector3(0, basketY + i * basketSpacing, 0);
            var b = Instantiate(basketPrefab, pos, Quaternion.identity, basketsParent);
            b.tag = "Basket";
            baskets.Add(b);
        }
        RefreshUI();
    }

    public void AddScore(int v) { score += v; RefreshUI(); }

    public void MissApple()
    {
        if (baskets.Count > 0)
        {
            var last = baskets[^1];
            baskets.RemoveAt(baskets.Count - 1);
            Destroy(last);
        }

        lives--;
        if (lives <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void RefreshUI()
    {
        if (scoreText) scoreText.text = $"Apples: {score}";
    }
}