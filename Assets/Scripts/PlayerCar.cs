using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    public float lateralSpeed = 5f;
    public float xLimit = 4f; 

    private bool _moveLeft;
    private bool _moveRight;

    public void SetMoveLeft(bool isMoving) => _moveLeft = isMoving;
    public void SetMoveRight(bool isMoving) => _moveRight = isMoving;

    void Update()
    {
        float moveX = 0f;
        if (_moveLeft) moveX = -1f;
        if (_moveRight) moveX = 1f;

        Vector3 pos = transform.position;
        pos.x += moveX * lateralSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -xLimit, xLimit);

        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameManager.Instance.HandleCrash();
            Destroy(other.gameObject);
        }
    }
}
