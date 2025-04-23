using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SpawnBlocksInEditor : MonoBehaviour
{
    public GameObject blockPrefab;
    public int numberOfBlocks = 999;
    public float zOffset = -17f;

    public void SpawnBlocks()
    {
        Vector3 spawnPosition = transform.position;

        for (int i = 0; i < numberOfBlocks; i++)
        {
#if UNITY_EDITOR
            GameObject block = PrefabUtility.InstantiatePrefab(blockPrefab) as GameObject;
#else
            GameObject block = Instantiate(blockPrefab);
#endif
            block.transform.position = spawnPosition;
            spawnPosition.z += zOffset; // Измените y на z, чтобы спавнить по оси z

            block.transform.parent = this.transform; // Делаем спавненный объект дочерним элементом текущего объекта
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(SpawnBlocksInEditor))]
public class SpawnBlocksInEditorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SpawnBlocksInEditor myScript = (SpawnBlocksInEditor)target;
        if(GUILayout.Button("Spawn Blocks"))
        {
            myScript.SpawnBlocks();
        }
    }
}
#endif