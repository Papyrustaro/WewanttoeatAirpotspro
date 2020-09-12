using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IGuard
{
    void Guard(Movement movement, Action onFinish);
}
