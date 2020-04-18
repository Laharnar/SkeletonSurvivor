using UnityEngine;

public class SetScale : MonoBehaviour
{
    [Header("Random")]
    public BoolVarValue setRandom;
    public RectVarValue randomAreaAround;

    [Header("Controlled")]
    public IntVarValue active;
    public Vector3[] relativeScales;
    public TransformVarValue target;

    void Awake()
    {
        target.Value = transform;
    }

    public void Next()
    {
        active.Value = (active.Value + 1) % relativeScales.Length;
    }

    public void SetToSelectedScale()
    {
        if (setRandom.Value)
        {
            target.Value.localScale = NewRandom(randomAreaAround.Value);
        }
        else
        {
            target.Value.localScale = relativeScales[active.Value];
        }
    }

    Vector2 NewRandom(Rect rect)
    {
        return new Vector2(
            randomAreaAround.Value.x + Random.value * randomAreaAround.Value.width,
            randomAreaAround.Value.y + Random.value * randomAreaAround.Value.height);
    }
}