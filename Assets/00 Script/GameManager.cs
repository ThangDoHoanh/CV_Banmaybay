using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject _player;
    public GameObject player => _player;
    [SerializeField] EnemyController _enemyPrefab;

    [SerializeField] Item boxHpPrefab;

    [SerializeField] GameObject _bulletPrefab;
    
    Vector2 oldRandomPos = Vector2.zero;
    
    void Start()
    {
        StartCoroutine(InvokeAfterTime());
        StartCoroutine(InvokeboxHp());
    }
    public void addEnemy()
    {
        Vector2 screenZize = Camera.main.ScreenToWorldPoint
            (new Vector2(Screen.width, Screen.height));

        
        Vector2 newPos = Vector2.zero;
        do
        {
            newPos.x = UnityEngine.Random.Range(-screenZize.x - 5, screenZize.x
                + 5);
            newPos.y = UnityEngine.Random.Range(-screenZize.y - 5, screenZize.y
               + 5);
        } while (newPos.x >= -screenZize.x && newPos.x <= screenZize.x ||
        (newPos.y >= -screenZize.y && newPos.y <= screenZize.y) ||
        Vector2.Distance(oldRandomPos, newPos) < 2);
        oldRandomPos = newPos;

        GameObject eneymy = ObjectPooling._instan.GetObject(_enemyPrefab.gameObject);
        eneymy.transform.position = newPos;
        eneymy.SetActive(true);

    }
    IEnumerator InvokeAfterTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(
               Random.Range(2, 7));

            addEnemy();
        }
    }
    
    public void addBoxHp()
    {
        // Lấy kích thước màn hình game trong không gian thế giới
        Vector2 screenZize = Camera.main.ScreenToWorldPoint
           (new Vector2(Screen.width, Screen.height));

        Vector2 newPos = Vector2.zero;
        do
        {
             newPos.x = Random.Range(0, screenZize.x);
             newPos.y = Random.Range(0, screenZize.y);
           
        } while (Vector2.Distance(oldRandomPos, newPos) < 2); // Kiểm tra khoảng cách so với vị trí cũ

        oldRandomPos = newPos;

        // Lấy một đối tượng từ Object Pooling
        GameObject boxhp = ObjectPooling._instan.GetObject(boxHpPrefab.gameObject);
        boxhp.transform.position = newPos;
        boxhp.SetActive(true);
    }
    IEnumerator InvokeboxHp()
    {
        while (true)
        {
            yield return new WaitForSeconds(
               Random.Range(10, 15));

            addBoxHp();
        }
    }

}
