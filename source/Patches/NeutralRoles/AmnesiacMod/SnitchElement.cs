using System.Linq;
using HarmonyLib;
using Hazel;
using TownOfUs.Roles;

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
                
              }
          }
      }
}
