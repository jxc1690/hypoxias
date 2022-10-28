using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using TUNING;
using UnityEngine;
namespace 缺氧mod
{
    public class Patches//固定代码
    {
        [HarmonyPatch(typeof(LiquidHeaterConfig))]//定位代码
        [HarmonyPatch("CreateBuildingDef")]//定位函数
        public class Patch_a//项目编号
        {
            public static void Postfix(ref BuildingDef __result)//固定代码
            {
                __result.Overheatable = false;
                //buildingDef.OverheatTemperature = 3000f + 273.15f;
                __result.BaseMeltingPoint = 3000f+273.15f;
                __result.EnergyConsumptionWhenActive = 100f;
            }
        }
        
        [HarmonyPatch(typeof(LiquidHeaterConfig))]//定位代码
        [HarmonyPatch("ConfigureBuildingTemplate")]//定位函数
        public class Patch_b//项目编号
        {
            public static void Postfix(GameObject go, Tag prefab_tag)
            {
                go.AddOrGet<SpaceHeater>().targetTemperature = 2500f + 273.15f;
                //spaceHeater.minimumCellMass = 400f;
            }
        }
    }
}
