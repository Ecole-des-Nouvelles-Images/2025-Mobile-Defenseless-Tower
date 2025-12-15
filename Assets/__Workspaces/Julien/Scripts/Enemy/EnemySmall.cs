using Class;
using UnityEngine;

public class EnemySmall : Enemy
{
    public override void SetUpSound()
    {
        DeathSound = SoundManager.Instance.GetSound(SoundManager.Instance.ChevalierSpawn);
    }
}
