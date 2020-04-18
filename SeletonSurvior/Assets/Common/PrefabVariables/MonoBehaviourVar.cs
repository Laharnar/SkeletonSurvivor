using System;
using UnityEngine;

[CreateAssetMenu]
public class MonoBehaviourVar:ScriptableObject {
     
    public MonoBehaviour value;
    public string expectType;

    public object Value {
        get {
            if (ValueTypeEqualsPrefabType())
                return value;
            return null;
        }
    }

    public T GetValueAs<T>() where T:MonoBehaviour
    {
        if (EqualsPrefabType(typeof(T)))
            return (T)value;
        else throw InvalidIncorrectTypeException(typeof(T));
    }

    private Exception InvalidIncorrectTypeException(Type type)
    {
        return new System.InvalidCastException("Type isn't same as is set in this prefab." + type + " != " + expectType + " n:" + name);
    }

    public void SetValue(MonoBehaviour val)
    {
        if (!val)
        {
            throw new NullReferenceException("setting value to null isn't allowed.");
        }
        this.value = val;
        TrySetCorrectType(val.GetType());
    }

    private bool TrySetCorrectType(Type t)
    {
        expectType = t.ToString();
        return true;
    }

    private bool ValueTypeEqualsPrefabType()
    {
        return EqualsPrefabType(value.GetType());
    }

    private bool EqualsPrefabType(Type t)
    {
        return t.Name == expectType.ToString();
    }

}
