using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    public AudioSource step, jump, land;
    public AudioClip stepc, jumpc, landc;

    public void PlayStep()
    {
        step.PlayOneShot(stepc);
    }
    public void PlayJump()
    {
        jump.PlayOneShot(jumpc);
    }
    public void PlayLand()
    {
        land.PlayOneShot(landc);
    }
}
