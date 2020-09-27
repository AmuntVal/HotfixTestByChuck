using System;

using System.Collections.Generic;

using System.Linq;

using System.Reflection;

using XLua;
/*
namespace XLuaTest
{

    //如果涉及到Assembly-CSharp.dll之外的其它dll，如下代码需要放到Editor目录
    public static class HotfixCfg
    {
        [Hotfix]
        public static List<Type> By_field = new List<Type>()
    {
        typeof(HotfixMultiply),
        typeof(GenericClass<>),
    };

        [Hotfix]
        public static List<Type> By_property
        {
            get
            {
                return (from type in Assembly.Load("Assembly-CSharp").GetTypes()
                        where type.Namespace == "XLuaTest"
                        select type).ToList();
            }
        }
    }
}
*/