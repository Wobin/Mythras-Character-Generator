using BlazorState;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MythrasCharacterGenerator.Features.ActiveCharacter
{
    public partial class ActiveCharacterState
    {
        public class SetActiveCharacterHandler : ActionHandler<SetActiveCharacterAction>
        {
            public SetActiveCharacterHandler(IStore aStore) : base(aStore) { }

            ActiveCharacterState ActivePlayer => Store.GetState<ActiveCharacterState>();

            public override Task<Unit> Handle(SetActiveCharacterAction aAction, CancellationToken aCancellationToken)
            {
                ActivePlayer.ActiveCharacter = aAction.TargetPlayer;

                return Unit.Task;
            }
        }
    }
}
