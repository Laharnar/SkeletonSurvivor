﻿using UnityEngine;


[System.Serializable]
public class ConditionGroup {
    public BoolVar[] boolConditions;

    public Condition[] conditions;
    public bool state = false;
    public int op;// 0: and, 1: or
    public bool skip = false;
    public bool valueOnSkip = true;

    public bool IsTrue()
    {
        if (skip)
        {
            return valueOnSkip;
        }
        if (op == 0)
        {
            state= And();
            return state;
        }
        else if( op == 1)
        {
            state = Or();
            return state;
        }
        else
        {
            throw new System.NotImplementedException("Op number isn't implemented. "+op);
        }
    }

    public bool IsFalse()
    {
        return IsTrue();
    }

    private bool Or()
    {
        if (conditions.Length == 0)
        {
            return valueOnSkip;
        }
        for (int i = 0; i < conditions.Length; i++)
        {
            if (conditions[i] == null)
            {
                throw new System.NullReferenceException("Condition in condition group is null.");
            }
            else if (conditions[i].IsTrue())
                return true;
        }
        return false;
    }

    private bool And()
    {
        if (conditions.Length == 0)
        {
            return valueOnSkip;
        }
        for (int i = 0; i < conditions.Length; i++)
        {
            if (conditions[i] == null)
            {
                throw new System.NullReferenceException("Condition in condition group is null.");
            }
            else if (conditions[i].IsFalse())
            {
                return false;
            }
        }
        return true;
    }

    bool IsBoolOnlyTrue(BoolVar b, bool cond)
    {
        return (b.value && !cond) || 
            (!b.value && cond);
    }
}
