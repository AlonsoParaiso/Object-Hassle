using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ActionParameters
{

    [Tooltip("Action that is gonna be executed")]
    public Actions actions;
    [Tooltip("Indicates if the actions check must be true or false")]
    public bool actionValues;
}

[System.Serializable]
public struct StateParameters
{
    [Tooltip("ActionsParameter´s array")]
    public ActionParameters[] actionParameters;
    [Tooltip("if the actions check equals actionsValue, nextState is pushed")]
    public State nextState;
    [Tooltip("All actions are executed or just one?")]
    public bool and;
}
public abstract class State : ScriptableObject
{
    
    public StateParameters[] stateparameters;

    public void DrawAllActionsGizmos(GameObject owner)
    {
        foreach (StateParameters parameters in stateparameters)
        {
            foreach (ActionParameters Av in parameters.actionParameters)
            {
                Av.actions.DrawGizmos(owner);
            }
        }
    }

    // Action [] actions
    // [CreateAssetMenu()]

    protected State CheckActions(GameObject owner)
    {
        for (int i = 0; i < stateparameters.Length; i++) // recorre el array de los parametros del estado
        {
            bool todaslasAccionesSeHanCumplido = true;
            for (int j = 0; j < stateparameters[i].actionParameters.Length; j++) // recorre un segundo array de las acciones 
            {
                ActionParameters actionparameter = stateparameters[i].actionParameters[j]; // evitamos repetir codigo
                if (actionparameter.actions.Check(owner) == actionparameter.actionValues) // si las acciones on iguales al valor
                {
                    if (!stateparameters[i].and) // si solo se tiene que cumplir una 
                    {
                        return stateparameters[i].nextState; // devuelve el siguiente estado 
                    }
                }
                else if (stateparameters[i].and) // estanmos seguros de que esta accion no se ha cumplido. Se ha marcado que se deben cumplir todas
                {
                    todaslasAccionesSeHanCumplido = false;
                    break; // salimos del bucle, porque una accion no se ha cumplido y estamos en and 
                }
            }
            // si llegamos hasta aqui, significa que el disegnador que todas las acciones tienen que cumplirse. Ademas, se ha cumplido
            if (stateparameters[i].and && todaslasAccionesSeHanCumplido)
            {
                return stateparameters[i].nextState;
            }
        }
        return null;   // ninguna accion se cumple, por lo que no cambiamos de estado
    }

    // comprueba si las acciones se cumplen y ademas
    // ejecuta el comportamiento asociado al estado
    public abstract State Run(GameObject owner);
}