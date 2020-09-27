using UnityEngine;
using XLua;

namespace XLuaTest
{ 
    [Hotfix]
    [LuaCallCSharp]
    public class HotfixMultiply
    {
        public int Multiply(int a, int b)
        {
            return a + b;
        }
    }

    public class NoHotfixMultiply
    {
        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }

    public class HotfixTestByChuck : MonoBehaviour
    {
        //use this for initialization
        void Start()
        {

            Debug.Log("This is the hotfix test made by Chao Liu.");
            Debug.Log("Student ID: 2020214421.");
            LuaEnv luaenv = new LuaEnv();
            HotfixMultiply multi = new HotfixMultiply();
            NoHotfixMultiply ordinaryMulti = new NoHotfixMultiply();

            int CALL_TIME = 100 * 1000 * 1000;
            var start = System.DateTime.Now;
            for (int i = 0; i < CALL_TIME; i++)
                multi.Multiply(2, 1);
            var d1 = (System.DateTime.Now - start).TotalMilliseconds;
            Debug.Log("Hotfix uses " + d1);

            start = System.DateTime.Now;
            for (int i = 0; i < CALL_TIME; i++)
                ordinaryMulti.Multiply(2, 1);
            var d2 = (System.DateTime.Now - start).TotalMilliseconds;
            Debug.Log("NoHotfix uses " + d2);

            Debug.Log("drop:" + (d1 - d2) / d1);

            Debug.Log("Before fix: 2 * 1 =" + multi.Multiply(2, 1));
            luaenv.DoString(@"
            xlua.hotfix(CS.XLuaTest.HotfixMultiply, 'Multiply', function(self, a, b)
                return a * b
            end)
        ");
            Debug.Log("After fix: 2 * 1 =" + multi.Multiply(2, 1));
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

