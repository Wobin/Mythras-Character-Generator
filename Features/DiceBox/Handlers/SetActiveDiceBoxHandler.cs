using BlazorState;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MythrasCharacterGenerator.Features.DiceBox
{
    public partial class DiceBoxState
    {
        public class SetActiveDiceBoxHandler : ActionHandler<SetActiveDiceBoxAction>
        {
            public SetActiveDiceBoxHandler(IStore aStore) : base(aStore) { }

            DiceBoxState TargetDiceBox => Store.GetState<DiceBoxState>();

            public override Task<Unit> Handle(SetActiveDiceBoxAction aAction, CancellationToken aCancellationToken)
            {
                TargetDiceBox.TargetPool = aAction.TargetPool;                
                return Unit.Task;
            }
        }
    }
}
