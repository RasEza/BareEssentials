using System.Reflection;
using MonoMod.Cil;
using Terraria;
using Terraria.ModLoader;

namespace QuickSwap
{
	class QuickSwapMod : Mod
	{
        public static QuickSwapMod Instance;

        public override void Load()
        {
            Instance = this;
            Terraria.IL_Player.Update += UpdatePatch;
            Terraria.IL_Player.ScrollHotbar += ScrollHotbarPatch;
        }

        public override void Unload()
        {
            Instance = null;
        }

        private void ScrollHotbarPatch(ILContext il)
        {
            var ilCursor = new ILCursor(il);

            //remove check for itemAnimation, without removing this scrolling is fucked
            if (!ilCursor
                .TryGotoNext((i => 
                    i.MatchLdfld(typeof(Player) 
                        .GetField("itemAnimation", BindingFlags.Instance | BindingFlags.Public)))))
                return;
            ilCursor.RemoveRange(3);
        }

        private void UpdatePatch(ILContext il)
        {
            var ilCursor = new ILCursor(il);

            if (!ilCursor.TryGotoNext(
                i => i.MatchCall(typeof(Player), "dropItemCheck")))
                return;
            //goto place just before if clause i want to remove, then remove it.
            ilCursor.GotoPrev(i => i.MatchStfld(typeof(Player), "controlUseItem"));
            //goto twice to ensure that we keep the first Ldarg_0, and remove the one belonging to itemDropCheck instead
            //as that one doesnt have any other instructions that refer to it
            ilCursor.GotoNext();
            ilCursor.GotoNext();
            //now we remove this if statement and handle it ourselves:
            //  if (this.itemAnimation == 0 && this.itemTime == 0 && this.reuseDelay == 0)
            ilCursor.RemoveRange(9);
        }
    }
}