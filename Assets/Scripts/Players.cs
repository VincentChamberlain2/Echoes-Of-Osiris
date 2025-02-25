using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    GameObject Cat, Mummy;

}
public class Mummy {
    int maxHealth;
    int health;
    int mana;

    int movementRange = 2;
    int attackRange = 1;

}
public class Cat : Players {
    int maxHealth;
    int health;
    int mana;

    int movementRange = 3;
    int attackRange = 1;
}

