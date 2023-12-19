using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
    public virtual bool StartSpecialAttack(GameObject owner) 
    { 
        return true;
    }
}
