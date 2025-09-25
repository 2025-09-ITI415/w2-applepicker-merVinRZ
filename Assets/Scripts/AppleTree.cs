using UnityEngine;

public class Tree : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 3f;
    public float xLimit = 8f;
    public float randomTurnPerSecond = 0.5f;

    [Header("Spawning")]
    public GameObject applePrefab;
    public float dropInterval = 1.0f;

    float timer;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);

        if (transform.position.x > xLimit) speed = -Mathf.Abs(speed);
        if (transform.position.x < -xLimit) speed =  Mathf.Abs(speed);

        if (Random.value < randomTurnPerSecond * Time.deltaTime)
            speed = -speed;

        timer += Time.deltaTime;
        if (timer >= dropInterval && applePrefab != null)
        {
            Instantiate(applePrefab, transform.position, Quaternion.identity);
            timer = 0f;
        }
    }
}