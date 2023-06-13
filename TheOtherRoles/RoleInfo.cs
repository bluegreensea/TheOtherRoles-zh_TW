using System.Linq;
using System;
using System.Collections.Generic;
using TheOtherRoles.Players;
using static TheOtherRoles.TheOtherRoles;
using UnityEngine;
using TheOtherRoles.Utilities;
using TheOtherRoles.CustomGameModes;

namespace TheOtherRoles
{
    public class RoleInfo {
        public Color color;
        public string name;
        public string introDescription;
        public string shortDescription;
        public RoleId roleId;
        public bool isNeutral;
        public bool isModifier;

        public RoleInfo(string name, Color color, string introDescription, string shortDescription, RoleId roleId, bool isNeutral = false, bool isModifier = false) {
            this.color = color;
            this.name = name;
            this.introDescription = introDescription;
            this.shortDescription = shortDescription;
            this.roleId = roleId;
            this.isNeutral = isNeutral;
            this.isModifier = isModifier;
        }

        public static RoleInfo jester = new RoleInfo("小丑", Jester.color, "被投出去", "被投出去", RoleId.Jester, true);
        public static RoleInfo mayor = new RoleInfo("市長", Mayor.color, "投票會變兩票", "投票會變兩票", RoleId.Mayor);
        public static RoleInfo portalmaker = new RoleInfo("傳送師", Portalmaker.color, "你可以建造傳送門", "你可以建造傳送門", RoleId.Portalmaker);
        public static RoleInfo engineer = new RoleInfo("工程師",  Engineer.color, "維護船上的重要系統 ", "修復船隻", RoleId.Engineer);
        public static RoleInfo sheriff = new RoleInfo("警長", Sheriff.color, "射擊 <color=#FF1919FF>偽裝者</color>", "射擊偽裝者", RoleId.Sheriff);
        public static RoleInfo deputy = new RoleInfo("警員", Sheriff.color, "上銬<color=#FF1919FF>偽裝者</color>", "上銬偽裝者", RoleId.Deputy);
        public static RoleInfo lighter = new RoleInfo("點燈人", Lighter.color, "你的燈永不熄滅", "你的燈永不熄滅", RoleId.Lighter);
        public static RoleInfo godfather = new RoleInfo("教父", Godfather.color, "殺死所有船員", "殺死所有船員", RoleId.Godfather);
        public static RoleInfo mafioso = new RoleInfo("黑手黨員", Mafioso.color, "在<color=#FF1919FF>黑手黨</color>工作，教父死後殺死船員", "殺死所有船員", RoleId.Mafioso);
        public static RoleInfo janitor = new RoleInfo("守墓人", Janitor.color, "在<color=#FF1919FF>黑手黨</color>工作，隱藏屍體", "隱藏屍體", RoleId.Janitor);
        public static RoleInfo morphling = new RoleInfo("百變怪", Morphling.color, "改變你的樣子避免被抓到", "改變你的樣子", RoleId.Morphling);
        public static RoleInfo camouflager = new RoleInfo("魔術師", Camouflager.color, "偽裝並殺死船員", "隱藏船員其中", RoleId.Camouflager);
        public static RoleInfo vampire = new RoleInfo("吸血鬼", Vampire.color, "咬人來殺死船員", "咬你的敵人", RoleId.Vampire);
        public static RoleInfo eraser = new RoleInfo("抹除者", Eraser.color, "殺死船員並抹除他們的職業", "抹除敵人的職業", RoleId.Eraser);
        public static RoleInfo trickster = new RoleInfo("詭騙師", Trickster.color, "用你的詭騙箱讓別人大吃一驚", "讓你的敵人大吃一驚", RoleId.Trickster);
        public static RoleInfo cleaner = new RoleInfo("清道夫", Cleaner.color, "殺人並不留痕跡", "清理屍體", RoleId.Cleaner);
        public static RoleInfo warlock = new RoleInfo("咒詛師", Warlock.color, "詛咒其他玩家並殺死所有人", "詛咒並殺死所有人", RoleId.Warlock);
        public static RoleInfo bountyHunter = new RoleInfo("賞金獵人", BountyHunter.color, "追捕你的懸賞", "追捕你的懸賞", RoleId.BountyHunter);
        public static RoleInfo detective = new RoleInfo("偵探", Detective.color, "通過檢查腳印來找到<color=#FF1919FF>偽裝者</color>", "檢查腳印", RoleId.Detective);
        public static RoleInfo timeMaster = new RoleInfo("時間管理大師", TimeMaster.color, "用你的時間之盾保護自己", "用你的時間之盾", RoleId.TimeMaster);
        public static RoleInfo medic = new RoleInfo("醫生", Medic.color, "用盾牌保護某人", "保護其他人", RoleId.Medic);
        public static RoleInfo swapper = new RoleInfo("換票師", Swapper.color, "交換得票來放逐<color=#FF1919FF>偽裝者</color>", "交換得票", RoleId.Swapper);
        public static RoleInfo seer = new RoleInfo("靈媒", Seer.color, "你可以看到玩家的死亡", "你可以看到玩家的死亡", RoleId.Seer);
        public static RoleInfo hacker = new RoleInfo("駭客", Hacker.color, "駭入系統來找到<color=#FF1919FF>偽裝者</color>", "駭入來找到偽裝者", RoleId.Hacker);
        public static RoleInfo tracker = new RoleInfo("追踪者", Tracker.color, "追踪<color=#FF1919FF>偽裝者</color>", "追踪偽裝者", RoleId.Tracker);
        public static RoleInfo snitch = new RoleInfo("密探", Snitch.color, "完成你的任務來找出<color=#FF1919FF>偽裝者</color>", "完成你的任務", RoleId.Snitch);
        public static RoleInfo jackal = new RoleInfo("豺狼", Jackal.color, "殺死所有船員與<color=#FF1919FF>偽裝者</color>來勝利", "殺死所有人", RoleId.Jackal, true);
        public static RoleInfo sidekick = new RoleInfo("跟班", Sidekick.color, "幫助你的豺狼殺死所有人", "幫助你的豺狼殺死所有人", RoleId.Sidekick, true);
        public static RoleInfo spy = new RoleInfo("間諜", Spy.color, "讓<color=#FF1919FF>偽裝者</color>混亂", "讓偽裝者混亂", RoleId.Spy);
        public static RoleInfo securityGuard = new RoleInfo("守衛", SecurityGuard.color, "封鎖通風口跟放置攝影機", "封鎖通風口跟放置攝影機", RoleId.SecurityGuard);
        public static RoleInfo arsonist = new RoleInfo("縱火狂", Arsonist.color, "燒了大家", "燒了大家", RoleId.Arsonist, true);
        public static RoleInfo goodGuesser = new RoleInfo("好賭徒", Guesser.color, "猜測並放逐", "猜測並放逐", RoleId.NiceGuesser);
        public static RoleInfo badGuesser = new RoleInfo("壞賭徒", Palette.ImpostorRed, "猜測並放逐", "猜測並放逐", RoleId.EvilGuesser);
        public static RoleInfo vulture = new RoleInfo("禿鷲", Vulture.color, "吃屍體來獲勝 ", "吃屍體 ", RoleId.Vulture, true);
        public static RoleInfo medium = new RoleInfo("通靈師", Medium.color, "詢問靈魂來取得資訊", "詢問靈魂", RoleId.Medium);
        public static RoleInfo trapper = new RoleInfo("陷阱師", Trapper.color, "放置陷阱來找出偽裝者", "放置陷阱", RoleId.Trapper);
        public static RoleInfo lawyer = new RoleInfo("律師", Lawyer.color, "保護您的客戶", "保護您的客戶", RoleId.Lawyer, true);
        public static RoleInfo prosecutor = new RoleInfo("檢察官", Lawyer.color, "票出你的目標", "票出你的目標", RoleId.Prosecutor, true);
        public static RoleInfo pursuer = new RoleInfo("原告", Pursuer.color, "填空偽裝者", "填空偽裝者", RoleId.Pursuer);
        public static RoleInfo impostor = new RoleInfo("偽裝者", Palette.ImpostorRed, Helpers.cs(Palette.ImpostorRed, "搞破壞並殺死所有人"), "搞破壞並殺死所有人", RoleId.Impostor);
        public static RoleInfo crewmate = new RoleInfo("船員", Color.white, "找出偽裝者", "找出偽裝者", RoleId.Crewmate);
        public static RoleInfo witch = new RoleInfo("巫師", Witch.color, "對你的敵人施法", "對你的敵人施法", RoleId.Witch);
        public static RoleInfo ninja = new RoleInfo("忍者", Ninja.color, "驚嚇並暗殺你的敵人", "驚嚇並暗殺你的敵人", RoleId.Ninja);
        public static RoleInfo thief = new RoleInfo("小偷", Thief.color, "殺了殺手來竊取他們的職業", "竊取殺手的職業", RoleId.Thief, true);
        public static RoleInfo bomber = new RoleInfo("炸彈客", Bomber.color, "炸了所有船員", "炸了所有船員", RoleId.Bomber);

        public static RoleInfo hunter = new RoleInfo("獵人", Palette.ImpostorRed, Helpers.cs(Palette.ImpostorRed, "尋找並殺死所有船員"), "尋找並殺死所有船員", RoleId.Impostor);
        public static RoleInfo hunted = new RoleInfo("獵物", Color.white, "躲藏", "躲藏", RoleId.Crewmate);



        // Modifier
        public static RoleInfo bloody = new RoleInfo("血族", Color.yellow, "殺你的殺手將留下血跡", "殺你的殺手將留下血跡", RoleId.Bloody, false, true);
        public static RoleInfo antiTeleport = new RoleInfo("反傳送", Color.yellow, "你不會被傳送", "你不會被傳送", RoleId.AntiTeleport, false, true);
        public static RoleInfo tiebreaker = new RoleInfo("決勝者", Color.yellow, "你的票將打破平票", "打破平票", RoleId.Tiebreaker, false, true);
        public static RoleInfo bait = new RoleInfo("誘餌", Color.yellow, "引誘你的敵人", "引誘你的敵人", RoleId.Bait, false, true);
        public static RoleInfo sunglasses = new RoleInfo("墨鏡", Color.yellow, "你有墨鏡", "你的視野將下降", RoleId.Sunglasses, false, true);
        public static RoleInfo lover = new RoleInfo("戀人", Lovers.color, $"你正在戀愛中", $"你正在戀愛中", RoleId.Lover, false, true);
        public static RoleInfo mini = new RoleInfo("迷你", Color.yellow, "在你長大之前沒有人可以傷害你", "沒有人可以傷害你", RoleId.Mini, false, true);
        public static RoleInfo vip = new RoleInfo("VIP", Color.yellow, "你是VIP", "每個人都會知道你死亡", RoleId.Vip, false, true);
        public static RoleInfo invert = new RoleInfo("反轉", Color.yellow, "你的移動是相反的", "你的移動是相反的", RoleId.Invert, false, true);
        public static RoleInfo chameleon = new RoleInfo("變色龍", Color.yellow, "你不動的時候很難被看見", "你不動的時候很難被看見", RoleId.Chameleon, false, true);
        public static RoleInfo shifter = new RoleInfo("轉職師", Color.yellow, "轉移你的職業", "轉移你的職業", RoleId.Shifter, false, true);
        

        public static List<RoleInfo> allRoleInfos = new List<RoleInfo>() {
            impostor,
            godfather,
            mafioso,
            janitor,
            morphling,
            camouflager,
            vampire,
            eraser,
            trickster,
            cleaner,
            warlock,
            bountyHunter,
            witch,
            ninja,
            bomber,
            goodGuesser,
            badGuesser,
            lover,
            jester,
            arsonist,
            jackal,
            sidekick,
            vulture,
            pursuer,
            lawyer,
            thief,
            prosecutor,
            crewmate,
            mayor,
            portalmaker,
            engineer,
            sheriff,
            deputy,
            lighter,
            detective,
            timeMaster,
            medic,
            swapper,
            seer,
            hacker,
            tracker,
            snitch,
            spy,
            securityGuard,
            bait,
            medium,
            trapper,
            bloody,
            antiTeleport,
            tiebreaker,
            sunglasses,
            mini,
            vip,
            invert,
            chameleon,
            shifter
        };

        public static List<RoleInfo> getRoleInfoForPlayer(PlayerControl p, bool showModifier = true) {
            List<RoleInfo> infos = new List<RoleInfo>();
            if (p == null) return infos;

            // Modifier
            if (showModifier) {
                // after dead modifier
                if (!CustomOptionHolder.modifiersAreHidden.getBool() || PlayerControl.LocalPlayer.Data.IsDead || AmongUsClient.Instance.GameState == InnerNet.InnerNetClient.GameStates.Ended)
                {
                    if (Bait.bait.Any(x => x.PlayerId == p.PlayerId)) infos.Add(bait);
                    if (Bloody.bloody.Any(x => x.PlayerId == p.PlayerId)) infos.Add(bloody);
                    if (Vip.vip.Any(x => x.PlayerId == p.PlayerId)) infos.Add(vip);
                }
                if (p == Lovers.lover1 || p == Lovers.lover2) infos.Add(lover);
                if (p == Tiebreaker.tiebreaker) infos.Add(tiebreaker);
                if (AntiTeleport.antiTeleport.Any(x => x.PlayerId == p.PlayerId)) infos.Add(antiTeleport);
                if (Sunglasses.sunglasses.Any(x => x.PlayerId == p.PlayerId)) infos.Add(sunglasses);
                if (p == Mini.mini) infos.Add(mini);
                if (Invert.invert.Any(x => x.PlayerId == p.PlayerId)) infos.Add(invert);
                if (Chameleon.chameleon.Any(x => x.PlayerId == p.PlayerId)) infos.Add(chameleon);
                if (p == Shifter.shifter) infos.Add(shifter);
            }

            int count = infos.Count;  // Save count after modifiers are added so that the role count can be checked

            // Special roles
            if (p == Jester.jester) infos.Add(jester);
            if (p == Mayor.mayor) infos.Add(mayor);
            if (p == Portalmaker.portalmaker) infos.Add(portalmaker);
            if (p == Engineer.engineer) infos.Add(engineer);
            if (p == Sheriff.sheriff || p == Sheriff.formerSheriff) infos.Add(sheriff);
            if (p == Deputy.deputy) infos.Add(deputy);
            if (p == Lighter.lighter) infos.Add(lighter);
            if (p == Godfather.godfather) infos.Add(godfather);
            if (p == Mafioso.mafioso) infos.Add(mafioso);
            if (p == Janitor.janitor) infos.Add(janitor);
            if (p == Morphling.morphling) infos.Add(morphling);
            if (p == Camouflager.camouflager) infos.Add(camouflager);
            if (p == Vampire.vampire) infos.Add(vampire);
            if (p == Eraser.eraser) infos.Add(eraser);
            if (p == Trickster.trickster) infos.Add(trickster);
            if (p == Cleaner.cleaner) infos.Add(cleaner);
            if (p == Warlock.warlock) infos.Add(warlock);
            if (p == Witch.witch) infos.Add(witch);
            if (p == Ninja.ninja) infos.Add(ninja);
            if (p == Bomber.bomber) infos.Add(bomber);
            if (p == Detective.detective) infos.Add(detective);
            if (p == TimeMaster.timeMaster) infos.Add(timeMaster);
            if (p == Medic.medic) infos.Add(medic);
            if (p == Swapper.swapper) infos.Add(swapper);
            if (p == Seer.seer) infos.Add(seer);
            if (p == Hacker.hacker) infos.Add(hacker);
            if (p == Tracker.tracker) infos.Add(tracker);
            if (p == Snitch.snitch) infos.Add(snitch);
            if (p == Jackal.jackal || (Jackal.formerJackals != null && Jackal.formerJackals.Any(x => x.PlayerId == p.PlayerId))) infos.Add(jackal);
            if (p == Sidekick.sidekick) infos.Add(sidekick);
            if (p == Spy.spy) infos.Add(spy);
            if (p == SecurityGuard.securityGuard) infos.Add(securityGuard);
            if (p == Arsonist.arsonist) infos.Add(arsonist);
            if (p == Guesser.niceGuesser) infos.Add(goodGuesser);
            if (p == Guesser.evilGuesser) infos.Add(badGuesser);
            if (p == BountyHunter.bountyHunter) infos.Add(bountyHunter);
            if (p == Vulture.vulture) infos.Add(vulture);
            if (p == Medium.medium) infos.Add(medium);
            if (p == Lawyer.lawyer && !Lawyer.isProsecutor) infos.Add(lawyer);
            if (p == Lawyer.lawyer && Lawyer.isProsecutor) infos.Add(prosecutor);
            if (p == Trapper.trapper) infos.Add(trapper);
            if (p == Pursuer.pursuer) infos.Add(pursuer);
            if (p == Thief.thief) infos.Add(thief);

            // Default roles (just impostor, just crewmate, or hunter / hunted for hide n seek
            if (infos.Count == count) {
                if (p.Data.Role.IsImpostor)
                    infos.Add(TORMapOptions.gameMode == CustomGamemodes.HideNSeek ? RoleInfo.hunter : RoleInfo.impostor);
                else
                    infos.Add(TORMapOptions.gameMode == CustomGamemodes.HideNSeek ? RoleInfo.hunted : RoleInfo.crewmate);
            }

            return infos;
        }

        public static String GetRolesString(PlayerControl p, bool useColors, bool showModifier = true, bool suppressGhostInfo = false) {
            string roleName;
            roleName = String.Join(" ", getRoleInfoForPlayer(p, showModifier).Select(x => useColors ? Helpers.cs(x.color, x.name) : x.name).ToArray());
            if (Lawyer.target != null && p.PlayerId == Lawyer.target.PlayerId && CachedPlayer.LocalPlayer.PlayerControl != Lawyer.target) 
                roleName += (useColors ? Helpers.cs(Pursuer.color, " §") : " §");
            if (HandleGuesser.isGuesserGm && HandleGuesser.isGuesser(p.PlayerId)) roleName += " (賭徒)";

            if (!suppressGhostInfo && p != null) {
                if (p == Shifter.shifter && (CachedPlayer.LocalPlayer.PlayerControl == Shifter.shifter || Helpers.shouldShowGhostInfo()) && Shifter.futureShift != null)
                    roleName += Helpers.cs(Color.yellow, " ← " + Shifter.futureShift.Data.PlayerName);
                if (p == Vulture.vulture && (CachedPlayer.LocalPlayer.PlayerControl == Vulture.vulture || Helpers.shouldShowGhostInfo()))
                    roleName = roleName + Helpers.cs(Vulture.color, $" ({Vulture.vultureNumberToWin - Vulture.eatenBodies} 剩餘)");
                if (Helpers.shouldShowGhostInfo()) {
                    if (Eraser.futureErased.Contains(p))
                        roleName = Helpers.cs(Color.gray, "(被抹除) ") + roleName;
                    if (Vampire.vampire != null && !Vampire.vampire.Data.IsDead && Vampire.bitten == p && !p.Data.IsDead)
                        roleName = Helpers.cs(Vampire.color, $"(被咬 {(int)HudManagerStartPatch.vampireKillButton.Timer + 1}) ") + roleName;
                    if (Deputy.handcuffedPlayers.Contains(p.PlayerId))
                        roleName = Helpers.cs(Color.gray, "(被銬) ") + roleName;
                    if (Deputy.handcuffedKnows.ContainsKey(p.PlayerId))  // Active cuff
                        roleName = Helpers.cs(Deputy.color, "(被銬) ") + roleName;
                    if (p == Warlock.curseVictim)
                        roleName = Helpers.cs(Warlock.color, "(被詛咒) ") + roleName;
                    if (p == Ninja.ninjaMarked)
                        roleName = Helpers.cs(Ninja.color, "(被標記) ") + roleName;
                    if (Pursuer.blankedList.Contains(p) && !p.Data.IsDead)
                        roleName = Helpers.cs(Pursuer.color, "(被填空) ") + roleName;
                    if (Witch.futureSpelled.Contains(p) && !MeetingHud.Instance) // This is already displayed in meetings!
                        roleName = Helpers.cs(Witch.color, "☆ ") + roleName;
                    if (BountyHunter.bounty == p)
                        roleName = Helpers.cs(BountyHunter.color, "(被懸賞) ") + roleName;
                    if (Arsonist.dousedPlayers.Contains(p))
                        roleName = Helpers.cs(Arsonist.color, "♨ ") + roleName;
                    if (p == Arsonist.arsonist)
                        roleName = roleName + Helpers.cs(Arsonist.color, $" ({CachedPlayer.AllPlayers.Count(x => { return x.PlayerControl != Arsonist.arsonist && !x.Data.IsDead && !x.Data.Disconnected && !Arsonist.dousedPlayers.Any(y => y.PlayerId == x.PlayerId); })} 剩餘)");
                    if (p == Jackal.fakeSidekick)
                        roleName = Helpers.cs(Sidekick.color, $" (假跟班)") + roleName;
                    // Death Reason on Ghosts
                    if (p.Data.IsDead) {
                        string deathReasonString = "";
                        var deadPlayer = GameHistory.deadPlayers.FirstOrDefault(x => x.player.PlayerId == p.PlayerId);

                        Color killerColor = new();
                        if (deadPlayer != null && deadPlayer.killerIfExisting != null) {
                            killerColor = RoleInfo.getRoleInfoForPlayer(deadPlayer.killerIfExisting, false).FirstOrDefault().color;
                        }

                        if (deadPlayer != null) {
                            switch (deadPlayer.deathReason) {
                                case DeadPlayer.CustomDeathReason.Disconnect:
                                    deathReasonString = " - 斷開連線";
                                    break;
                                case DeadPlayer.CustomDeathReason.Exile:
                                    deathReasonString = " - 票出";
                                    break;
                                case DeadPlayer.CustomDeathReason.Kill:
                                    deathReasonString = $" - 被擊殺 由 {Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName)} ";
                                    break;
                                case DeadPlayer.CustomDeathReason.Guess:
                                    if (deadPlayer.killerIfExisting.Data.PlayerName == p.Data.PlayerName)
                                        deathReasonString = $" - 猜測失敗";
                                    else
                                        deathReasonString = $" - 被猜出 由 {Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName)}";
                                    break;
                                case DeadPlayer.CustomDeathReason.Shift:
                                    deathReasonString = $" - {Helpers.cs(Color.yellow, "轉移")} {Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName)}";
                                    break;
                                case DeadPlayer.CustomDeathReason.WitchExile:
                                    deathReasonString = $" - {Helpers.cs(Witch.color, "被下蠱")} 由 {Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName)}";
                                    break;
                                case DeadPlayer.CustomDeathReason.LoverSuicide:
                                    deathReasonString = $" - {Helpers.cs(Lovers.color, "戀人死亡")}";
                                    break;
                                case DeadPlayer.CustomDeathReason.LawyerSuicide:
                                    deathReasonString = $" - {Helpers.cs(Lawyer.color, "不成功的律師")}";
                                    break;
                                case DeadPlayer.CustomDeathReason.Bomb:
                                    deathReasonString = $" - 被炸死 由 {Helpers.cs(killerColor, deadPlayer.killerIfExisting.Data.PlayerName)}";
                                    break;
                            }
                            roleName = roleName + deathReasonString;
                        }
                    }
                }
            }
            return roleName;
        }
    }
}
