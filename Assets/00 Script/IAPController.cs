using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPController : MonoBehaviour
{
    [SerializeField] GameObject _Hp;
    [SerializeField] float _hoiHP;
    public void BuyHpSes()
    {
        Debug.Log("+50 hp !");
        _Hp.GetComponent<HpPlayerController>().takeDame(-_hoiHP);
        Time.timeScale = 1;
    }
    public void BuyHpfail()
    {
        Debug.Log("Buy Hp fai !");
        Time.timeScale = 1;
    }
}
