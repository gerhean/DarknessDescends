﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	public int totalHealth;
	private int health;
	public CharacterDeathEvent characterDeathEvent;
	public AllyType characterType;

	void Awake()
	{
		health = totalHealth;
		if (characterDeathEvent == null) {
			characterDeathEvent = new CharacterDeathEvent();
		}
	}

	void takeDamage(int i) {
		health -= i;
		if (health <= 0) {
			characterDeathEvent.Invoke(this);
			Destroy(gameObject);
		}
	}

    void OnCollisionEnter2D(Collision2D collision) {
        Damager damageComponent = collision.gameObject.GetComponent<Damager>();
        if (damageComponent != null) {
            onCollision(damageComponent);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Damager damageComponent = collision.gameObject.GetComponent<Damager>();
        if (damageComponent != null) {
            onCollision(damageComponent);
        }
    }

    private void onCollision(Damager damageComponent) {
        if (damageComponent.damageSource != characterType) {
            this.takeDamage(damageComponent.damageAmount);
            this.GetComponent<CharacterAnimator>().Hurt();
            damageComponent.triggerContact();
        }
    }
}
