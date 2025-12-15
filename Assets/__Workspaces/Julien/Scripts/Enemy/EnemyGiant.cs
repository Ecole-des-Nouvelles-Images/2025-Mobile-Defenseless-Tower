using Class;
using UnityEngine;

public class EnemyGiant : Enemy
{
    public override void SetUpSound()
    {
        DeathSound = SoundManager.Instance.GetSound(SoundManager.Instance.GolemSpawn);
    }
}
