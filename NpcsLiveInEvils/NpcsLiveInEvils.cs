using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;
using Terraria.ModLoader;

namespace NpcsLiveInEvils
{
	public class NpcsLiveInEvils : Mod
	{
        public override void Load()
        {
            IL.Terraria.WorldGen.ScoreRoom += NpcHouseScorePatch;
        }

        // Removes call to GetTileTypeCountByCategory in ScoreRoom method
        // Needs to also remove parameters to the method
        // The return value of the call is replaced to always be 0
        // This makes it corruption/hallow is never counted against house score
        private void NpcHouseScorePatch(ILContext il)
        {
            var ilCursor = new ILCursor(il);

            // Cursor <--
            // bunch of IL
            // IL: arr
            // IL: dup
            // bunch of IL
            // IL: ldc.i4.4
            // IL: call

            if (ilCursor.TryGotoNext(i => i.MatchCall(typeof(WorldGen).GetMethod(nameof(WorldGen.GetTileTypeCountByCategory)))))
            {
                // bunch of IL
                // IL: arr
                // IL: dup
                // bunch of IL
                // IL: ldc.i4.4
                // Cursor <--
                // IL: call

                ilCursor.GotoPrev();
                // bunch of IL
                // IL: arr
                // IL: dup
                // bunch of IL
                // Cursor <--
                // IL: ldc.i4.4
                // IL: call

                // Remove GetTileTypeCountByCategory and call
                ilCursor.RemoveRange(2);
                // bunch of IL
                // IL: arr
                // IL: dup
                // bunch of IL
                // Cursor <--

                ilCursor.Emit(OpCodes.Ldc_I4_0);
                // bunch of IL
                // IL: arr
                // IL: dup
                // bunch of IL
                // Cursor <--
                // IL: ldc.i4.0


                ilCursor.GotoPrev(i => i.MatchDup());
                // bunch of IL
                // IL: arr
                // Cursor <--
                // IL: dup
                // bunch of IL
                // IL: ldc.i4.0

                // duplicate adds an extra array to the stack, as we remove the call that consumes this, we remove it
                ilCursor.Remove();
                // bunch of IL
                // IL: arr
                // Cursor <--
                // bunch of IL
                // IL: ldc.i4.0
            }
        }
    }
}