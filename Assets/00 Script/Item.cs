using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Item : MonoBehaviour
{
    [SerializeField] GameObject _Hp;
    [SerializeField] float _hoiHP;
    
    private void Start()
    {
        _Hp = GameManager._instan.player;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(CONSTANT.PLAYER))
        {
            AudioManager._instan.SetSFX(7);
            _Hp.GetComponent<HpPlayerController>().takeDame(-_hoiHP);
            this.gameObject.SetActive(false);
        }
    }
}
