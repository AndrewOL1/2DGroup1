using Player;
using Player.StateMachineScripts.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawningState : BaseState
{
    public RespawningState(PlayerController player, Animator animator) : base(player, animator)
    {
    }
    public override void OnEnter()
    {
        //delay for animaiton
        //move
        //fadein
        GameManager.instance.FadeOut(player.playerData.RespawnTime);
        player.StartCoroutine(Respawn(player.playerData.RespawnTime));
        player.PlayerLocomotion.ZeroVelocity();
    }
    public override void OnExit()
    {
        GameManager.instance.FadeIn(player.playerData.RespawnTime);
    }
    IEnumerator Respawn(float s)
    {
        yield return new WaitForSeconds(s);
        player.transform.position = player.playerData.lastCheckpoint;
        player.playerData.IsDead = false;
    }

}
