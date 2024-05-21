using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnController : MonoBehaviour
{
    [SerializeField] Button _IAP;
    [SerializeField] Button _BTLPlay;
    [SerializeField] Button _BTLSetting;
    [SerializeField] Button _BTLHome;
    [SerializeField] Button _BTLBack;
    [SerializeField] Button _BTLReset;
    [SerializeField] Button _BTLQuit;
    [SerializeField] Button _ATK;
    [SerializeField] GameObject TextCore;
    [SerializeField] GameObject _OBjBTLSetting;
    [SerializeField] GameObject _PanelSetTing;

    [SerializeField] float _atkSpeed;


    float countDownAtk = 0;
    private void Awake()
    {
        if (_IAP != null)
        {
            _IAP.onClick.AddListener(() =>
            {
              Time.timeScale = 0;
            });
        }

        if (_BTLSetting != null)
        {
            _BTLSetting.onClick.AddListener(() =>
            {
                AudioManager._instan.SetSFX(5);
                _OBjBTLSetting.SetActive(false);
                TextCore.SetActive(false);
                _PanelSetTing.SetActive(true);
                Time.timeScale = 0;

            });
        }
        if (_ATK != null)
        {
            _ATK.onClick.AddListener(() =>
            {
                if (countDownAtk > 0)
                    return;
                PlayerController._instan.ATK();
                countDownAtk = _atkSpeed;

            });
        }
        if (_BTLBack != null)
        {
            _BTLBack.onClick.AddListener(() =>
            {
                _OBjBTLSetting.SetActive(true);
                TextCore.SetActive(true);
                _PanelSetTing.SetActive(false);
                Time.timeScale = 1;
                AudioManager._instan.SetSFX(5);
            });
        }
        if (_BTLHome != null)
        {
            _BTLHome.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(CONSTANT.PLAY_SETTING);
                AudioManager._instan.SetSFX(5);
            });
        }
        if (_BTLPlay != null)
        {
            _BTLPlay.onClick.AddListener(() =>
            {
                AudioManager._instan.SetSFX(5);
                SceneManager.LoadScene(CONSTANT.PLAYING);
                Time.timeScale = 1;
            });
        }
        if (_BTLReset != null)
        {
            _BTLReset.onClick.AddListener(() =>
            {
                AudioManager._instan.SetSFX(5);
                Time.timeScale = 1;
                SceneManager.LoadScene(CONSTANT.PLAYING);

            });
        }
        if (_BTLQuit != null)
        {
            _BTLQuit.onClick.AddListener(() =>
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(CONSTANT.PLAY_SETTING);
                AudioManager._instan.SetSFX(5);
            });
        }
    }
    private void Update()
    {
        countDownAtk -= Time.deltaTime;
    }
}
