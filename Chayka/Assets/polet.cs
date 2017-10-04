using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class polet : MonoBehaviour
{
    public float cosA;
    public Vector3 targetPosition; // сюда передаем координаты цели
    public float speed;
    public GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Bird");
        speed = 2;
        targetPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (this.gameObject.transform.position.y <= -10)
        {
            Destroy(this.gameObject);

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("facebird"))
        {
            GameData.gd.f_currenthp -= 0.15f * GameData.gd.armor[GameData.gd.armorLevel];
            collision.GetComponent<Controll>().Bang();
            Destroy(this.gameObject);
        }

    }
}
