using System.Collections.Generic;
using Class;
using Interface;
using ScriptableObjectsScripts.Spells;
using UnityEngine;
using EventBus = Utils.EventBus;
using Image = UnityEngine.UI.Image;

public class Vampiric : Spell
{
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();
    [SerializeField] private Image _image;

    public float CurrentFill;
    public float FillAmountProgressMax;
    public override void OnEnable()
    {
        base.OnEnable();
        EventBus.EnemieTookDamage += FileBard;
    }
    
    public override void OnDisable()
    {
        base.OnDisable();
        EventBus.EnemieTookDamage -= FileBard;
    }

    public override void Start()
    {
        base.Start();
        FillAmountProgressMax = SpellClass.SpellData.Efficiency;
        Debug.Log(FillAmountProgressMax);
    }

    private void Update()
    {
        if (InPause) return;
        TimeSpell -= Time.deltaTime;

        if (TimeSpell <= 0)
        {
            GiveHealthPoint();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _enemies.Add(other.gameObject.GetComponent<Enemy>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _enemies.Remove(other.gameObject.GetComponent<Enemy>());
        }
    }

    private void FileBard(float damage, Enemy enemy)
    {
        if (_enemies.Contains(enemy))
        {
            CurrentFill += damage;
            _image.fillAmount = CurrentFill / FillAmountProgressMax;
            CurrentFill = Mathf.Clamp(CurrentFill, 0, FillAmountProgressMax);
            if (CurrentFill >= FillAmountProgressMax)
            {
                GiveHealthPoint();
            }
        }
    }

    private void GiveHealthPoint()
    {
        EventBus.OnAllEnemieGetHealth?.Invoke(CurrentFill * 0.10f);
        Destroy(gameObject);
    }
    
    public override void SetUp()
    {
        throw new System.NotImplementedException();
    }

    public override void DoSpell()
    {
        throw new System.NotImplementedException();
    }
}
