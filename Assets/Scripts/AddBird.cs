using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class AddBird : MonoBehaviour
{
    public PlayerController player;
    public SpriteRenderer spriteRenderer;
    public void Spawn()
    { 
        spriteRenderer.enabled = false;
        player.Bird=true;
    }
}
