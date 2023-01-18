using System;
using System.ComponentModel.Design.Serialization;

namespace StatePattern
{
    // Abstract State
    public abstract class LightSwitchState
    {
        protected LightSwitch context;

        protected LightSwitchState(LightSwitch context)
        {
            this.context = context;
        }        

        // Handler1
        public abstract void Push();

        // Handler2
        public abstract bool CanPush();
    }

    public class OnState : LightSwitchState
    {
        public OnState(LightSwitch context) : base(context)
        {
        }

        public override bool CanPush() => context.State is OffState;

        public override void Push()
        {
            Console.WriteLine("wyłącz przekaźnik");

            context.State = new OffState(context);
        }
    }

    public class OffState : LightSwitchState
    {
        public OffState(LightSwitch context) : base(context)
        {
        }

        public override bool CanPush() => context.State is OnState;
        
        public override void Push()
        {
            Console.WriteLine("załącz przekaźnik");

            context.State = new OnState(context);
        }
    }


    // Context
    public class LightSwitch
    {        
        public LightSwitchState State { get; set; }

        public LightSwitch() => State = new OffState(this);

        public void Push() => State.Push();

        public bool CanPush() => State.CanPush();
    }

    //public enum LightSwitchState
    //{
    //    On,
    //    Off,
    //    Blink
    //}

}
