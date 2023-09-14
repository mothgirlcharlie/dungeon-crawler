using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class PlayerHealthManager
{
    public static int maxHealth;
    public static int currentHealth;
    public static Dictionary<String, int> armor = new Dictionary<String, int>
    {
        {"base", 0},
        {"sun", 0},
        {"moon", 0},
        {"sky", 0},
        {"tera", 0}
    };
    public static Dictionary<String, bool> weaknesses = new Dictionary<String, bool>
    {
        {"base", false},
        {"sun", false},
        {"moon", false},
        {"sky", false},
        {"tera", false}
    };
    public static Dictionary<String, bool> resists = new Dictionary<String, bool>
    {
        {"base", false},
        {"sun", false},
        {"moon", false},
        {"sky", false},
        {"tera", false}
    };

    public static void Hurt(int damage, string element)
    {
        int finalDamage = damage - armor[element];
        if(weaknesses[element])
        {
            finalDamage *= 2;
        }
        if(resists[element])
        {
            finalDamage /= 2;
        }
        if(finalDamage <= 0)
        {
            finalDamage = 1;
        }
        currentHealth -= finalDamage;
        if(currentHealth < 0)
        {
            Die();
        }
    }

    public static void Die()
    {
        //Play death animation
        Time.timeScale = 0;
    }
}
