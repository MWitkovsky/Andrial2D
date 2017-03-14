using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysLayers {

    public static readonly int defaultLayer = LayerMask.NameToLayer("Default");
    public static readonly int transparentFX = LayerMask.NameToLayer("Transparent FX");
    public static readonly int ignoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
    public static readonly int water = LayerMask.NameToLayer("Water");
    public static readonly int ui = LayerMask.NameToLayer("UI");
    public static readonly int ground = LayerMask.NameToLayer("Ground");
    public static readonly int player = LayerMask.NameToLayer("Player");
    public static readonly int items = LayerMask.NameToLayer("Items");
    public static readonly int enemies = LayerMask.NameToLayer("Enemies");
    public static readonly int corpses = LayerMask.NameToLayer("Corpses");
}
