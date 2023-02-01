using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;


[CustomEditor(typeof(MonoBehaviour), true)]
public class ButtonAttribute : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MonoBehaviour script = (MonoBehaviour)target;

        MethodInfo[] methods = script.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (MethodInfo method in methods)
        {
            if (method.GetCustomAttributes(typeof(Button), true).Length > 0)
            {
                if (GUILayout.Button(method.Name))
                {
                    method.Invoke(script, null);
                }
            }
        }
    }
}
