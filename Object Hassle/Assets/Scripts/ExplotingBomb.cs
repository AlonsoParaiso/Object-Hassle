using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class ExplotingBomb : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnDisable()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1);
        for (int i = 0; i < colliders.Length; i++) //recorremos elemento a elemento.
        {
            // y comprobamos si el elemento es suelo o no.
            if (colliders[i].gameObject.layer == LayerMask.NameToLayer("Player")) //Recorre cada elemento del array para ver si tocamos suelo
            {
                Character character = colliders[i].GetComponent<Character>();
                character.GetDamage();
            }
        }
        Debug.Log("no dar");
     
    }
}
