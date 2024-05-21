using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] RectTransform stick;
    
    Vector2 start;
    [SerializeField] float _speedMove;


    Rigidbody2D _rigi;
    [SerializeField] Rigidbody2D _bulletfrefab;
    bool _isPause = false;
    void Start()
    {
        start = stick.anchoredPosition;

        _isPause = false;
        _rigi = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (_isPause == false)
        {
            Move();
        }

    }
    private void Move()
    {

        // Lấy vị trí mới của stick
        Vector2 newStickPosition = stick.anchoredPosition;

        // Tính toán vector từ vị trí bắt đầu đến vị trí mới của stick
        Vector2 displacement = newStickPosition - start;
        if (displacement.Equals(Vector2.zero))
        {
            _rigi.velocity = Vector2.zero;
            return;
        }

        // Xác định hướng di chuyển dựa trên vị trí của stick
        Vector2 moveDirection = displacement.normalized;

        // Áp dụng hướng di chuyển cho đối tượng
        _rigi.velocity = transform.up * Time.deltaTime * _speedMove;

        // Áp dụng xoay cho đối tượng
        Quaternion rotate = transform.rotation;
        float newAngle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg - 90;

        rotate.eulerAngles = new Vector3(0, 0, newAngle);
        transform.rotation = rotate;

    }
    public void ATK()
    {

        GameObject bullet = ObjectPooling._instan.GetObject(_bulletfrefab.gameObject);

        bullet.transform.position = this.transform.position; // Set vị trí của người chơi
        bullet.transform.rotation = this.transform.rotation;
        bullet.SetActive(true);


        AudioManager._instan.SetSFX(1);

    }

    public void SetPause(bool _pause)
    {

        _isPause = _pause;
        this.transform.rotation = Quaternion.identity;
        _rigi.velocity = Vector2.zero;
    }
}
