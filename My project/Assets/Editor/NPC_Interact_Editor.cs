using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NPC_Interact))]
public class NPC_Interact_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        //"draw" (meaning display on screen) the default inspector of our NPC_Interact Class
        //(or whatever class this custom editor is affecting
        //DrawDefaultInspector();
        //EditorGUILayout.HelpBox("Reminder: Load in the NPC Cam Prefab first, before trying to generate & assign variable", MessageType.Info);

        //we are loading a SerializedProperty tmp variable called `typeProp`
        //and we are loading in the `type` property from our NPC_Interact class
        SerializedProperty typeProp = serializedObject.FindProperty("type");
        EditorGUILayout.PropertyField(typeProp);

        iType currentType = (iType)typeProp.enumValueIndex;

        if(currentType == iType.npc)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("textData"));
            EditorGUILayout.HelpBox("Don't forget to write the string you want to display when interacting", MessageType.Info);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("dialogVars"));
        }

        //load the class we want to modify/change
        //so that we can call the methods from that class in our editor layout
        NPC_Interact npcI = (NPC_Interact)target;

        //if statements in Editor Scripts "generate" GUILayout elements instead of "checking" to see that they exist
        //the logic below does not query a condition, but instead makes the condition true by default
        if (GUILayout.Button("Set Interact Text Object"))
        {
            //use the npcI variable called above to call the setTextVars method in the editor/inspector
            npcI.setTextVars();
        }
        else if(GUILayout.Button("Set YarnSpinner Dialog Runner"))
        {
            npcI.setYS();
        }
        else if(GUILayout.Button("Load NPC Cam Prefab"))
        {
            npcI.loadNpcCamPrefab();
        }
        else if(GUILayout.Button("Set NPC Cam Variable"))
        {
            npcI.setNpcCam();
        }

        serializedObject.ApplyModifiedProperties();

    }
}
