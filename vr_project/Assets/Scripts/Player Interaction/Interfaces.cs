////////////////////////////////////////////////////////////////////////////////////////////////////////
//Author : Jeremy Almonte
//Created On : 10/10/2023
//Description : Hold all the interfaces used for whatever kind of interactions we need in-game
////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact();
    //void Interact(T interactable, int id);
}

public interface IDamageable<T>
{
    void Damage(T damageTaken);
}
