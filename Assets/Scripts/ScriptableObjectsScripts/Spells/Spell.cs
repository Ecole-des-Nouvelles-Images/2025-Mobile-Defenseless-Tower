using System;
using System.Collections.Generic;
using Class;
using Managers;
using UnityEngine;
using Utils;

namespace ScriptableObjectsScripts.Spells
{
    public abstract class Spell : MonoBehaviour
    {
        public bool InPause;
        public SpellClass SpellClass;
        public float TimeSpell;

        private void OnEnable()
        {
            EventBus.OnGamePaused += OnPause;
            EventBus.OnGameResume += OnResume;
            EventBus.OnLevelFinished += Destroy;
        }

        private void OnDisable()
        {
            EventBus.OnGamePaused -= OnPause;
            EventBus.OnGameResume -= OnResume;
            EventBus.OnLevelFinished -= Destroy;
        }
    
        private void Start()
        {
            transform.localScale = new Vector3(SpellClass.AreaSize, SpellClass.AreaSize, SpellClass.AreaSize);
            TimeSpell = SpellClass.Time;
            if(SpellClass.SpellData.SpawnSounds[0]) SoundManager.Instance.PlayRandomSoundInTransform(SpellClass.SpellData.SpawnSounds, transform);
        }

        private void OnPause()
        {
            InPause = true;
        }

        private void OnResume()
        {
            InPause = false;
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }

        public abstract void SetUp();
        public abstract void DoSpell();
    }
}
