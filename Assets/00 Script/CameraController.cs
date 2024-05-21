using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputEventTrace;

public class CameraController :Singleton<CameraController>
{
   
    [SerializeField] Transform _Player;
    [SerializeField] Vector2 _offSet;
   
    [SerializeField] GameObject ObjPooling;
    
    
    private void Update()
    {
            setCamLv1();
    }
    void setCamLv1()
    {
        //Debug.LogError("cam1");
        Vector3 pos = _Player.position + (Vector3)_offSet;
        pos.z = Camera.main.transform.position.z;
        Camera.main.transform.position = pos;
    }

    public void GenerateColliders()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            float screenHeightInUnits = mainCamera.orthographicSize * 2f;
            Debug.Log("Chiều dài của màn hình theo đơn vị Unity: " + screenHeightInUnits);
            float screenWidthInUnits = mainCamera.orthographicSize * 2f * mainCamera.aspect;
            Debug.Log("Chiều rộng của màn hình theo đơn vị Unity: " + screenWidthInUnits);

            Vector2 trenphai = Camera.main.ScreenToWorldPoint
               (new Vector2(Screen.width, Screen.height));
            Vector2 trentrai = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height));
            Vector3 giuatren = new Vector3((trenphai.x + trentrai.x) / 2, (trenphai.y + trentrai.y) / 2, 0);

            GameObject newObject_giuatren = new GameObject("newObject_giutren");

            BoxCollider2D boxCollider_giutren = newObject_giuatren.AddComponent<BoxCollider2D>();
            boxCollider_giutren.size = new Vector2(screenWidthInUnits, 2);
            newObject_giuatren.transform.position = new Vector3(giuatren.x, giuatren.y + 1, 0);



            Vector2 duoiphai = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0));
            Vector2 duoitrai = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
            Vector3 giuaduoi = new Vector3((duoiphai.x + duoitrai.x) / 2, duoitrai.y, 0);


            GameObject newObject_giuaduoi = new GameObject("newObject_giuaduoi");
            BoxCollider2D boxCollider_giuaduoi = newObject_giuaduoi.AddComponent<BoxCollider2D>();
            boxCollider_giuaduoi.size = new Vector2(screenWidthInUnits, 2);
            newObject_giuaduoi.transform.position = new Vector3(giuaduoi.x, giuaduoi.y - 1, 0);

            Vector3 giuaphai = new Vector3((trenphai.x + duoiphai.x) / 2, (trenphai.y + duoiphai.y) / 2, 0);


            GameObject newObject_giuaphai = new GameObject("newObject_giuaphai");
            BoxCollider2D boxCollider_giuaphai = newObject_giuaphai.AddComponent<BoxCollider2D>();
            boxCollider_giuaphai.size = new Vector2(2, screenHeightInUnits);
            newObject_giuaphai.transform.position = new Vector3(giuaphai.x + 1, giuaphai.y, 0);


            Vector3 giuatrai = new Vector3((trentrai.x + duoitrai.x) / 2, (trentrai.y + duoitrai.y) / 2, 0);

            GameObject newObject_giuatrai = new GameObject("newObject_giuatrai");
            BoxCollider2D boxCollider_giuatrai = newObject_giuatrai.AddComponent<BoxCollider2D>();
            boxCollider_giuatrai.size = new Vector2(2, screenHeightInUnits);
            newObject_giuatrai.transform.position = new Vector3(giuatrai.x - 1, giuatrai.y, 0);

            newObject_giuatren.transform.parent = ObjPooling.transform;
            newObject_giuaduoi.transform.parent = ObjPooling.transform;
            newObject_giuaphai.transform.parent = ObjPooling.transform;
            newObject_giuatrai.transform.parent = ObjPooling.transform;

        }

        PlayerController._instan.SetPause(false);
    }
}
