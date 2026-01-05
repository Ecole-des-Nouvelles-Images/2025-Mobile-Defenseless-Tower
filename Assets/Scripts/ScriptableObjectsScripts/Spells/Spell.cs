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

        public virtual void OnEnable()
        {
            EventBus.OnGamePaused += OnPause;
            EventBus.OnGameResume += OnResume;
            EventBus.OnLevelFinished += Destroy;
        }

        public virtual void OnDisable()
        {
            EventBus.OnGamePaused -= OnPause;
            EventBus.OnGameResume -= OnResume;
            EventBus.OnLevelFinished -= Destroy;
        }
    
        public virtual void Start()
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
