using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IAttack
{
    void Attack(Movement movement, Action onFinish);
}
