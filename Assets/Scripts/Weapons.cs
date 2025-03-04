using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    
}
// Default weapon for Cat
public class Stratch { 
    int attackRange = 1;
    int damage = 5;
}
// Default weapon for Mummy
public class Punch { 
    int attackRange = 1;
    int damage = 10;
}
public class Sword  {
    int attackRange = 1;
    int damage = 20 ;
    // Cat gains +20 max HP
}
public class Spear {
    int attackRange = 2;
    int damage = 15;
    // The Cat goes first 
}
public class Bow {
    int attackRange = 3;
    int damage = 10;
    // Cat gets +2 Range on spells and attacks
}
