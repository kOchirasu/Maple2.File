namespace Maple2.File.Flat.standardmodellibrary {
    public interface ITimeOfDay {
        float TimeOfDayTimeScaleMultiplier => 10;
        bool TimeOfDayAnimate => true;
        float TimeOfDayDuration => 86400;
        float TimeOfDayInitialTime => 0;
    }
}
