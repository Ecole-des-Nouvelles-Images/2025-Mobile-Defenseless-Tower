using System;
using UnityEngine;

public class FreezSpell : MonoBehaviour
{
    public  SpellClass SpellClass;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }
}
