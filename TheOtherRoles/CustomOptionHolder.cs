using System.Collections.Generic;
using UnityEngine;
using BepInEx.Configuration;
using System;
using System.Linq;
using HarmonyLib;
using Hazel;
using System.Reflection;
using System.Text;
using static TheOtherRoles.TheOtherRoles;

namespace TheOtherRoles {
    public class CustomOptionHolder {
        public static string[] rates = new string[]{"0%", "10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "100%"};
        public static string[] presets = new string[]{"設定 1", "設定 2", "設定 3", "設定 4", "設定 5"};

        public static CustomOption presetSelection;
        public static CustomOption activateRoles;
        public static CustomOption crewmateRolesCountMin;
        public static CustomOption crewmateRolesCountMax;
        public static CustomOption neutralRolesCountMin;
        public static CustomOption neutralRolesCountMax;
        public static CustomOption impostorRolesCountMin;
        public static CustomOption impostorRolesCountMax;

        public static CustomOption mafiaSpawnRate;
        public static CustomOption janitorCooldown;

        public static CustomOption morphlingSpawnRate;
        public static CustomOption morphlingCooldown;
        public static CustomOption morphlingDuration;

        public static CustomOption camouflagerSpawnRate;
        public static CustomOption camouflagerCooldown;
        public static CustomOption camouflagerDuration;

        public static CustomOption vampireSpawnRate;
        public static CustomOption vampireKillDelay;
        public static CustomOption vampireCooldown;
        public static CustomOption vampireCanKillNearGarlics;

        public static CustomOption eraserSpawnRate;
        public static CustomOption eraserCooldown;
        public static CustomOption eraserCanEraseAnyone;

        public static CustomOption miniSpawnRate;
        public static CustomOption miniGrowingUpDuration;

        public static CustomOption loversSpawnRate;
        public static CustomOption loversImpLoverRate;
        public static CustomOption loversBothDie;
        public static CustomOption loversCanHaveAnotherRole;

        public static CustomOption guesserSpawnRate;
        public static CustomOption guesserIsImpGuesserRate;
        public static CustomOption guesserNumberOfShots;
        public static CustomOption guesserHasMultipleShotsPerMeeting;
        public static CustomOption guesserShowInfoInGhostChat;
        public static CustomOption guesserKillsThroughShield;

        public static CustomOption jesterSpawnRate;
        public static CustomOption jesterCanCallEmergency;

        public static CustomOption arsonistSpawnRate;
        public static CustomOption arsonistCooldown;
        public static CustomOption arsonistDuration;

        public static CustomOption jackalSpawnRate;
        public static CustomOption jackalKillCooldown;
        public static CustomOption jackalCreateSidekickCooldown;
        public static CustomOption jackalCanUseVents;
        public static CustomOption jackalCanCreateSidekick;
        public static CustomOption sidekickPromotesToJackal;
        public static CustomOption sidekickCanKill;
        public static CustomOption sidekickCanUseVents;
        public static CustomOption jackalPromotedFromSidekickCanCreateSidekick;
        public static CustomOption jackalCanCreateSidekickFromImpostor;
        public static CustomOption jackalAndSidekickHaveImpostorVision;

        public static CustomOption bountyHunterSpawnRate;
        public static CustomOption bountyHunterBountyDuration;
        public static CustomOption bountyHunterReducedCooldown;
        public static CustomOption bountyHunterPunishmentTime;
        public static CustomOption bountyHunterShowArrow;
        public static CustomOption bountyHunterArrowUpdateIntervall;

        public static CustomOption witchSpawnRate;
        public static CustomOption witchCooldown;
        public static CustomOption witchAdditionalCooldown;
        public static CustomOption witchCanSpellAnyone;
        public static CustomOption witchSpellCastingDuration;
        public static CustomOption witchTriggerBothCooldowns;
        public static CustomOption witchVoteSavesTargets;

        public static CustomOption shifterSpawnRate;
        public static CustomOption shifterShiftsModifiers;

        public static CustomOption mayorSpawnRate;

        public static CustomOption engineerSpawnRate;
        public static CustomOption engineerNumberOfFixes;
        public static CustomOption engineerHighlightForImpostors;
        public static CustomOption engineerHighlightForTeamJackal;

        public static CustomOption sheriffSpawnRate;
        public static CustomOption sheriffCooldown;
        public static CustomOption sheriffCanKillNeutrals;

        public static CustomOption lighterSpawnRate;
        public static CustomOption lighterModeLightsOnVision;
        public static CustomOption lighterModeLightsOffVision;
        public static CustomOption lighterCooldown;
        public static CustomOption lighterDuration;

        public static CustomOption detectiveSpawnRate;
        public static CustomOption detectiveAnonymousFootprints;
        public static CustomOption detectiveFootprintIntervall;
        public static CustomOption detectiveFootprintDuration;
        public static CustomOption detectiveReportNameDuration;
        public static CustomOption detectiveReportColorDuration;

        public static CustomOption timeMasterSpawnRate;
        public static CustomOption timeMasterCooldown;
        public static CustomOption timeMasterRewindTime;
        public static CustomOption timeMasterShieldDuration;

        public static CustomOption medicSpawnRate;
        public static CustomOption medicShowShielded;
        public static CustomOption medicShowAttemptToShielded;
        public static CustomOption medicSetShieldAfterMeeting;
        public static CustomOption medicShowAttemptToMedic;

        public static CustomOption swapperSpawnRate;
        public static CustomOption swapperCanCallEmergency;
        public static CustomOption swapperCanOnlySwapOthers;

        public static CustomOption seerSpawnRate;
        public static CustomOption seerMode;
        public static CustomOption seerSoulDuration;
        public static CustomOption seerLimitSoulDuration;

        public static CustomOption hackerSpawnRate;
        public static CustomOption hackerCooldown;
        public static CustomOption hackerHackeringDuration;
        public static CustomOption hackerOnlyColorType;

        public static CustomOption trackerSpawnRate;
        public static CustomOption trackerUpdateIntervall;
        public static CustomOption trackerResetTargetAfterMeeting;
        public static CustomOption trackerCanTrackCorpses;
        public static CustomOption trackerCorpsesTrackingCooldown;
        public static CustomOption trackerCorpsesTrackingDuration;

        public static CustomOption snitchSpawnRate;
        public static CustomOption snitchLeftTasksForReveal;
        public static CustomOption snitchIncludeTeamJackal;
        public static CustomOption snitchTeamJackalUseDifferentArrowColor;

        public static CustomOption spySpawnRate;
        public static CustomOption spyCanDieToSheriff;
        public static CustomOption spyImpostorsCanKillAnyone;
        public static CustomOption spyCanEnterVents;
        public static CustomOption spyHasImpostorVision;

        public static CustomOption tricksterSpawnRate;
        public static CustomOption tricksterPlaceBoxCooldown;
        public static CustomOption tricksterLightsOutCooldown;
        public static CustomOption tricksterLightsOutDuration;

        public static CustomOption cleanerSpawnRate;
        public static CustomOption cleanerCooldown;
        
        public static CustomOption warlockSpawnRate;
        public static CustomOption warlockCooldown;
        public static CustomOption warlockRootTime;

        public static CustomOption securityGuardSpawnRate;
        public static CustomOption securityGuardCooldown;
        public static CustomOption securityGuardTotalScrews;
        public static CustomOption securityGuardCamPrice;
        public static CustomOption securityGuardVentPrice;

        public static CustomOption baitSpawnRate;
        public static CustomOption baitHighlightAllVents;
        public static CustomOption baitReportDelay;

        public static CustomOption vultureSpawnRate;
        public static CustomOption vultureCooldown;
        public static CustomOption vultureNumberToWin;
        public static CustomOption vultureCanUseVents;
        public static CustomOption vultureShowArrows;

        public static CustomOption mediumSpawnRate;
        public static CustomOption mediumCooldown;
        public static CustomOption mediumDuration;
        public static CustomOption mediumOneTimeUse;

        public static CustomOption lawyerSpawnRate;
        public static CustomOption lawyerTargetKnows;
        public static CustomOption lawyerWinsAfterMeetings;
        public static CustomOption lawyerNeededMeetings;
        public static CustomOption lawyerVision;
        public static CustomOption lawyerKnowsRole;
        public static CustomOption pursuerCooldown;
        public static CustomOption pursuerBlanksNumber;

        public static CustomOption maxNumberOfMeetings;
        public static CustomOption blockSkippingInEmergencyMeetings;
        public static CustomOption noVoteIsSelfVote;
        public static CustomOption hidePlayerNames;
        public static CustomOption allowParallelMedBayScans;
        public static CustomOption dynamicMap;


        internal static Dictionary<byte, byte[]> blockedRolePairings = new Dictionary<byte, byte[]>();

        public static string cs(Color c, string s) {
            return string.Format("<color=#{0:X2}{1:X2}{2:X2}{3:X2}>{4}</color>", ToByte(c.r), ToByte(c.g), ToByte(c.b), ToByte(c.a), s);
        }
 
        private static byte ToByte(float f) {
            f = Mathf.Clamp01(f);
            return (byte)(f * 255);
        }

        public static void Load() {
            
            // Role Options
            presetSelection = CustomOption.Create(0, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "設定"), presets, null, true);
            activateRoles = CustomOption.Create(7, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "啟用模組職業並禁用原版職業"), true, null, true);

            // Using new id's for the options to not break compatibilty with older versions
            crewmateRolesCountMin = CustomOption.Create(300, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最小船員職業數"), 0f, 0f, 15f, 1f, null, true);
            crewmateRolesCountMax = CustomOption.Create(301, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最大船員職業數"), 0f, 0f, 15f, 1f);
            neutralRolesCountMin = CustomOption.Create(302, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最小獨立職業數"), 0f, 0f, 15f, 1f);
            neutralRolesCountMax = CustomOption.Create(303, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最大獨立職業數"), 0f, 0f, 15f, 1f);
            impostorRolesCountMin = CustomOption.Create(304, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最小偽裝者職業數"), 0f, 0f, 3f, 1f);
            impostorRolesCountMax = CustomOption.Create(305, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "最大偽裝者職業數"), 0f, 0f, 3f, 1f);

            mafiaSpawnRate = CustomOption.Create(10, cs(Janitor.color, "黑手黨"), rates, null, true);
            janitorCooldown = CustomOption.Create(11, "守墓人冷卻", 30f, 10f, 60f, 2.5f, mafiaSpawnRate);

            morphlingSpawnRate = CustomOption.Create(20, cs(Morphling.color, "百變怪"), rates, null, true);
            morphlingCooldown = CustomOption.Create(21, "百變怪冷卻", 30f, 10f, 60f, 2.5f, morphlingSpawnRate);
            morphlingDuration = CustomOption.Create(22, "變身持續時間", 10f, 1f, 20f, 0.5f, morphlingSpawnRate);

            camouflagerSpawnRate = CustomOption.Create(30, cs(Camouflager.color, "魔術師"), rates, null, true);
            camouflagerCooldown = CustomOption.Create(31, "魔術師冷卻", 30f, 10f, 60f, 2.5f, camouflagerSpawnRate);
            camouflagerDuration = CustomOption.Create(32, "迷彩持續時間", 10f, 1f, 20f, 0.5f, camouflagerSpawnRate);

            vampireSpawnRate = CustomOption.Create(40, cs(Vampire.color, "吸血鬼"), rates, null, true);
            vampireKillDelay = CustomOption.Create(41, "吸血鬼死亡延遲", 10f, 1f, 20f, 1f, vampireSpawnRate);
            vampireCooldown = CustomOption.Create(42, "吸血鬼冷卻", 30f, 10f, 60f, 2.5f, vampireSpawnRate);
            vampireCanKillNearGarlics = CustomOption.Create(43, "吸血鬼可在大蒜附近殺人", true, vampireSpawnRate);

            eraserSpawnRate = CustomOption.Create(230, cs(Eraser.color, "抹除者"), rates, null, true);
            eraserCooldown = CustomOption.Create(231, "抹除者冷卻", 30f, 10f, 120f, 5f, eraserSpawnRate);
            eraserCanEraseAnyone = CustomOption.Create(232, "抹除者可抹除任何人", false, eraserSpawnRate);

            tricksterSpawnRate = CustomOption.Create(250, cs(Trickster.color, "詭騙師"), rates, null, true);
            tricksterPlaceBoxCooldown = CustomOption.Create(251, "詭騙箱冷卻", 10f, 0f, 30f, 2.5f, tricksterSpawnRate);
            tricksterLightsOutCooldown = CustomOption.Create(252, "詭騙師關燈冷卻", 30f, 10f, 60f, 5f, tricksterSpawnRate);
            tricksterLightsOutDuration = CustomOption.Create(253, "詭騙師關燈持續時間", 15f, 5f, 60f, 2.5f, tricksterSpawnRate);

            cleanerSpawnRate = CustomOption.Create(260, cs(Cleaner.color, "清除者"), rates, null, true);
            cleanerCooldown = CustomOption.Create(261, "清除者冷卻", 30f, 10f, 60f, 2.5f, cleanerSpawnRate);

            warlockSpawnRate = CustomOption.Create(270, cs(Cleaner.color, "咒詛師"), rates, null, true);
            warlockCooldown = CustomOption.Create(271, "咒詛師冷卻", 30f, 10f, 60f, 2.5f, warlockSpawnRate);
            warlockRootTime = CustomOption.Create(272, "咒詛師定身持續時間", 5f, 0f, 15f, 1f, warlockSpawnRate);

            bountyHunterSpawnRate = CustomOption.Create(320, cs(BountyHunter.color, "賞金獵人"), rates, null, true);
            bountyHunterBountyDuration = CustomOption.Create(321, "懸賞改變後的持續時間",  60f, 10f, 180f, 10f, bountyHunterSpawnRate);
            bountyHunterReducedCooldown = CustomOption.Create(322, "擊殺懸賞後的冷卻", 2.5f, 0f, 30f, 2.5f, bountyHunterSpawnRate);
            bountyHunterPunishmentTime = CustomOption.Create(323, "殺死其他人後的額外冷卻", 20f, 0f, 60f, 2.5f, bountyHunterSpawnRate);
            bountyHunterShowArrow = CustomOption.Create(324, "顯示指向懸賞的指示箭頭", true, bountyHunterSpawnRate);
            bountyHunterArrowUpdateIntervall = CustomOption.Create(325, "指示箭頭更新間隔", 15f, 2.5f, 60f, 2.5f, bountyHunterShowArrow);

            witchSpawnRate = CustomOption.Create(370, cs(Witch.color, "巫師"), rates, null, true);
            witchCooldown = CustomOption.Create(371, "Witch Spell Casting Cooldown", 30f, 10f, 120f, 5f, witchSpawnRate);
            witchAdditionalCooldown = CustomOption.Create(372, "Witch Additional Cooldown", 10f, 0f, 60f, 5f, witchSpawnRate);
            witchCanSpellAnyone = CustomOption.Create(373, "Witch Can Spell Anyone", false, witchSpawnRate);
            witchSpellCastingDuration = CustomOption.Create(374, "Spell Casting Duration", 1f, 0f, 10f, 1f, witchSpawnRate);
            witchTriggerBothCooldowns = CustomOption.Create(375, "Trigger Both Cooldowns", true, witchSpawnRate);
            witchVoteSavesTargets = CustomOption.Create(376, "Voting The Witch Saves All The Targets", true, witchSpawnRate);

            miniSpawnRate = CustomOption.Create(180, cs(Mini.color, "迷你"), rates, null, true);
            miniGrowingUpDuration = CustomOption.Create(181, "迷你成長時間", 400f, 100f, 1500f, 100f, miniSpawnRate);

            loversSpawnRate = CustomOption.Create(50, cs(Lovers.color, "戀人"), rates, null, true);
            loversImpLoverRate = CustomOption.Create(51, "一個戀人是偽裝者的機率", rates, loversSpawnRate);
            loversBothDie = CustomOption.Create(52, "戀人雙死", true, loversSpawnRate);
            loversCanHaveAnotherRole = CustomOption.Create(53, "戀人可有其他職業", true, loversSpawnRate);

            guesserSpawnRate = CustomOption.Create(310, cs(Guesser.color, "賭徒"), rates, null, true);
            guesserIsImpGuesserRate = CustomOption.Create(311, "賭徒是個偽裝者的機率", rates, guesserSpawnRate);
            guesserNumberOfShots = CustomOption.Create(312, "賭徒的猜測次數", 2f, 1f, 15f, 1f, guesserSpawnRate);
            guesserHasMultipleShotsPerMeeting = CustomOption.Create(313, "賭徒每個會議可以猜測多次", false, guesserSpawnRate);
            guesserShowInfoInGhostChat = CustomOption.Create(314, "賭徒在死者聊天中可見 ", true, guesserSpawnRate);
            guesserKillsThroughShield  = CustomOption.Create(315, "賭徒忽略醫生盾", true, guesserSpawnRate);

            jesterSpawnRate = CustomOption.Create(60, cs(Jester.color, "小丑"), rates, null, true);
            jesterCanCallEmergency = CustomOption.Create(61, "小丑可召開緊急會議", true, jesterSpawnRate);

            arsonistSpawnRate = CustomOption.Create(290, cs(Arsonist.color, "縱火狂"), rates, null, true);
            arsonistCooldown = CustomOption.Create(291, "縱火狂冷卻", 12.5f, 2.5f, 60f, 2.5f, arsonistSpawnRate);
            arsonistDuration = CustomOption.Create(292, "縱火狂澆油持續時間", 3f, 1f, 10f, 1f, arsonistSpawnRate);

            jackalSpawnRate = CustomOption.Create(220, cs(Jackal.color, "豺狼"), rates, null, true);
            jackalKillCooldown = CustomOption.Create(221, "豺狼/跟班殺人冷卻", 30f, 10f, 60f, 2.5f, jackalSpawnRate);
            jackalCreateSidekickCooldown = CustomOption.Create(222, "豺狼製造跟班冷卻", 30f, 10f, 60f, 2.5f, jackalSpawnRate);
            jackalCanUseVents = CustomOption.Create(223, "豺狼可使用通風口", true, jackalSpawnRate);
            jackalCanCreateSidekick = CustomOption.Create(224, "豺狼可製造跟班跟班", false, jackalSpawnRate);
            sidekickPromotesToJackal = CustomOption.Create(225, "在豺狼死亡後跟班可升職成豺狼", false, jackalSpawnRate);
            sidekickCanKill = CustomOption.Create(226, "跟班可以殺人", false, jackalSpawnRate);
            sidekickCanUseVents = CustomOption.Create(227, "跟班可使用通風口", true, jackalSpawnRate);
            jackalPromotedFromSidekickCanCreateSidekick = CustomOption.Create(228, "從跟班升職的豺狼可製造跟班", true, jackalSpawnRate);
            jackalCanCreateSidekickFromImpostor = CustomOption.Create(229, "豺狼可讓偽裝者轉成跟班", true, jackalSpawnRate);
            jackalAndSidekickHaveImpostorVision = CustomOption.Create(430, "豺狼與跟班有偽裝者視野", false, jackalSpawnRate);

            vultureSpawnRate = CustomOption.Create(340, cs(Vulture.color, "禿鷲"), rates, null, true);
            vultureCooldown = CustomOption.Create(341, "禿鷲冷卻", 15f, 10f, 60f, 2.5f, vultureSpawnRate);
            vultureNumberToWin = CustomOption.Create(342, "需要吃的屍體數量", 4f, 0f, 10f, 1f, vultureSpawnRate);
            vultureCanUseVents = CustomOption.Create(343, "禿鷲可以使用通風口", true, vultureSpawnRate);
            vultureShowArrows = CustomOption.Create(344, "顯示指向屍體的箭頭", true, vultureSpawnRate);

            lawyerSpawnRate = CustomOption.Create(350, cs(Lawyer.color, "律師"), rates, null, true);
            lawyerTargetKnows = CustomOption.Create(351, "Lawyer Target Knows", true, lawyerSpawnRate);
            lawyerWinsAfterMeetings = CustomOption.Create(352, "Lawyer Wins After Meetings", false, lawyerSpawnRate);
            lawyerNeededMeetings = CustomOption.Create(353, "Lawyer Needed Meetings To Win", 5f, 1f, 15f, 1f, lawyerWinsAfterMeetings);
            lawyerVision = CustomOption.Create(354, "Lawyer Vision", 1f, 0.25f, 3f, 0.25f, lawyerSpawnRate);
            lawyerKnowsRole = CustomOption.Create(355, "Lawyer Knows Target Role", false, lawyerSpawnRate);
            pursuerCooldown = CustomOption.Create(356, "Pursuer Blank Cooldown", 30f, 5f, 60f, 2.5f, lawyerSpawnRate);
            pursuerBlanksNumber = CustomOption.Create(357, "Pursuer Number Of Blanks", 5f, 0f, 20f, 1f, lawyerSpawnRate);

            shifterSpawnRate = CustomOption.Create(70, cs(Shifter.color, "轉職者"), rates, null, true);
            shifterShiftsModifiers = CustomOption.Create(71, "轉職者轉移調整", false, shifterSpawnRate);

            mayorSpawnRate = CustomOption.Create(80, cs(Mayor.color, "市長"), rates, null, true);

            engineerSpawnRate = CustomOption.Create(90, cs(Engineer.color, "工程師"), rates, null, true);
            engineerNumberOfFixes = CustomOption.Create(91, "破壞修復數量", 1f, 0f, 3f, 1f, engineerSpawnRate);
            engineerHighlightForImpostors = CustomOption.Create(92, "偽裝者可看到通風口發光", true, engineerSpawnRate);
            engineerHighlightForTeamJackal = CustomOption.Create(93, "豺狼與跟班可看到通風口發光", true, engineerSpawnRate);

            sheriffSpawnRate = CustomOption.Create(100, cs(Sheriff.color, "警長"), rates, null, true);
            sheriffCooldown = CustomOption.Create(101, "警長冷卻", 30f, 10f, 60f, 2.5f, sheriffSpawnRate);
            sheriffCanKillNeutrals = CustomOption.Create(102, "警長可擊殺獨立職業", false, sheriffSpawnRate);

            lighterSpawnRate = CustomOption.Create(110, cs(Lighter.color, "點燈人"), rates, null, true);
            lighterModeLightsOnVision = CustomOption.Create(111, "開燈時點燈視野", 2f, 0.25f, 5f, 0.25f, lighterSpawnRate);
            lighterModeLightsOffVision = CustomOption.Create(112, "關燈時點燈視野", 0.75f, 0.25f, 5f, 0.25f, lighterSpawnRate);
            lighterCooldown = CustomOption.Create(113, "點燈人冷卻", 30f, 5f, 120f, 5f, lighterSpawnRate);
            lighterDuration = CustomOption.Create(114, "點燈持續時間", 5f, 2.5f, 60f, 2.5f, lighterSpawnRate);

            detectiveSpawnRate = CustomOption.Create(120, cs(Detective.color, "偵探"), rates, null, true);
            detectiveAnonymousFootprints = CustomOption.Create(121, "匿名足跡", false, detectiveSpawnRate); 
            detectiveFootprintIntervall = CustomOption.Create(122, "足跡間隔", 0.5f, 0.25f, 10f, 0.25f, detectiveSpawnRate);
            detectiveFootprintDuration = CustomOption.Create(123, "足跡持續時間", 5f, 0.25f, 10f, 0.25f, detectiveSpawnRate);
            detectiveReportNameDuration = CustomOption.Create(124, "偵探舉報將有名字的時間", 0, 0, 60, 2.5f, detectiveSpawnRate);
            detectiveReportColorDuration = CustomOption.Create(125, "偵探舉報將有顏色類型的時間", 20, 0, 120, 2.5f, detectiveSpawnRate);

            timeMasterSpawnRate = CustomOption.Create(130, cs(TimeMaster.color, "時間管理大師"), rates, null, true);
            timeMasterCooldown = CustomOption.Create(131, "時間管理大師冷卻", 30f, 10f, 120f, 2.5f, timeMasterSpawnRate);
            timeMasterRewindTime = CustomOption.Create(132, "回溯時間", 3f, 1f, 10f, 1f, timeMasterSpawnRate);
            timeMasterShieldDuration = CustomOption.Create(133, "回溯時間護盾持續時間", 3f, 1f, 20f, 1f, timeMasterSpawnRate);

            medicSpawnRate = CustomOption.Create(140, cs(Medic.color, "醫生"), rates, null, true);
            medicShowShielded = CustomOption.Create(143, "顯示被上盾者", new string[] {"所有人", "被上盾者 + 醫生", "醫生"}, medicSpawnRate);
            medicShowAttemptToShielded = CustomOption.Create(144, "被上盾者可看到謀殺未遂", false, medicSpawnRate);
            medicSetShieldAfterMeeting = CustomOption.Create(145, "盾在會議後生效", false, medicSpawnRate);
            medicShowAttemptToMedic = CustomOption.Create(146, "醫生可看到對被上盾者的謀殺未遂", false, medicSpawnRate);

            swapperSpawnRate = CustomOption.Create(150, cs(Swapper.color, "換票師"), rates, null, true);
            swapperCanCallEmergency = CustomOption.Create(151, "換票師可召開緊急會議", false, swapperSpawnRate);
            swapperCanOnlySwapOthers = CustomOption.Create(152, "換票師只可掉包其他人的得票", false, swapperSpawnRate);

            seerSpawnRate = CustomOption.Create(160, cs(Seer.color, "靈媒"), rates, null, true);
            seerMode = CustomOption.Create(161, "靈媒能力模式", new string[]{ "顯示死亡閃爍 + 靈魂", "顯示死亡閃爍", "顯示靈魂"}, seerSpawnRate);
            seerLimitSoulDuration = CustomOption.Create(163, "靈魂有持續時間限制", false, seerSpawnRate);
            seerSoulDuration = CustomOption.Create(162, "靈魂持續時間", 15f, 0f, 60f, 5f, seerLimitSoulDuration);
        
            hackerSpawnRate = CustomOption.Create(170, cs(Hacker.color, "駭客"), rates, null, true);
            hackerCooldown = CustomOption.Create(171, "駭客冷卻", 30f, 0f, 60f, 5f, hackerSpawnRate);
            hackerHackeringDuration = CustomOption.Create(172, "駭客持續時間", 10f, 2.5f, 60f, 2.5f, hackerSpawnRate);
            hackerOnlyColorType = CustomOption.Create(173, "駭客只可看到有顏色類型", false, hackerSpawnRate);

            trackerSpawnRate = CustomOption.Create(200, cs(Tracker.color, "追踪者"), rates, null, true);
            trackerUpdateIntervall = CustomOption.Create(201, "追踪更新間隔", 5f, 2.5f, 30f, 2.5f, trackerSpawnRate);
            trackerResetTargetAfterMeeting = CustomOption.Create(202, "會議後重置追踪", false, trackerSpawnRate);
            trackerCanTrackCorpses = CustomOption.Create(203, "追踪者可以追踪屍體", true, trackerSpawnRate);
            trackerCorpsesTrackingCooldown = CustomOption.Create(204, "屍體追踪冷卻", 30f, 0f, 120f, 5f, trackerCanTrackCorpses);
            trackerCorpsesTrackingDuration = CustomOption.Create(205, "屍體追踪持續時間", 5f, 2.5f, 30f, 2.5f, trackerCanTrackCorpses);
                           
            snitchSpawnRate = CustomOption.Create(210, cs(Snitch.color, "密探"), rates, null, true);
            snitchLeftTasksForReveal = CustomOption.Create(211, "告密者可看到偽裝者在哪的任務數", 1f, 0f, 5f, 1f, snitchSpawnRate);
            snitchIncludeTeamJackal = CustomOption.Create(212, "包含豺狼團隊", false, snitchSpawnRate);
            snitchTeamJackalUseDifferentArrowColor = CustomOption.Create(213, "對豺狼團隊使用不同顏色的箭頭", true, snitchIncludeTeamJackal);

            spySpawnRate = CustomOption.Create(240, cs(Spy.color, "間諜"), rates, null, true);
            spyCanDieToSheriff = CustomOption.Create(241, "間諜可被警長殺死", false, spySpawnRate);
            spyImpostorsCanKillAnyone = CustomOption.Create(242, "如果偽裝者中有間諜可以殺死任何人", true, spySpawnRate);
            spyCanEnterVents = CustomOption.Create(243, "間諜可進入通風口", false, spySpawnRate);
            spyHasImpostorVision = CustomOption.Create(244, "間諜有偽裝者視野", false, spySpawnRate);

            securityGuardSpawnRate = CustomOption.Create(280, cs(SecurityGuard.color, "守衛"), rates, null, true);
            securityGuardCooldown = CustomOption.Create(281, "守衛冷卻", 30f, 10f, 60f, 2.5f, securityGuardSpawnRate);
            securityGuardTotalScrews = CustomOption.Create(282, "初始守衛螺絲數量", 7f, 1f, 15f, 1f, securityGuardSpawnRate);
            securityGuardCamPrice = CustomOption.Create(283, "設置攝影機消耗螺絲數量", 2f, 1f, 15f, 1f, securityGuardSpawnRate);
            securityGuardVentPrice = CustomOption.Create(284, "封鎖通風口消耗螺絲數量", 1f, 1f, 15f, 1f, securityGuardSpawnRate);

            baitSpawnRate = CustomOption.Create(330, cs(Bait.color, "誘餌"), rates, null, true);
            baitHighlightAllVents = CustomOption.Create(331, "如果通風口被佔用所有通風口發光", false, baitSpawnRate);
            baitReportDelay = CustomOption.Create(332, "誘餌舉報延遲", 0f, 0f, 10f, 1f, baitSpawnRate);

            mediumSpawnRate = CustomOption.Create(360, cs(Medium.color, "通靈師"), rates, null, true);
            mediumCooldown = CustomOption.Create(361, "通靈師詢問冷卻", 30f, 5f, 120f, 5f, mediumSpawnRate);
            mediumDuration = CustomOption.Create(362, "通靈師詢問持續時間", 3f, 0f, 15f, 1f, mediumSpawnRate);
            mediumOneTimeUse = CustomOption.Create(363, "每個靈魂只能被詢問一次", false, mediumSpawnRate);

            // Other options  
            maxNumberOfMeetings = CustomOption.Create(3, "會議數量(不包括市長會議)", 10, 0, 15, 1, null, true);
            blockSkippingInEmergencyMeetings = CustomOption.Create(4, "在緊急會議中封鎖跳過", false);
            noVoteIsSelfVote = CustomOption.Create(5, "不能投票給自己", false, blockSkippingInEmergencyMeetings);
            hidePlayerNames = CustomOption.Create(6, "隱藏玩家名稱", false);
            allowParallelMedBayScans = CustomOption.Create(7, "允許並列醫務室掃描", false);
            dynamicMap = CustomOption.Create(8, "Play On A Random Map", false, null, false);

            blockedRolePairings.Add((byte)RoleId.Vampire, new [] { (byte)RoleId.Warlock});
            blockedRolePairings.Add((byte)RoleId.Warlock, new [] { (byte)RoleId.Vampire});
            blockedRolePairings.Add((byte)RoleId.Spy, new [] { (byte)RoleId.Mini});
            blockedRolePairings.Add((byte)RoleId.Mini, new [] { (byte)RoleId.Spy});
            
        }
    }
}
