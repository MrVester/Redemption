using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    public void SpawnDroppedItem()
    {
        Vector2 playerPos = new Vector3(player.position.x + player.transform.localScale.x * 5f, player.position.y + 0.5f, -3);
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
