#if UNITY_EDITOR

using ColorSystem;
using UnityEditor;
using UnityEngine;

namespace LevelGeneratorSystem
{
    public class LevelGenerator : EditorWindow
    {
        private Transform levelParent;
        private GameObject prefab;
        private float prefabSize;
        private float areaPerPixel;
        private Color emptySpaceColor;
        private float colorSimilarityThreshold;
        private Texture2D levelTexture;
        private bool keepAspectRatio;
        private bool oldKeepAspectRatio;
        private float aspectRatio;
        private Vector2Int size;
        private Vector2Int oldSize;
        private Texture2D scaledLevelTexture;
        private bool destroyParentChildren;


        [MenuItem("Tools/Level Generator")]
        public static void OpenTheWindow()
        {
            GetWindow<LevelGenerator>("Level Generator");
        }

        
        private void Awake()
        {
            prefabSize = 1;
            areaPerPixel = .5f;
            size = Vector2Int.one * 100;
            destroyParentChildren = true;
            emptySpaceColor = Color.black;
            colorSimilarityThreshold = .1f;
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();

            levelParent = EditorGUILayout.ObjectField("GameObject Parent",levelParent, typeof(Transform), true) as Transform;
            prefab = EditorGUILayout.ObjectField("Prefab",prefab, typeof(GameObject), false) as GameObject;
            prefabSize = EditorGUILayout.FloatField("Size of the Objects", prefabSize);
            prefabSize = Mathf.Max(0.1f, prefabSize); 
            areaPerPixel = EditorGUILayout.FloatField("Area Per Pixel", areaPerPixel);
            areaPerPixel = Mathf.Max(0.1f, areaPerPixel);
            emptySpaceColor = EditorGUILayout.ColorField("Empty Space Color", emptySpaceColor);
            colorSimilarityThreshold = EditorGUILayout.FloatField("Color Similarity Threshold", colorSimilarityThreshold);
            levelTexture = EditorGUILayout.ObjectField("Level Texture (Source)", levelTexture, typeof(Texture2D), false) as Texture2D;
            if (levelTexture)
            {
                oldKeepAspectRatio = keepAspectRatio;
                keepAspectRatio = EditorGUILayout.Toggle("Keep Aspect Ratio", keepAspectRatio);
                oldSize = size;
                size = EditorGUILayout.Vector2IntField("Size of the Texture", size);
                size.x = Mathf.Max(0, size.x); 
                size.y = Mathf.Max(0, size.y); 
                if (keepAspectRatio)
                {
                    aspectRatio = levelTexture.width * 1f / levelTexture.height;
                    if (oldKeepAspectRatio == false)
                    {
                        size.x = (int)(size.y * aspectRatio);
                    }
                    if (oldSize.y != size.y)
                    {
                        size.x = (int)(size.y * aspectRatio);
                    }
                    else if (oldSize.x != size.x)
                    {
                        size.y = (int)(size.x / aspectRatio);
                    }

                }
                if (GUILayout.Button("Create Scaled Texture"))
                {
                    ScaleTexture();
                }
                if (scaledLevelTexture)
                {
                    var rect = EditorGUILayout.GetControlRect();
                    var normalizedSize = ((Vector2)size).normalized; 
                    rect = new Rect(rect.x+(1-normalizedSize.x)*position.width*.5f, rect.y , normalizedSize.x*position.width, normalizedSize.y*position.width);
                    EditorGUI.DrawPreviewTexture(rect, scaledLevelTexture);
                    GUILayout.Space(rect.height);
                }
                destroyParentChildren = EditorGUILayout.Toggle("Destroy Parent Children", destroyParentChildren);
                if (GUILayout.Button("Create Level Objects"))
                {
                    ScaleTexture();
                    CreateLevelObjects();
                }
            }
            EditorGUILayout.EndVertical();

        }

        private void ScaleTexture() 
        {
            if (scaledLevelTexture)
            {
                DestroyImmediate(scaledLevelTexture);
            }
            scaledLevelTexture=new Texture2D(size.x,size.y,levelTexture.format,false);
            scaledLevelTexture.alphaIsTransparency = true;
            float incX=(1.0f / (float)size.x);
            float incY=(1.0f / (float)size.y);

            for (int i = 0; i < scaledLevelTexture.height; ++i) {
                for (int j = 0; j < scaledLevelTexture.width; ++j) {
                    Color newColor = levelTexture.GetPixelBilinear((float)j / (float)scaledLevelTexture.width, (float)i / (float)scaledLevelTexture.height);
                    scaledLevelTexture.SetPixel(j, i, newColor);
                }
            }

            scaledLevelTexture.Apply();
        }

        private void CreateLevelObjects()
        {
            if (prefab == null)
            {
                Debug.Log("No Object Prefab");
                return;
            }
            if (levelParent == null)
            {
                levelParent = new GameObject(levelTexture.name).transform;
            }
            if (destroyParentChildren)
            {
                var count = levelParent.childCount;
                for (int i = 0; i < count; i++)
                {
                    DestroyImmediate(levelParent.GetChild(0).gameObject);
                }
            }

            Vector3 offset = new Vector3(size.x,0,size.y) * (areaPerPixel * .5f);
                
            for (int i = 0; i < size.x; i++)
            {
                for (int j = 0; j < size.y; j++)
                {
                    Color pixel = scaledLevelTexture.GetPixel(i, j);
                    if (!IsSimilarColor(pixel, Color.clear) && !IsSimilarColor(pixel, emptySpaceColor))
                    {
                        GameObject gameObject = PrefabUtility.InstantiatePrefab(prefab,levelParent) as GameObject;
                        gameObject.GetComponent<ColorSetter>().SetColor(pixel);
                        gameObject.transform.localScale = Vector3.one*prefabSize;
                        gameObject.transform.localPosition = new Vector3(j, 0, i) * areaPerPixel-offset;
                    }
                }   
            }
        }

        private bool IsSimilarColor(Color color1, Color color2)
        {
            if (Mathf.Abs(color1.r - color2.r) > colorSimilarityThreshold)
            {
                return false;
            }
            if (Mathf.Abs(color1.g - color2.g) > colorSimilarityThreshold)
            {
                return false;
            }
            if (Mathf.Abs(color1.b - color2.b) > colorSimilarityThreshold)
            {
                return false;
            }

            return true;
        }
    }

}

#endif