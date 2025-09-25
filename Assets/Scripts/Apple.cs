using UnityEngine;

public class Apple : MonoBehaviour
{
    public int pointValue = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basket"))
        {
            other.GetComponent<Basket>()?.CatchApple(this);
        }
        else if (other.CompareTag("Bottom"))
        {
            FindFirstObjectByType<ApplePicker>()?.MissApple();
            Destroy(gameObject);
        }
    }
}