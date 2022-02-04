using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

using HarmonyLib;
using AuroraPatch;
using Lib;
using System.Data;

namespace SYComponenentsByDefault
{
    public class SYComponenentsByDefault : AuroraPatch.Patch
    {
        public override string Description => "Shipyard Use Components defaults to ticked with this mod active.";
        public override IEnumerable<string> Dependencies => new[] { "Lib" };

        protected override void Loaded(Harmony harmony)
        {
            var lib = GetDependency<Lib.Lib>("Lib");
            lib.RegisterEventHandler(AuroraType.EconomicsForm, "Shown", GetType().GetMethod("ShownHandler", AccessTools.all));
            
        }

        private static void ShownHandler(object sender, EventArgs e)
        {
            var subgf = UIManager.GetControlByName<CheckBox>((Form)sender, "chkUseComponents");
            subgf.Checked = true;
        }
    }
}