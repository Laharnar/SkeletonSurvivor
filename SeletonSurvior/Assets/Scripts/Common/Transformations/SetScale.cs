using UnityEngine;

public class SetScale : MonoBehaviour
{
    [Header("Random")]
    public BoolVarValue setRandom;
    public RectVarValue randomAreaAround;

    [Header("Controlled")]
    public BoolVarValue useControlled;
    public IntVarValue active;
    public Vector3[] relativeScales;
    public TransformVarValue target;

    [Header("Prefab floats")]
    public BoolVarValue usePrefabs;
    public FloatVarRef fx;
    public FloatVarRef fy;
    public FloatVarRef fz;
    you were working on getting hp ready
        to scale down when hp is reduced
        hp doesnt ahve calulcation on get damage
        to update ui with set scale
        it's to linked yet
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
        else if(useControlled.Value)
        {
            target.Value.localScale = relativeScales[active.Value];
        }
        else if(usePrefabs.Value)
        {
            target.Value.localScale = new Vector3(fx.Value, fy.Value, fz.Value);
        }
    }

    Vector2 NewRandom(Rect rect)
    {
        return new Vector2(
            randomAreaAround.Value.x + Random.value * randomAreaAround.Value.width,
            randomAreaAround.Value.y + Random.value * randomAreaAround.Value.height);
    }
}