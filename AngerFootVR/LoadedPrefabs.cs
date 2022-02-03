using UnityEngine;

namespace AngerFootVR
{
    public static class LoadedPrefabs
    {
        public static Object LeftHandPrefab;
        public static Object RightHandPrefab;
        public static Object Capsule;
        public static Object Cube;
        public static Object Cylinder;
        public static Object Plane;
        public static Object Quad;
        public static Object Sphere;

        public static void Initialize()
        {
            var handsBundle = AssetBundle.LoadFromFile(@"C:\Users\Admin\Downloads\Anger Foot VR\Mods\Packages\hands");
            LeftHandPrefab = handsBundle.LoadAsset("LeftHand");
            RightHandPrefab = handsBundle.LoadAsset("RightHand");

            var primitivesBundle = AssetBundle.LoadFromFile(@"C:\Users\Admin\Downloads\Anger Foot VR\Mods\Packages\primitives");
            Capsule = primitivesBundle.LoadAsset("Capsule");
            Cube = primitivesBundle.LoadAsset("Cube");
            Cylinder = primitivesBundle.LoadAsset("Cylinder");
            Plane = primitivesBundle.LoadAsset("Plane");
            Quad = primitivesBundle.LoadAsset("Quad");
            Sphere = primitivesBundle.LoadAsset("Sphere");
        }
    }
}
