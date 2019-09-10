﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDG
{
public abstract class Weapon : MonoBehaviour, IItem
{
    public void OnPickUp(ICharacter c)
    {
        c.EquipAsWeapon(this);
    }

    public void SetParentTransform(Transform t)
    {
        transform.parent = t;
        transform.position = t.position;

    }

    public void SetFaceDirection(bool facingRight)
    {
        Vector3 weaponScale = transform.localScale;
        float xSign = facingRight ? 1 : -1; // To Change
        transform.localScale =
            new Vector3(weaponScale.x * xSign,
                        weaponScale.y,
                        weaponScale.z);
    }


    public void Destroy()
    {
        Destroy(gameObject);
    }

    public abstract void Use();
}
}
