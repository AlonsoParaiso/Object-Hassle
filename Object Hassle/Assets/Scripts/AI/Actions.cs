using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actions : ScriptableObject
{
    // la accion no se puede implementar 
    public abstract bool Check(GameObject owner); // ejecutar el comportamiento de la accion

    // metodo abstracto de dibujar gizmo 
    public abstract void DrawGizmos(GameObject owner);
}
