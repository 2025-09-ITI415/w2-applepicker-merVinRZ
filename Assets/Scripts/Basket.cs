using UnityEngine;

public class Basket : MonoBehaviour
{
    void Update()
    {
        Vector3 m = Input.mousePosition;
        m.z = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        Vector3 w = Camera.main.ScreenToWorldPoint(m);
        transform.position = new Vector3(w.x, transform.position.y, transform.position.z);
    }
    public void CatchApple(Apple apple)
    {
        if (apple != null) Destroy(apple.gameObject);
        var mgr = FindFirstObjectByType<ApplePicker>();
        if (mgr != null) mgr.AddScore(apple != null ? apple.pointValue : 1);
    }
}