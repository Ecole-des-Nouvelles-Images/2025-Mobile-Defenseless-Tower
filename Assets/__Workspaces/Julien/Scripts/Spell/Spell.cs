using System;
using Class;
using UnityEngine;
using Utils;

public abstract class Spell : MonoBehaviour
{
    public bool InPause;
    public SpellClass SpellClass;
    public float TimeSpell;

    private void OnEnable()
    {
        EventBus.OnGamePaused += OnPause;
        EventBus.OnGameResume += OnResume;
    }

    private void OnDisable()
    {
        EventBus.OnGamePaused -= OnPause;
        EventBus.OnGameResume -= OnResume;
    }
    
    private void Start()
    {
        transform.localScale = new Vector3(SpellClass.AreaSize, SpellClass.AreaSize, SpellClass.AreaSize);
        TimeSpell = SpellClass.Time;
    }

    private void OnPause()
    {
        InPause = true;
    }

    private void OnResume()
    {
        InPause = false;
    }
    
    public abstract void SetUp();
    public abstract void DoSpell();
}
