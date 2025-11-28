using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    void Update()
    {
        float relativeSpeed = GameManager.Instance.currentSpeed + 2f;
        transform.Translate(Vector3.down * relativeSpeed * Time.deltaTime);

        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }
}
