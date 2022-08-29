using HarmonyLib;
using Hazel;
using TownOfUs.CrewmateRoles.InvestigatorMod;
using TownOfUs.CrewmateRoles.SnitchMod;
using TownOfUs.CrewmateRoles.TrapperMod;
using TownOfUs.Roles;
using UnityEngine;
using System;
using Il2CppSystem.Collections.Generic;
using TownOfUs.Extensions;

namespace TownOfUs.NeutralRoles.AmnesiacMod
{
  [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.CompleteTask))]
      public class CompleteTask
      {
          public static void Postfix(PlayerControl __instance)
          {
              if (!__instance.Is(RoleEnum.Amnesiac)) return;
              var role = Role.GetRole<Amnesiac>(__instance);

              var taskinfos = __instance.Data.Tasks.ToArray();

              var tasksLeft = taskinfos.Count(x => !x.Complete);

              if (tasksLeft == 0){
                 var survRole = Role.GetRole<Survivor>(amnesiac);
                 survRole.LastVested = DateTime.UtcNow;
                 survRole.UsesLeft = CustomGameOptions.MaxVests;
              }
          }
      }
}
