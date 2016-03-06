﻿using System.Linq;

using EloBuddy;
using EloBuddy.SDK;

namespace ezEvade.SpecialSpells
{
    class Yasuo : ChampionPlugin
    {
        static Yasuo()
        {

        }

        public void LoadSpecialSpell(SpellData spellData)
        {
            if (spellData.spellName == "YasuoQW")
            {
                AIHeroClient hero = EntityManager.Heroes.Enemies.FirstOrDefault(h => h.ChampionName == "Yasuo");
                if (hero == null)
                {
                    return;
                }

                AIHeroClient.OnProcessSpellCast += (sender, args) => ProcessSpell_YasuoQW(sender, args, spellData);
            }

            if (spellData.spellName == "yasuoq3w")
            {
                AIHeroClient hero = EntityManager.Heroes.Enemies.FirstOrDefault(h => h.ChampionName == "Yasuo");
                if (hero == null)
                {
                    return;
                }

                AIHeroClient.OnProcessSpellCast += (sender, args) => ProcessSpell_YasuoQW(sender, args, spellData);
            } 
        }

        private static void ProcessSpell_YasuoQW(Obj_AI_Base hero, GameObjectProcessSpellCastEventArgs args, SpellData spellData)
        {
            if (hero.IsEnemy && args.SData.Name == "yasuoq")
            {
                var castTime = (hero.Spellbook.CastTime - Game.Time) * 1000;

                if (castTime > 0)
                {
                    spellData.spellDelay = castTime;
                }
            }
        }
    }
}
