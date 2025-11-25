using System;
using UnityEngine;

public class HealthSpell : MonoBehaviour
{
    public  SpellClass SpellClass;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }
}
