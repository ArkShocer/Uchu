using System.Threading.Tasks;

namespace Uchu.World.Behaviors
{
    public class CameraBehavior : BehaviorBase
    {
        public override BehaviorTemplateId Id => BehaviorTemplateId.Camera;
        
        public override Task BuildAsync()
        {
            return Task.CompletedTask;
        }
    }
}