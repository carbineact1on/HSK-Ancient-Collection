using RimWorld;
using Verse;
using RimWorld.QuestGen;
using System.Collections.Generic;

namespace BreadMoAncientFarm
{
    public class CompProperties_UseEffectGiveQuestRandom : CompProperties_UseEffect
    {
        public List<QuestScriptDef> quests;

        public bool? discovered;

        public CompProperties_UseEffectGiveQuestRandom()
        {
            compClass = typeof(CompUseEffect_GiveQuestRandom);
        }
    }

    public class CompUseEffect_GiveQuestRandom : CompUseEffect
    {
        public CompProperties_UseEffectGiveQuestRandom Props => (CompProperties_UseEffectGiveQuestRandom)props;

        public override void DoEffect(Pawn user)
        {
            Slate slate = new Slate();
            slate.Set("points", StorytellerUtility.DefaultThreatPointsNow(user.Map));
            slate.Set("asker", user);
            if (Props.discovered.HasValue)
            {
                slate.Set("discovered", Props.discovered.Value);
            }
            Quest quest = QuestUtility.GenerateQuestAndMakeAvailable(Props.quests.RandomElement(), slate);
            if (!quest.hidden && quest.root.sendAvailableLetter)
            {
                QuestUtility.SendLetterQuestAvailable(quest);
            }
        }
    }

}
